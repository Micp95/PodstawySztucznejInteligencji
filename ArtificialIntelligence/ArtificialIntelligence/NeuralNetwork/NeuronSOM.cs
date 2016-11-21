using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class NeuronSOM
    {

        List<NeuronSOM> inputs;
        public List<double> weights = new List<double>();

        public double output { get; set; }
        public int x {get;}
        public int y { get; }





        public NeuronSOM(List<NeuronSOM> inputs,int x,int y)
        {
            this.x = x;
            this.y = y;
            this.inputs = inputs;

            if (inputs != null)
                InitializeWeights();
        }
        

        public double getDistance()
        {
            double result = 0;

            for (int k = 0; k < inputs.Count; k++)
                result +=  (inputs[k].output- weights[k])* (inputs[k].output - weights[k]);

            return Math.Sqrt(result);
        }
        
        public void setWeights(double LearningRate,double Influence)
        {
            for (int k = 0; k < inputs.Count; k++)
                weights[k] += Influence * LearningRate * (inputs[k].output-weights[k]);
        }

        static Random rand = new Random();
        private void InitializeWeights()
        {
            
            weights.Clear();

            for (int k = 0; k < inputs.Count; k++)
                weights.Add(rand.NextDouble());
        }
    }
}
