using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class NeuronHebbaController
    {
        private List<List<NeuronHebba>> neurons = new List<List<NeuronHebba>>();
        public NeuronHebbaController(int[] layers, double lernValue)
        {
            List<NeuronHebba> prevLayer = null;
            neurons.Clear();

            foreach (int k in layers)
            {
                List<NeuronHebba> actLayer = new List<NeuronHebba>();
                for (int p = 0; p < k; p++)
                    actLayer.Add(new NeuronHebba(prevLayer,lernValue));
                neurons.Add(actLayer);
                prevLayer = actLayer;
            }
        }


        public double[] ask(double[] input)
        {
            setInput(input);
            for (int k = 1; k < neurons.Count; k++)
            {
                foreach (NeuronHebba ad in neurons[k])
                {
                    ad.Ask();
                }
            }
            double[] res = new double[neurons[neurons.Count - 1].Count];
            int p = 0;
            foreach (NeuronHebba ad in neurons[neurons.Count - 1])
            {
                res[p] = ad.output;
            }
            return res;
        }

        public void lern(double[] input, double[] res)
        {
            setInput(input);
            ask(input);

            int p = 0;
            foreach (NeuronHebba ad in neurons[neurons.Count - 1])
            {
                ad.Lern(res[p++]);
            }


            for (int k = neurons.Count - 2; k > 0; k--)
            {

                foreach (NeuronHebba ad in neurons[k])
                {
                    ad.Lern();
                }
            }
        }

        public void lern(double[] input)
        {
            setInput(input);
            ask(input);

            for ( int k =1; k < neurons.Count;k++)
                foreach (NeuronHebba neuron in neurons[k])
                    neuron.Lern();
        }



        private void setInput(double[] input)
        {
            int k = 0;
            foreach (NeuronHebba ad in neurons[0])
                ad.output = input[k++];
        }


        private double getMaxErr(double[] output, double[] res)
        {
            double actMax = 0, tmp;
            for (int k = 0; k < res.Length; k++)
            {
                tmp = res[k] - output[k];
                if (tmp < 0)
                    tmp = -tmp;

                if (actMax < tmp)
                    actMax = tmp;
            }
            return actMax;
        }

        public double lernArr(double[] input, double[] res, double error)
        {
            double iterations = 0;
            double actErr;
            do
            {
                lern(input, res);
                actErr = getMaxErr(ask(input), res);

                if (actErr < 0)
                    actErr = -actErr;

                iterations++;
                if (iterations >= 10e4)
                    break;
            } while (actErr > error);

            return iterations;
        }

    }
}
