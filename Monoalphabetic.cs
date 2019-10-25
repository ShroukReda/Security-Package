using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            int c = 0;
            char[] key = new char[26];
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                for (int i = 0; i < plainText.Length; i++)
                {
                    if (plainText.Contains(ch))
                    {
                        if (plainText[i] == ch)
                        {
                            key[c] = cipherText[i];
                            c++;
                            break;
                        }
                    }
                    else
                    {
                        for (char x = 'A'; x <= 'Z'; x++)
                        {
                            if (!(cipherText.Contains(x)) && !(key.Contains(x)))
                            {
                                key[c] = x;
                                c++;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            string keyy = new string(key).ToLower();
            return keyy;
        }

        public string Decrypt(string cipherText, string key)
        {
            Dictionary<char, char> Map = new Dictionary<char, char>();
            int i = 0;
            char[] plainText = new char[cipherText.Length];
            cipherText = cipherText.ToLower();
            for (char c = 'a'; c <= 'z'; c++)
            {
                Map.Add(c, key[i]);
                i++;
            }
            for (int j = 0; j < cipherText.Length; j++)
            {
                foreach (KeyValuePair<char, char> pair in Map)
                {
                    if (pair.Value == cipherText[j])
                    {
                        plainText[j] = pair.Key;
                        break;
                    }
                }
            }
            string Text = new string(plainText).ToLower();
            return Text;
        }

        public string Encrypt(string plainText, string key)
        {
            Dictionary<char, char> Map = new Dictionary<char, char>();
            int i = 0;
            char[] cipherText = new char[plainText.Length];
            for (char c = 'a'; c <= 'z'; c++)
            {
                Map.Add(c, key[i]);
                i++;
            }
            for (int j = 0; j < plainText.Length; j++)
            {

                if (Map.ContainsKey(plainText[j]))
                {
                    cipherText[j] = Map[plainText[j]];
                }
            }
            string Chipher = new string(cipherText).ToUpper();
            return Chipher;
        }

        /// <summary>
        public static Dictionary<char, double> freq = new Dictionary<char, double>();
        public static char maxKey, maxKey2, maxKey1, key;
        public static double maxValue1;
        public static double target;
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        public string AnalyseUsingCharFrequency(string cipher)
        {
            freq.Add('E', 12.51);
            freq.Add('T', 9.25);
            freq.Add('A', 8.04);
            freq.Add('O', 7.60);
            freq.Add('I', 7.26);
            freq.Add('N', 7.09);
            freq.Add('S', 6.54);
            freq.Add('R', 6.12);
            freq.Add('H', 5.49);
            freq.Add('L', 4.14);
            freq.Add('D', 3.99);
            freq.Add('C', 3.06);
            freq.Add('U', 2.71);
            freq.Add('M', 2.53);
            freq.Add('F', 2.30);
            freq.Add('P', 2.00);
            freq.Add('G', 1.96);
            freq.Add('W', 1.92);
            freq.Add('Y', 1.73);
            freq.Add('B', 1.54);
            freq.Add('V', 0.99);
            freq.Add('K', 0.67);
            freq.Add('X', 0.19);
            freq.Add('J', 0.16);
            freq.Add('Q', 0.11);
            freq.Add('Z', 0.09);
            int s = 0;
            var characterCount = new Dictionary<char, double>();
            var outliers = new Dictionary<char, double>();
            var outliers2 = new Dictionary<char, double>();
            var saved = characterCount;
            var saved2 = freq;

            foreach (var c in cipher)
            {
                if (characterCount.ContainsKey(c))
                    characterCount[c]++;
                else
                    characterCount[c] = 1;
            }


            for (int y = 0; y < 26; y++)
            {
                var maxValue = freq.Values.Min();
                var maxValue2 = characterCount.Values.Min();
                foreach (KeyValuePair<char, double> pair in freq)
                {
                    if (pair.Value == maxValue)
                    {
                        maxKey = pair.Key;
                        freq.Remove(pair.Key);
                        break;
                    }
                }
                foreach (KeyValuePair<char, double> pair2 in characterCount)
                {
                    if (pair2.Value == maxValue2)
                    {
                        maxKey2 = pair2.Key;
                        characterCount.Remove(pair2.Key);
                        break;
                    }
                }
                if (cipher.Contains(maxKey2.ToString().ToUpper()))
                {

                    cipher = cipher.Replace(maxKey2.ToString().ToUpper(), maxKey.ToString().ToLower());
                }


            }
            return cipher.ToUpper();

        }
    }
}
