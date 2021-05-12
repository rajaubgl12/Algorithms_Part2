using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    /// <summary>
    /// https://www.youtube.com/watch?v=jgiZlGzXMBw
    /// </summary>
    public class CoinChangeAlg
    {
        /// <summary>
        /// bottom up approach
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChangeDynamic(int [] coins, int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = max;
            }
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j])
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }


        public int CoinChange(int[] coins, int amount)
        {
            if (coins.Length == 1
                && coins[0] == 1)
                return amount;

            if (coins.Length == 1
                && coins[0] > 1
                && amount < coins[0])
                return -1;

            if (coins.Length == 1 && coins[0] > 1
                && amount > coins[0]
                && (amount % coins[0] == 0))
                return amount / coins[0];

            if (coins.Length == 1 && coins[0] > 1
                && amount > coins[0]
                && (amount % coins[0] != 0))
                return -1;

            int minCount = 0;
            //int dividend = 0;
            Array.Sort(coins);

            for (int i = coins.Length - 1; i >= 0; i--)
            {
                if (coins[i] > amount)
                    continue;

                minCount += amount / coins[i];
                amount = amount % coins[i];
            }

            return minCount;
        }

        public int CoinChangeInfiniteChange(int [] coins, int amount)
        {
            return CoinChangeInfiniteChangeRec(coins, coins.Length, amount);
        }

        private int CoinChangeInfiniteChangeRec(int[] coins, int length, int amount)
        {
            if (amount == 0)
                return 1;
            if (amount < 0)
                return 0;
            if (length <= 0 && amount >=1)
                return 0;

            return CoinChangeInfiniteChangeRec(coins, length - 1, amount) 
                + CoinChangeInfiniteChangeRec(coins, length, amount - coins[length - 1]);
        }
    }
}
