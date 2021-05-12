using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    /// <summary>
    /// https://www.geeksforgeeks.org/total-number-of-subsets-of-size-at-most-k/
    /// Given a number N which is the size of the set and a number K, the task is to find the count of subsets, 
    /// of the set of N elements, having at most K elements in it, i.e. the size of subset is less than or equal to K.
    /// Input: N = 3, K = 2
    //Output: 6
    //Subsets with 1 element in it = {1}, {2}, {3}
    //Subsets with 2 elements in it = {1, 2}, {1, 3}, {1, 2}
    //Since K = 2, therefore only the above subsets will be considered for length atmost K.Therefore the count is 6.
    ///  C(n, k) = C(n-1, k-1) + C(n-1, k)
    ///  C(n, 0) = C(n, n) = 1
    ///  
    /// Combination, Binomial coefficient
    /// // Function to compute the value 
    // of Binomial Coefficient C(n, k) 
    /// </summary>
    public class CombinationSubsetOfSizeK
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubsetOfSizeKRec(int n, int k)
        {
            if (n == k)
                return 1;
            if (k == 0) 
                return 1;
            if (n == 0)
                return 1;
            else
                return SubsetOfSizeKRec(n - 1, k - 1) + SubsetOfSizeKRec(n - 1, k);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubsetOfSizeKDP(int n, int k)
        {
            int[,] dp = new int[n + 1, k + 1];
            
            for(int i=0;i<=n;i++)
            {
                //Math.Min(i,k), say for instance n= number of students and k = size of an subset
                // k<=n, size of an subset cannot be more than the number of students.
                for (int j=0;j<=Math.Min(i,k);j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 1;
                    else
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                }
            }
            return dp[n, k];
        }
    }
}
