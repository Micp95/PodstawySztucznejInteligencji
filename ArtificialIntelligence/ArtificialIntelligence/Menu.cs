﻿using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ex1 window = new Ex1(this);
            window.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ex2 window = new Ex2(this);
            window.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ex21 window = new Ex21(this);
            window.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ex3 window = new Ex3(this);
            window.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ex4 window = new Ex4(this);
            window.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ex5 window = new Ex5(this);
            window.Show();
            this.Hide();
        }
    }
}
