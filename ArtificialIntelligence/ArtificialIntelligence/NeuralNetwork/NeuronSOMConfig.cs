using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class NeuronSOMConfig
    {
        public int outWidth;
        public int outHight;
        public double numIterations;
        public double learningRate;

        private double mapRadius;
        private double timeConstant;

        public void Initialization()
        {
            mapRadius = (double) Math.Max(outWidth, outHight) / 2.0;
            timeConstant = numIterations / Math.Log(mapRadius);
        }

        public double getNeighbourhoodRadius(int iIterationCount)
        {
            return mapRadius * Math.Exp(-(double)iIterationCount/timeConstant);
        }
        public double getLearningRate(int iIterationCount)
        {
            return learningRate * Math.Exp(-(double)iIterationCount / numIterations);
        }


    }
}
