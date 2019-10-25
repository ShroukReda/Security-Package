using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class PlayFair : ICryptographic_Technique<string, string>
    {
        public string Decrypt(string cipherText, string key)
        {
            string newkey = "";
            string mainplain = "";
            string l = "";
            int index = 0;
            int row1 = 0;
            int row2 = 0;
            int col1 = 0;
            int col2 = 0;
            int a = 0;
            int k = 0;
            char[,] matrix = new char[5, 5];
            // key = key.ToUpper();
            cipherText = cipherText.ToLower();
            cipherText = cipherText.Replace('j', 'i');
            key = key.Replace('j', 'i');
            key = key.Insert(key.Count(), "abcdefghiklmnopqrstuvwxyz");
            foreach (char x in key)
            {
                if (newkey.IndexOf(x) == -1)
                {
                    newkey += x;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = newkey[index];
                    index++;
                }
            }

            for (a = 0; a < cipherText.Count(); a += 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (k = 0; k < 5; k++)
                    {
                        if (matrix[i, k] == cipherText[a])
                        {
                            row1 = i;
                            col1 = k;
                        }
                        if (matrix[i, k] == cipherText[a + 1])
                        {
                            row2 = i;
                            col2 = k;
                        }
                    }
                }
                if (row1 == row2)
                {
                    if (col1 > 0 && col2 > 0)
                    {
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1, col1 - 1].ToString());
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1, col2 - 1].ToString());
                    }
                    else if (col1 > 0 && col2 == 0)
                    {
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1, col1 - 1].ToString());
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1, 4].ToString());
                    }
                    else if (col2 > 0 && col1 == 0)
                    {
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1, 4].ToString());
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1, col2 - 1].ToString());
                    }
                }
                else if (col1 == col2)
                {
                    if (row1 > 0 && row2 > 0)
                    {
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1 - 1, col1].ToString());
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row2 - 1, col2].ToString());
                    }
                    else if (row1 > 0 && row2 == 0)
                    {
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1 - 1, col1].ToString());
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row2 + 4, col2].ToString());
                    }
                    else if (row2 > 0 && row1 == 0)
                    {
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row1 + 4, col1].ToString());
                        mainplain = mainplain.Insert(mainplain.Count(), matrix[row2 - 1, col2].ToString());
                    }
                }
                else
                {
                    mainplain = mainplain.Insert(mainplain.Count(), matrix[row1, col2].ToString());
                    mainplain = mainplain.Insert(mainplain.Count(), matrix[row2, col1].ToString());

                }
            }
            for (int i = 0; i < mainplain.Count(); i++)
            {

                if (i < mainplain.Count() - 1 && mainplain[i] == 'x' && mainplain[i - 1] == mainplain[i + 1] && i % 2 != 0)
                {
                    continue;

                }
                else if (i == mainplain.Count() - 1 && mainplain[i] == 'x')
                {
                    continue;
                }
                else
                {
                    l += mainplain[i].ToString();
                }

            }


            return l;
        }

        
        public string Encrypt(string plainText, string key)
        {
            char[,] matrix = new char[5, 5];
            string newkey = "";
            string cipherText = "";
            int index = 0;
            int a = 0;
            int k = 0;
            int row1 = 0;
            int row2 = 0;
            int col1 = 0;
            int col2 = 0;

            key = key.ToUpper();
            key = key.Replace('J', 'I');
            plainText = plainText.ToUpper();
            plainText = plainText.Replace('J', 'I');
            key = key.Insert(key.Count(), "ABCDEFGHIKLMNOPQRSTUVWXYZ");
            foreach (char x in key)
            {
                if (newkey.IndexOf(x) == -1)
                {
                    newkey += x;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = newkey[index];
                    index++;
                }
            }
            for (int i = 0; i < plainText.Count() - 1; i++)
            {
                if (plainText[i] == plainText[i + 1] && (i) % 2 == 0)
                {
                    plainText = plainText.Insert(i + 1, "X");
                }
            }
            if (plainText.Count() % 2 != 0)
            {
                plainText = plainText.Insert(plainText.Count(), "X");
            }
            for (a = 0; a < plainText.Count(); a += 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (k = 0; k < 5; k++)
                    {
                        if (matrix[i, k] == plainText[a])
                        {
                            row1 = i;
                            col1 = k;
                        }
                        if (matrix[i, k] == plainText[a + 1])
                        {
                            row2 = i;
                            col2 = k;
                        }
                    }
                }
                if (row1 == row2)
                {
                    if (col1 < 4 && col2 < 4)
                    {
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1, col1 + 1].ToString());
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1, col2 + 1].ToString());
                    }
                    else if (col1 < 4 && col2 == 4)
                    {
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1, col1 + 1].ToString());
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1, 0].ToString());
                    }
                    else if (col2 < 4 && col1 == 4)
                    {
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1, 0].ToString());
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1, col2 + 1].ToString());
                    }
                }
                else if (col1 == col2)
                {
                    if (row1 < 4 && row2 < 4)
                    {
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1 + 1, col1].ToString());
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row2 + 1, col2].ToString());
                    }
                    else if (row1 < 4 && row2 == 4)
                    {
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1 + 1, col1].ToString());
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row2 - 4, col2].ToString());
                    }
                    else if (row2 < 4 && row1 == 4)
                    {
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row1 - 4, col1].ToString());
                        cipherText = cipherText.Insert(cipherText.Count(), matrix[row2 + 1, col2].ToString());
                    }
                }
                else
                {
                    cipherText = cipherText.Insert(cipherText.Count(), matrix[row1, col2].ToString());
                    cipherText = cipherText.Insert(cipherText.Count(), matrix[row2, col1].ToString());

                }
            }
            return cipherText;

        }
    }
}
