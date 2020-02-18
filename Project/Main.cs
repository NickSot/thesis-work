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

        NeuralNetwork model = new NeuralNetwork(new int[] { 19 , 25, 1 });
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

        private void btnTrain_Click(object sender, EventArgs e)
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
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //This is merely for testing purposes
            var inputs = normalizeInputData();

            for (int i = 0; i < inputs.Length; i++)
            {
                var value = model.forwardPropagate(inputs[i]);
                this.txtOutput.Text += $"{Math.Round(value[0]).ToString()} {inputs[i][19]}\n";
                //this.txtOutput.Text += string.Format("Output for [{0}] is [{1}]\n", string.Join(",", inputs[i]), string.Join(" ", value));
            }
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

        private void btnPrepareData_Click(object sender, EventArgs e)
        {
            InputDataPreparator.loadInputDataToDB(this.ofdTrainingData.FileNames, this.ofdTrainingLabels.FileNames);

            this.initializeDataSet();

            this.txtOutput.Text += "Done writing data to SQL Server!\n";
        }
    }
}
