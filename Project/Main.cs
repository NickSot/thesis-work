using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SharpPcap;
using SharpPcap.Npcap;
using SharpPcap.LibPcap;
using System.Data.SqlClient;
using System.Text;

namespace Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            new DbManager();
            this.getModels();
            this.initializeComboboxDataSources();
        }

        List<NeuralNetwork> models = new List<NeuralNetwork>();
        List<PacketInformation> inputData = new List<PacketInformation>();
        List<PacketInformation> positiveData = new List<PacketInformation>();
        List<PacketInformation> negativeData = new List<PacketInformation>();

        private static Random rng = new Random();

        private void initializeComboboxDataSources()
        {
            var comboBoxDataSource = this.getTables().AsEnumerable()
                .Select(p => p["name"].ToString().Replace("NeuralNetwork", "")).ToList();

            this.txtModelNameTrain.DataSource = comboBoxDataSource;

            var comboBoxDataSourceCmp1 = this.getTables().AsEnumerable()
                .Select(p => p["name"].ToString().Replace("NeuralNetwork", "")).ToList();

            this.txtFirstModelNameCmp.DataSource = comboBoxDataSourceCmp1;

            var comboBoxDataSourceCmp2 = this.getTables().AsEnumerable()
                .Select(p => p["name"].ToString().Replace("NeuralNetwork", "")).ToList();

            this.txtSecondModelNameCmp.DataSource = comboBoxDataSourceCmp2;

            var comboBoxDataSourceCmp3 = this.getTables().AsEnumerable()
                .Select(p => p["name"].ToString().Replace("NeuralNetwork", "")).ToList();

            this.cbModelViewDetails.DataSource = comboBoxDataSourceCmp3;
        }
        
        private DataTable getTables() {
            DbManager.connection.Open();
            SqlCommand sqlCmd = new SqlCommand("Use ThesisProject;\nSelect * From sysobjects Where name Like '%NeuralNetwork';", DbManager.connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            da.Fill(dt);

            DbManager.connection.Close();

            return dt;
        }
        private void getModels()
        {
            this.models.Clear();

            var dt = this.getTables();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tableName = dt.Rows[i]["Name"].ToString();
                DataTable dataTable = DbManager.All(tableName, "Count(NumberOfLayer) As NeuronsCount", "Group By NumberOfLayer");


                int[] dimensions = new int[dataTable.Rows.Count + 1];

                dimensions[0] = 19;

                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    dimensions[j + 1] = Convert.ToInt32(dataTable.Rows[j]["NeuronsCount"].ToString());
                }

                this.models.Add(new NeuralNetwork(dimensions, tableName.Replace("NeuralNetwork", "")));
            }
        }

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
            this.pbModelOperation.Minimum = 0;
            this.pbModelOperation.Maximum = 100;
            this.btnTest.Enabled = false;
            this.btnSaveModel.Enabled = false;
            this.btnLoadModel.Enabled = false;

            var model = new NeuralNetwork(this.models.Where(m => m.getName() == this.txtModelNameTrain.Text.Trim()).FirstOrDefault());

            await Task.Run(() =>
            {
                double[][] trainingData = normalizeInputData();

                for (int i = 0; i < 5000; i++)
                {
                    for (int j = 0; j < trainingData.Length; j++)
                    {
                        model.forwardPropagate(trainingData[j]);
                        model.backPropagate(new double[] { trainingData[j][19] });
                    }

                    this.pbModelOperation.Invoke(new Action(() => {
                        this.pbModelOperation.Value = (int)i*100/5000;
                    }));
                }
            });

            this.txtOutput.Text += "Trained!\n";
            this.txtOutput.Text += "Awaiting testing...\n";
            this.pbModelOperation.Value = this.pbModelOperation.Minimum;
            this.btnTest.Enabled = true;
            this.btnLoadModel.Enabled = true;
            this.btnSaveModel.Enabled = true;
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            this.btnSaveModel.Enabled = false;

            this.txtOutput.Text += "Loading test data...";

            var model = this.models.Where(m => m.getName() == this.txtModelNameTrain.Text).FirstOrDefault();

            string outputText = await Task.Run<string>(() =>
            {
                var inputs = normalizeInputData();
                string returnValue = "";

                for (int i = 0; i < inputs.Length; i++)
                {
                    var value = model.forwardPropagate(inputs[i]);
                    returnValue += $"Rounded result: {Math.Round(value[0]).ToString()} - Actual expected value:{inputs[i][19]}\n";

                    this.pbModelOperation.Invoke(new Action(() => {
                        this.pbModelOperation.Value = (int)i * 100 / inputs.Length;
                    }));
                }

                return returnValue;
            });


            MessageBox.Show("Testing is over!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.pbModelOperation.Value = this.pbModelOperation.Minimum;

            this.txtOutput.AppendText(outputText);
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

            string outputValue = await Task.Run<string>(prepare);

            this.txtOutput.AppendText(outputValue);
        }

        private delegate void delProgressBarIncr(int index, int maxValue);
        private async void btnSaveModel_Click(object sender, EventArgs e)
        {
            var model = this.models.Where(m => m.getName() == this.txtModelNameTrain.Text).First();

            await Task.Run(new Action(() =>
            {
                model.saveModelToDB(new delProgressBarIncr((int index, int maxValue) => {
                    this.pbModelOperation.Invoke(new Action(() =>
                    {
                        this.pbModelOperation.Maximum = 100;
                        this.pbModelOperation.Value = (int)index * 100 / maxValue;
                    }));
                }));
            }));

            this.txtOutput.Text += "Successfully saved model to the database!\n";
            this.pbModelOperation.Value = this.pbModelOperation.Minimum;
            this.btnSaveModel.Enabled = false;
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            var model = this.models.Where(m => m.getName() == this.txtModelNameTrain.Text).First();
            this.btnTest.Enabled = false;
            model.loadModelFromDB();
            this.txtOutput.Text += "Successfully loaded model from the database!\n";
            this.btnTest.Enabled = true;
            this.btnSaveModel.Enabled = true;
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

            var model = this.models.Where(m => m.getName() == this.txtModelNameTrain.Text).First();

            double[][] inputData = normalizeInputData(this.inputData);

            for (int i = 0; i < inputData.Length; i++)
            {
                double[] result = model.forwardPropagate(inputData[i]);
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

        private void btnRealTimeDetection_Click(object _sender, EventArgs _e)
        {
            var devices = CaptureDeviceList.Instance;

            foreach (var device in devices)
            {
                device.OnPacketArrival += new PacketArrivalEventHandler((object sender, CaptureEventArgs e) =>
                {
                    PacketInformation packetInfo = new PacketInformation();

                    var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                    var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
                });

                int readTimeoutMilliseconds = 1000;

                if (device is NpcapDevice)
                {
                    var nPcap = device as NpcapDevice;
                    nPcap.Open(SharpPcap.Npcap.OpenFlags.DataTransferUdp | SharpPcap.Npcap.OpenFlags.Promiscuous, readTimeoutMilliseconds);
                }
                else if (device is LibPcapLiveDevice)
                {
                    var livePcapDevice = device as LibPcapLiveDevice;
                    livePcapDevice.Open(DeviceMode.Normal, readTimeoutMilliseconds);
                }
                else
                {
                    throw new InvalidOperationException("unknown device type of " + device.GetType().ToString());
                }

                device.StartCapture();

                

                device.StopCapture();
            }
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtModelName.Text))
            {
                MessageBox.Show("Please select a name for the new model!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtModelDimensions.Text))
            {
                MessageBox.Show("Please specify the dimentions of the model!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] modelArchitecture = this.txtModelDimensions.Text.Split(' ').Select(p => Convert.ToInt32(p)).ToArray<int>();

            var model = this.models.Where(m => m.getName() == this.txtModelName.Text.Trim()).FirstOrDefault();

            if (model != null)
            {
                this.models.Remove(model);
            }

            model = new NeuralNetwork(modelArchitecture, this.txtModelName.Text.Trim());
            model.saveModelToDB();
            this.models.Add(model);

            this.txtModelDimensions.Clear();
            this.txtModelName.Clear();

            this.initializeComboboxDataSources();
            this.getModels();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var model1 = this.models.Where(m => m.getName().Contains(this.txtFirstModelNameCmp.Text)).FirstOrDefault();
            var model2 = this.models.Where(m => m.getName().Contains(this.txtSecondModelNameCmp.Text)).FirstOrDefault();

            model1.loadModelFromDB();
            model2.loadModelFromDB();

            var data = normalizeInputData();

            double model1Accuracy = model1.calculateModelAccuracy(data);
            double model2Accuracy = model2.calculateModelAccuracy(data);

            this.rtxtComparisonResults.Text += $"{model1.getName()}'s accuracy: {Math.Round(model1Accuracy, 2)}%\n";
            this.rtxtComparisonResults.Text += $"{model2.getName()}'s accuracy: {Math.Round(model2Accuracy, 2)}%\n";

            this.txtFirstModelNameCmp.Text = "";
            this.txtSecondModelNameCmp.Text = "";

            this.initializeComboboxDataSources();
        }

        private void txtFirstModelNameCmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtSecondModelNameCmp.Items.Remove(this.txtFirstModelNameCmp.Text);
        }

        private void txtSecondModelNameCmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtFirstModelNameCmp.Items.Remove(this.txtFirstModelNameCmp.Text);
        }

        private void btnClearOurpurCreate_Click(object sender, EventArgs e)
        {
            this.rtxtComparisonResults.Clear();
        }

        private void btnOutputModelDetails_Click(object sender, EventArgs e)
        {
            NeuralNetwork model = this.models.Where(m => m.getName() == this.cbModelViewDetails.Text.Trim()).FirstOrDefault();
            model.loadModelFromDB();

            StringBuilder sb = new StringBuilder();

            var data = normalizeInputData();

            sb.AppendLine("---- Details ----");
            sb.AppendLine($"Model name: {model.getName()}");

            int[] dimensions = model.getDimensions();
            
            for (int i = 0; i < dimensions.Length; i++) {
                if (i == 0)
                    sb.AppendLine($"Input layer: {dimensions[0]} inputs");
                else if (i < dimensions.Length - 1)
                {
                    sb.AppendLine($"Hidden layer {i}: {dimensions[i]} neurons");
                }
                else
                {
                    sb.AppendLine($"Output Layer: {dimensions[i]} outputs");
                }
            }
            
            sb.AppendLine($"Model accuracy: {model.calculateModelAccuracy(data)}%");
            sb.AppendLine($"---- Details ----\n");

            this.rtxtComparisonResults.AppendText(sb.ToString());
        }
    }
}
