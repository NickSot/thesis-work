using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class NeuralNetwork
    {
        private int[] layerSizes;
        private NeuralLayer[] layers;
        private string name;

        public NeuralNetwork(NeuralNetwork neuralNetwork)
        {
            this.layers = neuralNetwork.layers;
            this.layerSizes = neuralNetwork.layerSizes;
            this.name = neuralNetwork.name;
        }

        public NeuralNetwork(int[] layerSizes, string name)
        {
            this.name = name;

            this.layerSizes = new int[layerSizes.Length];

            for (int i = 0; i < this.layerSizes.Length; i++)
            {
                this.layerSizes[i] = layerSizes[i];
            }

            this.layers = new NeuralLayer[this.layerSizes.Length - 1];

            for (int i = 0; i < this.layers.Length; i++)
            {
                this.layers[i] = new NeuralLayer(this, this.layerSizes[i], this.layerSizes[i + 1], i);
            }
        }

        public double calculateModelAccuracy(double [][] data)
        {
            var tptn = 0;
            var allPredictions = 0;

            foreach (var d in data)
            {
                var feedForwardResult = this.forwardPropagate(d)[0];
                var result = Math.Abs(Math.Round(feedForwardResult));

                if (result == d[19])
                    tptn++;

                allPredictions++;
            }

            double returnValue = (double) tptn / allPredictions;

            return returnValue;
        }

        public string getName()
        {
            return this.name;
        }

        public void loadModelFromDB()
        {
            for (int i = 0; i < this.layers.Length; i++)
            {
                this.layers[i].GetType().GetMethod("initializeWeights", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(this.layers[i], new object [] { true });
            }
        }

        public void saveModelToDB(Delegate action = null)
        {
            try
            {
                DbManager.Delete($"{this.name}NeuralNetwork");
                DbManager.Delete($"{this.name}NeuralLinks");
            }
            catch (Exception)
            {

            }
            //DbManager.DropTable($"{this.name}NeuralNetwork");
            //DbManager.DropTable($"{this.name}NeuralLinks");

            DbManager.CreateTable($"{this.name}NeuralNetwork", new Dictionary<string, string> {
                { "Id", "Integer Identity(1, 1) Not NULL"},
                { "NumberOfNeuron", "Integer Not NULL"},
                { "NumberOfLayer", "Integer Not NULL"},
                { "OutputValue", "Float"},
                { "Primary Key", "(NumberOfNeuron, NumberOfLayer)" }
            });

            DbManager.CreateTable($"{this.name}NeuralLinks", new Dictionary<string, string> {
                { "Id", "Integer Identity(1, 1) Not NULL" },
                { "PreviousLayer", "Integer Not NULL" },
                { "NextLayer", "Integer Not NULL"},
                { "PreviousNeuron", "Integer Not NULL"},
                { "NextNeuron", "Integer Not NULL"},
                { "WeightValue", "Float"},
                { "Delta", "Float"},
                { "PreviousWeightValue", "Float"},
                { "Primary Key", "(PreviousLayer, NextLayer, PreviousNeuron, NextNeuron)" }
            });

            for (int i = 0; i < this.layers.Length; i++)
            {
                for (int j = 0; j < this.layers[i].getOutputs().Length; j++)
                {
                    DbManager.Insert($"{this.name}NeuralNetwork", new Dictionary<string, object>()
                    {
                        { "NumberOfNeuron", j},
                        { "NumberOfLayer", i},
                        { "OutputValue", this.layers[i].getOutputs()[j]}
                    });
                }

                for (int j = 0; j < this.layers[i].getNumOutputs(); j++)
                {
                    for (int k = 0; k < this.layers[i].getNumInputs(); k++)
                    {
                        DbManager.Insert($"{this.name}NeuralLinks", new Dictionary<string, object>()
                        {
                            { "PreviousLayer", i },
                            { "NextLayer", i + 1 },
                            { "PreviousNeuron", k},
                            { "NextNeuron", j },
                            { "WeightValue", this.layers[i].getWeights()[j, k] },
                            { "Delta", this.layers[i].getDeltas()[j, k] },
                            { "PreviousWeightValue", this.layers[i].getPrevWeights()[j, k] }
                        });
                    }
                }
                
                if (action != null)
                    action.DynamicInvoke(i, this.layers.Length);
            }
        }

        public double[] forwardPropagate(double[] inputs)
        {
            this.layers[0].forwardPropagate(inputs);

            for (int i = 1; i < this.layers.Length; i++)
            {
                this.layers[i].forwardPropagate(this.layers[i - 1].getOutputs());
            }

            return this.layers[this.layers.Length - 1].getOutputs();
        }

        public void backPropagate(double[] expected)
        {
            for (int i = this.layers.Length - 1; i >= 0; i--)
            {
                if (i == layers.Length - 1)
                {
                    this.layers[i].backPropagateOutputs(expected);
                }
                else
                {
                    this.layers[i].backPropagateHidden(this.layers[i + 1].getGammas(), this.layers[i + 1].getWeights());
                }
            }

            for (int i = 0; i < this.layers.Length; i++)
            {
                this.layers[i].UpdateWeights();
            }
        }
    }
}
