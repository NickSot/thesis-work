using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class DataNormalizer
    {
        private double [] dataPoints;
        private double mean;
        private double standardDeviation;
        public DataNormalizer() {
            
        }

        public void setDataPoints(double [] dataPoints)
        {
            this.dataPoints = dataPoints;
            this.mean = calculateMean();
            this.standardDeviation = calculateStandardDeviation();
        }

        private double calculateMean() {
            double sum = 0;

            foreach (var number in dataPoints)
            {
                sum += number;
            }

            return sum / dataPoints.Length;
        }

        private double calculateStandardDeviation() {
            double sum = 0;

            foreach (var number in dataPoints) {
                sum += Math.Pow((number - this.mean), 2);
            }

            return Math.Sqrt(sum / (this.dataPoints.Length - 1));
        }

        public double[] ZScoreStandartization() {
            double[] standardizedPoints = new double[this.dataPoints.Length];

            for (int i = 0; i < this.dataPoints.Length; i++)
            {
                standardizedPoints[i] = (this.dataPoints[i] - this.mean) / this.standardDeviation;
            }

            return standardizedPoints;
        }
    }
}