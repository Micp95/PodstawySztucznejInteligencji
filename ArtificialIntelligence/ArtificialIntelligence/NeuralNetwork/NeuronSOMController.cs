using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class NeuronSOMController
    {
        private NeuronSOMConfig netConfig;

        private List<NeuronSOM> inputs;
        private List<NeuronSOM> neurons;


        private selectMethod myMode;

        private int actualIteration;

        private double learningRate;

        private bool lernDone;

        private Random myRandom;

        private List<List<double>> lernData;
        public enum selectMethod
        {
            WTA,Gauss, Rectangle
        }
        public NeuronSOMController(selectMethod mode,int inputSize, int x, int y, int maxEpoch,double lernValue)
        {
            myMode = mode;
            netConfig = new NeuronSOMConfig();
            netConfig.outHight = y;
            netConfig.outWidth = x;
            netConfig.numIterations = maxEpoch;
            netConfig.learningRate = lernValue;
            netConfig.Initialization();

            actualIteration = 0;
            lernDone = false;
            myRandom = new Random();

            InitializeNetwork(inputSize);
        }

        public double GetActiovationValue(int x, int y)
        {
            int position = x * netConfig.outHight + y;
            return neurons[position].getDistance();
        }
        public List<double> GetNeuronValue(int x, int y)
        {
            int position = x * netConfig.outHight + y;
            return neurons[position].weights;
        }
        public void SetInput(List<double> data)
        {
            int iterator = 0;
            foreach (var input in inputs)
            {
                input.output = data[iterator++];

            }
        }


        public void SetEpochData(List<List<double>> data)
        {
            lernData = data;
        }
        public void CalculateEpoch()
        {
            Epoch(lernData);
        }


        private void Epoch(List<List<double>> data)
        {
            if (lernDone)
                return;

            learningRate = netConfig.getLearningRate(actualIteration);

            if (--netConfig.numIterations > 0)
            {
                double distance, widthSq, neighbourhoodRadius, influence;

                int randVector = myRandom.Next(0,data.Count);
                SetInput(data[randVector]);

                NeuronSOM winner = FindBestNeuron();

                if (myMode != selectMethod.WTA)
                {

                    foreach ( var neuron in neurons)
                    {
                        distance =Math.Sqrt((winner.x - neuron.x) * (winner.x - neuron.x) + (winner.y - neuron.y) * (winner.y - neuron.y));
                        neighbourhoodRadius = netConfig.getNeighbourhoodRadius(actualIteration);

                        influence = 0;
                        switch (myMode)
                        {
                            case selectMethod.Gauss:
                                if (distance < neighbourhoodRadius)
                                {
                                    widthSq = neighbourhoodRadius * neighbourhoodRadius;
                                    influence = Math.Exp(-(distance * distance) / (2 * widthSq));
                                    neuron.setWeights(learningRate, influence);
                                }
                                break;
                            case selectMethod.Rectangle:
                                if (distance <= neighbourhoodRadius)
                                    influence = 1;
                                else
                                    influence = 0;
                                neuron.setWeights(learningRate, influence);
                                break;
                            default:
                                break;
                        }

                     //   neuron.setWeights(learningRate, influence);
                    }
                }
                else
                {
                    winner.setWeights(learningRate, 1);             //WTA
                }


                actualIteration++;
            }
            else
                lernDone = true;
        }

        private NeuronSOM FindBestNeuron()
        {
            int winner = 0;
            double winVar = double.MaxValue, tmp;

            for ( int k =0; k < neurons.Count; k++)
            {
                tmp = neurons[k].getDistance();
                if(tmp < winVar)
                {
                        winVar = tmp;
                    winner = k;
                }
            }
            return neurons[winner];
        }
        private void InitializeNetwork(int inputSize)
        {
            inputs = new List<NeuronSOM>();
            neurons = new List<NeuronSOM>();

            for(int k =0; k < inputSize; k++)
            {
                inputs.Add(new NeuronSOM(null,0,0));
            }

            for (int x = 0; x < netConfig.outWidth; x++)
                for (int y = 0; y < netConfig.outWidth; y++)
                    neurons.Add(new NeuronSOM(inputs, x, y));
        }






    }
}
