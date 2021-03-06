﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class Adaline
    {
        List<Adaline> inputs = new List<Adaline>();
        public double z;

        List<double> weights = new List<double>();
        private double b;

        public double output { get; set; }
       // double deltaError;

        private double lernValue { get; set; }

        public Adaline(double lernValue, List<Adaline> inputs)
        {
            this.inputs = inputs;
            this.lernValue = lernValue;
            z = double.NaN;
            if( inputs != null)
                InitializeWeights();
        }

        public void Ask()
        {
            double s = b;
            for (int k = 0; k < inputs.Count; k++)
                s += weights[k] * inputs[k].output;


            output = function(s);

            if (!double.IsNaN(z))
            {
                errorFunction();
                z = double.NaN;
            }
        }

        void errorFunction()
        {
            double delta = z - output;
            for (int k = 0; k < inputs.Count; k++)
                weights[k] = weights[k] + (lernValue*delta* dFunction (output)* inputs[k].output);
            b = b + lernValue * dFunction(output) * delta;
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

    }
}
