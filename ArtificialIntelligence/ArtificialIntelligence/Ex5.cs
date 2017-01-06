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
    public partial class Ex5 : Form
    {
        private HopfieldLernMap controller;
        private Menu myMenu;

        public Ex5(Menu myMenu)
        {
            this.myMenu = myMenu;
            InitializeComponent();
            controller = new HopfieldLernMap();
        }

        private void Ex5_Load(object sender, EventArgs e)
        {

        }

        private void Ex5_FormClosed(object sender, FormClosedEventArgs e)
        {
            myMenu.Show();
        }

        private void addButt_Click(object sender, EventArgs e)
        {
            List<double> vector = GetVector();

            AddVector(vector);


        }

        private void AddVector(List<double> vector)
        {
            controller.AddLernVector(vector);
            string row = "";
            foreach (double x in vector)
            {
                row += String.Format("{0}, ", x);
            }
            row = row.Remove(row.Length - 2);
            row = String.Format("[ {0} ]", row);
            listBox.Items.Add(row);

        }

        private List<double> GetVector()
        {
            List<double> vector = new List<double>();
            double tmp;
            double.TryParse(field00.Text, out tmp);
            vector.Add(tmp);
            double.TryParse(field01.Text, out tmp);
            vector.Add(tmp);
            double.TryParse(field02.Text, out tmp);
            vector.Add(tmp);

            double.TryParse(field10.Text, out tmp);
            vector.Add(tmp);
            double.TryParse(field11.Text, out tmp);
            vector.Add(tmp);
            double.TryParse(field12.Text, out tmp);
            vector.Add(tmp);

            double.TryParse(field20.Text, out tmp);
            vector.Add(tmp);
            double.TryParse(field21.Text, out tmp);
            vector.Add(tmp);
            double.TryParse(field22.Text, out tmp);
            vector.Add(tmp);

            return vector;

        }

        private void SetVector(List<double> tab)
        {
            field00.Text = tab[0].ToString();
            field01.Text = tab[1].ToString();
            field02.Text = tab[2].ToString();

            field10.Text = tab[3].ToString();
            field11.Text = tab[4].ToString();
            field12.Text = tab[5].ToString();

            field20.Text = tab[6].ToString();
            field21.Text = tab[7].ToString();
            field22.Text = tab[8].ToString();

        }

        private void askButt_Click(object sender, EventArgs e)
        {
            var res = controller.AskNetwork(GetVector());
            SetVector(res.newtowrkOutput);

            textOutput.Text = "Algorith iterations:\t" + res.iterations.ToString();

        }

        private void learnButt_Click(object sender, EventArgs e)
        {
            controller.StartLern();
        }

        private void initButt_Click(object sender, EventArgs e)
        {
            controller.InitializeNetwork(3, 3);

            List<double> vector1 = new List<double>();
            List<double> vector2 = new List<double>();
            List<double> vector3 = new List<double>();
            double[] tmpArr1 = {1,1,1,1,-1,1,1,1,1 };
            double[] tmpArr2 = { 1, -1, 1, -1, 1, -1, 1, -1, 1 };
            double[] tmpArr3 = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            vector1.AddRange(tmpArr1);
            AddVector(vector1);


            vector2.AddRange(tmpArr2);
            AddVector(vector2);


            vector3.AddRange(tmpArr3);
            AddVector(vector3);
        }

        private void restartButt_Click(object sender, EventArgs e)
        {
            controller.RestartNetwork(3, 3);
            listBox.Items.Clear();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;
            List<double> tab = controller.GetLernVector(listBox.SelectedIndex);
            SetVector(tab);

        }
    }
}
