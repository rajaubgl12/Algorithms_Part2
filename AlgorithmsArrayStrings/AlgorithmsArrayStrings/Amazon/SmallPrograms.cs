using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
    public class SmallPrograms
    {
        public int CompareVersion(string version1, string version2)
        {
            var numsa = version1.Split('.');
            var numsb = version2.Split('.');
            var maxLen = Math.Max(numsa.Length, numsb.Length);
            for (var i = 0; i < maxLen; ++i)
            {
                var a = i < numsa.Length ? Convert.ToInt32(numsa[i]) : 0;
                var b = i < numsb.Length ? Convert.ToInt32(numsb[i]) : 0;
                if (a > b)
                {
                    return 1;
                }
                else if (b > a)
                {
                    return -1;
                }
            }
            return 0;

        }

        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            string[] strSplit = s.Trim().Split(' ');
            StringBuilder sb = new StringBuilder();

            for (int i = strSplit.Length - 1; i > -1; i--)
            {
                if (!string.IsNullOrEmpty(strSplit[i]))
                    sb.Append(strSplit[i]);
                if (i != 0 && (!string.IsNullOrEmpty(strSplit[i])))
                    sb.Append(" ");
            }

            return sb.ToString();
        }

        public static string ReverseString(String s)
        {
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0, j = s.Length - 1; i < s.Length / 2; i++, j--)
            {
                char t = sb[i];
                sb[i] = sb[j];
                sb[j] = t;
            }

            return sb.ToString();
        }

        public  int [] ReverseArrayInGroup(int[] a, int k)
        {
            int counter = k;
            for (int i = 0; i < a.Length; i += k)
            {
                int endIndex = Math.Min(a.Length - 1, i + counter - 1);
                ReverseArray(a, i, endIndex);
            }

            return a;
        }

        private int [] ReverseArray(int []  a, int startIndex, int endIndex)
        {
            while (startIndex < endIndex && endIndex < a.Length)
            {
                int temp = a[startIndex];
                a[startIndex] = a[endIndex];
                a[endIndex] = temp;
                startIndex++;
                endIndex--;
            }
            return a;
        }

        public  int MaximumPlatformNeeded(int[] a, int[] d)
        {
            Array.Sort(a);
            Array.Sort(d);
            int maxPlatformNeeded = 1;
            int currPlatformCount = 1;
            int indexArr = 1;
            int indexDep = 0;
            while(indexArr<a.Length&&indexDep<d.Length)
            {
                if(a[indexArr]<=d[indexDep])
                {
                    currPlatformCount++;
                    indexArr++;
                    maxPlatformNeeded = Math.Max(currPlatformCount, maxPlatformNeeded);
                }
                else
                {
                    currPlatformCount--;
                    indexDep++;
                }
                
            }

            return maxPlatformNeeded;
        }

        public int PivotIndex(int[] nums)
        {
            int leftSum = 0;
            int totalSum = 0;

            for(int i=0;i<nums.Length;i++)
            {
                totalSum += nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {                
                if (leftSum == totalSum - nums[i] - leftSum) return i;
                leftSum += nums[i];
            }

            return -1;
        }

        public int SubarrayForGivenSum(int[] nums, int k)
        {
            int currSum = 0;
            int startIndex = 0;
            for(int i=0;i<nums.Length;i++)
            {
                currSum += nums[i];
                while (currSum > k)
                {
                    currSum -= nums[startIndex];
                    startIndex++;
                }
                if (currSum==k)
                {
                    return i - startIndex + 1;
                }
                
            }
            return -1;
        }

        
        public int NumOfSubarraysForGivenSum(int[] nums, int k)
        {
            int count = 0, sum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (map.ContainsKey(sum - k))
                    count += map[sum - k];
                if (!map.ContainsKey(sum))
                {
                    map[sum] = 0;
                }
                map[sum] += 1;
            }
            return count;
        }

        public  int LargestSumContiguousArray(int[] a)
        {
            int maxSumTillNow = 0;
            int maxSumCurrent = 0;
            //int startIndex = 0;
            //int maxLen = 0;
            for(int i=0;i<a.Length;i++)
            {
                maxSumCurrent += a[i];
                if (maxSumCurrent < 0)
                {
                    maxSumCurrent = 0;
                    //startIndex = i;
                }
                    
                maxSumTillNow = Math.Max(maxSumTillNow, maxSumCurrent);
                //maxLen = Math.Max(maxLen, i - startIndex + 1);
            }

            return maxSumTillNow;
        }
    }
}
