using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook
{
    class LC_FaceBk_General
    {
        /// <summary>
        /// https://leetcode.com/problems/task-scheduler/discuss/104500/Java-O(n)-time-O(1)-space-1-pass-no-sorting-solution-with-detailed-explanation
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval(char[] tasks, int n)
        {
            int[] counter = new int[26];
            int max = 0;
            int maxCount = 0;
            foreach (char task in tasks)
            {
                counter[task - 'A']++;
                if (max == counter[task - 'A'])
                {
                    maxCount++;
                }
                else if (max < counter[task - 'A'])
                {
                    max = counter[task - 'A'];
                    maxCount = 1;
                }
            }

            int partCount = max - 1;
            int partLength = n - (maxCount - 1);
            int emptySlots = partCount * partLength;
            int availableTasks = tasks.Length - max * maxCount;
            int idles = Math.Max(0, emptySlots - availableTasks);

            return tasks.Length + idles;
        }
        public string MinWindow(string src, string pat)
        {
            if(string.IsNullOrWhiteSpace(src))
            {
                return "";
            }
            if (src.Length < pat.Length)
                return "";
            int[] patMap = new int[128];
            int count = 0;
            int saveFirstIndex = 0;
            bool isFirstIndex = true;
            bool isMatched = false;
            string subString = src;
            if (src == pat)
                return pat;
            if (src.Length == 1 && pat.Length == 1 && src != pat)
                return "";
            //store the occurances of the pattern 
            foreach (char c in pat)
            {
                patMap[c]++;
            }

            //start matching the characters of string with pattern increment if it matches
            for(int i=0; i<src.Length;i++)
            {
                //
                if(patMap[src[i]]>0)
                {
                    count++;                   

                    if(isFirstIndex)
                    {
                        saveFirstIndex = i;
                        isFirstIndex = false;
                    }
                    if (count == pat.Length)
                    {
                        isMatched = true;
                        int subLen = ((i - saveFirstIndex) + 1);
                        if (subString.Length > subLen)
                            subString = src.Substring(saveFirstIndex, subLen);
                        //reset values
                        isFirstIndex = true;
                        count = 0;
                        i--;
                    }
                }
            }
            return isMatched?subString:"";
        }

        public string MinWindow2(string src, string pat)
        {
            src = src.ToLower();
            pat = pat.ToLower();
            int[] map = new int[26];
            int begin = 0, end = 0, head = 0, d = int.MaxValue;
            int counter = 0;
            //store the occurances of the pattern
            foreach (char ch in pat)
            {
                int charIndex = ch - 'a';
                map[charIndex]++;
            }
                
            //loop through the src string
            while (end < src.Length)
            {
                if (map[src[end++]-'a']-- > 0)
                    counter++;

                while (counter == pat.Length)
                {
                    if (d > end - begin)
                        d = end - (head = begin);

                    if (map[src[begin++]-'a']++ == 0)
                        counter--;
                }
            }
            return d == int.MaxValue ? "" : src.Substring(head, d);

        }
        public int Divide(int dividend, int divisor)
        {
            //1. check overflow: 2 ways of over flow 1) 0 divisor; 2) int.Minvalue/(-1)
            if (divisor == 0 || dividend == int.MinValue && divisor == -1) return int.MaxValue;
            //2. calculate sign
            int sign = dividend > 0 ^ divisor > 0 ? -1 : 1, result = 0;
            long m = Math.Abs((long)dividend), n = Math.Abs((long)divisor);
            //3. looping from 1 to possible maximum pow(2, x) to add into result
            while (m >= n)
            {
                long subN = n;
                for (int subCount = 1; m >= subN; subCount <<= 1, subN <<= 1)
                {
                    m -= subN;
                    result += subCount;
                }
            }
            return result * sign;
        }

        public int FindKthLargest(int[] nums, int k)
        {

            //build min Heap O(k)
            for (int j = (k / 2) - 1; j >= 0; j--)
            {
                Minheapify(nums, j, k);
            }

            //(n-k)log(k)
            for (int i = k; i < nums.Length; i++)
            {
                if (nums[0] < nums[i])
                {
                    Swap(nums, 0, i);
                    Minheapify(nums, 0, k);
                }
            }
            return nums[0];
        }

        public void Minheapify(int[] nums, int index, int k)
        {
            var left = (2 * index) + 1;
            if (left >= k)
            {
                return;
            }
            var right = (2 * index) + 2;
            if (right >= k || nums[left] < nums[right])
            {
                if (nums[left] < nums[index])
                {
                    Swap(nums, left, index);
                    Minheapify(nums, left, k);
                }
            }
            else
            {
                if (nums[right] < nums[index])
                {
                    Swap(nums, right, index);
                    Minheapify(nums, right, k);
                }
            }
        }

        private void Swap(int[] nums, int child, int parent)
        {
            var temp = nums[child];
            nums[child] = nums[parent];
            nums[parent] = temp;
        }
    }
}
