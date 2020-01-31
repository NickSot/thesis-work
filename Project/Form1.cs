using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                history
                orig_pkts
                orig_ip_bytes
                resp_pkts
                resp_ip_bytes
                tunnel_parents
                orig_cc - maybe not
                resp_cc - maybe not
             */

        NeuralNetwork model = new NeuralNetwork(new int[] { 18 , 25, 1 });
        // This is the model to be tested for the internet packets!

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
    }
}
