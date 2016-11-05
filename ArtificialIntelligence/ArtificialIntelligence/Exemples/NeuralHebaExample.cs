using ArtificialIntelligence.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Exemples
{
    class NeuralHebaExample
    {
        public enum selectedEnum
        {
            supervised, unsupervised
        }
        NeuronHebbaController network;

        public void initializeNetworks(double lernValue)
        {
            int[] layers = new int[] { 9, 1 };
            network = new NeuronHebbaController(layers,lernValue);
        }

        public double ask(double[] input)
        {
            return network.ask(input)[0];
        }
        public void lern(selectedEnum mode,double[][] data, int iterations)
        {
            while (iterations != 0)
            {
                double[] tmp = new double[] {-1}; 
                foreach (double[] actData in data)
                {
                    if( mode == selectedEnum.unsupervised)
                        network.lern(actData);
                    else
                    {
                        network.lern(actData,tmp);
                        if (tmp[0] == -1)
                            tmp[0] = 1;
                        else
                            tmp[0] = -1;
                    }

                }
                iterations--;
            }
        }
        //public string lernEnd(selectedEnum mode, double[][] data)
        //{
        //    double iteration = 0;
        //    do
        //    {
        //        double[] tmp = new double[] { -1 };
        //        foreach (double[] actData in data)
        //        {
        //            if (mode == selectedEnum.unsupervised)
        //                network.lern(actData);
        //            else
        //            {
        //                network.lern(actData, tmp);
        //                if (tmp[0] == -1)
        //                    tmp[0] = 1;
        //                else
        //                    tmp[0] = -1;
        //            }

        //        }
        //        iteration++;

        //        if (iteration >= 10e4)
        //            break;
        //    } while (testGate(net) != 1);
        //    //if (testGate(net) != 1)

        //    return "iter" + iteration + "  " + "Act%: " + testGate(net);
        //}





    }
}
