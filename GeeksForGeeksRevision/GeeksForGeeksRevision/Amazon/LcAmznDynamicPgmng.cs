using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class LcAmznDynamicPgmng
    {
        //  Climbing Stairs
        public int ClimbStairs(int n)
        {
            if (n < 4)
                return n;
            int n1 = 1;
            int n2 = 2;
            int total = 0;
            for(int i=2;i<n;i++)
            {
                total = n1 + n2;
                n1 = n2;
                n2 = total;
            }
            return total;
        }

        public int BuySellStock(int[] a)
        {
            int curr_min = a[0];
            int max = 0;
            for (int i = 1; i < a.Length; i++)
            {
                max = Math.Max(max, a[i] - curr_min);
                curr_min = Math.Min(curr_min, a[i]);
            }
            return max > curr_min ? max : curr_min;
        }

        public int MaxSubArray(int [] nums)
        {
            var max = int.MinValue;
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum >= 0)
                {
                    sum += nums[i];
                }
                else
                {
                    sum = nums[i];
                }
                max = Math.Max(max, sum);
            }
            return max;
        }
    }
    public class Others
    {
        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i=0;i<nums.Length;i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            foreach(KeyValuePair<int,int> keyVal in dict)
            {
                if (keyVal.Value > 1)
                    return keyVal.Key;
            }
            return -1;
        }
        public int SingleNumber2(int[] nums)
        {
            int x = 0;
            foreach (int num in nums)
            {
                x = x ^ num;
            }

            return x;

        }
        // Returns -1 if celebrity 
        // is not present. If present, 
        // returns id (value from 0 to n-1).
        static int findCelebrity(int n)
        {
            // Initialize two pointers 
            // as two corners
            int a = 0;
            int b = n - 1;

            // Keep moving while 
            // the two pointers
            // don't become same.
            while (a < b)
            {
                if (knows(a, b))
                    a++;
                else
                    b--;
            }

            // Check if a is actually 
            // a celebrity or not
            for (int i = 0; i < n; i++)
            {
                // If any person doesn't 
                // know 'a' or 'a' doesn't
                // know any person, return -1
                if (i != a && (knows(a, i) ||
                              !knows(i, a)))
                    return -1;
            }
            return a;
        }
        // Person with 2 is celebrity
        static int[,] MATRIX = {{ 0, 0, 1, 0 },
                            { 0, 0, 1, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 1, 0 }};

        // Returns true if a knows
        // b, false otherwise
        static bool knows(int a, int b)
        {
            bool res = (MATRIX[a, b] == 1) ?
                                      true :
                                      false;
            return res;
        }

        public int NumOfIslands(int [,] grid)
        {
            int islandCount = 0;
            int rows = grid.GetUpperBound(0) - grid.GetLowerBound(0) ;
            int cols = grid.GetUpperBound(1) - grid.GetLowerBound(1) ;
            for (int i=0;i<rows;i++)
            {
                for(int j =0;j<cols;j++)
                {
                    if (grid[i, j] == 1)
                    {
                        //increase the island count.
                        islandCount++;

                        //change any  other land connected to zero as all connected lands are one island.
                        ZeroDownConnectedIslands(grid,i,j);
                    }                        
                }
            }
            return islandCount;
        }

        private void ZeroDownConnectedIslands(int[,] grid, int i, int j)
        {
            //base condition
            if (i < 0 || i > grid.GetUpperBound(0) || j < 0 || j > grid.GetLowerBound(1) || grid[i, j] == 0)
                return;
            grid[i, j] = 0;
            ZeroDownConnectedIslands(grid, i + 1, j); // right
            ZeroDownConnectedIslands(grid, i - 1, j); //left
            ZeroDownConnectedIslands(grid, i, j+1); //top
            ZeroDownConnectedIslands(grid, i, j-1); //bottom
        }

        public int[] MaxSlidingWindowSizeK(int[] nums, int k)
        {
            if (nums == null || nums.Length < 1)
                return new int[0];
            int[] maxOfSubArray = null;
            if (nums.Length <= k)
            {
                maxOfSubArray = new int[nums.Length];
                Array.Copy(nums, maxOfSubArray, nums.Length);
                return maxOfSubArray;
            }
            else
            {
                maxOfSubArray = new int[nums.Length - k + 1];
            }
                
            int max = 0;
            for (int j = 0; j < k; j++)
            {
                if (nums[j] > max)
                    max = nums[j];
            }
            
            int index = 0;
            maxOfSubArray[index] = max;
            index++;
            
            for (int i = k; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                }
                maxOfSubArray[index] = max;
                index++;
            }
            return maxOfSubArray;
        }

        public int[] MaxSlidingWindow2(int[] nums, int k)
        {
            List<int> res = new List<int>();
            int maxIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                while (i < k)
                {
                    if (i < nums.Length)
                    {
                        maxIndex = nums[maxIndex] > nums[i] ? maxIndex : i;
                        i++;
                        if (i == k) res.Add(nums[maxIndex]);
                    }
                    else break;
                }
                if (i == nums.Length)
                {
                    return res.ToArray();
                }
                if (maxIndex < i - k + 1)
                {
                    maxIndex = i - k + 1;
                    for (int j = i - k + 2; j <= i; j++)
                    {
                        if (nums[j] > nums[maxIndex]) maxIndex = j;
                    }

                }
                else
                {
                    maxIndex = nums[maxIndex] > nums[i] ? maxIndex : i;
                }
                res.Add(nums[maxIndex]);
            }
            return res.ToArray();
        }

        //https://www.youtube.com/watch?v=OXLgNDt4QMY

        public String MinWindowSubstring(String s, String t)
        {
            if (t.Length > s.Length)
                return "";
            String result = "";
            //character counter for t
            Dictionary<Char, int> target = new Dictionary<Char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                char c = t[i];
                if (target.ContainsKey(c))
                {
                    // target.Add(c, target[c] + 1);
                    target[c]++;
                }
                else
                {
                    target.Add(c, 1);
                }
            }
            // character counter for s
            Dictionary < Char, int> map = new Dictionary<Char, int>();
            int left = 0;
            int minLen = s.Length + 1;
            int count = 0; // the total of mapped characters
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (target.ContainsKey(c))
                {
                    if (map.ContainsKey(c))
                    {
                        if (map[c] < target[c])
                        {
                            count++;
                        }
                        map[c]++;
                    }
                    else
                    {
                        map.Add(c, 1);
                        count++;
                    }
                }
                if (count == t.Length)
                {
                    char sc = s[left];
                    while (!map.ContainsKey(sc) || map[sc] > target[sc])
                    {
                        if (map.ContainsKey(sc) && map[sc] > target[sc])
                            //map.Add(sc, map[sc] - 1);
                            map[sc]--;
                        left++;
                        sc = s[left];
                    }
                    if (i - left + 1 < minLen)
                    {
                        //result = s.Substring(left, i + 1);
                        minLen = i - left + 1;
                        result = s.Substring(left, minLen);
                    }
                }
            }
            return result;
        }

        public string MinWindowSubstringOpt(string s, string t)
        {
            int[] map = new int[128];
            int begin = 0, end = 0, head = 0, d = int.MaxValue;
            int counter = t.Length;
            foreach (char ch in t) map[ch]++;
            while (end < s.Length)
            {
                if (map[s[end++]]--   > 0)

                    counter--;

                while (counter == 0)
                {
                    if (d > end - begin)
                        d = end - (head = begin);

                    if (map[s[begin++]]++ == 0)
                        counter++;
                }
            }
            return d == int.MaxValue ? "" : s.Substring(head, d);
        }

        /// <summary>
        /// Not working
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MaxWindowSubstringOpt(string s, string t)
        {
            int[] map = new int[128];
            int begin = 0, end = 0, head = 0, d = int.MaxValue;
            int counter = t.Length;
            foreach (char ch in t) map[ch]++;
            while (end < s.Length)
            {
                if (map[s[end++]]-- > 0)

                    counter--;

                while (counter == 0)
                {
                    if (d < end - begin)
                        d = end - (head = begin);

                    if (map[s[begin++]]++ == 0)
                        counter++;
                }
            }
            return d == int.MaxValue ? "" : s.Substring(head, d);
        }
    }    

}
