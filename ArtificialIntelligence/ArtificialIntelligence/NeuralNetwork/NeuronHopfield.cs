using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.NeuralNetwork
{
    class NeuronHopfield
    {
        int indexX, indexY;
        int index;
        public List<double> weights;

        public double output;
        List<NeuronHopfield> inputNeurons;
        public double input;

        public NeuronHopfield(int x, int y, int index, List<NeuronHopfield> inputNeurons, int N)
        {
            this.inputNeurons = inputNeurons;
            this.indexX = x;
            this.indexY = y;
            this.index = index;
            weights = new List<double>();
            for (int k = 0; k < N; k++)
            {
                weights.Add(0);

            }
            input = 0;
            output = 0;
        }
        public bool SetOutput(){
            double sum = 0;

            IEnumerator enumWeights = weights.GetEnumerator();
            IEnumerator enumInputs = inputNeurons.GetEnumerator();

            while ((enumWeights.MoveNext()) && (enumInputs.MoveNext()))
            {
                double w =   (double)enumWeights.Current;
                NeuronHopfield neuron = (NeuronHopfield)enumInputs.Current;
                sum += w * neuron.output;
            }
            sum += input;

            bool resultFlag = false;

            if (sum > 0){
                resultFlag = true;
                output = 1;
            }
            else if (sum < 0){
                resultFlag = true;
                output = -1;
            }

            return resultFlag;
        }




    }
}
