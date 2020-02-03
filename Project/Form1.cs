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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NeuralNetwork model = new NeuralNetwork(new int[] { 19 , 25, 1 });
        List<PacketInformation> inputData;

        // This is the model to be tested for the internet packets + the raw input data

        private double[][] normalizeInputData() {
            return new InputDataPreparator(this.inputData).prepareInputData();
        }


        private void btnTrainXOR_Click(object sender, EventArgs e)
        {
            // This is the XOR test model to verify that the deep learning algorithm works fine

            this.btnTest.Enabled = false;

            double[][] trainingData = normalizeInputData();

            for (int i = 0; i < 5000; i++)
            {
                for (int j = 0; j < trainingData.Length; j++)
                {
                    model.forwardPropagate(trainingData[j]);
                    model.backPropagate(new double[] { 0 });
                }
            }

            this.txtOutput.Text += "Trained!\n";
            this.txtOutput.Text += "Awaiting testing...\n";
            this.btnTest.Enabled = true;
        }
        static Random r = new Random();
        private void btnTestXOR_Click(object sender, EventArgs e)
        {
            //This is merely for testing purposes
            var inputs = normalizeInputData();

            for (int i = 0; i < inputs.Length; i++)
            {
                var value = model.forwardPropagate(inputs[i]);
                this.txtOutput.Text += string.Format("Output for [{0}] is [{1}]\n", string.Join(",", inputs[i]), string.Join(" ", value));
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (this.ofdTrainingData.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(this.ofdTrainingData.FileName);
                    string FileData = new StreamReader(this.ofdTrainingData.FileName).ReadToEnd();

                    inputData = JsonConvert.DeserializeObject<List<PacketInformation>>(FileData);

                    this.txtOutput.Text += "Done deserializing input data!\n";

                    this.btnTrain.Enabled = true;
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
