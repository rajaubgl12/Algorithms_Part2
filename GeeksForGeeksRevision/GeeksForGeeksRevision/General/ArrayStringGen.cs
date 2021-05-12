using GeeksForGeeksRevision.DataStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.General
{
    class ArrayStringGen
    {
       
        public int CharToInt(string s)
        {
            #region practice
            //object len = 2.3;
            //int? m = len as int ?;
            //int len2 = (int)len;
            //int[] a = new int[3] { 1, 2, 3 };

            //object b = a.Clone();
            #endregion

            int sum = s[s.Length-1]-'0';
            int decValue = 1;
            for(int i=s.Length-2;i>-1;i--)
            {
                decValue = decValue * 10;
                sum = sum + (s[i] - '0')*decValue;
            }
            
            return sum;
        }

        public string FormatString(string str)
        {

            for(int i=0;i<str.Length;i++)
            {
                if(str[i]=='"')
                {
                               
                }
                if(str[i]==' ')
                {
                           
                }
            }
            return "";
        }

        public  int [] GetLatestMovie(int[] a, int count)
        {
            int[] res = new int[count];
            int[] copy = new int[a.Length];
            for(int i=0;i<a.Length;i++)
            {
                for(int j=i+1;j<a.Length;j++)
                {
                    if(a[i]<a[j] )
                    {
                        int temp = a[j];
                        a[j] = a[i];
                        a[i] = temp;
                    }
                }
            }
            return copy;
        }
        
        public int [] GetLatestMovie2(int[] a, int count)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            int[] temp = new int[a.Length];
           
            //copy the array and index to dictionary

            SortedList<int, int> sortedYear = new SortedList<int, int>();
            for(int i=0;i<a.Length;i++)
            {
                queue.Enqueue(a[i]);
                sortedYear.Add(a[i], i);
            }
            var sortDict= sortedYear.OrderByDescending(x => x.Key).ToDictionary(x=>x.Key,k=>k.Value);

            SortedList<int, int> srtdIndex = new SortedList<int, int>();
            
            int tmpCount = count;

            foreach(var srtdYr in sortDict)
            {
                if(tmpCount>0)
                {
                    srtdIndex.Add(srtdYr.Value, srtdYr.Key);
                    tmpCount--;
                }
                
            }

            //var sortDict = sortedIndex.OrderByDescending(m => m.Value).ToDictionary(x=>x.Key,k=>k.Value);
            //CustomComparer cusComp = new CustomComparer();
            //var sortDict = sortedIndex.OrderByDescending(m => m.Key, cusComp);

            return null;
        }

        public int[] SortTopNbasedOnIndex(int[] a, int topN)
        {
            Dictionary<int, int> valuePairs = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                valuePairs.Add(a[i], i);
            }
            Dictionary<int, int> sortIndex = new Dictionary<int, int>();
            var sortByKey = valuePairs.OrderByDescending(x => x.Key);

            foreach (KeyValuePair<int, int> keyValue in sortByKey)
            {
                if (topN == 0)
                    break;

                sortIndex.Add(keyValue.Key, keyValue.Value);
                topN--;
            }

            var sortValue = sortIndex.OrderBy(x => x.Value);

            return sortValue.Select(x => x.Key).ToArray();
        }
        /// <summary>
        /// Reorder an array according to given indexes
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int [] ReOrderBasedOnIndex(int [] a, int [] index)
        {
            int[] temp = new int[a.Length];
            for(int i=0;i<a.Length;i++)
            {
                temp[index[i]] = a[i];
            }

            return temp;
        }

        public void SortColors(int[] nums)
        {
            
            int[] counts = new int[3];
            foreach (int x in nums)
            {
                counts[x]++;
            }
            
            int index = 0;
            for (int x = 0; x <= 2; x++)
            {
                while (counts[x]-- > 0)
                {
                    nums[index++] = x;
                }
            }
        }

        class CustomComparer : IComparer<KeyValuePair<int, int>>
        {
            public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
            {
                if(x.Key>y.Key)
                {
                    return x.Value < y.Value ? 1 : -1;
                }
                return 1;
            }
        }
       
    }    
}
