using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Facebook
{
    public class EasyAlgs
    {
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> uniqueChars = new Dictionary<char, int>();
            for(int i=0;i<s.Length;i++)
            {
                if(uniqueChars.ContainsKey(s[i]))
                {
                    uniqueChars[s[i]]++;
                }
                else
                {
                    uniqueChars.Add(s[i], 1);
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (uniqueChars[s[i]] == 1)
                    return i;
            }

            return -1;
        }


    }
}
