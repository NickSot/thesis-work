using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        // This is the model to be tested for the internet packets + the raw input data

        NeuralNetwork model = new NeuralNetwork(new int[] { 19 , 38, 1 });
        List<PacketInformation> inputData = new List<PacketInformation>();
        List<PacketInformation> positiveData = new List<PacketInformation>();
        List<PacketInformation> negativeData = new List<PacketInformation>();

        private static Random rng = new Random();

        public static void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private double[][] normalizeInputData() {
            var rawData = new List<PacketInformation>(positiveData);
            rawData.AddRange(negativeData);
            Shuffle<PacketInformation>(rawData);

            return new InputDataPreparator(rawData).prepareInputData();
        }

        private double[][] normalizeInputData(List<PacketInformation> inputsList)
        {
            var rawData = new List<PacketInformation>(inputsList);

            return new InputDataPreparator(rawData).prepareInputData();
        }

        private async void btnTrain_Click(object sender, EventArgs e)
        {
            await new Task(() =>
            {
                this.btnTest.Enabled = false;

                double[][] trainingData = normalizeInputData();

                for (int i = 0; i < 5000; i++)
                {
                    for (int j = 0; j < trainingData.Length; j++)
                    {
                        model.forwardPropagate(trainingData[j]);
                        model.backPropagate(new double[] { trainingData[j][19] });
                    }
                }

                this.txtOutput.Text += "Trained!\n";
                this.txtOutput.Text += "Awaiting testing...\n";
                this.btnTest.Enabled = true;
                this.btnLoadModel.Enabled = true;
            });
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.btnSaveModel.Enabled = false;

            var inputs = normalizeInputData();

            for (int i = 0; i < inputs.Length; i++)
            {
                var value = model.forwardPropagate(inputs[i]);
                this.txtOutput.Text += $"Rounded result: {Math.Round(value[0]).ToString()} - Actual expected value:{inputs[i][19]}\n";
            }

                
            this.btnSaveModel.Enabled = true;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (this.ofdTrainingData.ShowDialog() == DialogResult.OK)
            {
                this.txtFileName.Text = string.Join("; ", this.ofdTrainingData.FileNames);
            }
        }

        private void btnSelectLabelsFile_Click(object sender, EventArgs e)
        {
            if (this.ofdTrainingLabels.ShowDialog() == DialogResult.OK)
            {
                this.txtLabelFileNames.Text = string.Join("; ", this.ofdTrainingLabels.FileNames);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            new DbManager();
            this.initializeDataSet();
        }

        private void initializeDataSet()
        {
            DataTable dataTable = DbManager.All("DataSet");

            this.inputData.AddRange(from dataRow in dataTable.AsEnumerable() select new PacketInformation()
            {
                Conn_State = dataRow["Connection_state"].ToString(),
                Service = dataRow["Service_Protocol"].ToString(),
                History = dataRow["History"].ToString(),
                Resp_Bytes = Convert.ToInt32(dataRow["Resp_Bytes"].ToString()),
                Resp_H = dataRow["Id_Resp_H"].ToString(),
                Resp_P = Convert.ToInt32(dataRow["Id_Resp_P"].ToString()),
                Orig_Bytes = Convert.ToInt32(dataRow["Orig_Bytes"].ToString()),
                Orig_H = dataRow["Id_Orig_H"].ToString(),
                Orig_P = Convert.ToInt32(dataRow["Id_Orig_P"].ToString()),
                Local_Resp = Convert.ToBoolean(dataRow["Local_Resp"].ToString()),
                Resp_IP_Bytes = Convert.ToInt32(dataRow["Resp_Ip_Bytes"].ToString()),
                Orig_IP_Bytes = Convert.ToInt32(dataRow["Orig_Ip_Bytes"].ToString()),
                Orig_Pkts = Convert.ToInt32(dataRow["Orig_Pkts"].ToString()),
                Label = Convert.ToInt32(dataRow["Label_Value"].ToString()),
                Local_Orig = Convert.ToBoolean(dataRow["Local_Orig"].ToString()),
                Duration = Convert.ToDouble(dataRow["Duration"].ToString()),
                Missed_Bytes = Convert.ToInt32(dataRow["Missed_Bytes"].ToString()),
                Proto = dataRow["Protocol"].ToString(),
                Resp_Pkts = Convert.ToInt32(dataRow["Resp_Pkts"].ToString())
            });

            this.negativeData = inputData.Where(p => p.Label == 1).ToList();
            this.positiveData = inputData.Where(p => p.Label == 0).ToList();
            this.positiveData.RemoveRange(this.negativeData.Count, this.positiveData.Count - this.negativeData.Count);
        }
        
        private async void btnPrepareData_Click(object sender, EventArgs e)
        {
            if (this.txtFileName.Text ==  "" || this.txtLabelFileNames.Text== "")
            {
                MessageBox.Show("Please select the files!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Func<string> prepare = () =>
            {
                try
                {
                    InputDataPreparator.loadInputDataToDB(this.ofdTrainingData.FileNames, this.ofdTrainingLabels.FileNames);
                    this.initializeDataSet();
                    return "Done writing data to SQL Server!\n";
                }
                catch (Exception)
                {
                    return "Something went wrong...\n";
                }
            };

            string outputValue = await new Task<string>(prepare);

            this.txtOutput.Text += outputValue;
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            this.model.saveModelToDB();
            this.txtOutput.Text += "Successfully saved model to the database!\n";
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            this.model.loadModelFromDB();
            this.txtOutput.Text += "Successfully loaded model from the database!\n";
            this.btnTest.Enabled = true;
        }

        private void btnOpenValidation_Click(object sender, EventArgs e)
        {
            if (this.ofdValidateModel.ShowDialog() == DialogResult.OK)
            {
                this.txtValidateModel.Text = string.Join("; ", this.ofdValidateModel.FileNames);
            }
        }

        private void btnValidateModel_Click(object sender, EventArgs e)
        {
            if (this.txtValidateModel.Text == "")
            {
                MessageBox.Show("Please select the files!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StreamReader sr = new StreamReader(this.ofdValidateModel.FileNames[0]);
            try
            {
                this.inputData = JsonConvert.DeserializeObject<List<PacketInformation>>(sr.ReadToEnd());
            }
            catch (Exception) {
                this.txtOutput.Text += "An error occured while reading the file!\n";
                return;
            }

            double[][] inputData = normalizeInputData(this.inputData);

            for (int i = 0; i < inputData.Length; i++)
            {
                double[] result = this.model.forwardPropagate(inputData[i]);
                this.txtOutput.Text += $"Results of the validation: {result[0]}\n";

                if (Math.Round(result[0]) == 1)
                {
                    DbManager.Insert("IntrusionDetections", new Dictionary<string, object>() {
                    { "Id_Orig_H", this.inputData[i].Orig_H},
                    { "Id_Resp_H", this.inputData[i].Resp_H},
                    { "Id_Orig_P", this.inputData[i].Orig_P},
                    { "Id_Resp_P", this.inputData[i].Resp_P},
                    { "Service_Protocol", this.inputData[i].Service},
                    { "Missed_Bytes", this.inputData[i].Missed_Bytes},
                    { "Duration", this.inputData[i].Duration},
                    { "Orig_Bytes", this.inputData[i].Orig_Bytes},
                    { "Resp_Bytes", this.inputData[i].Resp_Bytes},
                    { "Connection_State", this.inputData[i].Conn_State},
                    { "Local_Orig", this.inputData[i].Local_Orig},
                    { "Local_Resp", this.inputData[i].Local_Resp},
                    { "History", this.inputData[i].History},
                    { "Protocol", this.inputData[i].Proto},
                    { "Orig_Pkts", this.inputData[i].Orig_Pkts},
                    { "Orig_Ip_Bytes", this.inputData[i].Orig_IP_Bytes},
                    { "Resp_Pkts", this.inputData[i].Resp_Pkts},
                    { "Resp_Ip_Bytes", this.inputData[i].Resp_IP_Bytes},
                    { "TimeOfDetection", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") }
                });
                }
            }

            sr.Close();
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            this.txtOutput.Clear();
        }
    }
}
