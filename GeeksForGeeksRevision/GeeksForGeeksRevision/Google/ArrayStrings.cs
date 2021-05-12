using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Google
{
    class ArrayStrings
    {
        /// <summary>
        /// replace the empty spaces by %20
        /// 1. Count the number of spaces.
        /// 1. Triple this space count will tell the how mauch extra spaces required.
        /// 2. second pass in reverse order edit the string when we see space replace with %20.
        /// 3. If there is not space then copy the original character.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trueLen"></param>
        /// <returns></returns>
        public string Urlify(string str, int trueLen)
        {
            char[] charsArray = str.ToCharArray();
            int spaceCount = 0; 
            int index =0;
            for(int i=0;i<trueLen;i++)
            {
                if (charsArray[i] == ' ')
                    spaceCount++;
            }
            index = trueLen + 2 * spaceCount;
            if (trueLen < str.Length)
                charsArray[trueLen] = '\0';

            for(int i=trueLen-1;i>=0;i--)
            {
                if(str[i]==' ')
                {
                    charsArray[index - 1] = '0';
                    charsArray[index - 2] = '2';
                    charsArray[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    charsArray[index - 1] = charsArray[i];
                    index--;
                }
            }
            return new string(charsArray);
        }

        /// <summary>
        /// Input:  arr[] = {2, 5, 2, 8, 5, 6, 8, 8}
        /// Output: arr[] = {8, 8, 8, 2, 2, 5, 5, 6}
        ///Input: arr[] = {2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8}
        ///Output: arr[] = {8, 8, 8, 2, 2, 5, 5, 6, -1, 9999999}
        ///1) Use a sorting algorithm to sort the elements O(nlogn)
        ///2) Scan the sorted array and construct a 2D array of element and count O(n).
        ///3) Sort the 2D array according to count O(nlogn).
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int [] SortByFrequency(int [] a)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for(int i=0;i<a.Length;i++)
            {
                if(keyValuePairs.ContainsKey(a[i]))
                {
                    keyValuePairs[a[i]]++;
                }
                else
                {
                    keyValuePairs.Add(a[i], 1);
                }
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //var ordered = dic.OrderBy(x => x.Value);
            //var ordered2= ordered.ToDictionary(t => t.Key, t => t.Value);
            var keyValuePairs2 = keyValuePairs.OrderByDescending(x => x.Value);
            var saveInDictionary = keyValuePairs2.ToDictionary(t=>t.Key,t=>t.Value);

            if (a==null||a.Length<1)
            {
                return null;
            }
            return null;
        }

        public string FrequencySortCharacters(string s)
        {
            var dict = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            CustomerComparer dictComp = new CustomerComparer();
            //var sortedDict = from entry in dict orderby entry.Value descending select entry;

            var sortedDict = dict.OrderByDescending(x => x.Value);
            var res = new StringBuilder();
            //foreach (var d in sortedDict)
            //{
            //    for (int i = 0; i < d.Value; i++)
            //        res.Append(d.Key);
            //}
            return res.ToString();
        }

        /*
         * if(s == null || s.Length <= 1) return s;
        
        //each element stores the ASCCI and Frequency
        int[][] freq = new int[128][]; 
        for(int i = 0; i < 128; i++)
        {
            freq[i] = new int[2];
            freq[i][0] = i;
        }
        
        foreach(char c in s) freq[c][1]++;
        
        //Sort char by its frequency
        Array.Sort(freq, (x,y) => y[1].CompareTo(x[1])); 
        
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < 128; i++) sb.Append((char)(freq[i][0]), freq[i][1]);

        return sb.ToString();
         * */

        /*
1. Create an array with the frequency of every character
2. Create a string char array which has all characters with their count
3. Iterate through the string array in reverse to append the char to the final stringbuilder

Time: O(n)
Space: O(m) where m is the number of distinct characters
*/
        public string FrequencySort(string s)
        {
            int[] cnts = new int[256];
            foreach (char c in s) cnts[c]++;

            string[] chars = new string[s.Length + 1];
            for (int i = 0; i < 256; i++)
            {
                if (cnts[i] > 0)
                {
                    int cnt = cnts[i];
                    if (chars[cnt] == null) chars[cnt] = "";
                    chars[cnt] += (char)i;
                }
            }

            StringBuilder output = new StringBuilder();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                AppendEachXTimes(output, chars[i], i);
            }

            return output.ToString();
        }

        public void AppendEachXTimes(StringBuilder builder, string s, int times)
        {
            if (s == null) return;
            foreach (char c in s)
            {
                for (int i = 0; i < times; i++) builder.Append(c);
            }
        }
        public string LargestNumber(int[] nums)
        {
            IntComparer intComparer = new IntComparer();

            Array.Sort(nums, intComparer);
            StringBuilder stringBuilder = new StringBuilder();

            for(int i=0;i<nums.Length;i++)
            {
                stringBuilder.Append(nums[i]);
            }

            return stringBuilder.ToString();
        }
    }

    public class FreqComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -1;
        }
    }
    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            long l1 = Convert.ToInt32(x.ToString() + y.ToString());
            long l2 = Convert.ToInt32(y.ToString()+ x.ToString());
            if (l1 == l2)
                return 0;
            else
            {
               return (l1 < l2) ? 1 : -1;
            }
        }
    }

    public class CustomerComparer : IComparer<KeyValuePair<int, int>>
    {        

        public int Compare(KeyValuePair<int, int> str1, KeyValuePair<int, int> str2)
        {
            if (str1.Value == str2.Value)
            {
                return str1.Key > str2.Key ? -1 : 1;
            }
            return 1;
        }
    }

}
