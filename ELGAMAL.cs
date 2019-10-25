using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.ElGamal
{
    public class ElGamal
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
        public static int GetMultiplicativeInverse(int number, int baseN)
        {
            int Q = 0, Result = 0, A1 = 1, A2 = 0, A3, B1 = 0, B2 = 1, B3, A1P, A2P, A3P, B1P, B2P, B3P;
            B3 = number;
            A3 = baseN;
            while ((B3 != 0) && (B3 != 1))
            {
                A1P = A1;
                A2P = A2;
                A3P = A3;
                B1P = B1;
                B2P = B2;
                B3P = B3;
                A1 = B1P;
                A2 = B2P;
                A3 = B3P;
                B1 = A1P - (Q * B1P);
                B2 = A2P - (Q * B2P);
                B3 = A3P - (Q * B3P);
                if (B3 == 0)
                {
                    Result = -1;
                    break;
                }
                else if (B3 == 1)
                {
                    if (B2 < baseN && B2 > 0)
                    {
                        Result = B2;
                        break;
                    }
                    else
                    {
                        while (B2 < 0)
                        {
                            B2 += baseN;
                        }
                        Result = B2;
                        break;
                    }
                }
                Q = A3 / B3;

            }
            return Result;
        }
        /// <summary>
        /// Encryption
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="q"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        /// <returns>list[0] = C1, List[1] = C2</returns>
        public List<long> Encrypt(int q, int alpha, int y, int k, int m)
        {
            long K, C1, C2;
            List<long> L = new List<long>();
            K = Power(y, k, q);
            C1 = Power(alpha, k, q);
            C2 = (K * m) % q;
            L.Add(C1);
            L.Add(C2);
            return L;

        }
        public int Decrypt(int c1, int c2, int x, int q)
        {
            int K, KN, M;
            K = Power(c1, x, q);
            KN = GetMultiplicativeInverse(K, q);
            M = (c2 * KN) % q;
            return M;
        }

    }
}
