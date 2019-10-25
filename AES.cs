using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.AES
{
    /// <summary>
    /// If the string starts with 0x.... then it's Hexadecimal not string
    /// </summary>
    public class AES : CryptographicTechnique
    {
        static string[,] inverseBox = new string[16, 16] {
      {"52","09","6a","d5","30","36","a5","38","bf","40","a3","9e","81","f3","d7","fb"},
      {"7c","e3","39","82","9b","2f","ff","87","34","8e","43","44","c4","de","e9","cb"},
      {"54","7b","94","32","a6","c2","23","3d","ee","4c","95","0b","42","fa","c3","4e"},
      {"08","2e","a1","66","28","d9","24","b2","76","5b","a2","49","6d","8b","d1","25"},
      {"72","f8","f6","64","86","68","98","16","d4","a4","5c","cc","5d","65","b6","92"},
      {"6c","70","48","50","fd","ed","b9","da","5e","15","46","57","a7","8d","9d","84"},
      {"90","d8","ab","00","8c","bc","d3","0a","f7","4e","58","05","b8","b3","45","06"},
      {"d0","2c","1e","8f","ca","3f","0f","02","c1","af","bd","03","01","13","8a","6b"},
      {"3a","91","11","41","4f","67","dc","ea","97","f2","cf","ce","f0","b4","e6","73"},
      {"96","ac","74","22","e7","ad","35","85","e2","f9","37","e8","1c","75","df","6e"},
      {"47","f1","1a","71","1d","29","c5","89","6f","b7","62","0e","aa","18","be","1b"},
      {"fc","56","3e","4b","c6","d2","79","20","9a","db","c0","fe","78","cd","5a","f4"},
      {"1f","dd","a8","33","88","07","c7","31","b1","12","10","59","27","80","ec","5f"},
      {"60","51","7f","a9","19","b5","4a","0d","2d","e5","7a","9f","93","c9","9c","ef"},
      {"a0","e0","3b","4d","ae","2a","f5","b0","c8","eb","bb","3c","83","53","99","61"},
      {"17","2b","04","7e","ba","77","d6","26","e1","69","14","63","55","21","0c","7d"}

     };
        static string[,] Box = new string[16, 16] {
      {"63", "7c", "77", "7b", "f2", "6b", "6f", "c5", "30", "01", "67", "2b", "fe", "d7", "ab", "76"},
      {"ca", "82", "c9", "7d", "fa", "59", "47", "f0", "ad", "d4", "a2", "af", "9c", "a4", "72", "c0"},
      {"b7", "fd", "93", "26", "36", "3f", "f7", "cc", "34", "a5", "e5", "f1", "71", "d8", "31", "15"},
      {"04", "c7", "23", "c3", "18", "96", "05", "9a", "07", "12", "80", "e2", "eb", "27", "b2", "75"},
      {"09", "83", "2c", "1a", "1b", "6e", "5a", "a0", "52", "3b", "d6", "b3", "29", "e3", "2f", "84"},
      {"53", "d1", "00", "ed", "20", "fc", "b1", "5b", "6a", "cb", "be", "39", "4a", "4c", "58", "cf"},
      {"d0", "ef", "aa", "fb", "43", "4d", "33", "85", "45", "f9", "02", "7f", "50", "3c", "9f", "a8"},
      {"51", "a3", "40", "8f", "92", "9d", "38", "f5", "bc", "b6", "da", "21", "10", "ff", "f3", "d2"},
      {"cd", "0c", "13", "ec", "5f", "97", "44", "17", "c4", "a7", "7e", "3d", "64", "5d", "19", "73"},
      {"60", "81", "4f", "dc", "22", "2a", "90", "88", "46", "ee", "b8", "14", "de", "5e", "0b", "db"},
      {"e0", "32", "3a", "0a", "49", "06", "24", "5c", "c2", "d3", "ac", "62", "91", "95", "e4", "79"},
      {"e7", "c8", "37", "6d", "8d", "d5", "4e", "a9", "6c", "56", "f4", "ea", "65", "7a", "ae", "08"},
      {"ba", "78", "25", "2e", "1c", "a6", "b4", "c6", "e8", "dd", "74", "1f", "4b", "bd", "8b", "8a"},
      {"70", "3e", "b5", "66", "48", "03", "f6", "0e", "61", "35", "57", "b9", "86", "c1", "1d", "9e"},
      {"e1", "f8", "98", "11", "69", "d9", "8e", "94", "9b", "1e", "87", "e9", "ce", "55", "28", "df"},
      {"8c", "a1", "89", "0d", "bf", "e6", "42", "68", "41", "99", "2d", "0f", "b0", "54", "bb", "16"}
     };

        public string sub(string input)
        {
            string input2 = "0x";
            for (int i = 0; i < 32; )
            {
                string s = "";
                s = input[i + 2].ToString() + input[i + 3].ToString();
                int v = Convert.ToInt32(s[0].ToString(), 16);
                int v1 = Convert.ToInt32(s[1].ToString(), 16);
                s = Box[v, v1];
                input2 += s;
                i = i + 2;
            }


            return input2;
        }
        public string inverse_sub(string input)
        {
            string input2 = "0x";
            for (int i = 0; i < 32; )
            {
                string s = "";
                s = input[i + 2].ToString() + input[i + 3].ToString();
                int v = Convert.ToInt32(s[0].ToString(), 16);
                int v1 = Convert.ToInt32(s[1].ToString(), 16);
                s = inverseBox[v, v1];
                input2 += s;
                i = i + 2;
            }


            return input2;
        }


        public string generatekey(string key, int r)
        {
            string keygen = "01020408102040801b36";
            string final = "";
            string input2 = "0x";
            string input = "";
            input2 = key.Substring(26);
            char[] t = input2.ToCharArray();

            string s = input2[0].ToString() + input2[1].ToString();
            for (int i = 0; i < 6; i++)
            {
                t[i] = t[i + 2];
            }
            t[6] = s[0];
            t[7] = s[1];
            input2 = new string(t);
            r = (r - 1) * 2;
            for (int i = 0; i < 8; i = i + 2)
            {
                s = "";
                s = t[i].ToString() + t[i + 1].ToString();
                int v = Convert.ToInt32(s[0].ToString(), 16);
                int v1 = Convert.ToInt32(s[1].ToString(), 16);
                s = Box[v, v1];
                input += s;
            }
            string b = "";
            b = keygen[r].ToString() + keygen[r + 1].ToString();
            int a, aa;
            for (int i = 0; i < 8; i = i + 2)
            {
                s = "";
                s = input[i].ToString() + input[i + 1].ToString();
                a = Convert.ToInt32(s, 16);
                aa = Convert.ToInt32(b, 16);
                string z = key[i + 2].ToString() + key[i + 3];
                int f = Convert.ToInt32(z, 16);
                if (i == 0)
                {
                    a = a ^ f ^ aa;
                    s = a.ToString("X");
                    if (s.Length == 1)
                        s = "0" + s;
                    final = final + s;
                }
                else
                {
                    a = a ^ f;
                    s = a.ToString("X");
                    if (s.Length == 1)
                        s = "0" + s;
                    final = final + s;
                }

            }
            int l = 0;
            for (int i = 10; i < 34; i = i + 2)
            {
                s = "";
                b = "";
                s = key[i].ToString() + key[i + 1].ToString();
                b = final[l].ToString() + final[l + 1].ToString();

                l = l + 2;
                a = Convert.ToInt32(s, 16);
                aa = Convert.ToInt32(b, 16);
                a = a ^ aa;
                s = a.ToString("X");
                if (s.Length == 1)
                    s = "0" + s;
                final = final + s;
            }

            final = "0x" + final;
            return final;
        }
        public string AddRK(string input, string key)
        {
            string arr3 = "0x";
            string a = "";
            string b = "";

            for (int i = 2; i < 34; i++)
            {
                a = a + input[i].ToString();
                b = b + key[i].ToString();
                if ((i + 1) % 2 == 0)
                {
                    int aa = Convert.ToInt32(a, 16);
                    int bb = Convert.ToInt32(b, 16);
                    aa = aa ^ bb;
                    string s = aa.ToString("X");
                    if (s.Length == 1)
                    {
                        string h = "";
                        h = "0" + s;
                        s = h;
                    }

                    arr3 = arr3 + s;
                    a = "";
                    b = "";

                }
            }

            return arr3;
        }


        public string inverse_shift(string input)
        {
            int p = 20;
            // int e = 28;
            for (int j = 0; j < 6; j++)
            {
                if (j == 1 || j == 2)
                {
                    p = 22;
                }
                if (j >= 3)
                {
                    p = 24;
                }
                string a = "";
                a = input[p + 8].ToString() + input[p + 9].ToString();
                char[] t = input.ToCharArray();
                int z = p - 16;

                for (int i = 0; i < 6; i++)
                {
                    t[p + 8] = t[p];
                    if (p % 2 != 0)
                    {
                        p -= 9;
                        continue;
                    }
                    p++;
                }

                t[z] = a[0];
                t[z + 1] = a[1];
                input = new string(t);
            }
            return input;
        }
        public string shiftR(string input)
        {
            int p = 4;
            for (int j = 0; j < 6; j++)
            {
                if (j == 1 || j == 2)
                {
                    p = 6;
                }
                if (j >= 3)
                {
                    p = 8;
                }
                string a = "";
                a = input[p].ToString() + input[p + 1].ToString();
                char[] t = input.ToCharArray();
                int z = p + 24;

                for (int i = 0; i < 6; i++)
                {
                    t[p] = t[p + 8];
                    if (p % 2 != 0)
                    {
                        p += 7;
                        continue;
                    }
                    p++;
                }

                t[z] = a[0];
                t[z + 1] = a[1];
                input = new string(t);
            }
            return input;
        }


        public string mixc(string input)
        {

            string arr2 = "0x02030101010203010101020303010102";
            string finals = "0x";
            int index = 2;
            for (int ii = 0; ii < 4; ii++)
            {
                string s = "", p = "";
                int a, b, c;

                int co = 2;
                int final = 0;
                int hh = 2 + 8 * ii;
                for (int j = 0; j < 4; j++)
                {
                    final = 0;
                    index = hh;
                    for (int i = 0; i < 4; i++)
                    {
                        s = input[index].ToString() + input[index + 1].ToString();
                        p = arr2[co].ToString() + arr2[co + 1].ToString();
                        a = Convert.ToInt32(s, 16);
                        b = Convert.ToInt32(p, 16);

                        if (b == 2)
                        {
                            c = a * b;
                            if (c > 255)
                            {
                                c = c & 255;
                                c = c ^ 27;
                                final = final ^ c;
                            }
                            else
                            {
                                final = final ^ c;
                            }
                        }
                        else if (b == 3)
                        {
                            b = 2;
                            c = a * b;
                            if (c > 255)
                            {
                                c = c & 255;
                                c = c ^ 27;

                            }
                            c = a ^ c;
                            final = final ^ c;

                        }
                        else
                        {
                            final = final ^ a;
                        }

                        index += 2;
                        co += 2;
                    }

                    s = final.ToString("X");
                    if (s.Length == 1)
                        s = "0" + s;
                    finals = finals + s;
                }
            }
            return finals;

        }
        public string inverse_mixc(string input)
        {
            string c = "0x0E090D0B0B0E090D0D0B0E09090D0B0E";
            string final = "0x";
            string o = "";
            int index = 2;
            int co = 2;
            string s = "";
            string n = "";
            int deci = 0;
            string binary = "";
            int d = 0;
            string q = "";
            int s1 = 0;
            int s2 = 0;
            int s3 = 0;
            int out1;
            int finall = 0;
            string w = "";
            int flag = 0;
            int ww = 0;
            string result = "";
            for (int z = 0; z < 4; z++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        s = c[index].ToString() + c[index + 1].ToString();
                        n = input[co].ToString() + input[co + 1].ToString();
                        d = Convert.ToInt32(n, 16);
                        binary = Convert.ToString(d, 2);
                        q = binary;
                        deci = d;
                        s1 = deci;
                        s2 = deci;
                        s3 = deci;
                        if (s == "0E")
                        {

                            for (int x = 0; x < 3; x++)
                            {

                                if (q.Count() < 8)
                                {
                                    s1 = s1 * 2;
                                    q = Convert.ToString(s1, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);

                                        }
                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        s1 = s1 * 2;
                                        q = Convert.ToString(s1, 2);
                                        continue;
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                            for (int y = 0; y < 2; y++)
                            {

                                if (q.Count() < 8)
                                {
                                    s2 = s2 * 2;
                                    q = Convert.ToString(s2, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s2 = s2 * 2;
                                        s2 = s2 ^ 27;
                                        if (s2 > 256)
                                        {
                                            s2 = s2 - 256;
                                            q = Convert.ToString(s2, 2);

                                        }
                                        else
                                        {
                                            s2 = s2 * 2;
                                            q = Convert.ToString(s2, 2);

                                        }
                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s2 = s2 * 2;
                                        s2 = s2 ^ 27;
                                        if (s2 > 256)
                                        {
                                            s2 = s2 - 256;
                                            q = Convert.ToString(s2, 2);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        s2 = s2 * 2;
                                        q = Convert.ToString(s2, 2);
                                        continue;
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                            for (int x = 0; x < 1; x++)
                            {

                                if (q.Count() < 8)
                                {
                                    s3 = s3 * 2;
                                    q = Convert.ToString(s3, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s3 = s3 * 2;
                                        s3 = s3 ^ 27;
                                        if (s3 > 256)
                                        {
                                            s3 = s3 - 256;
                                            q = Convert.ToString(s3, 2);

                                        }
                                    }
                                    else
                                    {
                                        s3 = s3 * 2;
                                        q = Convert.ToString(s3, 2);

                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s3 = s3 * 2;
                                        s3 = s3 ^ 27;
                                        if (s3 > 256)
                                        {
                                            s3 = s3 - 256;
                                            q = Convert.ToString(s3, 2);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        s3 = s3 * 2;
                                        q = Convert.ToString(s3, 2);
                                        continue;
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                        }

                        else if (s == "0B")
                        {
                            for (int x = 0; x < 3; x++)
                            {

                                if (q.Count() < 8)
                                {
                                    s1 = s1 * 2;
                                    q = Convert.ToString(s1, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);

                                        }
                                    }
                                    else
                                    {
                                        s1 = s1 * 2;
                                        q = Convert.ToString(s1, 2);

                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        s1 = s1 * 2;
                                        q = Convert.ToString(s1, 2);
                                        continue;
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                            for (int y = 0; y < 1; y++)
                            {

                                if (q.Count() < 8)
                                {
                                    s2 = s2 * 2;
                                    q = Convert.ToString(s2, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s2 = s2 * 2;
                                        s2 = s2 ^ 27;
                                        if (s2 > 256)
                                        {
                                            s2 = s2 - 256;
                                            q = Convert.ToString(s2, 2);

                                        }
                                    }
                                    else
                                    {
                                        s2 = s2 * 2;
                                        q = Convert.ToString(s2, 2);

                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s2 = s2 * 2;
                                        s2 = s2 ^ 27;
                                        if (s2 > 256)
                                        {
                                            s2 = s2 - 256;
                                            q = Convert.ToString(s2, 2);
                                        }
                                    }

                                    else
                                    {
                                        s2 = s2 * 2;
                                        q = Convert.ToString(s2, 2);
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                            s3 = deci;
                        }

                        else if (s == "0D")
                        {
                            for (int x = 0; x < 3; x++)
                            {

                                if (q.Count() < 8)
                                {
                                    s1 = s1 * 2;
                                    q = Convert.ToString(s1, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);

                                        }
                                    }
                                    else
                                    {
                                        s1 = s1 * 2;
                                        q = Convert.ToString(s1, 2);

                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);
                                        }
                                    }
                                    else
                                    {
                                        s1 = s1 * 2;
                                        q = Convert.ToString(s1, 2);
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                            for (int x = 0; x < 2; x++)
                            {

                                if (q.Count() < 8)
                                {
                                    s2 = s2 * 2;
                                    q = Convert.ToString(s2, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s2 = s2 * 2;
                                        s2 = s2 ^ 27;
                                        if (s2 > 256)
                                        {
                                            s2 = s2 - 256;
                                            q = Convert.ToString(s2, 2);

                                        }
                                    }
                                    else
                                    {
                                        s2 = s2 * 2;
                                        q = Convert.ToString(s2, 2);

                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s2 = s2 * 2;
                                        s2 = s2 ^ 27;
                                        if (s2 > 256)
                                        {
                                            s2 = s2 - 256;
                                            q = Convert.ToString(s2, 2);
                                        }
                                    }
                                    else
                                    {
                                        s2 = s2 * 2;
                                        q = Convert.ToString(s2, 2);
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                            s3 = deci;
                        }


                        else if (s == "09")
                        {
                            for (int x = 0; x < 3; x++)
                            {

                                if (q.Count() < 8)
                                {
                                    s1 = s1 * 2;
                                    q = Convert.ToString(s1, 2);
                                    continue;
                                }
                                else if (q.Count() == 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);

                                        }
                                    }
                                    else
                                    {
                                        s1 = s1 * 2;
                                        q = Convert.ToString(s1, 2);

                                    }
                                    continue;
                                }
                                else if (q.Count() > 8)
                                {
                                    if (q[q.Count() - 8] == '1')
                                    {
                                        s1 = s1 * 2;
                                        s1 = s1 ^ 27;
                                        if (s1 > 256)
                                        {
                                            s1 = s1 - 256;
                                            q = Convert.ToString(s1, 2);
                                        }
                                    }
                                    else
                                    {
                                        s1 = s1 * 2;
                                        q = Convert.ToString(s1, 2);
                                    }
                                    continue;
                                }

                            }
                            q = Convert.ToString(deci, 2);

                            s2 = deci;
                            flag = 1;
                        }
                        if (flag == 0)
                        {
                            out1 = s1 ^ s2 ^ s3;
                        }
                        else
                        {
                            out1 = s1 ^ s2;
                            flag = 0;
                        }
                        w = Convert.ToString(out1, 10);
                        ww = Convert.ToInt32(w);
                        finall = finall ^ ww;
                        index += 8;
                        co += 2;

                    }
                    result = finall.ToString("X");
                    if (result.Count() == 1)
                    {
                        result = '0' + result;
                    }
                    o += result;
                    finall = 0;
                    if (co == 18)
                    {
                        co = 10;
                    }
                    else if (co == 10)
                    {
                        co = 2;
                    }
                    else if (co == 26)
                    {
                        co = 18;
                    }
                    else
                    {
                        co = 26;
                    }
                    index -= 30;
                }
                co += 8;
                index = 2;
            }
            o = final + o;
            return o;
        }


        public override string Decrypt(string cipherText, string key)
        {
            string plainttext = "";
            string[] keys = new string[10];
            string first = key;
            string s = key;
            for (int i = 0; i <= 9; i++)
            {
                keys[i] = generatekey(s, i + 1);
                s = keys[i];
            }

            plainttext = AddRK(cipherText, keys[9]);
            for (int i = 8; i >= 0; i--)
            {
                plainttext = inverse_shift(plainttext);
                plainttext = inverse_sub(plainttext);
                plainttext = AddRK(plainttext, keys[i]);
                plainttext = inverse_mixc(plainttext);
            }
            plainttext = inverse_shift(plainttext);
            plainttext = inverse_sub(plainttext);
            plainttext = AddRK(plainttext, first);

            return plainttext;
        }

        public override string Encrypt(string plainText, string key)
        {
            string final = "";
            final = AddRK(plainText, key);

            for (int i = 0; i < 9; i++)
            {
                final = sub(final);
                final = shiftR(final);
                final = mixc(final);
                key = generatekey(key, i + 1);
                final = AddRK(final, key);
            }

            final = sub(final);
            final = shiftR(final);
            key = generatekey(key, 10);
            final = AddRK(final, key);

            return final;

        }
    }
}
