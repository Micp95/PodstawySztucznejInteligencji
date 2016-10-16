using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{

    class AdalineNetworkController
    {
        private List<List<Adaline>> neurons = new List<List<Adaline>>();

        public AdalineNetworkController(int[] layers,double lernValue)
        {
            List<Adaline> prevLayer = null;
            neurons.Clear();

            foreach (int k  in layers)
            {
                List<Adaline> actLayer = new List<Adaline>();
                for (int p = 0; p < k; p++)
                    actLayer.Add(new Adaline(lernValue,prevLayer));
                neurons.Add(actLayer);
                prevLayer = actLayer;
            }
        }

        public void lern(double[] input, double[] res)
        {
            setInput(input);
            int p;
            for (int k = 1; k < neurons.Count; k++)
            {
                p = 0;
                foreach (Adaline ad in neurons[k])
                {
                    ad.z = res[p++];
                    ad.Ask();
                }
            }
        }
        public string ask(double[] input)
        {
            setInput(input);
            for( int k = 1; k < neurons.Count; k++)
            {
                foreach (Adaline ad in neurons[k])
                {
                    ad.Ask();
                }
            }
            string res = "";
            foreach (Adaline ad in neurons[neurons.Count -1])
            {
                res += ad.output + " ";
            }
            return res.Substring(0,res.Length-2);
        }

        private void setInput(double[] input)
        {
            int k = 0;
            foreach (Adaline ad in neurons[0])
                ad.output = input[k++];
        }

    }
}
