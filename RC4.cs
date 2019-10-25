using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.RC4
{
    /// <summary>
    /// If the string starts with 0x.... then it's Hexadecimal not string
    /// </summary>
    public class RC4 : CryptographicTechnique
    {
        public override string Decrypt(string cipherText, string key)
        {
            int[] T = new int[256];
            int[] S = new int[256];
            int j = 0, k = 0, l = 0, len, t, c = 0;
            int temp;
            int Sub;
            int flag = 0;
            string pla="";
            string h = "0x";
            char check = cipherText[0];
            if (check.ToString() == "0")
            {
                cipherText = cipherText.Substring(2, cipherText.Length - 2);
                key = key.Substring(2, key.Length - 2);
                string c2 = "";
                string k2 = "";
                for (int i = 0; i < cipherText.Length; i += 2)
                {
                    c2 += (char)Int16.Parse(cipherText.Substring(i, 2), NumberStyles.AllowHexSpecifier);
                    k2 += (char)Int16.Parse(key.Substring(i, 2), NumberStyles.AllowHexSpecifier);
                }
                cipherText = c2;
                key = k2;
                flag = 1;

            }

            for (int i = 0; i <= 255; i++)
            {
                S[i] = (char)i;
                T[i] = key[i % key.Length];
            }
            for (int i = 0; i <= 255; i++)
            {
                j = (j + S[i] + T[i]) % 256;
                temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }
            len = cipherText.Length;
            char[] plain = new char[cipherText.Length];
            while (c < len)
            {
                k = (k + 1) % 256;
                l = (l + S[k]) % 256;
                temp = S[k];
                S[k] = S[l];
                S[l] = temp;
                t = (S[k] + S[l]) % 256;
                Sub = S[t];
                plain[c] = (char)(cipherText[c] ^ Sub);
                c++;
            }
            if (flag == 1)
            {
                byte[] plain_bytes = Encoding.Default.GetBytes(plain);
                pla += "0x";
                pla += BitConverter.ToString(plain_bytes);
                pla = pla.Replace("-", "");

            }
            else
            {
                pla = new string(plain);
            }
            return pla;
        }

        public override string Encrypt(string plainText, string key)
        {
            int[] T = new int[256];
            //char[] S = new char[256];
            int[] S = new int[256];
            int j = 0, k = 0, l = 0, len, t, c = 0;
            //char temp;
            //char Sub;
            int temp;
            int Sub;
            int flag = 0;
            string ciphe = "";
            string h = "0x";
            char check = plainText[0];

            if (check.ToString() == "0")
            {
                plainText = plainText.Substring(2, plainText.Length - 2);
                key = key.Substring(2, key.Length - 2);
                string p2 = "";
                string k2 = "";
                for (int i = 0; i < plainText.Length; i += 2)
                {
                    p2 += (char)Int16.Parse(plainText.Substring(i, 2), NumberStyles.AllowHexSpecifier);
                    k2 += (char)Int16.Parse(key.Substring(i, 2), NumberStyles.AllowHexSpecifier);
                }
                plainText = p2;
                key = k2;
                flag = 1;
            }

            for (int i = 0; i <= 255; i++)
            {
                //S[i] = (char)i;
                S[i] = i;
                T[i] = key[i % key.Length];
            }
            for (int i = 0; i <= 255; i++)
            {
                j = (j + S[i] + T[i]) % 256;
                temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }
            len = plainText.Length;
            char[] cipher = new char[plainText.Length];
            while (c < len)
            {
                k = (k + 1) % 256;
                l = (l + S[k]) % 256;
                temp = S[k];
                S[k] = S[l];
                S[l] = temp;
                t = (S[k] + S[l]) % 256;
                Sub = S[t];

                cipher[c] = (char)(plainText[c] ^ Sub);
                c++;
            }
            if (flag == 1)
            {
                byte[] cypher_bytes = Encoding.Default.GetBytes(cipher);
                ciphe += "0x";
                ciphe += BitConverter.ToString(cypher_bytes);
                ciphe = ciphe.Replace("-", "");

            }
            else
            {
                ciphe = new string(cipher);
            }
            return ciphe;
        }
    }
}
