using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{

    class AdalineMPLNetworkController
    {
        private List<List<AdalineMPL>> neurons = new List<List<AdalineMPL>>();

        public AdalineMPLNetworkController(int[] layers,double lernValue)
        {
            List<AdalineMPL> prevLayer = null;
            neurons.Clear();

            foreach (int k  in layers)
            {
                List<AdalineMPL> actLayer = new List<AdalineMPL>();
                for (int p = 0; p < k; p++)
                    actLayer.Add(new AdalineMPL(lernValue,prevLayer));
                neurons.Add(actLayer);
                prevLayer = actLayer;
            }
        }

        public void lern(double[] input, double[] res)
        {
            setInput(input);
            ask(input);

            int p = 0;
            foreach (AdalineMPL ad in neurons[neurons.Count-1])
            {
                ad.LernInitialization(res[p++]);
            }


            for (int k = neurons.Count - 2; k >0; k--)
            {

                foreach (AdalineMPL ad in neurons[k])
                {
                    ad.Lern();
                }
            }
        }
        public double[] ask(double[] input)
        {
            setInput(input);
            for( int k = 1; k < neurons.Count; k++)
            {
                foreach (AdalineMPL ad in neurons[k])
                {
                    ad.Ask();
                }
            }
            double[] res = new double[neurons[neurons.Count - 1].Count];
            int p = 0;
            foreach (AdalineMPL ad in neurons[neurons.Count -1])
            {
                res[p] = ad.output;
            }
            return res;
        }
        private double getMaxErr(double[] output, double[] res)
        {
            double actMax = 0, tmp;
            for(int k =0; k < res.Length; k++)
            {
                tmp = res[k] - output[k];
                if (tmp < 0)
                    tmp = -tmp;

                if (actMax < tmp)
                    actMax = tmp;
            }
            return actMax;
        }

        public double lernArr(double[] input, double[] res,double error)
        {
            double iterations = 0;
            double actErr;
            do
            {
                lern(input, res);
                actErr = getMaxErr(ask(input),res);

                if (actErr < 0)
                    actErr = -actErr;

                iterations++;
                if (iterations >= 10e4)
                    break;
            } while (actErr > error);

            return iterations;
        }


        private void setInput(double[] input)
        {
            int k = 0;
            foreach (AdalineMPL ad in neurons[0])
                ad.output = input[k++];
        }

    }
}
