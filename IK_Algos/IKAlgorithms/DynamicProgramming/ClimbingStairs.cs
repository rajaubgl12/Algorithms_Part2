using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    /// <summary>
    /// You are climbing a stair case. It takes n steps to reach to the top.
    /// https://leetcode.com/problems/climbing-stairs/
    //Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    /// f(n) = f(n-1) + f(n-2)
    /// </summary>
    public class ClimbingStairs
    {
        public int ClimbStairsRec(int n)
        {
            if (n == 0 || n == 1 || n == 2)
                return n;

            return ClimbStairsRec(n - 1) + ClimbStairsRec(n - 2);

        }

        public int ClimbStairsDP(int n)
        {
            if (n == 0)
                return n;
            int[] memo = new int[n + 1];
            memo[0] = 0;
            memo[1] = 1;
            memo[2] = 2;
            for (int i = 3; i < n + 1; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }
            return memo[n];
        }

        /// <summary>
        /// https://leetcode.com/problems/min-cost-climbing-stairs/
        /// Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
        /// Output: 6
        ///Explanation: Cheapest is start on cost[0], and only step on 1s, skipping cost[3]
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int[] dp = new int[cost.Length];
            dp[0] = cost[0];
            dp[1] = cost[1];

            for (int i = 2; i < cost.Length; i++)
            {
                dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
            }

            return Math.Min(dp[dp.Length - 1], dp[dp.Length - 2]);
        }

        /// <summary>
        /// Example One  Input: n=1, steps=[1, 2] Output: 1 Only one way to reach: [{1}] 
        /// Example Two Input: n=2, steps=[1, 2] Output: 2 Two ways to reach: [{1, 1}, {2}]
        /// Example Three Input: n=7, steps=[2, 3] Output: 3 Three ways to reach: [{2, 2, 3}, {2, 3, 2}, {3, 2, 2}]
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public long CountWaysToClimb(int[] steps, int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[steps[0]] = 1;
            if (n == 1)
                return dp[0];

            for(int i= steps[0]+1; i<n+1;i++)
            {
                for(int j=0;j<steps.Length;j++)
                {
                    if(steps[j]<=i)
                    dp[i] += dp[i - steps[j]];
                }
            }
            return dp[n];
        }
    }
}
