using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class kalk
    {
        private Stack<string> stack = new Stack<string>();
        private string vihodnaiaStroka = "";
        HranenenieOper element = new HranenenieOper();
        private string[] hranil = { };
        public string[] vihodstr = { };

        public kalk()
        {
            element.Dobavlenie(new Operacia("(", 1));
            element.Dobavlenie(new Operacia(")", 1));
            element.Dobavlenie(new Operacia("+", 2));
            element.Dobavlenie(new Operacia("-", 2));
            element.Dobavlenie(new Operacia("*", 3));
            element.Dobavlenie(new Operacia("/", 3));
            element.Dobavlenie(new Operacia("$", 4));// замена корню
            element.Dobavlenie(new Operacia("c", 5));//косинус
            element.Dobavlenie(new Operacia("s", 5));//синус
            element.Dobavlenie(new Operacia("t", 5));//тангенс
            element.Dobavlenie(new Operacia("k", 5));//котангенс
        }
        public string kk(string s)
        {
            Vivod(s);
            //
            //clears();
            return vihodnaiaStroka;
        }
        private string razdelenie(string s)
        {
            string vremper = "";
            foreach (var item in s)
            {
                if (Char.IsDigit(item))
                {
                    vremper += item;
                    continue;
                }
                else
                {
                    vremper += "|";
                    vremper += item;
                    vremper += "|";
                }
            }
            return vremper;
        }
        public string Opz = "";
        bool bd = false;
        private string Vivod(string s)
        {
            s.Trim();
            string data = s.Replace(" ", null).Replace("sin", "s").Replace("cos", "c").Replace("tg", "t").Replace("ctg", "k");

            vihodnaiaStroka = razdelenie(data).Replace("||", "|");

            hranil = vihodnaiaStroka.Split('|');

            for (int i = 0; i < hranil.Length; i++)
            {
                bd = int.TryParse(hranil[i], out int n);

                if (bd)
                {
                    Array.Resize(ref vihodstr, vihodstr.Length + 1);
                    vihodstr[vihodstr.Length - 1] += hranil[i];
                    continue;
                }
                else
                {
                    if (hranil[i] == "")
                    {
                        continue;
                    }
                    if (stack.Count == 0)
                    {
                        stack.Push(hranil[i]);

                        continue;
                    }
                    if (hranil[i] == "(")
                    {

                        stack.Push(hranil[i]);

                        continue;
                    }
                    if (hranil[i] == ")")
                    {

                        while (stack.Peek() != "(")
                        {
                            Array.Resize(ref vihodstr, vihodstr.Length + 1);
                            vihodstr[vihodstr.Length - 1] += stack.Pop();

                        }
                        stack.Pop();

                        continue;
                    }
                    if (stack.Count != 0)
                    {

                        if (HranenenieOper.Naiti(stack.Peek()).range < HranenenieOper.Naiti(hranil[i]).range)
                        {

                            stack.Push(hranil[i]);

                            continue;

                        }

                        else
                        {

                            if (stack.Count != 0)
                            {
                                try
                                {
                                    while (HranenenieOper.Naiti(stack.Peek()).range >= HranenenieOper.Naiti(hranil[i]).range)
                                    {
                                        Array.Resize(ref vihodstr, vihodstr.Length + 1);
                                        vihodstr[vihodstr.Length - 1] += stack.Pop();


                                    }
                                }
                                catch { }
                                if (stack.Count == 0)
                                {
                                    stack.Push(hranil[i]);

                                    continue;
                                }
                                else
                                {
                                    if (HranenenieOper.Naiti(stack.Peek()).range < HranenenieOper.Naiti(hranil[i]).range)
                                    {

                                        stack.Push(hranil[i]);

                                        continue;
                                    }
                                }
                            }

                        }
                    }

                }

            }
            while (stack.Count != 0)
            {
                Array.Resize(ref vihodstr, vihodstr.Length + 1);
                vihodstr[vihodstr.Length - 1] += stack.Pop();

            }

            Opz = string.Join("", vihodstr);
            data = "";
            stack.Clear();
            for (int i = 0; i < vihodstr.Length; i++)
            {
                bd = int.TryParse(vihodstr[i], out int n);
                if (bd)
                {
                    stack.Push(vihodstr[i]);

                }
                else
                {
                    deistvie(vihodstr[i]);
                }
            }
            if (stack.Count != 0)
            {
                vihodnaiaStroka = Convert.ToString(stack.Peek());
            }

            return vihodnaiaStroka;
        }


        private void deistvie(string s)
        {
            int a, b;
            string stroka;
            switch (s)
            {
                case "+":
                    a = Convert.ToInt32(stack.Pop());
                    b = Convert.ToInt32(stack.Pop());
                    stroka = Convert.ToString(b + a);
                    stack.Push(stroka);
                    break;
                case "-":
                    a = Convert.ToInt32(stack.Pop());
                    b = Convert.ToInt32(stack.Pop());

                    stroka = Convert.ToString(b - a);
                    stack.Push(stroka);
                    break;
                case "*":
                    a = Convert.ToInt32(stack.Pop());
                    b = Convert.ToInt32(stack.Pop());
                    stroka = Convert.ToString(b * a);
                    stack.Push(stroka);
                    break;
                case "/":

                    a = Convert.ToInt32(stack.Pop());
                    b = Convert.ToInt32(stack.Pop());

                    if (a != 0)
                    {
                        stroka = Convert.ToString(b / a);
                        stack.Push(stroka);
                    }
                    break;
                case "$":
                    a = Convert.ToInt32(stack.Pop());
                    if (a >= 0)
                    {
                        stroka = Convert.ToString(Math.Sqrt(a));
                        stack.Push(stroka);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка.(Подкоренное выражение не может быть отрицательным)");
                    }
                    break;
                case "s":
                    a = Convert.ToInt32(stack.Pop());

                    stroka = Convert.ToString(Math.Sin(a));
                    stack.Push(stroka);
                    break;
                case "c":
                    a = Convert.ToInt32(stack.Pop());

                    stroka = Convert.ToString(Math.Cos(a));
                    stack.Push(stroka);
                    break;
                case "t":
                    a = Convert.ToInt32(stack.Pop());
                    if (a == 90 && a == 270)
                    {
                        MessageBox.Show("Ошибка.Такого тангенса не существует");
                    }
                    else
                    {
                        stroka = Convert.ToString(1 / Math.Tan(a));
                        stack.Push(stroka);

                    }
                    break;
                case "k":
                    a = Convert.ToInt32(stack.Pop());
                    if (a == 0 && a == 180 && a == 360)
                    {
                        MessageBox.Show("Ошибка.Такого котангенса не существует");
                    }
                    else
                    {
                        stroka = Convert.ToString(1 / Math.Tan(a));
                        stack.Push(stroka);

                    }
                    break;


            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void clears()
        {
            stack.Clear();
            vihodnaiaStroka = "";

            for (int i = 0; i < hranil.Length; i++)
            {
                hranil[i] = "";

            }
            for (int i = 0; i < vihodstr.Length; i++)
            {
                vihodstr[i] = "";

            }
        }
    }
}
