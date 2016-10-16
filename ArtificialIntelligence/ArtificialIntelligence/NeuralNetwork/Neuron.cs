using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    interface Neuron
    {
        void Ask();
        void Lern(double lernValue, double response);
    }
}
