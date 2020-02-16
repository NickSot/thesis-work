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
        List<PacketInformation> labels = new List<PacketInformation>();

        private double[][] normalizeInputData() {
            return new InputDataPreparator(this.inputData).prepareInputData();
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
                    model.backPropagate(new double[] { inputData[j].Label });
                }
            }

            this.txtOutput.Text += "Trained!\n";
            this.txtOutput.Text += "Awaiting testing...\n";
            this.btnTest.Enabled = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //This is merely for testing purposes
            var inputs = normalizeInputData().Skip((int)(this.inputData.Count*0.7)).ToArray();

            for (int i = 0; i < inputs.Length; i++)
            {
                var value = model.forwardPropagate(inputs[i]);
                this.txtOutput.Text += string.Format("Output for [{0}] is [{1}]\n", string.Join(",", inputs[i]), string.Join(" ", value));
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //File selection and processing

            if (this.ofdTrainingData.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in this.ofdTrainingData.FileNames)
                {
                    try
                    {
                        string fileData = new StreamReader(fileName).ReadToEnd();

                        inputData.AddRange(JsonConvert.DeserializeObject<List<PacketInformation>>(fileData));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }

                this.txtOutput.Text += "Done deserializing input data!\n";
                this.btnTrain.Enabled = true;
                this.txtFileName.Text = string.Join("; ", this.ofdTrainingData.FileNames);
            }
        }
    }
}
