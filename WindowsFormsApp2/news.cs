using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class news : Form
    {
      
        Random rand = new Random();
        testirovschik element = new testirovschik();
        int kolvo_testov=10;
        int Verno_rescheno;
        int Recheno;

        int k;
       
        public news()
        {
            InitializeComponent();
            
            label1.Text = element.Primer();
            pictureBox1.SendToBack();

            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox1.Refresh();
            label2.Text = "Решено " + Recheno + " из " + kolvo_testov;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            Shkala.Refresh();
             k = rand.Next(2, 5);
           
            Knopki(k);
           
        }
       
        string raschet = "";
        Button[] bot = { };
        int Knopka_s_otvetom;
        private void Knopki(int t)
        {

            Array.Resize(ref bot, t);
           
            Knopka_s_otvetom = rand.Next(0, bot.Length);

            //GraphicsPath bt = new GraphicsPath();
            //bt.AddEllipse(0, 0, 150, 40);
             for (int i = 0; i < t; i++)
             {
                 bot[i] = new Button();
                 bot[i].Visible = true;
                 switch (t)
                 {
                    case 2:
                       bot[i].Size = new Size(247, 49);
                       bot[i].Location = new Point(31 + 302 * i, 160);
                       break;
                    case 3:
                       bot[i].Size = new Size(150, 49);
                       bot[i].Location = new Point(31 + 200 * i, 160);
                       break;
                    case 4:
                       bot[i].Size = new Size(131, 49);
                       bot[i].Location = new Point(20 + 150 * i, 160);
                       break;
                 }
                 //bot[i].Region = new Region(bt);
                 bot[i].BackColor = Color.SteelBlue;
                 bot[i].FlatStyle = FlatStyle.Popup;
                 bot[i].Font = new Font("Microsoft Sans Serif", 28);
                 bot[i].Click += button1_Click;
                 bot[i].Text = rand.Next(0, 200).ToString();
               
                 this.Controls.Add(bot[i]);
             }

            ////
            ////
            ///
            
             raschet = Convert.ToString(element.ras);
            Button_otvet(bot);
          
            
        }
       private void Button_otvet(Button[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Text ==raschet)
                {
                    b[i].Text = raschet;
                }
                else bot[Knopka_s_otvetom].Text = raschet;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {


            base.OnPaint(e);
            

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            string txt = (sender as Button).Text;
          
            //
                PictureBox Shkala = new PictureBox();
                Shkala.Location = new Point(this.Size.Width / kolvo_testov * Recheno, 404);
                Shkala.Size = new Size(this.Size.Width/kolvo_testov, 40);
           
            Recheno++;
            label2.Text = "Решено " + Recheno + " из " + kolvo_testov;
            this.Controls.Add(Shkala);
                Shkala.Refresh();
                Shkala.BringToFront();
            if (txt == raschet)
            {
                Shkala.BackColor = Color.LimeGreen;
                Verno_rescheno++;

            }
            else
            {
                Shkala.BackColor = Color.Brown;

            }
            if (Recheno == kolvo_testov)
            {
                panel1.Visible = true;
                button3.Text = "Еще раз ";
                //
                panel1.BackgroundImageLayout = ImageLayout.Center;
              //
                label4.Text = Ocenka();
                label4.BackColor = Color.FromArgb(0, 0, 0, 0);

               
            }

                for (int i = 0; i < bot.Length; i++)
                {
                    bot[i].Dispose();
                }

                label1.Text = element.Clear_Stoka();
                
                k = rand.Next(2, 5);
                //
                Knopki(k);
                news_Load(sender, e);
            
           
        }
        string ocen = "";
        private string Ocenka()
        {
            if (Verno_rescheno*100 / kolvo_testov >= 80)
            {
                panel1.BackgroundImage = new Bitmap(Properties.Resources.оценка51);
                return ocen = "Спасибо за прохождение теста:) \n Ваша оценка: "+ 5 + " Верно решено: " + Verno_rescheno + "из" + kolvo_testov;
            }
            else if (Verno_rescheno* 100 / kolvo_testov  < 80 && Verno_rescheno * 100 / kolvo_testov >= 50)
            {
                panel1.BackgroundImage = new Bitmap(Properties.Resources.оценка41);
                return ocen = "Спасибо за прохождение теста:) \n Ваша оценка: " + 4 + " Верно решено: " + Verno_rescheno + "из" + kolvo_testov;
            }
            else if (Verno_rescheno* 100  / kolvo_testov < 50 && Verno_rescheno * 100 / kolvo_testov >30)
            {
                panel1.BackgroundImage = new Bitmap(Properties.Resources.оценка31);
                return ocen = "Спасибо за прохождение теста:) \n Ваша оценка: " + 3 + " Верно решено: " + Verno_rescheno + "из" + kolvo_testov;
            }
            else 
            {
                panel1.BackgroundImage = new Bitmap(Properties.Resources.оценка21);
                return ocen = "Спасибо за прохождение теста:) \n Ваша оценка: " + 2 + "\n Верно решено: " + Verno_rescheno + "из" + kolvo_testov;
            }
        }
        private void news_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < bot.Length; i++)
            {
                bot[i].BringToFront();
            }
            Shkala.BringToFront();
            kolvo_testov = Convert.ToInt32(numericUpDown1.Value);
            
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            kolvo_testov = Convert.ToInt32(numericUpDown1.Value);
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            kolvo_testov = Convert.ToInt32(numericUpDown1.Value);
            Recheno = 0;
            ocen = "";
            Verno_rescheno = 0;
            foreach (var item in Controls)
            {
                var pic = item as PictureBox;
                if (pic!=null)
                {
                    pic.BackColor = Color.FromArgb(0, 0, 0, 0);
                   
                }
                
                //

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BringToFront();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
