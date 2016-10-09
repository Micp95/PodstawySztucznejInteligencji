using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialIntelligence.NeuralNetwork;

namespace ArtificialIntelligence.Exemples
{
    
    
    class LogicGate
    {
        NetworkController networkAND;
        NetworkController networkOR;
        NetworkController networkNOT;

        public enum gateValue{
            AND,OR,NOT
        }

        public LogicGate()
        {
            initializeNetworks();
        }

        public double LernNetwork(gateValue val, int iteratin,double lernVal)
        {
            switch (val)
            {
                case gateValue.AND:
                    return lernAND(iteratin, lernVal);
                case gateValue.OR:
                    return lernOR(iteratin, lernVal);
                case gateValue.NOT:
                    return lernNOT(iteratin, lernVal);
            }
            return 0;
        }

        public void RestartNetwork(gateValue val)
        {
            switch (val)
            {
                case gateValue.AND:
                    networkAND.RestartNetwork();
                    break;
                case gateValue.OR:
                    networkOR.RestartNetwork();
                    break;
                case gateValue.NOT:
                    networkNOT.RestartNetwork();
                    break;
            }
        }

        public string AskNetwork(gateValue val,double[] input)
        {
            List<double> inputList = new List<double>(input);

            switch (val)
            {
                case gateValue.AND:
                    return networkAND.AksNetwork(inputList);
                case gateValue.OR:
                    return networkOR.AksNetwork(inputList);
                    break;
                case gateValue.NOT:
                    return networkNOT.AksNetwork(inputList);
            }
            return "";
        }


        private double lernAND(int iteratin, double lernVal)
        {
            double[] x1 = new double[] { 0, 0, 1, 1 };
            double[] x2 = new double[] { 0, 1, 0, 1 };
            double[] re = new double[] { 0, 0, 0, 1 };

            List<double[]> list = new List<double[]>();
            list.Add(x1);
            list.Add(x2);

            return networkAND.SimpleNetworLern(list,re, lernVal,iteratin);
        }
        private double lernOR(int iteratin, double lernVal)
        {
            double[] x1 = new double[] { 0, 0, 1, 1 };
            double[] x2 = new double[] { 0, 1, 0, 1 };
            double[] re = new double[] { 0, 1, 1, 1 };

            List<double[]> list = new List<double[]>();
            list.Add(x1);
            list.Add(x2);

            return networkOR.SimpleNetworLern(list, re, lernVal, iteratin);

        }
        private double lernNOT(int iteratin, double lernVal)
        {
            double[] x1 = new double[] { 0, 1 };
            double[] re = new double[] { 1, 0 };

            List<double[]> list = new List<double[]>();
            list.Add(x1);

            return networkOR.SimpleNetworLern(list, re, lernVal, iteratin);
        }


        private void initializeNetworks()
        {
            int[] tab = new int[] { 1 };
            List<int> list = new List<int>(tab);

            networkAND = new NetworkController(list);
            networkOR = new NetworkController(list);
            networkNOT = new NetworkController(list);
        }


    }
}
