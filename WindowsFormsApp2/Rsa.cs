using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Rsa : Form
    {
        public Rsa()
        {
            InitializeComponent();
            label7.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label5.BackColor = Color.FromArgb(0, 0, 0, 0);
            linkLabel1.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel1.Visible = false;
        }
        RSA0_0 objek = new RSA0_0();
        RSACryptoServiceProvider wer = new RSACryptoServiceProvider();
        string otkr_key = "",clz_key="";
        byte sch = 0;
        private void button1_Click(object sender, EventArgs e)
        {
           
            objek.Generic_keys();
             otkr_key = " (" + objek.Exp.ToString() + "," + objek.n.ToString() + ")";
            clz_key = " (" + objek.d.ToString() + "," + objek.n.ToString() + ")";
            label11.Text = objek.p.ToString();
            label12.Text = objek.q.ToString();
            label13.Text = objek.Function_E.ToString();
            label14.Text = objek.Exp.ToString();
            label16.Text = objek.n.ToString();
            label7.Text = "Открытый ключ" + otkr_key;
            label5.Text = " Закрытый ключ" + clz_key;
            label1.Text = objek.d.ToString();
            textBox2.Text = objek.Encrypt(textBox1.Text).ToString();
            
      
        }

        private void Rsa_Load(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sch++;
            textBox3.Text = objek.Decrypt(textBox2.Text).ToString();
            //objek.Clear_resourse();
            if (sch == 5)
            {
                objek.Clear_resourse();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
