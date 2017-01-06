using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    public class NeuronHopfieldController
    {
        private List<NeuronHopfield> neurons;
        private int X, Y;


        public NeuronHopfieldController(int sizeX, int sizeY)
        {
            this.X = sizeX;
            this.Y = sizeY;

            neurons = new List<NeuronHopfield>();
            for ( int x = 0; x < X; x++){
                for ( int y =0; y < Y; y++) {
                    neurons.Add(new NeuronHopfield(x, y, y * X + x,neurons, X * Y));
                }
            }
        }

        public void LernNetwork(List<List<double>> inputs)
        {
            SetWeights(inputs);
        }

        public AskResult AskNetwork(List<double> data)
        {
            AskResult result = new AskResult();
            bool endFlag;
            SetInput(data);
            ClearOutput();
            do
            {
                endFlag = false;
                foreach (NeuronHopfield neuron in neurons){
                    if (neuron.SetOutput())
                        endFlag = true;
                }

                result.iterations++;

                if (result.iterations > 1000)
                    endFlag = false;
            } while (endFlag);


            foreach (NeuronHopfield neuron in neurons){
                result.newtowrkOutput.Add(neuron.output);
            }

            return result;
        }

        private void SetInput(List<double> data)
        {

            IEnumerator enumDAta = data.GetEnumerator();
            IEnumerator enumNeuons = neurons.GetEnumerator();

            while ((enumDAta.MoveNext()) && (enumNeuons.MoveNext()))
            {
                double input = (double)enumDAta.Current;
                NeuronHopfield neuron = (NeuronHopfield)enumNeuons.Current;

                neuron.input = input;
            }

        }

        private void ClearOutput()
        {

            foreach (NeuronHopfield neuron in neurons)
            {
                neuron.output = 0;
            }
        }

        private void SetWeights(List<List<double>> inputs)
        {
            int mapSize = neurons.Count * neurons.Count;
            int x, y;
            for ( int k = 0; k < mapSize; k++){
                x = k % neurons.Count;
                y = k / neurons.Count;

                neurons[x].weights[y] = 0;
                if(x != y){
                    foreach (List<double> input in inputs){
                        neurons[x].weights[y] += input[x] * input[y];
                    }
                    neurons[x].weights[y] /= neurons.Count;
                }
            }
        }

        public class AskResult
        {
            public List<double> newtowrkOutput { get; set; }
            public int iterations { get; set; }
            public AskResult(){
                iterations = 0;
                newtowrkOutput = new List<double>();
            }
        }
    }
}
