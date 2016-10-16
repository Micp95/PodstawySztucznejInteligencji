using ArtificialIntelligence.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Exemples
{
    
    class AdalineLogicGate
    {
        AdalineNetworkController ANDGAte;

        public AdalineLogicGate(double lernValue)
        {
            restartAND(lernValue);
        }

        public void restartAND(double lernValue)
        {
            int[] conf = new int[] { 2, 1 };
            ANDGAte = new AdalineNetworkController(conf, lernValue);

        }

        public void lernAND(int iteratin)
        {
            while (iteratin != 0)
            {
                double[] x = new double[] { 0, 0};
                double[] res = new double[] { 0 };
                ANDGAte.lern(x, res);

                x = new double[] { 0, 1 };
                res = new double[] { 0 };
                ANDGAte.lern(x, res);

                x = new double[] { 1, 0 };
                res = new double[] { 0 };
                ANDGAte.lern(x, res);

                x = new double[] { 1, 1 };
                res = new double[] { 1 };
                ANDGAte.lern(x, res);

                iteratin--;
            }
        }

        public string askAND(double[] input)
        {
            return ANDGAte.ask(input);
        }
        double error = 0.1;
        bool correctFunction(double x, double y)
        {
            double res = y - x;
            if (res < 0)
                res = -res;
            if (res < error)
                return true;
            else
                return false;
        }

        public string testAND()
        {
            double correct = 0;


            double[] x = new double[] { 0, 0 };
            if (correctFunction(double.Parse(askAND(x)),0))
                correct++;

            x = new double[] { 0, 1 };
            if (correctFunction(double.Parse(askAND(x)), 0))
                correct++;

            x = new double[] { 1, 0 };
            if (correctFunction(double.Parse(askAND(x)), 0))
                correct++;

            x = new double[] { 1, 1 };
            if (correctFunction(double.Parse(askAND(x)), 1))
                correct++;

            return (correct / 4.0).ToString();
        }
    }
}
