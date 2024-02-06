using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form4 newForm4 = new Form4();
            //newForm4.Show();
            MessageBox.Show("Еще не доступно");
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form6 newForm6 = new Form6();
            newForm6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 newForm6 = new Form6();
            newForm6.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Form4 newForm4 = new Form4();
            //newForm4.Show();
            MessageBox.Show("Еще не доступно");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
