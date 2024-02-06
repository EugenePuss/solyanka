using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApp2
{
    class testirovschik
    {
        public testirovschik()
        {

        }
        private int kolvo_operac;
        public int kolvo_otvetov;
       
        private string operac = "+-*/";
        Random rand = new Random();
        StringBuilder s1 = new StringBuilder();


        private string operacia()
        {
            s1.Clear();
            s1.Append(operac[rand.Next(0, operac.Length)]);
            return s1.ToString();
        }
        string vivoid = "";
        string[] vb = { };
        string a = "";
        int ch1;
        public int ras;
       
        public string Primer()
        {
            kolvo_operac = rand.Next(1, 4);
            kolvo_otvetov = rand.Next(2, 5);
            for (int i = 0; i < kolvo_operac; i++)
            {

                a = operacia();
                ch1 = rand.Next(21);
                Array.Resize(ref vb, vb.Length + 1);
                vb[vb.Length - 1] += ch1;
                Array.Resize(ref vb, vb.Length + 1);
                vb[vb.Length - 1] += a;
            }
            ch1 = rand.Next(21);
            Array.Resize(ref vb, vb.Length + 1);
            vb[vb.Length - 1] += ch1;

            
            Proverka(vb);
            vivoid = "";
            foreach (var item in vb)
            {
                vivoid += item;
            }
            //
            ras = Convert.ToInt32(raschet());
            if (ras < 0 )
            {
                Clear_Stoka();

            }

            return vivoid;
        }
        public string Clear_Stoka()
        {
            a = "";
            ch1 = 0;
            vivoid = "";
            
            Array.Clear(vb, 0, vb.Length);
            vb = new string[0];
            return Primer();
        }

        private void Proverka(string[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] != null)
                {
                    if (mas[i] == "/")
                    {
                        if (Convert.ToInt32(mas[i + 1]) == 0)
                        {
                            mas[i + 1] = rand.Next(1, 21).ToString();
                        }
                        int ostatok = Convert.ToInt32(mas[i - 1]) % Convert.ToInt32(mas[i + 1]);
                        if (ostatok.ToString() != 0.ToString())
                        {
                            while (ostatok.ToString() != 0.ToString())
                            { 
                                mas[i + 1] = rand.Next(1, 20).ToString();
                                ostatok = Convert.ToInt32(mas[i - 1]) % Convert.ToInt32(mas[i + 1]);
                                
                            }
                            
                        }
                        if (mas[i + 1] != mas[mas.Length - 1])
                        {
                            if (mas[i] == "/" && mas[i + 2] == "/")
                            {
                                Clear_Stoka();
                                break;
                            }
                        }
                    }

                    else if (mas[i] == "-")
                    {
                        if (Convert.ToInt32(mas[i - 1]) < Convert.ToInt32(mas[i + 1]))
                        {
                            mas[i - 1] = rand.Next(Convert.ToInt32(mas[i + 1]), 21).ToString();
                        }
                    }
                    else if (mas[i] == "*")
                    {
                        if (mas[i + 1] != mas[mas.Length - 1])
                        {
                            if (mas[i] == "*" && mas[i + 2] == "*")
                            {
                                Clear_Stoka();
                                break;
                            }
                        }
                        if (Convert.ToInt32(mas[i - 1]) > 10 && Convert.ToInt32(mas[i + 1]) > 10)
                        {
                            mas[i - 1] = rand.Next(0, 10).ToString();
                        }
                    }
                }


            }

        }


        public string raschet()
        {
            kalk el = new kalk();
            return el.kk(vivoid);
        }

    }
}
