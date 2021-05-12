using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.ArraysStrings
{

    
        //     * Given a non-empty list of words, return the k most frequent elements.

        //Your answer should be sorted by frequency from highest to lowest. 
    //If two words have the same frequency, then the word with the lower alphabetical order comes first.

        //Example 1:
        //Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
        //Output: ["i", "love"]
        //Explanation: "i" and "love" are the two most frequent words.
        //    Note that "i" comes before "love" due to a lower alphabetical order.
        //Example 2:
        //Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
        //Output: ["the", "is", "sunny", "day"]
        //Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
        //    with the number of occurrence being 4, 3, 2 and 1 respectively.
        //Note:
        //You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
        //Input words contain only lowercase letters.
        //Follow up:
        //Try to solve it in O(n log k) time and O(n) extra space.

     
    public class TopKFreqWords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var dic = new Dictionary<string, int>();
            SortedSet<int> srtd = new SortedSet<int>();
            
            foreach (string w in words)
            {
                if (dic.ContainsKey(w)) dic[w]++;
                else dic.Add(w, 1);
            }
            CustComparer objComp = new CustComparer();
            

            var sortedDic = dic.OrderBy(x => x, objComp);

            var ret = new List<string>();
            foreach (var item in sortedDic)
            {
                ret.Add(item.Key);
                if (ret.Count == k) return ret;
            }
            return ret;
        }
    }
    public class CustComparer : IComparer<KeyValuePair<string, int>>
    {
        public int Compare(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            if (a.Value == b.Value) return a.Key.CompareTo(b.Key);
            return b.Value.CompareTo(a.Value);
        }
    }

   
}
