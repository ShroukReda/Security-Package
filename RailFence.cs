using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();
            int key = 1;
            string plain = "";
            int result;
            plain = Decrypt(cipherText, key);
            for (int i = 0; i < plainText.Count(); i++)
            {
                result = string.Compare(plain, plainText);
                if (result == 0)
                {
                    break;
                }
                else
                {
                    key++;
                    plain = Decrypt(cipherText, key);

                }
            }
            return key;
        }

        public string Decrypt(string cipherText, int key)
        {
            //throw new NotImplementedException();
            cipherText = cipherText.ToLower();
            string plaintext = "";
            int k = 0;
            int col = 0;
            int x = 0;
            int m = 0;
            if (cipherText.Count() % key == 0)
            {
                col = cipherText.Count() / key;
            }
            else
            {
                col = (cipherText.Count() / key) + 1;
                m = cipherText.Count() % key;
                x = m;
            }
            int[] count = new int[key];
            for (int i = 0; i < key; i++)
            {
                if (m > 0)
                {
                    count[i] = col;
                    m--;
                }
                else
                {
                    count[i] = col - x;
                }
            }
            char[,] matrix = new char[key, col];
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    if (k < cipherText.Count())
                    {
                        matrix[i, j] = cipherText[k];
                        k += 1;
                    }

                }
            }
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    plaintext += matrix[j, i].ToString();

                }

            }
            return plaintext;
        }

        public string Encrypt(string plainText, int key)
        {
         //   throw new NotImplementedException();
            int k = 0;
            int col = 0;
            plainText = plainText.ToUpper();
            string cipher = "";
            if (plainText.Count() % key == 0)
            {
                col = plainText.Count() / key;
            }
            else
            {
                col = (plainText.Count() / key) + 1;
            }

            char[,] matrix = new char[key, col];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    if (k < plainText.Count())
                    {
                        matrix[j, i] = plainText[k];
                        k += 1;
                    }

                }
            }
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    cipher += matrix[i, j].ToString();
                }

            }
            return cipher;
        
        }
    }
}
