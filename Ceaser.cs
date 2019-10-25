using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Ceaser : ICryptographicTechnique<string, int>
    {
        private static Dictionary<Int32, char> my_dic = new Dictionary<int, char>()
        {
            {0,'A'},{10,'K'},{20,'U'},
            {1,'B'},{11,'L'},{21,'V'},
            {2,'C'},{12,'M'},{22,'W'},
            {3,'D'},{13,'N'},{23,'X'},
            {4,'E'},{14,'O'},{24,'Y'},
            {5,'F'},{15,'P'},{25,'Z'},
            {6,'G'},{16,'Q'},
            {7,'H'},{17,'R'},
            {8,'I'},{18,'S'},
            {9,'J'},{19,'T'},
        };

        public string Encrypt(string plainText, int key)
        {
            char pt, ct;
            string encrypted = "";
            int pt_index, ct_index;
            string upper = plainText.ToUpper();
            for (int i = 0; i < plainText.Length; i++)
            {
                pt = upper[i];
                pt_index = my_dic.FirstOrDefault(x => x.Value == pt).Key;
                ct_index = (pt_index + key) % 26;
                ct = my_dic.FirstOrDefault(x => x.Key == ct_index).Value;
                encrypted += ct;
            }
            return encrypted;
        }

        public string Decrypt(string cipherText, int key)
        {
            char pt, ct;
            string decrypted = "";
            int pt_index, ct_index;
            for (int i = 0; i < cipherText.Length; i++)
            {
                ct = cipherText[i];
                ct_index = my_dic.FirstOrDefault(x => x.Value == ct).Key;
                pt_index = (ct_index - key) % 26;
                if (pt_index < 0)
                {
                    pt_index += 26;
                }
                pt = my_dic.FirstOrDefault(x => x.Key == pt_index).Value;
                decrypted += pt;
            }
            decrypted = decrypted.ToLower();
            return decrypted;
        }

        public int Analyse(string plainText, string cipherText)
        {
            int i = 0, key;
            while (true)
            {
                string output = Encrypt(plainText, i);
                if (output == cipherText)
                {
                    key = i;
                    break;
                }
                else
                {
                    i++;
                }
            }
            return key;
        }
    }
}
