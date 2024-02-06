using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace WindowsFormsApp2
{
    public partial class TextEdit : Form
    {
        public TextEdit()
        {
            InitializeComponent();
            this.Size = new Size(638, 552);
            textBox1.Location = new Point(0, 26);
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
       
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ColorDialog nn = new ColorDialog();
            if (nn.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = nn.Color;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FontDialog schrift = new FontDialog();
            if (schrift.ShowDialog() == DialogResult.OK)
                textBox1.Font = schrift.Font;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var Content = string.Empty;//содержимое файла
                                       // var way = string.Empty;//путь
            OpenFileDialog Ofile = new OpenFileDialog();
            
                //fileDial.InitialDirectory = "c:\\";
                Ofile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                
                //fileDial.RestoreDirectory = true;

                if (Ofile.ShowDialog() == DialogResult.OK)
                {
                    //получаем путь  к файлу
                    //way = fileDial.FileName;

                    //открывем поток для чтений файла 
                    var fileStream = Ofile.OpenFile();

                    StreamReader reader = new StreamReader(fileStream);
                    
                        Content = reader.ReadToEnd();
                
                    textBox1.Text =Content;
                }
            

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog Sfile = new SaveFileDialog();
            //string name=Sfile.FileName;
          // Sfile.FilterIndex = 2;
            Sfile.FileName = "Text_";
            Sfile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            Sfile.ShowDialog();
            File.WriteAllText(Sfile.FileName, textBox1.Text);

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void TextEdit_Shown(object sender, EventArgs e)
        {
            //numericUpDown1.Value = dl.dlina ;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            Find Ravno = new Find();
            Ravno.dlina = (int)numericUpDown2.Value;
            Ravno.FindR(textBox1.Text);
           

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Find dl = new Find();
            dl.dlina =(int) numericUpDown1.Value;
            dl.FindB(textBox1.Text);
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Find vst = new Find();
            vst.vstavka(textBox1.Text);
        }
    }
}
