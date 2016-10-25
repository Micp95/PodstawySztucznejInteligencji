using ArtificialIntelligence.Exemples;
using ArtificialIntelligence.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArtificialIntelligence.Exemples.LogicGatesMPL;

namespace ArtificialIntelligence
{
    public partial class Ex21 : Form
    {
        private Menu myMenu;
        LogicGatesMPL network;
        LogicGatesMPL.gateValue selGate;

        public Ex21(Menu myMenu)
        {
            this.myMenu = myMenu;
            network = new LogicGatesMPL();
            InitializeComponent();

            labelSelect.Text = "AND";
            selGate = LogicGatesMPL.gateValue.AND;
            network.initializeNetworks(LogicGatesMPL.gateValue.AND, double.Parse(textBox1.Text), int.Parse(textBox6.Text));
            network.initializeNetworks(LogicGatesMPL.gateValue.OR, double.Parse(textBox1.Text), int.Parse(textBox7.Text));
            network.initializeNetworks(LogicGatesMPL.gateValue.NOT, double.Parse(textBox1.Text), int.Parse(textBox8.Text));
            network.initializeNetworks(LogicGatesMPL.gateValue.XOR, double.Parse(textBox1.Text), int.Parse(textBox9.Text));

        }

        private void Ex21_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            network.error = double.Parse(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelSelect.Text = "AND";
            selGate = LogicGatesMPL.gateValue.AND;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelSelect.Text = "OR";
            selGate = LogicGatesMPL.gateValue.OR;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelSelect.Text = "NOT";
            selGate = LogicGatesMPL.gateValue.NOT;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelSelect.Text = "XOR";
            selGate = LogicGatesMPL.gateValue.XOR;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int sizeLayer = 0;
            switch (selGate)
            {
                case gateValue.AND:
                    sizeLayer = int.Parse(textBox6.Text);
                    break;
                case gateValue.OR:
                    sizeLayer = int.Parse(textBox7.Text);
                    break;
                case gateValue.NOT:
                    sizeLayer = int.Parse(textBox8.Text);
                    break;
                case gateValue.XOR:
                    sizeLayer = int.Parse(textBox9.Text);
                    break;
            }

            network.initializeNetworks(selGate, double.Parse(textBox1.Text), sizeLayer);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            labelOut.Text = network.testGate(selGate)+"%";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labelOut.Text = network.ask(selGate, new double[] { double.Parse(textBox3.Text), double.Parse(textBox4.Text) }).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labelOut.Text = network.lern(selGate, int.Parse(textBox5.Text), double.Parse(textBox2.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            labelOut.Text = network.lernEnd(selGate, double.Parse(textBox2.Text));
        }

        private void Ex21_FormClosing(object sender, FormClosingEventArgs e)
        {
            myMenu.Show();
        }
    


        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            network.initializeNetworks(LogicGatesMPL.gateValue.AND, double.Parse(textBox1.Text), int.Parse(textBox6.Text));
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            network.initializeNetworks(LogicGatesMPL.gateValue.OR, double.Parse(textBox1.Text), int.Parse(textBox7.Text));
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            network.initializeNetworks(LogicGatesMPL.gateValue.NOT, double.Parse(textBox1.Text), int.Parse(textBox8.Text));
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            network.initializeNetworks(LogicGatesMPL.gateValue.XOR, double.Parse(textBox1.Text), int.Parse(textBox9.Text));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            labelOut.Text = network.getActualErrorForTest(selGate) + "%";
        }
    }
}
