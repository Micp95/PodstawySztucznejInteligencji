using ArtificialIntelligence.Exemples;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArtificialIntelligence.Exemples.NeuralHebaExample;

namespace ArtificialIntelligence
{
    public partial class Ex3 : Form
    {
        private Menu myMenu;
        selectedEnum actSelected = selectedEnum.unsupervised;
        NeuralHebaExample net;
        public Ex3(Menu myMenu)
        {
            this.myMenu = myMenu;
            InitializeComponent();
            labelSelect.Text = "Unsupervised";
            net = new NeuralHebaExample();
            double lern = double.Parse(textBox20.Text);
            net.initializeNetworks(lern);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelSelect.Text = "Supervised";
            actSelected = selectedEnum.supervised;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelSelect.Text = "Unsupervised";
            actSelected = selectedEnum.unsupervised;

        }

        private double[] getFirstTab()
        {
            double[] res = new double[9];
            res[0] = double.Parse(textBox1.Text);
            res[1] = double.Parse(textBox2.Text);
            res[2] = double.Parse(textBox3.Text);

            res[3] = double.Parse(textBox6.Text);
            res[4] = double.Parse(textBox5.Text);
            res[5] = double.Parse(textBox4.Text);

            res[6] = double.Parse(textBox9.Text);
            res[7] = double.Parse(textBox8.Text);
            res[8] = double.Parse(textBox7.Text);

            return res;
        }
        private double[] getSecondTab()
        {
            double[] res = new double[9];
            res[0] = double.Parse(textBox18.Text);
            res[1] = double.Parse(textBox17.Text);
            res[2] = double.Parse(textBox16.Text);

            res[3] = double.Parse(textBox12.Text);
            res[4] = double.Parse(textBox13.Text);
            res[5] = double.Parse(textBox14.Text);

            res[6] = double.Parse(textBox15.Text);
            res[7] = double.Parse(textBox16.Text);
            res[8] = double.Parse(textBox17.Text);

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelGeneral.Text ="Ans: " +  net.ask(getFirstTab());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double lern = double.Parse(textBox20.Text);
            net.initializeNetworks(lern);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelGeneral.Text = "Ans: " + net.ask(getSecondTab());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            net.lern(actSelected, new double[][] { getFirstTab(), getSecondTab() }, int.Parse(textBox19.Text));
        }

        private void Ex3_Load(object sender, EventArgs e)
        {

        }

        private void Ex3_FormClosing(object sender, FormClosingEventArgs e)
        {
            myMenu.Show();
        }
    }
}
