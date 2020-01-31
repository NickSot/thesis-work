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

        /*
                id.orig_h
                id.orig_p
                id.resp_h
                id.resp_p
                proto
                service
                duration
                orig_bytes
                resp_bytes
                conn_state
                local_orig
                local_resp
                history
                orig_pkts
                orig_ip_bytes
                resp_pkts
                resp_ip_bytes
                tunnel_parents
             */

        NeuralNetwork model = new NeuralNetwork(new int[] { 18 , 25, 1 });
        // This is the model to be tested for the internet packets!


        //*** NEED A METHOD THAT NORMALIZES THE INPUT DATA! ***


        private void btnTrainXOR_Click(object sender, EventArgs e)
        {
            model = new NeuralNetwork(new int[] { 3, 25, 25, 1 }); 
            // This is the XOR test model to verify that the deep learning algorithm works fine

            this.btnTestXOR.Enabled = false;

            for (int i = 0; i < 5000; i++)
            {
                model.forwardPropagate(new double[] { 0, 0, 0 });
                model.backPropagate(new double[] { 0 });

                model.forwardPropagate(new double[] { 0, 0, 1 });
                model.backPropagate(new double[] { 1 });

                model.forwardPropagate(new double[] { 0, 1, 0 });
                model.backPropagate(new double[] { 1 });

                model.forwardPropagate(new double[] { 0, 1, 1 });
                model.backPropagate(new double[] { 0 });

                model.forwardPropagate(new double[] { 1, 0, 0 });
                model.backPropagate(new double[] { 1 });

                model.forwardPropagate(new double[] { 1, 0, 1 });
                model.backPropagate(new double[] { 0 });

                model.forwardPropagate(new double[] { 1, 1, 0 });
                model.backPropagate(new double[] { 0 });

                model.forwardPropagate(new double[] { 1, 1, 1 });
                model.backPropagate(new double[] { 1 });
            }

            this.txtOutput.Text += "Trained!\n";
            this.txtOutput.Text += "Awaiting testing...\n";
            this.btnTestXOR.Enabled = true;
        }
        static Random r = new Random();
        private void btnTestXOR_Click(object sender, EventArgs e)
        {
            //This is merely for testing purposes
            int a = r.Next(0, 2);
            int b = r.Next(0, 2);
            int c = r.Next(0, 2);
            var inputs = new double[] { a, b, c};
            var value = model.forwardPropagate(inputs);
            this.txtOutput.Text += string.Format("Output for [{0}] is [{1}]\n", string.Join(",", inputs), string.Join(" ", value));
        }

        List<PacketInformation> inputData;

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
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
