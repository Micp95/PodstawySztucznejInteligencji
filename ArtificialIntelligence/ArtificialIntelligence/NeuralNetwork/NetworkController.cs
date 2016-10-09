using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class NetworkController
    {
        private List<List<Perceptron>> perceptrons = new List<List<Perceptron>>();
        private List<Perceptron> perceptronInput = new List<Perceptron>();

        public NetworkController(List<int> networkStructure)
        {
            List<Perceptron> perceptronsListPrev = null;
            foreach ( int perceptronsLength in networkStructure)
            {
                List<Perceptron> perceptronsList = new List<Perceptron>();
                for ( int k =0; k < perceptronsLength; k++)
                {
                    if (perceptronsListPrev != null)
                        perceptronsList.Add(new Perceptron(perceptronsListPrev));
                    else
                        perceptronsList.Add(new Perceptron());
                }
                perceptrons.Add(perceptronsList);
                perceptronsListPrev = perceptronsList;
            }
        }

        public double SimpleNetworLern(List<double[]> inputList,double[] outputList, double lernValue, int iterations)
        {
            List<List<double>> input = new List<List<double>>();
            List<List<double>> output = new List<List<double>>();

            for (int k =0; k < outputList.Length;k++)
            {
                List<double> tmpList = new List<double>();
                foreach (double[] tab in inputList)
                {
                    tmpList.Add(tab[k]);
                }

                input.Add(tmpList);
            }

            //foreach ( double[] tab in inputList)
            //    input.Add(new List<double>(tab));

            foreach (double value in outputList)
            {
                List<double> tmpList = new List<double>();
                tmpList.Add(value);
                output.Add(tmpList);
            }

            return LernNetwork(lernValue, input, output, iterations);
        }

        public double LernNetwork(double lernValue, List<List<double>> input,List<List<double>> output,int iterations)
        {

            for ( int k =0; k < iterations; k++)
            {
                for ( int p = 0; p < input.Count; p++)
                {
                    setInputNeurons(input[p]);
                    Lern(lernValue, output[p]);
                }
            }

            double correct = 0;
            for (int p = 0; p < output.Count; p++)
            {
                setInputNeurons(input[p]);
                List<double> ans = Ask();
                bool flag = true;
                for ( int g =0; g < ans.Count; g++)
                {
                    if (ans[g] != output[p][g])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    correct++;

            }


            return correct / ((double)output.Count) * 100;
        }

        public string AksNetwork(List<double> input)
        {
            setInputNeurons(input);
            string ret = "";
            List<double> ans = Ask();
            foreach ( double num in ans)
            {
                ret += num.ToString() + " ";
            }

            return ret;
        }

        public void RestartNetwork()
        {
            foreach (List<Perceptron> layer in perceptrons)
            {
                foreach (Perceptron perceptron in layer)
                {
                    perceptron.RestartPerceptron();
                }
            }
        }


        private List<double> Ask()
        {

            foreach (List<Perceptron> layer in perceptrons)
            {
                //active perceptrons
                foreach (Perceptron perceptron in layer)
                {
                    perceptron.Ask();
                }
            }

            //generateAnswer
            List<double> output = new List<double>();
            foreach (Perceptron perceptron in perceptrons.Last())
            {
                output.Add(perceptron.output);
            }

            return output;
        }
        private void Lern(double lernValue, List<double> output)
        {
            //setInputNeurons(input);

            foreach (List<Perceptron> layer in perceptrons)
            {
                int count = 0;
                //active perceptrons
                foreach (Perceptron perceptron in layer)
                {
                    perceptron.Lern(lernValue, output[count++]);
                }
            }

        }


        private void setInputNeurons(List<double> input)
        {
            if (perceptronInput.Count == input.Count)
            {
                //set input neurons
                int count = 0;
                foreach (Perceptron perceptron in perceptronInput)
                {
                    perceptron.output = input[count++];
                }
            }
            else
            {
                perceptronInput.Clear();

                //create input neurons
                foreach (double value in input)
                {
                    perceptronInput.Add(new Perceptron(value));
                }

                //set new input to first layer
                foreach (Perceptron perceptron in perceptrons[0])
                {
                    perceptron.ChangeInputPerceptrons(perceptronInput);
                }
            }
        }


    }
}
