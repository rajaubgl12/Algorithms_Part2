using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Google
{
    class ArrayStrngGayleLak
    {



        public string StringCompression(string s)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if ((i + 1) < s.Length)
                    if (s[i] == s[i + 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(new string(s[i], 1));
                        sb.Append(count);
                        count = 1;
                    }
            }
            sb.Append(new string(s[s.Length-1], 1));
            sb.Append(count);
            return sb.ToString();
        }

        public bool OneWay(string s1, string s2)
        {
            //get shorter and longer string
            string shorterString = s1.Length < s2.Length ? s1 : s2;
            string longerString = s1.Length < s2.Length ? s1 : s2;
            int diff = longerString.Length - shorterString.Length;

            if (diff > 1)
                return false;

            int countDiff = 0;

            for (int i = 0, j = 0; i < longerString.Length; i++, j++)
            {
                if (j < shorterString.Length)
                    if (s1[i] != s2[j])
                    {
                        countDiff++;
                        if (s1.Length != s2.Length)
                        {
                            if (s1.Length > s2.Length)
                                i++;
                            else
                                j++;

                        }

                        if (countDiff > 1)
                            return false;
                    }
            }
            return true;
        }

        public bool PermutationString(string str)
        {
            Dictionary<Char, int> charCount = new Dictionary<char, int>();
            
            for(int i=0;i<str.Length;i++)
            {
                Char c =  char.ToLower(str[i]);
                if (str[i]!=' ')
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount.Add(c, 1);
                    }
                }
                
            }
            int countOfNonRepeatingChar = 0;
            foreach(KeyValuePair<Char,int> keyValuePair in charCount)
            {
                if (keyValuePair.Value == 1)
                    countOfNonRepeatingChar++;
            }
            if (countOfNonRepeatingChar > 1)
                return false;
            else
                return true;
        }
    }
}
