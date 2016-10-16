 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class Perceptron : Neuron
    {
        private Dictionary<Perceptron, double> weights = new Dictionary<Perceptron, double>();
        List<Perceptron> keys = new List<Perceptron>();
        private double b;

        public double output { get; set;}

        //constructors
        public Perceptron()
        {

        }

        public Perceptron(double x)
        {
            output = x;
        }

        public Perceptron(List<Perceptron> perceptrons)
        {
            ChangeInputPerceptrons(perceptrons);
        }


        //public methods
        public void Ask()
        {
            double s = b;
            foreach (Perceptron key in weights.Keys)
            {
                s += weights[key] * key.output;
            }

            if (PerceptronFunction(s) >= 0)
                output = 1;
            else
                output = 0;
        }

        public void Lern(double lernValue, double response)
        {
            Ask();
            foreach (Perceptron key in keys)
            {
                weights[key] += lernValue * (response - output) * key.output;
            }
            b += lernValue * (response - output);
        }

        public void ChangeInputPerceptrons(List<Perceptron> perceptrons)
        {
            weights.Clear();
            foreach (Perceptron perc in perceptrons)
            {
                weights.Add(perc, 0);
            }
            InitializeWeights();
        }

        public void RestartPerceptron()
        {
            InitializeWeights();
        }



        //private functions
        double PerceptronFunction(double s)
        {
            double a = 1, b =0;

            return a*s+b;
        }

        void InitializeWeights()
        {
            Random rand = new Random();
            keys.Clear();
            foreach (KeyValuePair<Perceptron, double> entry in weights)
            {
                keys.Add(entry.Key);
            }
            foreach (Perceptron key in keys)
            {
                weights[key] = rand.NextDouble();
            }
            b = rand.NextDouble();
        }

    }
}
