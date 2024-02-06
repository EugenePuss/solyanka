using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        byte vpr = 0;
       
        bool znach = false;
        int value;
        bool vivod = false;
        Random r = new Random();
        int g;
        
        public Form2()
        {
            InitializeComponent();
            
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0);
            

            //linkLabel1.DisabledLinkColor = Color.FromArgb(0, 0, 0, 0);
            Random Ran = new Random();
            ClientSize = new Size(530, 495);
            button1.BackColor = Color.FromArgb(0, 0, 0, 0);
            button2.BackColor = Color.FromArgb(0, 0, 0, 0);
            button3.BackColor = Color.FromArgb(0, 0, 0, 0);
            //linkLabel1.Location = new Point(0,0);
            linkLabel1.BringToFront();
            



        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(" text");

            
            for (int i = vpr; i < image.Length; i++)
            {
                pictureBox2.Image = image[i];
                vpr++;
                if (pictureBox2.Image == image[5])
                {
                    timer1.Start();
                    linkLabel1.BringToFront();
                    linkLabel1.Visible = true;

                    pictureBox2.Refresh();
                    
                }
                break;
            }

        }
        
        public Image[] image = new Image[6] { Properties.Resources._8м_1, Properties.Resources._8м_2, Properties.Resources._8м_3, Properties.Resources._8м_4, Properties.Resources._8м_5, Properties.Resources.поздравление };
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=LdPtgKli5GE ");
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gggh = e.Graphics;
           
            

        }
       
        private void linkLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (znach == false)
            {
                linkLabel1.Location = new Point(r.Next(0, this.Size.Width - button1.Width), r.Next(0, this.Size.Height - button1.Height));
            }
            /*
            if (znach == false)
            { 
                linkLabel1.Location = new Point(e.X+linkLabel1.Width,e.Y+linkLabel1.Height);
            }*/
            
            
        }

        
        
        private void timer1_Tick(object sender, EventArgs e )
        {
            /*g = r.Next(-2, 2);
            linkLabel1.Location = new Point(znach ? linkLabel1.Location.X + 1 : linkLabel1.Location.X - 1, znach ? linkLabel1.Location.Y + 1 : linkLabel1.Location.Y - 1);
            if (linkLabel1.Location.X == 0)
            {
                znach = true;
                linkLabel1.Location = new Point(znach ? linkLabel1.Location.X + g : linkLabel1.Location.X - g, znach ? linkLabel1.Location.Y  : linkLabel1.Location.Y );
            }
            else if (linkLabel1.Location.X == Size.Width - linkLabel1.Width)
            {
                znach = false;
                linkLabel1.Location = new Point(znach ? linkLabel1.Location.X + g : linkLabel1.Location.X - g, znach ? linkLabel1.Location.Y  : linkLabel1.Location.Y );
            }
            
            if (linkLabel1.Location.Y == 0)
            {
                znach = true;
                linkLabel1.Location = new Point(znach ? linkLabel1.Location.X  : linkLabel1.Location.X , znach ? linkLabel1.Location.Y + g : linkLabel1.Location.Y - g);
            }
            else if (linkLabel1.Location.Y == Size.Height - linkLabel1.Height)
            {
                znach = false;
                linkLabel1.Location = new Point(znach ? linkLabel1.Location.X  : linkLabel1.Location.X , znach ? linkLabel1.Location.Y + g : linkLabel1.Location.Y - g);
            }
           */
           




            //linkLabel1.Left = znach ? linkLabel1.Left + 2 : linkLabel1.Left - 2;
            value++;
            if (value == 900)
            {
                button3.Visible = true;
            }
            
            linkLabel1.LinkColor= Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            
            pictureBox1.Refresh();
           
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            znach = true;
            linkLabel1.Location = new Point(163, 210);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
