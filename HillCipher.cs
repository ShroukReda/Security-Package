using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    /// <summary>
    /// The List<int> is row based. Which means that the key is given in row based manner.
    /// </summary>
    public class HillCipher : ICryptographicTechnique<List<int>, List<int>>
    {
        public List<int> inverse(List<int> key)
        {
            List<decimal> keyinv = new List<decimal>();
            decimal det;

            if (key.Count() == 9)
            {
                det = key[0] * ((key[4] * key[8]) - (key[5] * key[7]));
                det = det - key[1] * ((key[3] * key[8]) - (key[5] * key[6]));
                det = det + key[2] * ((key[3] * key[7]) - (key[4] * key[6]));
                det = det % 26;
            }
            else
            {
                det = (key[0] * key[3]) - (key[1] * key[2]);
                det = det % 26;
            }



            if (key.Count() == 9)
            {
                while (det < 0)
                {
                    det += 26;
                }
            }
            decimal z = -1;
            if (key.Count() == 9)
            {

                det = det % 26;
                for (int i = 1; i < 26; i++)
                {
                    if ((det * i) % 26 == 1)
                    {
                        z = i;
                        break;
                    }
                }
            }

            if ((z <= 0 & key.Count() == 9) || det == 0 || det % 2 == 0)
                throw new InvalidAnlysisException();

            if (key.Count() == 9)
            {
                decimal num;
                //1
                num = z * 1 * ((key[4] * key[8]) - (key[5] * key[7]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //2
                num = z * -1 * ((key[3] * key[8]) - (key[5] * key[6]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //3
                num = z * 1 * ((key[3] * key[7]) - (key[4] * key[6]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //4
                num = z * -1 * ((key[1] * key[8]) - (key[2] * key[7]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //5
                num = z * 1 * ((key[0] * key[8]) - (key[2] * key[6]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //6
                num = z * -1 * ((key[0] * key[7]) - (key[1] * key[6]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //7
                num = z * 1 * ((key[1] * key[5]) - (key[2] * key[4]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //8
                num = z * -1 * ((key[0] * key[5]) - (key[2] * key[3]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);

                //9
                num = z * 1 * ((key[0] * key[4]) - (key[1] * key[3]));
                num = num % 26;
                while (num < 0)
                {
                    num += 26;
                }
                keyinv.Add(num);
                key[0] = (int)keyinv[0];
                key[1] = (int)keyinv[3];
                key[2] = (int)keyinv[6];
                key[3] = (int)keyinv[1];
                key[4] = (int)keyinv[4];
                key[5] = (int)keyinv[7];
                key[6] = (int)keyinv[2];
                key[7] = (int)keyinv[5];
                key[8] = (int)keyinv[8];

            }

            else if (key.Count() == 4)
            {

                decimal m = key[3] * (1 / det);
                m = m % 26;
                keyinv.Add(m);

                m = -1 * key[1] * (1 / det);
                m = m % 26;
                keyinv.Add(m);

                m = -1 * key[2] * (1 / det);
                m = m % 26;
                keyinv.Add(m);

                m = key[0] * (1 / det);
                m = m % 26;
                keyinv.Add(m);


                key[0] = ((int)keyinv[0]) % 26;
                key[1] = ((int)keyinv[1]) % 26;
                key[2] = ((int)keyinv[2]) % 26;
                key[3] = ((int)keyinv[3]) % 26;


            }


            return key;
            //  throw new NotImplementedException();

        }

        public List<int> transpose(List<int> n)
        {
            List<int> cipherText = new List<int>();
            cipherText.Add(n[0]);
            cipherText.Add(n[3]);
            cipherText.Add(n[6]);
            cipherText.Add(n[1]);
            cipherText.Add(n[4]);
            cipherText.Add(n[7]);
            cipherText.Add(n[2]);
            cipherText.Add(n[5]);
            cipherText.Add(n[8]);

            return cipherText;
        }

        public int getb(int g)
        {
            int y = 0;

            for (int k = 1; k < 26; k++)
            {
                if ((g * k) % 26 == 1)
                {
                    y = k;
                    break;
                }
            }

            return y;
        }
        public List<int> Analyse(List<int> plainText, List<int> cipherText)
        {
            List<int> n = new List<int>();
            List<float> keyinv = new List<float>();
            List<int> key = new List<int>();
            List<int> key1 = new List<int>();
            //throw new NotImplementedException();
            if (plainText.Count() == 4)
                plainText = inverse(plainText);
            else
            {
                for (int i = 0; i < 9; i += 2)
                {

                    for (int j = i + 2; j < 12; j += 2)
                    {
                        keyinv = new List<float>();
                        key = new List<int>();

                        key.Add(plainText[i]);
                        key.Add(plainText[i + 1]);
                        key.Add(plainText[j]);
                        key.Add(plainText[j + 1]);

                        float det;
                        det = (key[0] * key[3]) - (key[1] * key[2]);

                        det = det % 26;

                        int y = getb((int)det);

                        if (y != 0)
                        {
                            int m = key[3];
                            keyinv.Add(m % 26);

                            m = -1 * key[1];
                            keyinv.Add(m % 26);

                            m = -1 * key[2];
                            keyinv.Add(m % 26);

                            m = key[0];
                            keyinv.Add(m % 26);

                            key[0] = (int)(y * keyinv[0]) % 26;
                            key[1] = (int)(y * keyinv[1]) % 26;
                            key[2] = (int)(y * keyinv[2]) % 26;
                            key[3] = (int)(y * keyinv[3]) % 26;

                            keyinv = new List<float>();

                            key1.Add(cipherText[i]);
                            key1.Add(cipherText[j]);
                            key1.Add(cipherText[i + 1]);
                            key1.Add(cipherText[j + 1]);


                            n = Encrypt(key, key1);
                            int gg = n[1];
                            n[1] = n[2];
                            n[2] = gg;



                        }
                    }
                }

            }

            return n;
        }


        public List<int> Decrypt(List<int> cipherText, List<int> key)
        {
            List<int> Encrypt1 = new List<int>();

            key = inverse(key);

            Encrypt1 = Encrypt(cipherText, key);

            return Encrypt1;
        }


        public List<int> Encrypt(List<int> plainText, List<int> key)
        {
            List<int> decrypt = new List<int>();
            int lenkey = (int)Math.Sqrt(key.Count());
            int lenPT = (int)plainText.Count() / lenkey;
            int indexpt = 0;
            int indexkey = 0;
            int sum = 0;
            for (int i = 0; i < lenPT; i++)
            {
                indexpt = i * lenkey;
                for (int j = 0; j < lenkey; j++)
                {
                    for (int k = 0; k < lenkey; k++)
                    {
                        sum = sum + (plainText[indexpt] * key[indexkey]);
                        indexkey++;
                        indexpt++;
                    }
                    indexpt = indexpt - lenkey;
                    sum = sum % 26;
                    while (sum < 0)
                    {
                        sum += 26;
                    }
                    decrypt.Add(sum);
                    sum = 0;
                }

                if (indexkey == key.Count())
                    indexkey = 0;

            }


            return decrypt;

        }


        public List<int> Analyse3By3Key(List<int> plainText, List<int> cipherText)
        {
            // throw new NotImplementedException();
            plainText = inverse(plainText);

            List<int> n = new List<int>();

            n = transpose(cipherText);

            n = Encrypt(plainText, n);

            cipherText = transpose(n);

            return cipherText;
        }

    }
}
