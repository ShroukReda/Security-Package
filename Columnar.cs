using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Columnar : ICryptographicTechnique<string, List<int>>
    {
        public List<int> Analyse(string plainText, string cipherText)
        {
            plainText = plainText.ToUpper();
            cipherText = cipherText.ToUpper();
            List<string> Cols = new List<string>();
            List<int> key = new List<int>();
            char First = cipherText[0];
            char Second = cipherText[1];
            int ColNum = 0;
            int check = 0;
            int ElementsPerCol = 0;
            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] == First)
                {
                    int index = i;
                    if (plainText[i + 1] == First)
                    {
                        index = i + 1;
                    }
                    for (int j = index + 1; j < plainText.Length - index; j++)
                    {
                        if (plainText[j] == Second)
                        {
                            ColNum = j - index;
                            break;
                        }
                    }
                    break;
                }
            }
            if (plainText.Length % ColNum == 0)
            {
                ElementsPerCol = plainText.Length / ColNum;
            }
            else
            {
                int diff = plainText.Length;
                while (diff > 0)
                {
                    diff -= ColNum;
                    ElementsPerCol++;
                }
            }
            for (int i = 0; i < cipherText.Length; i += ElementsPerCol)
            {
                if (cipherText.Length - i >= ElementsPerCol)
                {
                    string Col = cipherText.Substring(i, ElementsPerCol);
                    Cols.Add(Col);
                }
                else
                {
                    check = 1;
                    for (int j = 0; j < ColNum; j++)
                    {
                        key.Add(j);
                    }
                }
            }
            int k = 0;
            int m = 0;
            int row = 0;
            int l = 0;
            if (plainText.Count() % ColNum == 0)
            {
                row = plainText.Count() / ColNum;
            }
            else
            {
                row = (plainText.Count() / ColNum) + 1;
                l = (row * ColNum) - plainText.Count();
                for (int a = 0; a < 3; a++)
                {
                    plainText += 'x';
                }

            }
            char[] cipher = new char[plainText.Count()];

            char[,] matrix = new char[row, ColNum];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < ColNum; j++)
                {
                    if (k < plainText.Count())
                    {
                        matrix[i, j] = plainText[k];
                        k += 1;
                    }

                }
            }
            int s = 0;
            for (int i = 0; i < ColNum; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    cipher[s] = matrix[j, i];
                    s++;
                }
            }
            string Sorted = new string(cipher);
            List<string> L = new List<string>();

            for (int i = 0; i < Sorted.Length; i += ElementsPerCol)
            {
                if (Sorted.Length - i >= ElementsPerCol)
                {
                    string Col = Sorted.Substring(i, ElementsPerCol);
                    L.Add(Col);
                }
                else
                {
                    break;
                }
            }

            if (check == 0)
            {
                for (int t = 0; t < L.Count; t++)
                {
                    for (int y = 0; y < Cols.Count; y++)
                    {
                        if (L[t] == Cols[y])
                        {
                            key.Add(y + 1);
                        }
                    }
                }
            }
            return key;
        }

        public string Decrypt(string cipherText, List<int> key)
        {
            // throw new NotImplementedException();
            string plaintext = "";
            int m = 0;
            int row = 0;
            cipherText = cipherText.ToLower();
            char[] cipher = new char[cipherText.Count()];

            if (cipherText.Count() % key.Count() == 0)
            {
                row = cipherText.Count() / key.Count();
            }
            else
            {
                row = (cipherText.Count() / key.Count()) + 1;
                m = cipherText.Count() % key.Count();

            }
            for (int i = 0; i < cipherText.Count(); i++)
            {
                cipher[i] += cipherText[i];
            }
            char[,] matrix = new char[row, key.Count()];
            int s = 0;
            int counter = (row * key.Count()) - cipherText.Count();

            int[] start = new int[key.Count()];
            int[] count = new int[key.Count()];
            int x = 0;
            for (int i = key.Count() - 1; i >= 0; i--)
            {
                x = key[i] - 1;
                if (counter > 0)
                {
                    count[x] = row - 1;
                    counter--;
                }
                else
                {
                    count[x] = row;
                }
            }
            start[0] = 0;
            for (int i = 1; i < key.Count(); i++)
            {
                start[i] = start[i - 1] + count[i - 1];
            }
            int y = 1;
            for (int i = 0; i < key.Count(); i++)
            {
                s = (key[i] - 1) * row;

                for (int j = 0; j < count[i]; j++)
                {
                    if (count[i] < row && count[i - 1] < row)
                    {

                        matrix[j, i] = cipherText[s - y];
                        s++;

                    }
                    else
                    {
                        matrix[j, i] = cipherText[s];
                        s++;
                    }

                }
                if (count[i] < row && count[i - 1] < row)
                {
                    y++;
                }
            }
            int z = cipherText.Count();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < key.Count(); j++)
                {
                    if (z == 0)
                    {
                        break;
                    }
                    z--;
                    plaintext += matrix[i, j];
                }
            }
            return plaintext;
        }
        public string Encrypt(string plainText, List<int> key)
        {
            //throw new NotImplementedException();
            int k = 0;
            int m = 0;
            int row = 0;
            int l = 0;
            plainText = plainText.ToUpper();
            string cipherText = "";
            if (plainText.Count() % key.Count() == 0)
            {
                row = plainText.Count() / key.Count();
            }
            else
            {
                row = (plainText.Count() / key.Count()) + 1;
                l = (row * key.Count()) - plainText.Count();
                for (int a = 0; a < 3; a++)
                {
                    plainText += 'x';
                }

            }
            char[] cipher = new char[plainText.Count()];

            char[,] matrix = new char[row, key.Count()];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < key.Count(); j++)
                {
                    if (k < plainText.Count())
                    {
                        matrix[i, j] = plainText[k];
                        k += 1;
                    }

                }
            }

            int s = 0;
            for (int i = 0; i < key.Count(); i++)
            {
                s = (key[i] - 1) * row;

                for (int j = 0; j < row; j++)
                {
                    cipher[s] = matrix[j, i];
                    s++;
                }
            }
            for (int i = 0; i < plainText.Count(); i++)
            {
                cipherText += cipher[i];
            }
            return cipherText;
        }
    }
}
