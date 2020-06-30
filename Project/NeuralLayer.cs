using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumSharp;
using NumSharp.Backends.Unmanaged;

namespace Project
{
    class NeuralLayer
    {
        private int layerNumber;
        private NeuralNetwork neuralNetwork;
        private NDArray outputs;
        //private double[,] weights;
        private double[,] prevWeights;
        //private double[,] deltas;
        private NDArray weights;
        private NDArray deltas;
        private double[] gammas;
        private double[] errors;
        private double[] inputs;
        private static Random random = new Random();

        int numInputs;
        int numOutputs;
        public NeuralLayer(NeuralNetwork neuralNetwork, int numInputs, int numOutputs, int layerNumber)
        {
            this.neuralNetwork = neuralNetwork;
            this.numInputs = numInputs;
            this.numOutputs = numOutputs;
            this.layerNumber = layerNumber;
            this.outputs = new double[numOutputs];
            this.inputs = new double[numInputs];
            //this.weights = np.array<double>(new NDArray(NPTypeCode.Double, new Shape(this.numOutputs, this.numInputs)));
            this.weights = new double[numOutputs, numInputs];
            this.deltas = new double[numOutputs, numInputs];
            this.gammas = new double[numOutputs];
            this.errors = new double[numOutputs];

            this.initializeWeights();
        }

        private double calculateTanhDerivative(double value)
        {
            return 1 - Math.Pow(value, 2);
        }

        private void initializeWeights(bool initFromDB = false)
        {
            if (!initFromDB)
            {
                for (int i = 0; i < this.numOutputs; i++)
                {
                    for (int j = 0; j < this.numInputs; j++)
                    {
                        this.weights[i, j] = (double)random.NextDouble() - 0.5f;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.numOutputs; i++)
                {
                    for (int j = 0; j < this.numInputs; j++)
                    {
                        var dataTable = DbManager.WhereAnd($"{this.neuralNetwork.getName()}NeuralLinks", new Dictionary<string, object>() {
                            { "NextNeuron", i },
                            { "PreviousNeuron", j },
                            { "NextLayer", this.layerNumber + 1 },
                            { "PreviousLayer", this.layerNumber}
                        });
                        if (dataTable.Rows.Count != 0)
                        {
                            string weightValue = dataTable.Rows[0]["WeightValue"].ToString();
                            this.weights[i, j] = Double.Parse(weightValue);
                        }
                    }
                }
            }

            this.prevWeights = (double[,])this.weights.Clone();
        }

        public int getNumOutputs() {
            return this.numOutputs;
        }

        public int getNumInputs()
        {
            return this.numInputs;
        }

        public NDArray getOutputs()
        {
            return this.outputs;
        }

        public double[] getGammas()
        {
            return this.gammas;
        }

        public NDArray getDeltas()
        {
            return this.deltas;
        }

        public NDArray getWeights()
        {
            return this.weights;
        }

        public double [,] getPrevWeights()
        {
            return this.prevWeights;
        }

        public NDArray forwardPropagate(NDArray input)
        {
            if (layerNumber == 0)
            {
                this.inputs = input.ToArray<double>().Take(input.ToArray<double>().Length - 1).ToArray();
            }
            else
                this.inputs = input.ToArray<double>();

            var outputs = np.zeros(new int[] { this.numOutputs });
            var inputs = np.array(this.inputs);
            var weights = np.array(this.weights);

            var result1 = inputs * weights;

            this.outputs = outputs + result1.sum(1);

            //outputs.CopyTo<double>(this.outputs);

            /*for (int i = 0; i < this.numOutputs; i++)
            {
                outputs[i] = 0;

                for (int j = 0; j < this.numInputs; j++)
                {
                    this.outputs[i] += inputs[j] * weights[i, j];
                }

                outputs[i] = (double)Math.Tanh(outputs[i]);
            }*/

            return this.outputs;
        }

        public void backPropagateOutputs(double[] expected)
        {
            var inputs = np.array<double>(this.inputs);
            var gammas = np.array<double>(this.gammas);
            var exp = np.array<double>(expected);
            

            for (int i = 0; i < this.numOutputs; i++)
            {
                this.errors[i] = this.outputs[i] - expected[i];
            }

            

            for (int i = 0; i < this.numOutputs; i++)
            {
                this.gammas[i] = this.errors[i] * this.calculateTanhDerivative(this.outputs[i]);
            }

            /*
            for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < this.numInputs; j++)
                {
                    this.deltas[i, j] = this.gammas[i] * this.inputs[j];
                }
            }
            */

            this.deltas = np.outer(gammas, inputs);

            //Debug.WriteLine(this.deltas.ToString());
        }

        public void backPropagateHidden(double[] gammaForwardLayer, NDArray weightsForward)
        {
            var gammas = np.array<double>(this.gammas);
            var inputs = np.array<double>(this.inputs);
            
            var wfl = np.array<double>(weightsForward);
            var gfl = np.array<double>(gammaForwardLayer);

            /*for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < gammaForwardLayer.Length; j++)
                {
                    this.gammas[i] += gammaForwardLayer[j] * weightsForward[j, i];
                }

                this.gammas[i] *= this.calculateTanhDerivative(this.outputs[i]);
            }
            */

            var result = gammas + gfl*wfl.sum(1);

            /*
            for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < this.numInputs; j++)
                {
                    this.deltas[i, j] = this.gammas[i] * this.inputs[j];
                }
            }*/


            this.deltas = np.outer(result, inputs);

            //result.CopyTo<double[]>(this.deltas);
        }

        public void UpdateWeights()
        {
            //this.prevWeights = (double[,])this.weights.Clone();

            /*for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < this.numInputs; j++)
                {
                    this.weights[i, j] -= this.deltas[i, j] * 0.01;
                }
            }*/

            this.weights -= deltas * 0.01;
            //weights.CopyTo<double[]>(this.weights);
        }
    }
}
