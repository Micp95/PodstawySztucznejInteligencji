using ArtificialIntelligence.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Exemples
{
    class LogicGatesMPL
    {
        AdalineMPLNetworkController networkAND;
        AdalineMPLNetworkController networkOR;
        AdalineMPLNetworkController networkNOT;
        AdalineMPLNetworkController networkXOR;

        public enum gateValue
        {
            AND, OR, NOT,XOR
        }
        public double error { get; set; }

        public LogicGatesMPL()
        {
            error = 0.1;
        }



        public void initializeNetworks(gateValue net, double lernValue,int neurons)
        {
            int[] layers = new int[] { 2, 1 };
            switch (net)
            {
                case gateValue.AND:
                    if (neurons != 1)
                        layers = new int[] { 2, neurons, 1 };
                    else
                        layers = new int[] { 2, 1 };

                    networkAND = new AdalineMPLNetworkController(layers,lernValue);
                    break;
                case gateValue.OR:
                    if (neurons != 1)
                        layers = new int[] { 2, neurons, 1 };
                    else
                        layers = new int[] { 2, 1 };
                    networkOR = new AdalineMPLNetworkController(layers, lernValue);
                    break;
                case gateValue.NOT:
                    if(neurons != 1)
                        layers = new int[] { 1,neurons, 1 };
                    else
                        layers = new int[] { 1, 1 };
                    networkNOT = new AdalineMPLNetworkController(layers, lernValue);
                    break;
                case gateValue.XOR:
                    layers = new int[] { 2, neurons, 1 };
                    networkXOR = new AdalineMPLNetworkController(layers, lernValue);
                    break;
            }

        }

        public string lern(gateValue net,int iterations, double error)
        {
            AdalineMPLNetworkController network = getNetwork(net);
            List<TestData> lernData = getTestData(net);
            

            while (iterations != 0)
            {
                foreach ( TestData actData in lernData)
                {
                    network.lernArr(actData.x, actData.res, error);
                    //network.lern(actData.x, actData.res);
                }
                iterations--;
            }


            return "Act%: "+testGate(net);
        }
        public string lernEnd(gateValue net,double error)
        {
            AdalineMPLNetworkController network = getNetwork(net);
            List<TestData> lernData = getTestData(net);
            double iteration = 0;
            do
            {
                foreach (TestData actData in lernData)
                {
                    network.lernArr(actData.x, actData.res,error);
                }
                iteration++;
                if (iteration >= 10e4)
                    break;
            } while (testGate(net) != 1);
            //if (testGate(net) != 1)

            return "iter" + iteration + "  " + "Act%: " + testGate(net);
        }


        bool correctFunction(double x, double y)
        {
            double res = y - x;
            if (res < 0)
                res = -res;
            if (res < error)
                return true;
            else
                return false;
        }
        
        double getActallError(double x,double y) {
            double res = y - x;
            if (res < 0)
                res = -res;
            return res;
        }

        public double ask(gateValue net, double[] input)
        {
            AdalineMPLNetworkController network = getNetwork(net);
            return network.ask(input)[0];
        }


        public double testGate(gateValue net)
        {
            AdalineMPLNetworkController network = getNetwork(net);
            List<TestData> lernData = getTestData(net);

            double correct = 0;
            foreach (TestData data in lernData)
            {
                if (correctFunction(ask(net,data.x), data.res[0]))
                    correct++;
            }
            return (correct / (double)(lernData.Count));

        }
        public double getActualErrorForTest(gateValue net)
        {
            AdalineMPLNetworkController network = getNetwork(net);
            List<TestData> lernData = getTestData(net);

            double acumlator = 0;
            foreach (TestData data in lernData)
            {
                acumlator += getActallError(ask(net, data.x), data.res[0]);
            }

            return acumlator / (double)lernData.Count;
        }

        private List<TestData> getTestData(gateValue net)
        {
            List<TestData> retData = new List<TestData>();
            double[] x;
            double[] res;
            switch (net)
            {
                case gateValue.AND:
                    x = new double[] { 0, 0 };
                    res = new double[] { 0 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 0, 1 };
                    res = new double[] { 0 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 1, 0 };
                    res = new double[] { 0 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 1, 1 };
                    res = new double[] { 1 };
                    retData.Add(new TestData(x, res));

                    break;
                case gateValue.OR:
                    x = new double[] { 0, 0 };
                    res = new double[] { 0 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 0, 1 };
                    res = new double[] { 1 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 1, 0 };
                    res = new double[] { 1 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 1, 1 };
                    res = new double[] { 1 };
                    retData.Add(new TestData(x, res));

                    break;
                case gateValue.NOT:
                    x = new double[] { 0 };
                    res = new double[] { 1 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 1 };
                    res = new double[] { 0 };
                    retData.Add(new TestData(x, res));

                    break;
                case gateValue.XOR:
                    x = new double[] { 0, 0 };
                    res = new double[] { 0 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 0, 1 };
                    res = new double[] { 1 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 1, 0 };
                    res = new double[] { 1 };
                    retData.Add(new TestData(x, res));

                    x = new double[] { 1, 1 };
                    res = new double[] { 0 };
                    retData.Add(new TestData(x, res));
                    break;
            }


            return retData;
        }

        private AdalineMPLNetworkController getNetwork(gateValue net)
        {
            switch (net)
            {
                case gateValue.AND:
                    return networkAND;
                case gateValue.OR:
                    return networkOR;
                case gateValue.NOT:
                    return networkNOT;
                case gateValue.XOR:
                    return networkXOR;
            }
            return null;
        }

        struct TestData
        {
            public double[] res;
            public double[] x;
            public TestData(double[] x,double[] res)
            {
                this.res = res;
                this.x = x;
            }
        }

    }
}
