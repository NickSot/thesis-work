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

        NeuralNetwork model = new NeuralNetwork(new int[] { 18 , 25, 1 });
        List<PacketInformation> inputData;

        // This is the model to be tested for the internet packets + the raw input data
        /*
        id.orig_h - decimalize 
        id.orig_p 
        id.resp_h - decimalize
        id.resp_p
        proto - string(enumeration)
        service - string(enumeration)
        duration
        orig_bytes
        resp_bytes
        conn_state - string(enumeration)
        local_orig - bool(zero or one)
        local_resp
        history - string(enumeration)
        orig_pkts
        orig_ip_bytes
        resp_pkts
        resp_ip_bytes
        tunnel_parents - no clue as to what is going to happen with this one at this point in time.
        */

        //*** NEED A METHOD THAT NORMALIZES THE INPUT DATA! ***

        private List<List<double>> normalizeInputData() {
            double[,] preparedInputData = new double[this.inputData.Count, 18];

            //protocol string

            Dictionary<string, int> protocolMap = new Dictionary<string, int>();

            protocolMap.Add("tcp", 1);
            protocolMap.Add("udp", 2);
            protocolMap.Add("ip", 3);
            protocolMap.Add("icmp", 4);

            //service - need to research more deeply
            //----
            
            //connection state string

            Dictionary<string, int> connStateMap = new Dictionary<string, int>();

            connStateMap.Add("S0", 1);
            connStateMap.Add("S1", 2);
            connStateMap.Add("SF", 3);
            connStateMap.Add("REJ", 4);
            connStateMap.Add("S2", 5);
            connStateMap.Add("S3", 6);
            connStateMap.Add("RSTO", 7);
            connStateMap.Add("RSTR", 8);
            connStateMap.Add("RSTOS0", 9);
            connStateMap.Add("RSTRH", 10);
            connStateMap.Add("SH", 11);
            connStateMap.Add("SHR", 12);
            connStateMap.Add("OTH", 13);

            //history string

            Dictionary<string, int> historyMap = new Dictionary<string, int>();

            historyMap.Add("S", 1);
            historyMap.Add("H", 2);
            historyMap.Add("A", 3);
            historyMap.Add("D", 4);
            historyMap.Add("F", 5);
            historyMap.Add("R", 6);
            historyMap.Add("C", 7);
            historyMap.Add("I", 8);
            historyMap.Add("s", 9);
            historyMap.Add("h", 10);
            historyMap.Add("a", 11);
            historyMap.Add("d", 12);
            historyMap.Add("f", 13);
            historyMap.Add("r", 14);
            historyMap.Add("c", 15);
            historyMap.Add("i", 16);

            inputData.ForEach(packetInfo => {
                //FINISH
            });

            return null;
        }


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
