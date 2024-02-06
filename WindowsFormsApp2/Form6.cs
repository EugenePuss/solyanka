using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security;


namespace WindowsFormsApp2
{
    
    public partial class Form6 : Form
    {
        private int Playere;


       
        private int a=0, b=0,f=0;
        
        private Button[,] bot = new Button[3, 3];

        public Form6()
        {
            
            Playere = 1;

            zapolnenie();
            InitializeComponent();
            Who.Text = "Сейчас ходит :1 Игрок(X) ";
            //pictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label4.BackColor = Color.FromArgb(0, 0, 0, 0);
            label5.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox3.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox2.BringToFront();
            pictureBox3.BringToFront();
            Who.BringToFront();
            pictureBox1.Location = new Point(20, 28);
            pictureBox2.Location = new Point(20, 28);
        }

        private void zapolnenie() {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <  3; j++)
                {
                    bot[i, j] = new Button();
                    bot[i, j].Size = new Size(112, 104);
                    bot[i, j].Location = new Point(29 + 137 * j, 43 + 129 * i);
                    bot[i, j].Click += button1_Click;
                    bot[i,j].Font = new Font("Microsoft Sans Serif", 48);
                    bot[i, j].FlatStyle = FlatStyle.Flat;
                    bot[i, j].ForeColor = Color.Aqua;
                    this.Controls.Add(bot[i, j]);
                    f++;
                    bot[i, j].SendToBack();
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            switch (Playere)
            {

                case 1:
                    //MessageBox.Show(sender.GetType().GetProperty("Name").GetValue(sender ).ToString);
                    sender.GetType().GetProperty("Text").SetValue(sender, "X", null);
                    Playere = 0;

                    Who.Text = "Сейчас ходит :2 Игрок(O) ";
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "O", null);
                    Playere = 1;
                    Who.Text = "Сейчас ходит :1 Игрок(X) ";
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false, null);

            //if (button1.Enabled) button1.ForeColor = Color.Blue;

            ChekGoriz();
            ChekWert();
            ChekX();
            label1.Text = "" + a;
            label2.Text = "" + b;
            if (bot[0, 0].Text != "" && bot[0, 1].Text != "" && bot[0, 2].Text != "" && bot[1, 0].Text != "" && bot[1, 1].Text != "" && bot[1, 2].Text != "" && bot[2, 0].Text != "" && bot[2, 1].Text != "" && bot[2, 2].Text != "")
            {
                MessageBox.Show("Ничья ");
                nichia();


            }
            
            
        }
        
        private void ChekGoriz()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bot[i, 0].Text==bot[i,1].Text && bot[i, 1].Text == bot[i, 2].Text && bot[i,j].Text!="")
                    {
                        pictureBox2.Size = new Size(381, 23);
                        pictureBox2.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                        pictureBox2.Location = new Point(bot[i, j].Location.X , bot[i, j].Location.Y+43);
                        pictureBox2.Visible = true;

                        Window();
                        pictureBox2.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    }

                    

                }
            }
        }
       
       
        private void ChekWert()
        {
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bot[0, j].Text == bot[1, j].Text && bot[1, j].Text == bot[2, j].Text && bot[i, j].Text != "")
                    {
                        pictureBox2.Size = new Size( 23, 381);
                        pictureBox2.Location=new Point(bot[i,j].Location.X+43, bot[i, j].Location.Y);
                        pictureBox2.Visible = true;
                        
                        Window();
                    }
                   

                }
            }
        }

        private void ChekX()
        {
            if (bot[0, 0].Text == bot[1, 1].Text && bot[1, 1].Text == bot[2, 2].Text && bot[2, 2].Text != "")
            {
                //pictureBox2.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                //pictureBox3.Visible = true;
                Window();
                //pictureBox3.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            else if (bot[0, 2].Text == bot[1, 1].Text && bot[1, 1].Text == bot[2, 0].Text && bot[2, 0].Text != "")
            {
                //pictureBox3.Visible = true;
                Window();
            }
            




        }
        
        private void Window()
        {
            if (Playere==0)
            {

                MessageBox.Show(" Победил 1 Игрок(X)") ;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                        bot[i, j].Text = "";
                        bot[i, j].Enabled = true;
                        Playere = 0;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                    }
                    }
                a++;
            }
            else if(Playere==1)
            {
                MessageBox.Show(" Победил 2 Игрок(O)") ;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                        bot[i, j].Text = "";
                        bot[i, j].Enabled = true;
                        Playere = 1;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                    }
                    }
                b++;
            }
            
            
            
        }

        private void nichia()
        {
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                   
                   
                    bot[i, j].Text = "";
                    bot[i, j].Enabled = true;
                    Playere = 1;

                }
            }
        }

    }    
}
    

