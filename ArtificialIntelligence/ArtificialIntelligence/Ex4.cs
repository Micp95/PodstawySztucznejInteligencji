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
    public partial class Ex4 : Form
    {
        private Menu myMenu;
        private RGB_SOM net;
        public Ex4(Menu myMenu)
        {
            InitializeComponent();
            this.myMenu = myMenu;
            net = new RGB_SOM();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Ex4_FormClosed(object sender, FormClosedEventArgs e)
        {
            myMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            net.AddCluster(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            labCluster.Text += "\nR: "+ textBox1.Text+ " G: " + textBox2.Text+ " B: " + textBox3.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            net.Initialize(int.Parse(textBox6.Text), int.Parse(textBox7.Text), int.Parse(textBox4.Text), double.Parse(textBox5.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = new Bitmap(net.GetNetResponse(int.Parse(textBox10.Text), int.Parse(textBox9.Text), int.Parse(textBox8.Text)), new Size(pictureBox1.Width, pictureBox1.Height));


        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = new Bitmap(net.GetActualMap(), new Size(pictureBox1.Width, pictureBox1.Height));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            net.lernEpoch(int.Parse(textBox11.Text));
            pictureBox1.BackgroundImage = new Bitmap(net.GetActualMap(), new Size(pictureBox1.Width, pictureBox1.Height));
        }

        int actualIteration = -1;
        private void button5_Click(object sender, EventArgs e)
        {
            actualIteration = 0;
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (actualIteration < int.Parse(textBox4.Text))
            {
                actualIteration++;
                net.lernEpoch(1);
                pictureBox1.BackgroundImage = new Bitmap(net.GetActualMap(), new Size(pictureBox1.Width, pictureBox1.Height));
            }
            else
            {
                timer1.Enabled = false;
                actualIteration = -1;
            }
        }
    }
}
