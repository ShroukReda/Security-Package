using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.AES
{
    public class ExtendedEuclid
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="baseN"></param>
        /// <returns>Mul inverse, -1 if no inv</returns>
        public int GetMultiplicativeInverse(int number, int baseN)
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
    }
}
