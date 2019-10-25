using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class AutokeyVigenere : ICryptographicTechnique<string, string>
    {
        public char[,] Vigenere()
        {
            char[,] vigenere = new char[27, 27];
            char c = 'A';
            char c2 = 'A';
            char z1 = 'a';
            char z2 = 'a';
            int x = 0;
            for (int i = 0; i < 27; i++)
            {
                if (x > 1)
                {
                    c2++;
                    c = c2;
                }
                for (int j = 0; j < 27; j++)
                {
                    if (j == 0 && i == 0)
                    {
                        vigenere[i, j] = ' ';
                    }
                    else if (i == 0)
                    {
                        vigenere[i, j] = z1;
                        z1++;
                    }
                    else if (j == 0)
                    {
                        vigenere[i, j] = z2;
                        z2++;
                    }

                    else
                    {
                        //c2++;
                        if (c >= 'A' && c <= 'Z')
                        {
                            vigenere[i, j] = c;
                            c++;
                        }
                        else
                        {
                            c = 'A';
                            vigenere[i, j] = c;
                            c++;
                        }

                    }

                }
                x++;
            }
            return vigenere;
        }
        public string Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();
            char[,] vigenere = Vigenere();
                 string key_stream = "";
            int p_index = 0;
            int c_index = 0;
            string key = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                char t = cipherText[i];
                char p = plainText[i];
                for (int j = 0; j < 27; j++)
                {
                    if (vigenere[j, 0] == p)
                    {
                        p_index = j;
                        break;
                    }
                }
                for (int j = 0; j < 27; j++)
                {
                    if (vigenere[p_index, j] == t)
                    {
                        c_index = j;
                        break;
                    }
                }
                key_stream += vigenere[0, c_index];
            }
            int q = 0;
            int q2 = 0;
            string e = "";
            for (int i = 0; i < key_stream.Length; i++)
            {
                if (key.Length > 0)
                {
                    if (q > plainText.Length - 1)
                    { 
                        e = "";
                        q = 0;
                    }
                    if (key_stream[i] != plainText[q])
                    {
                        if (e.Length > 0)
                        {
                            key += e;
                            key += key_stream[i];
                            e = "";
                            q = 0;
                        }
                        else
                        {
                            key += key_stream[i];
                        }

                    }
                    else
                    {
                        e += key_stream[i];
                        q++;
                    }
                }
                else
                {
                    key += key_stream[i];
                }
            }
            return(key);
        
        }

        public string Decrypt(string cipherText, string key)
        {
            char[,] vigenere = Vigenere();
               string key_stream = "";
            key_stream = key;
            int c_index = 0;
            int k_index = 0;
            string plain_text = "";
            string ci = cipherText.ToLower();
            int m = 0;
            int index = 0;
            while (key_stream.Length < cipherText.Length)
            {
                for (int i = index; i < key_stream.Length; i++)
                {
                    char t = cipherText[i];
                    char k = key_stream[i];
                    for (int j = 0; j < 27; j++)
                    {
                        if (vigenere[j, 0] == k)
                        {
                            k_index = j;
                            break;
                        }
                    }
                    for (int j = 0; j < 27; j++)
                    {
                        if (vigenere[k_index, j] == t)
                        {
                            c_index = j;
                            break;
                        }
                    }
                    plain_text += vigenere[0, c_index];
                }
                index = key_stream.Length;
               // m = 0;
                while (m < plain_text.Length && key_stream.Length < cipherText.Length)
                {
                    char p = plain_text[m];
                    key_stream += p;
                    m++;
                }
                               
            }
            for (int i = index; i < key_stream.Length; i++)
            {
                char t = cipherText[i];
                char k = key_stream[i];
                for (int j = 0; j < 27; j++)
                {
                    if (vigenere[j, 0] == k)
                    {
                        k_index = j;
                        break;
                    }
                }
                for (int j = 0; j < 27; j++)
                {
                    if (vigenere[k_index, j] == t)
                    {
                        c_index = j;
                        break;
                    }
                }
                plain_text += vigenere[0, c_index];
            }
           return plain_text;
        }

        public string Encrypt(string plainText, string key)
        {
            char[,] vigenere = Vigenere();
            string key_stream = "";
            key_stream = key;
            int p_index = 0;
            int k_index = 0;
            string cipher_text = "";
            int m = 0;
            for (int i = 0; i < plainText.Length - key.Length; i++)
            {
                if (m == plainText.Length)
                {
                    m = 0;
                    char p = plainText[m];
                    key_stream += p;
                    m++;
                }
                else
                {
                    char p = plainText[m];
                    key_stream += p;
                    m++;
                }
            }
            for (int i = 0; i < key_stream.Length; i++)
            {
                char t = plainText[i];
                char k = key_stream[i];
                for (int j = 0; j < 27; j++)
                {
                    if (vigenere[0, j] == t)
                    {
                        p_index = j;
                    }
                    if (vigenere[j, 0] == k)
                    {
                        k_index = j;
                    }
                }
                cipher_text += vigenere[k_index, p_index];
            }

            return(cipher_text);
        }
        
    }
}
