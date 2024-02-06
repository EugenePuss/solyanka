using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace WindowsFormsApp2
{
    public partial class kalculator : Form
    {

        kalk Enemi = new kalk();
        //
        public kalculator()
        {
            InitializeComponent();
            panel1.Visible = false;
        }
        //
        public void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text = Enemi.kk(textBox1.Text);
            label6.Text = Enemi.Opz;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ошибка. Поле ввода пустое");
                clears();
            }


        }
        //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void clears()
        {
            Enemi.clears();
            textBox2.Text = "";
            textBox1.Text = "";
            label6.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {

            clears();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }


}
