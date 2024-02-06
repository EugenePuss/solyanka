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
    public partial class Form1 : Form
    {
        bool peremennaia = false;
        public Form1()
        {
            InitializeComponent();
            //Process.Start("Ссылка ");
            ClientSize = new Size(725, 508);
            pictureBox1.Refresh();
            pictureBox1.Size = new Size(725, 508);
            //||||||||||||||||||||||||||||||||||||||||||||||

            // Process.Start(@"E:\RSA\Laba_5\bin\Debug\Laba_5.exe");

            //|||||||||||||||||||||||||||||||||||||||||||||||||||||
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.Show();
        }

        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
        }

        private void лб2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEdit TEd = new TextEdit ();
            TEd.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
        void bottons()
        {
            
            foreach (var item in this.Controls)
            {
                var bout = item as Button; 
                //tollitem.ForeColor = gg.Color;
                if (bout != null&&peremennaia==false)
                {
                    bout.ForeColor = gg.Color;
                    
                }
                if (bout!= null&&peremennaia == true)
                {
                    bout.BackColor = gg.Color;
                    
                }
            }
        }
        void tool(ToolStripItemCollection element)
        {

                foreach (ToolStripItem item in element)
                {
                    ToolStripDropDownItem menu = item as ToolStripDropDownItem;
                    //var meny = item as ToolStripMenuItem;
                    if (menu != null&&peremennaia==false)
                    {

                    item.ForeColor = gg.Color;
                        tool(menu.DropDownItems);
                    }
                    if (menu != null&&peremennaia == true)
                    {
                    item.BackColor = gg.Color;
                    tool(menu.DropDownItems);
                }
                }
            
        }
        ColorDialog gg = new ColorDialog();
        private void cvet()
        {
            
            //comboBox1_SelectedIndexChanged(selectedItem, e);
            
            if (gg.ShowDialog() == DialogResult.OK)
            {
                comboBox1.ForeColor = gg.Color;

                tool(MainMenuStrip.Items);
                bottons();

                //button1.ForeColor = gg.Color;
                //button2.ForeColor = gg.Color;
                //toolStripMenuItem1.ForeColor = gg.Color;

            }
        }
        private void cvetf()
        {

            //comboBox1_SelectedIndexChanged(selectedItem, e);

            if (gg.ShowDialog() == DialogResult.OK)
            {
                comboBox1.BackColor = gg.Color;
                menuStrip.BackColor = gg.Color;
                tool(MainMenuStrip.Items);
                bottons();
                this.BackColor = gg.Color;
                peremennaia = false;
                //button1.ForeColor = gg.Color;
                //button2.ForeColor = gg.Color;
                //toolStripMenuItem1.ForeColor = gg.Color;

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            peremennaia = false;
            cvet();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            int selectedIndex = comboBox1.SelectedIndex;
            //Object selectedItem = comboBox1.SelectedItem;
            
            //MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" +
            //"Index: " + selectedIndex.ToString());
            switch (selectedIndex)
            {
                case 0:
                    panel1.Visible = !panel1.Visible;
                    break;
                case 1:
                    Form5 newForm5 = new Form5();
                    newForm5.Show();
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            peremennaia = true;
            cvetf();
        }
        Image[] fon = new Image[] { Properties.Resources.травка, Properties.Resources.Джейк2 };
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox2.SelectedIndex;
            

            
            switch (selectedIndex)
            {
                case 0:
                    
                    pictureBox1.Image = fon[0];
                    this.BackColor = Color.Black;
                    break;
                case 1:
                    pictureBox1.Image = fon[1];
                    
                    break;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofile = new OpenFileDialog();

            
            Ofile.Filter = "Файлы изображений (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (Ofile.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(Ofile.FileName);

                


            }
        }

        private void лб3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kalculator newk = new kalculator();
            newk.Show();
        }

        private void лб4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            news n = new news();
            n.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void лб5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rsa form = new Rsa();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void лб6ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}
