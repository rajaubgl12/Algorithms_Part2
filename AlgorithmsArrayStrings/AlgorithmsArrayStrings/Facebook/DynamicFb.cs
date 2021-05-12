using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Facebook
{
   public class DynamicFb
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            if (nums.Length == 0 || nums.Length == 1)
                return false;

            for (int i = 0; i < nums.Length; i++)
            {
                int sum = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum += nums[j];

                    if (k == 0 && sum != 0)
                        continue;
                    if (k == 0 && sum == 0)
                        return true;


                    if (sum % k == 0)
                        return true;
                }
            }
            return false;

        }

        /// <summary>
        /// sum = sum + num[i]
        /// sum = sum%k
        /// add to dictionary
        /// check contains remainder
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySumDictionary(int[] nums, int k)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            int sum = 0;
            keyValuePairs.Add(0, -1);
            for(int i=0;i<nums.Length;i++)
            {
                sum += nums[i];
                if(k!=0)
                sum = sum % k;
                if(keyValuePairs.ContainsKey(sum))
                {
                    if (i - keyValuePairs[sum] > 1)
                        return true;
                }
                else
                {
                    keyValuePairs[sum] = i;
                }
            }
            return false;
        }
    }
}
