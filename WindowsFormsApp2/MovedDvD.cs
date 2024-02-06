using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    
        public class Operacia
        {
            public string operacia;
            public byte range;

            public Operacia(string operacia, byte range)
            {
                this.operacia = operacia;
                this.range = range;
            }
        }
    public class HranenenieOper
    {
        public static List<Operacia> Hran = new List<Operacia>();
        public void Dobavlenie(Operacia o)
        {
            Hran.Add(o);
        }
        public static Operacia Naiti(string s)
        {
            foreach (var item in Hran)
            {
                if (item.operacia == s)
                {
                    return item;
                }
            }
            return null;
        }
    
        internal static byte Naiti(object range)
        {
            throw new NotImplementedException();
        }
    }
}
