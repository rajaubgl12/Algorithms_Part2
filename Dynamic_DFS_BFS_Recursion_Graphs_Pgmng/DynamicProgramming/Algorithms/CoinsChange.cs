using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Algorithms
{
    class CoinsChange
    {      

      
        /// <summary>
        /// How many ways one can have a change for the given money.
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int NoOfWaysCoinChangeRecursive(int[] coins, int amount)
        {
            int len = coins.Length;
            return NoOfWaysCoinChangeRecFunc(coins, len, amount);
        }

        private int NoOfWaysCoinChangeRecFunc(int[] coins, int len, int amount)
        {
            if (amount == 0)
                return 1;
            //if amount is less than 0  then there is no combination
            if (amount < 0)
                return 0;
            //if there are no coins and amount is greater than zero then no solution exists.
            if (len <= 0 && amount > 0)
                return 0;
            return NoOfWaysCoinChangeRecFunc(coins, len - 1, amount)
                + NoOfWaysCoinChangeRecFunc(coins, len, amount - coins[len - 1]);
        }

        /// <summary>
        /// https://leetcode.com/problems/coin-change-2/solution/
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int NoOfWaysCoinChangeDynamic(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            //base case if a given value is zero.
            dp[0] = 1;
            for (int j = 0; j < coins.Length; j++)
            {
                for (int i = coins[j]; i < amount + 1; i++)
                {
                    dp[i] = dp[i] + dp[i - coins[j]];
                }
            }

            return dp[amount];
        }

         
        /// <summary>
        /// https://leetcode.com/problems/coin-change/solution/
        /// Logic: calculate the min coins required for each number of the amount.
        /// have amount as first loop and coins in second loop.
        /// calculate which denomination can make it min combination result to amount.
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int MinCoinsAmount(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];

            for (int i = 1; i <= amount; i++)
            {
                int minCoins = amount + 1;
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        minCoins = Math.Min(minCoins, dp[i - coins[j]] + 1);
                    }
                }
                dp[i] = minCoins;
            }

            if (dp[amount] > amount)
                return -1;

            return dp[amount];
        }

        public int ClimbStairs(int [] steps, int totalSteps)
        {
            int numWays = ClimbStairsCount(steps, steps.Length-1, totalSteps);
            return numWays;
        }

        private int ClimbStairsCount(int[] steps, int len, int totalSteps)
        {
            if (totalSteps < 0)
                return 0;
            if (totalSteps == 0)
                return 1;
            if (totalSteps >= 0 && len < 0)
                return 0;
            else
                return ClimbStairsCount(steps, len - 1, totalSteps)
                    + ClimbStairsCount(steps, len, totalSteps - steps[len]);
        }

        public int ClimbStairsCountDynamic(int steps, int [] memo)
        {
            if (steps < 0)
                return 0;
            if (steps == 0)
                return 1;
            if (memo[steps] == 0)
                memo[steps] = ClimbStairsCountDynamic(steps - 1, memo) + ClimbStairsCountDynamic(steps - 2, memo);

            return memo[steps];
        }
        public int ClimbStairsCountDynamicBottomUp(int steps, int[] memo)
        {
            
            //initialize the array.
                memo[0] = 1;            
                memo[1] = 1;
            for(int i=2;i<steps+1;i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }

            return memo[steps];
        }
    }
}
