using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class NeuralLayer
    {
        private double[] outputs;
        private double[,] weights;
        private double[,] deltas;
        private double[] gammas;
        private double[] errors;
        private double[] inputs;
        private static Random random = new Random();

        int numInputs;
        int numOutputs;
        public NeuralLayer(int numInputs, int numOutputs)
        {
            this.numInputs = numInputs;
            this.numOutputs = numOutputs;

            this.outputs = new double[numOutputs];
            this.inputs = new double[numInputs];
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

        private void initializeWeights()
        {
            for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < this.numInputs; j++)
                {
                    this.weights[i, j] = (double)random.NextDouble() - 0.5f;
                }
            }
        }
        public double[] getOutputs()
        {
            return this.outputs;
        }

        public double[] getGammas()
        {
            return this.gammas;
        }

        public double[,] getWeights()
        {
            return this.weights;
        }

        public double[] forwardPropagate(double[] input)
        {
            this.inputs = input;

            for (int i = 0; i < this.numOutputs; i++)
            {
                outputs[i] = 0;

                for (int j = 0; j < this.numInputs; j++)
                {
                    this.outputs[i] += inputs[j] * weights[i, j];
                }

                outputs[i] = (double)Math.Tanh(outputs[i]);
            }

            return this.outputs;
        }

        public void backPropagateOutputs(double[] expected)
        {
            for (int i = 0; i < this.numOutputs; i++)
            {
                this.errors[i] = this.outputs[i] - expected[i];
            }

            for (int i = 0; i < this.numOutputs; i++)
            {
                this.gammas[i] = errors[i] * this.calculateTanhDerivative(this.outputs[i]);
            }

            for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < this.numInputs; j++)
                {
                    this.deltas[i, j] = this.gammas[i] * this.inputs[j];
                }
            }
        }

        public void backPropagateHidden(double[] gammaForwardLayer, double[,] weightsForward)
        {
            for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < gammaForwardLayer.Length; j++)
                {
                    this.gammas[i] += gammaForwardLayer[j] * weightsForward[j, i];
                }

                this.gammas[i] *= this.calculateTanhDerivative(this.outputs[i]);
            }

            for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < this.numInputs; j++)
                {
                    this.deltas[i, j] = this.gammas[i] * this.inputs[j];
                }
            }
        }

        public void UpdateWeights()
        {
            for (int i = 0; i < this.numOutputs; i++)
            {
                for (int j = 0; j < this.numInputs; j++)
                {
                    this.weights[i, j] -= this.deltas[i, j] * 0.01;
                }
            }
        }
    }
}
