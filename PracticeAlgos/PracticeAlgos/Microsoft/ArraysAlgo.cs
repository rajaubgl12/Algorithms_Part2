using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgos.Microsoft
{
   public class ArraysAlgo
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/frequent-element-array/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static int mostFrequent(int[] arr, int n)
        {

            // Sort the array 
            Array.Sort(arr);

            // find the max frequency using  
            // linear traversal 
            int max_count = 1, res = arr[0];
            int curr_count = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1])
                    curr_count++;
                else
                {
                    if (curr_count > max_count)
                    {
                        max_count = curr_count;
                        res = arr[i - 1];
                    }
                    curr_count = 1;
                }
            }

            // If last element is most frequent 
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = arr[n - 1];
            }

            return res;
        }

        //find maximum consecutive repeating character in string.
        //Input : str = "aaaaaabbcbbbbbcbbbb"
        //Output :a
        public char MaxRepeatingChars(string input)
        {
            Dictionary<char, int> dictChars = new Dictionary<char, int>();
            for(int i=0;i<input.Length;i++)
            {
                if(dictChars.ContainsKey(input[i]))
                {
                    dictChars[input[i]]++;
                }
                else
                {
                    dictChars.Add(input[i], 1);
                }
            }
            var keyVal = dictChars.OrderByDescending(x=>x.Value).FirstOrDefault();
            return keyVal.Key;
        }

        public char MaxRepeatingConsecutiveChars(string input)
        {
            int maxCount = 0;
            char maxChar = ' ';
            int preCount = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if(input[i]==input[i-1])
                {
                    preCount++;
                }
                else
                {
                    preCount++;
                    if (preCount>maxCount)
                    {
                        maxCount = preCount;
                        maxChar = input[i - 1];
                    }
                    preCount = 0;
                }
            }
            return maxChar;  
        }

        public void MergeSortedArray(int [] a, int [] b)
        {
            int[] MergedArray = new int[(a.Length+b.Length)];
            int aIndex = 0;
            int bIndex = 0;
            int cIndex = 0;
            while(aIndex<a.Length&&bIndex<b.Length)
            {
                if(a[aIndex]<b[bIndex])
                {
                    MergedArray[cIndex] = a[aIndex];
                    aIndex++;
                }
                else
                {
                    MergedArray[cIndex] = b[bIndex];
                    bIndex++;
                }
                cIndex++;
            }
            while(aIndex<a.Length)
            {
                MergedArray[cIndex] = a[aIndex];
                aIndex++;
                cIndex++;
            }
            while(bIndex<b.Length)
            {
                MergedArray[cIndex] = b[bIndex];
                bIndex++;
                cIndex++;
            }
        }

        //public void MoveNegativeLeft(int [] a)
        //{
        //    int endIndex = a.Length - 1;
        //    int i = 0;
        //    while(i<endIndex)
        //    {
        //        if(a[i]>=0)
        //        {
                    
        //            while(a[endIndex]>=0 && endIndex>0)
        //            {
        //                endIndex--;
        //            }
        //            int temp = a[i];
        //            a[i] = a[endIndex];
        //            a[endIndex] = temp;
        //        }
        //        i++;
        //    }
        //}

        public void MoveNegativeLeft2(int[] arr)
        {

            int j = 0, temp;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j++;
                }
            }
        }

        public void MoveZeroLeft(int[] arr)
        {

            int j = 0, temp;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j++;
                }
            }
        }

        /// <summary>
        /// second method is sort an array , find difference i=0, j=1
        /// https://www.geeksforgeeks.org/find-a-pair-with-the-given-difference/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="diff"></param>
        public void FindPairForDiff(int [] a, int diff)
        {
            Dictionary<int, int> valuePairs = new Dictionary<int, int>();

            for (int i=0;i<a.Length;i++)
            {                
                {
                    valuePairs.Add(a[i],i);
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (valuePairs.ContainsKey(a[i] + diff))
                {
                    Console.WriteLine("Pair is {0} {1}", a[i] + diff, a[i]);
                }
               
            }
        }

        public void PrintAllPairsGivenSum(int [] a, int sum)
        {
            Array.Sort(a);

        }
        public int CountAllPairsGivenSum(int[] a, int sum)
        {
            Dictionary<int, int> valuePairs = new Dictionary<int, int>();
            int countPairs = 0;
            for(int i=0;i<a.Length;i++)
            {
                if(valuePairs.ContainsKey(a[i]))
                {
                    valuePairs[a[i]]++;
                }

                else
                {
                    valuePairs.Add(a[i], 1);
                }
            }

            for(int i=0;i<a.Length;i++)
            {
                if(valuePairs.ContainsKey(sum-a[i]))
                {
                    countPairs+=valuePairs[sum-a[i]];
                }
                if(sum-a[i]==a[i])
                {
                    countPairs--;
                }
            }
            return countPairs / 2;
        }

        public int LongestSubstringNonRepeating(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int maxLength = 0;
            int length = 0;
            int indexStart = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // Unique char found
                if (!dict.ContainsKey(s[i]) || dict[s[i]] < indexStart)
                {
                    length++;
                    dict[s[i]] = i;
                }
                // Non-unique char
                // move the start index to the next index of prev occured character index = dict[s[i]]+1;
                //length = i-index+1;
                //update the repeated character index to the current index dict[s[i]] =i;
                // second option use characters 256 https://www.geeksforgeeks.org/length-of-the-longest-substring-without-repeating-characters/
                else
                {
                    indexStart = dict[s[i]] + 1;
                    length = i - indexStart + 1;
                    dict[s[i]] = i;
                }

                maxLength = Math.Max(maxLength, length);
            }

            return maxLength;
        }

        /// <summary>
        /// string str= "the quick brown fox had jumped over the brown wall very quick"
        ///1. Max repeated words , if count same return longest word
        ///2. if count same and length return all those same len and count words.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string [] GetMaxOccuranceWord(string str)
        {
                           
            string[] wrdsList = str.Split(' ');
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            int maxCount = 0;
            int currCount = 0;
            string maxOccString = "";
            for (int i=0;i<wrdsList.Length;i++)
            {
                if (keyValues.ContainsKey(wrdsList[i]))
                {
                    currCount++;
                }
                else
                {
                    keyValues.Add(wrdsList[i], wrdsList[i].Length);
                }
                if(currCount>maxCount)
                {
                    maxCount = currCount;
                    maxOccString = wrdsList[i];
                    
                }
            }
            foreach(KeyValuePair<string,int> keyValue in keyValues)
            {
                if(keyValue.Value==maxCount)
                {
                    
                }
            }

            return null;
        }
    }
}
