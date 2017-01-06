using ArtificialIntelligence.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Exemples
{
    class HopfieldLernMap
    {
        private NeuronHopfieldController controller;

        List<List<double>> buffLernVectors;
        public void InitializeNetwork(int x, int y)
        {
            RestartNetwork(x,y);
        }
        public void AddLernVector(List<double> vector)
        {
            buffLernVectors.Add(vector);
        }

        public List<double> GetLernVector(int index)
        {
            return buffLernVectors[index];
        }
        public void StartLern()
        {
            controller.LernNetwork(buffLernVectors);
        }
        public NeuronHopfieldController.AskResult AskNetwork(List<double> vector)
        {
            return controller.AskNetwork(vector);
        }
        public void RestartNetwork(int x, int y)
        {
            controller = new NeuronHopfieldController(x, y);
            buffLernVectors = new List<List<double>>();
        }
    }
}
