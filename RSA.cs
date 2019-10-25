using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.RSA
{
    public class RSA
    {
        public int Encrypt(int p, int q, int M, int e)
        {
            List<long> l = new List<long>();
            int x = p * q;
            long mm = 1;
            long k = 1;

            for (int i = 0; i < e; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    mm = mm % x;
                    l.Add(mm);
                    mm = 1;
                }
                mm = M * mm;
            }

            if (e % 3 != 0)
            {
                mm = mm % x;
                l.Add(mm);
            }

            for (int i = 0; i < l.Count(); i++)
            {
                l[i] = l[i] % x;
                k = k * l[i];
                k = k % x;
            }
            p = (int)(k % x);
            return p;
        }

        public int inv(int a, int n)
        {

            int i = n, v = 0, d = 1;
            while (a > 0)
            {
                int t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n; return v;
        }
        public int Decrypt(int p, int q, int C, int e)
        {
            List<long> l = new List<long>();
            int x = p * q;
            long mm = 1;
            int ll = (p - 1) * (q - 1);
            long k = 1;
            e = inv(e, ll);
            for (int i = 0; i < e; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    mm = mm % x;
                    l.Add(mm);
                    mm = 1;
                }
                mm = C * mm;
            }

            if (e % 3 != 0)
            {
                mm = mm % x;
                l.Add(mm);
            }

            for (int i = 0; i < l.Count(); i++)
            {
                l[i] = l[i] % x;
                k = k * l[i];
                k = k % x;
            }
            p = (int)(k % x);
            return p;
        }
    }
}
