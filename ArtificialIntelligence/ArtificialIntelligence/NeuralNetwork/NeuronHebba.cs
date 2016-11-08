using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class NeuronHebba
    {
        List<NeuronHebba> inputs;
        List<double> weights = new List<double>();
        private double b;

        public double output { get; set; }

        private double lernValue;


        public NeuronHebba(List<NeuronHebba> inputs, double lernValue)
        {
            this.inputs = inputs;
            this.lernValue = lernValue;

            if (inputs != null)
                InitializeWeights();
        }


        public void Ask()
        {
            double s = b;
            for (int k = 0; k < inputs.Count; k++)
                s += weights[k] * inputs[k].output;

            //output = function(s);
            output = s;
        }

        public void Lern()
        {
         //   Ask();
            for (int k = 0; k < weights.Count; k++)
                weights[k] += lernValue * output * inputs[k].output;

            b += lernValue * output;
        }

        public void Lern(double d)
        {
        //    Ask();
            for (int k = 0; k < weights.Count; k++)
                weights[k] += lernValue * d * inputs[k].output;

            b += lernValue * d;
        }


        double alpha = 0.6;
        double function(double x)
        {
            return 1.0 / (1.0 + Math.Exp((-alpha) * x));
        }

        private void InitializeWeights()
        {
            Random rand = new Random();
            weights.Clear();

            for (int k = 0; k < inputs.Count; k++)
                weights.Add(rand.NextDouble());

            b = rand.NextDouble();
        }
    }
}
