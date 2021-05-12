using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.ArraysStrings
{
   public class GroupAnagram
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> res = new List<IList<string>>();
            Dictionary<string, int> used = new Dictionary<string, int>();
            
            for(int i=0;i<strs.Length;i++)
            {
                if(!used.ContainsKey(strs[i]))
                {
                    IList<string> currLst = new List<string>();
                    currLst.Add(strs[i]);
                    used.Add(strs[i], i);
                    
                    for (int j = i + 1; j < strs.Length; j++)
                    {
                        if (!used.ContainsKey(strs[j]))
                        {
                            
                            if (IsAnagram(strs[i], strs[j]))
                            {
                                used.Add(strs[j], j);
                                currLst.Add(strs[j]);
                            }
                        }                           

                    }
                    if(currLst!=null||currLst.Count>0)
                    res.Add(new List<string>(currLst));
                }                
            }
            return res;
        }
        private bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            int[] charArr1 = new int[26];
            int[] charArr2 = new int[26];
            for (int i=0;i<s1.Length;i++)
            {
                charArr1[s1[i]-'a']++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                charArr2[s2[i]-'a']++;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (charArr1[s1[i]-'a']!=charArr2[s1[i]-'a'])
                    return false;
            }
            return true;
        }

        public IList<IList<string>> GroupAnagrams_Opt(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (string anagram in strs)
            {
                char[] tempArray = anagram.ToCharArray();
                Array.Sort(tempArray);
                string sorted = new string(tempArray);
                if (!map.ContainsKey(sorted))
                {
                    map.Add(sorted, new List<string>() { anagram });
                }
                else
                {
                    map[sorted].Add(anagram);
                }
            }
            foreach (var pair in map)
            {
                result.Add(pair.Value);
            }
            return result;
        }
    }
}
