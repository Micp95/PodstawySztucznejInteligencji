using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class AdalineMPL
    {
        List<AdalineMPL> inputs = new List<AdalineMPL>();
        List<double> weights = new List<double>();
        private double b;


        public double output { get; set; }
        public double deltaError { get; set; }

        private double lernValue { get; set; }

        public AdalineMPL(double lernValue, List<AdalineMPL> inputs)
        {
            this.inputs = inputs;
            this.lernValue = lernValue;
            if( inputs != null)
                InitializeWeights();
        }

        public void Ask()
        {
            deltaError = 0;
            double s = b;
          //  double s = 0;
            for (int k = 0; k < inputs.Count; k++)
                s += weights[k] * inputs[k].output;


            output = function(s);
        }
        public void Lern()
        {
            //send error to prev layer
            for (int k = 0; k < inputs.Count; k++)
            {
                inputs[k].deltaError += deltaError * weights[k];
            }

            errorFunction();
        }

        public void LernInitialization(double z)
        {
            deltaError = z - output;
            Lern();
        }


        void errorFunction()
        {
     //       double delta = z - output;
            for (int k = 0; k < inputs.Count; k++)
                weights[k] = weights[k] + (lernValue* deltaError * dFunction (output)* inputs[k].output);
            b = b + lernValue * dFunction(output) * deltaError;
        }

        double alpha = 0.6;
        double function(double x)
        {
            return 1.0 / (1.0+Math.Exp((-alpha)*x));
        }
        double dFunction(double y)
        {
            return y * (1.0 - y);
        }

        void InitializeWeights()
        {
            Random rand = new Random();
            weights.Clear();

            for( int k = 0;k < inputs.Count;k++)
                weights.Add(rand.NextDouble());

            b = rand.NextDouble();
        }

        public double getError()
        {
            return deltaError;
        }
    }
}
