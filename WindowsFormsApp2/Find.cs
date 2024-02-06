using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;

namespace WindowsFormsApp2
{
    class Find
    {
        public int dlina=0;
        
        
        
        public void FindB(string text)
        {
            
            string baza = "";
            int kolvo = 0;
            string[] vp = new string[] { };
            TextBox h = new TextBox();
            //MessageBoxButtons copy = MessageB
            vp = text.Split(' ', ',', '.', '!', ':', ';', '&', '?', '|', '#', '%', '\n','\r');
            foreach (var item in vp)
            {
                //Console.WriteLine(item);
                

                if (item.Length > dlina)
                {
                    baza += item+',';
                    kolvo++;
                    h.Text += baza;
                }
                
            }

            
            h.Visible = false;
           
            if (MessageBox.Show("Количесво слов больше этой длинны: " + kolvo + "\nЭти слова: " + baza, "", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                Clipboard.SetDataObject(h.SelectedText);
            }
            
            
            
        }
        public void FindR(string text)
        {
            string baza = "";
            int kolvo = 0;
            string[] vp = new string[] { };

            vp = text.Split(' ', ',', '.', '!', ':', ';', '&', '?', '|', '#', '%', '\n', '\r');
            foreach (var item in vp)
            {
                //Console.WriteLine(item);


                if (item.Length == dlina)
                {
                    baza += item + ',';
                    kolvo++;
                }
                if (item.Length == dlina&& dlina == 0)
                {
                    kolvo = 0;
                    baza = "";
                }
            }
            MessageBox.Show("Количесво слов этой длинны: " + kolvo + "\nЭти слова: " + baza);
        }
        public void vstavka(string text)
        {
            IDataObject obmen = Clipboard.GetDataObject();
            text = (String)obmen.GetData(DataFormats.Text);
        }

    }
}
