using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.DiffieHellman
{
    public class DiffieHellman 
    {
        public static int Power(int Base, int exponent, int q)
        {
            if (exponent == 1)
            {
                return Base;
            }
            else if (exponent == 0)
            {
                return 1;
            }
            else
            {
                return Base * Power(Base, exponent - 1, q) % q;
            }
        }
        public List<int> GetKeys(int q, int alpha, int xa, int xb)
        {
            int ya = Power(alpha, xa, q);
            int yb = Power(alpha, xb, q);
            List<int> res = new List<int>();
            int k1 = Power(yb, xa, q);
            res.Add(k1);
            int k2 = Power(ya, xb, q);
            res.Add(k2);
            return res;
        }
    }
}
