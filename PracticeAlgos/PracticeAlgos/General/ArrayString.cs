using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgos.General
{
    public class ArrayString
    {
        class KeyValueWrds
        {
            public string wrd;
            public int count;
        }

        public string GetMaxRepeatedString(string[] wrds)
        {
            Dictionary<string, int> keyValues = new Dictionary<string, int>();

            List<KeyValueWrds> lst = new List<KeyValueWrds>();

            for (int i = 0; i < wrds.Length; i++)
            {
                if (keyValues.ContainsKey(wrds[i]))
                {
                    keyValues[wrds[i]]++;
                }
                else
                {
                    keyValues.Add(wrds[i], 1);
                }
            }

            foreach (KeyValuePair<string, int> valuePair in keyValues)
            {
                KeyValueWrds valueWrds = new KeyValueWrds();
                valueWrds.count = valuePair.Value;
                valueWrds.wrd = valuePair.Key;
                lst.Add(valueWrds);
            }
            comparecustom comparecustom = new comparecustom();
            lst.Sort(comparecustom);
            lst.Reverse();
            return lst[0].wrd;
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

        public int CoinChangeCount(int[] denomination, int index, int amount)
        {
            if (index > denomination.Length)
                return 0;
            if (amount <= 0)
                return 0;
            int waysCount = 0;
            int denom = denomination[index];
            if (amount >= denom)
            {
                waysCount = waysCount + amount / denom;
                amount = amount % denom;
            }
            return waysCount + CoinChangeCount(denomination, index + 1, amount);

        }

        public int CoinChangeInterative(int[] denomination, int amount)
        {
            int waysCount = 0;
            for (int i = 0; i < denomination.Length; i++)
            {
                if (amount >= denomination[i])
                {
                    waysCount += amount / denomination[i];
                    amount = amount % denomination[i];
                }
            }
            return waysCount;
        }

        public void Permute(string str)
        {
            int index = 0;
            PermuteSub(str, index);       
        }       

        private void PermuteSub(string str, int index)
        {
            if (index == str.Length - 1)
            {
                Console.WriteLine(str);
                return;
            }
                

            for(int i=index;i<str.Length;i++)
            {
                //swap elements
                str = Swap(str, index, i);

                //explore
                PermuteSub(str, index + 1);

                //swap again
                str = Swap(str, index, i);
            }
        }

        private string Swap(string str, int index, int i)
        {
            char[] charArray = str.ToCharArray();
            char temp = charArray[i];
            charArray[i] = charArray[index];
            charArray[index] = temp;
            return new string(charArray);
        }

        public void PermuteArrayNumbersWithoutDups(int [] a)
        {
            int index = 0;
            List<int []> result = new List<int []>();
           PermuteNumbersArray(a,index,result);
        }

        private void PermuteNumbersArray(int[] a, int index, List<int []> result)
        {
           // List<int> lst = new List<int>();
            if (index == a.Length - 1)
            {
                int[] b = new int[a.Length];
                a.CopyTo(b, 0);
                result.Add(b);
                //return result;
            }
            
            for(int i=index;i<a.Length;i++)
            {
                a = Swap(a, index, i);
                PermuteNumbersArray(a, index+1, result);
                a = Swap(a, index, i);
            }
        }

        private int [] Swap(int [] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            return a;
        }

        class comparecustom : IComparer<KeyValueWrds>
        {
            public int Compare(KeyValueWrds x, KeyValueWrds y)
            {
                if (x.count == y.count)
                    return x.wrd.Length.CompareTo(y.wrd.Length);
                return -1;
            }
        }

        class TwoIntsKey
        {
            public int key;
            public int value;
        }

        class customcompareints : IComparer<TwoIntsKey>
        {
            int IComparer<TwoIntsKey>.Compare(TwoIntsKey x, TwoIntsKey y)
            {
                if (x.key > y.key)
                    return y.value.CompareTo(x.value);
                return -1;
            }
        }
    }

}
