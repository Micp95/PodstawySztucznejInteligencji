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

namespace ArtificialIntelligence
{
    public partial class Ex2 : Form
    {
        public Ex2(Menu myMenu)
        {
            this.myMenu = myMenu;

            InitializeComponent();
            adalineNetwork = new AdalineLogicGate(1);
        }
        AdalineLogicGate adalineNetwork;
        private Menu myMenu;

        private void button1_Click(object sender, EventArgs e)
        {
            adalineNetwork = new AdalineLogicGate(double.Parse(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adalineNetwork.lernAND(int.Parse(textBox2.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = adalineNetwork.testAND();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = adalineNetwork.askAND(new double[] { double.Parse(textBox3.Text), double.Parse(textBox4.Text) });
        }

        private void Ex2_FormClosed(object sender, FormClosedEventArgs e)
        {
            myMenu.Show();
        }
    }
}
