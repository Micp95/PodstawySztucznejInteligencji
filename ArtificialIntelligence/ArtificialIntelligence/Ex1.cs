using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtificialIntelligence.NeuralNetwork;
using ArtificialIntelligence.Exemples;

namespace ArtificialIntelligence
{
    public partial class Ex1 : Form
    {
        private LogicGate ligicNetwork;
        private Menu myMenu;
        public Ex1(Menu myMenu)
        {
            this.myMenu = myMenu;
            InitializeComponent();
        }

        //private void Ex1_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    myMenu.Show();

        //}

        private void Ex1_Load(object sender, EventArgs e)
        {
            ligicNetwork = new LogicGate();
        }

        private void Ex1_FormClosed(object sender, FormClosedEventArgs e)
        {
            myMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double val = ligicNetwork.LernNetwork(LogicGate.gateValue.OR, int.Parse(textBox4.Text), double.Parse(textBox3.Text));

            label1.Text= val.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            double val = ligicNetwork.LernNetwork(LogicGate.gateValue.AND, int.Parse(textBox4.Text), double.Parse(textBox3.Text));

            label1.Text = val.ToString();

        }

        private void buttonNOTLern_Click(object sender, EventArgs e)
        {
            double val = ligicNetwork.LernNetwork(LogicGate.gateValue.NOT, int.Parse(textBox4.Text), double.Parse(textBox3.Text));

            label1.Text = val.ToString();

        }

        private void buttonORAsk_Click(object sender, EventArgs e)
        {
            double[] tab = new double[] { double.Parse(textBox1.Text), double.Parse(textBox2.Text) };
            label1.Text = ligicNetwork.AskNetwork(LogicGate.gateValue.OR, tab);
        }

        private void buttonANDAsk_Click(object sender, EventArgs e)
        {
            double[] tab = new double[] { double.Parse(textBox1.Text), double.Parse(textBox2.Text) };
            label1.Text = ligicNetwork.AskNetwork(LogicGate.gateValue.AND, tab);
        }

        private void buttonNOTAsk_Click(object sender, EventArgs e)
        {
            double[] tab = new double[] { double.Parse(textBox1.Text) };
            label1.Text = ligicNetwork.AskNetwork(LogicGate.gateValue.NOT, tab);
        }

        private void buttonORRestart_Click(object sender, EventArgs e)
        {
            ligicNetwork.RestartNetwork(LogicGate.gateValue.OR);
        }

        private void buttonANDRestart_Click(object sender, EventArgs e)
        {
            ligicNetwork.RestartNetwork(LogicGate.gateValue.AND);
        }

        private void buttonNOTRestart_Click(object sender, EventArgs e)
        {
            ligicNetwork.RestartNetwork(LogicGate.gateValue.NOT);
        }
    }
}
