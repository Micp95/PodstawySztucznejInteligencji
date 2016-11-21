using ArtificialIntelligence.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Exemples
{
    class RGB_SOM
    {
        private NeuronSOMController net;

        public NeuronSOMController.selectMethod netMode = NeuronSOMController.selectMethod.Gauss;
        public double startLernValue = 0.1;

        private List<List<double>> lernData;
        private int x,y;
        public RGB_SOM()
        {
            lernData = new List<List<double>>();

        }

        public void Initialize(int x, int y,int maxEpoch,double startLernValue)
        {
            this.startLernValue = startLernValue;
            this.x = x;
            this.y = y;
            net = new NeuronSOMController(netMode, 3, x, y, maxEpoch, startLernValue);
            net.SetEpochData(lernData);
        }


        public void AddCluster(int r, int g, int b)
        {
            List<double> cl = GetNormalizedColor(r, g, b);
            lernData.Add(cl);
        }
        private List<double> GetNormalizedColor(int r,int g, int b)
        {
            List<double> cl = new List<double>();
            cl.Add((double)r / 255);
            cl.Add((double)g / 255);
            cl.Add((double)b / 255);
            return cl;
        }

        public void lernEpoch(int count)
        {
            while (count-- > 0)
            {
                net.CalculateEpoch();

            }
        }

        public Bitmap GetActualMap()
        {
            Bitmap resBM = new Bitmap(x, y);
            Color newCol;
            int r, g, b;

            for (int xx = 0; xx < x; xx++)
            {
                for (int yy = 0; yy < y; yy++)
                {
                    List<double> dRGB = net.GetNeuronValue(xx, yy);
                    r = (int)(dRGB[0] * 255.0);
                    g = (int)(dRGB[1] * 255.0);
                    b = (int)(dRGB[2] * 255.0);
                    if (r > 255)
                        r = 255;
                    if (g > 255)
                        g = 255;
                    if (b > 255)
                        b = 255;
                    newCol = Color.FromArgb(r, g, b);
                    resBM.SetPixel(xx, yy, newCol);
                }
            }

            return resBM;
        }
        public Bitmap GetNetResponse(int rr, int gg, int bb)
        {
            net.SetInput(GetNormalizedColor(rr,gg,bb));


            Bitmap resBM = new Bitmap(x, y);
            Color newCol;
            int r, g, b;

            for (int xx = 0; xx < x; xx++)
            {
                for (int yy = 0; yy < y; yy++)
                {
                    double dRGB = net.GetActiovationValue (xx, yy);
                    r = (int)(dRGB * 255.0);
                    g = (int)(dRGB * 255.0);
                    b = (int)(dRGB * 255.0);

                    if (r > 255)
                        r = 255;
                    if (g > 255)
                        g = 255;
                    if (b > 255)
                        b = 255;
                    newCol = Color.FromArgb(r, g, b);
                    resBM.SetPixel(xx, yy, newCol);
                }
            }

            return resBM;
        }


    }
}
