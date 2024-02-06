using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Numerics;

namespace WindowsFormsApp2
{
    class RSA0_0
    {
        //

        public int p, q;//простые числа
        public int n;//модуль
        public int Function_E;// функция Эйлера
        public int Exp;// открытая экспонента
        public int d;// часть закрытого ключа
        Random rand = new Random();
        private int Generating_a_simple_number()
        {
            //
            int chislo = rand.Next(2, 40);
            bool Prostoe = Is_number_simple(chislo);
                
            if (Prostoe)
            {
                return chislo;
            }
            else return Generating_a_simple_number(); ;
           
        }
        //
        private bool Is_number_simple(int ch)
        {
            bool Simple = true;
            //
            for (int i = 2; i <= ch / 2; i++)
            {
                //
                if (ch % i == 0)
                {
                    Simple = false;

                }
                //
            }
            return Simple;

        }
        private int Create_E()
        {
            //
            int Exponent = rand.Next(2, Function_E);
            int Ost;
            Ost = Function_E % Exponent;
            
                if (Is_number_simple(Exponent) && Ost!=0)
                {
                    return Exponent;
                }
            else
            {
                while (!Is_number_simple(Exponent) && Ost != 0)
                {
                    //
                    Exponent = rand.Next(2, Function_E);
                    Ost = Function_E % Exponent;
                    //
                }
            }
            return Exponent;
            
            

        }
        //:D
        public void Generic_keys()
        {
            //
            q = Generating_a_simple_number();
            p = Generating_a_simple_number();
            n = p * q;
            Function_E = (p - 1) * (q - 1);
            Exp = Create_E();
            //
            d = Creat_d(Exp,Function_E);

            Get_d = (d * Exp) % Function_E;

        }
        public int Get_d;
        private int Creat_d(int e,int f)
        {
            //
            //int number_d = rand.Next(Exp, Function_E);
            
            for (int d = Exp; ; d++)
            {
                //
                if ((d*e)%f==1)
                {
                    return d;
                }
            }

        }
        public string Encrypt(string Message)
        {
            //
            
        
            string m = "";
            for (int i = 0; i < Message.Length; i++)
            {
                //m += (char)Convert.ToDecimal(Math.Pow(Message[i], Exp) % n);
                m += (char)(int)BigInteger.ModPow((int)Message[i], Exp, n);
            }
            return m;
           

        }
        public string Decrypt(string Encrypt_message)
        {
           
            string m = "";
            for (int i = 0; i < Encrypt_message.Length; i++)
            {
               // m +=(char) (decimal)Math.Pow(Encrypt_message[i], d) % n;
                m += (char)(int)BigInteger.ModPow((int)Encrypt_message[i], d, n);
            }
            return m;
        }
        public void Clear_resourse()
        {
            p = 0;
                q = 0;
                n = 0;
            Function_E = 0;
             Exp = 0;
                 d = 0;

        }

        
        

    }
}
