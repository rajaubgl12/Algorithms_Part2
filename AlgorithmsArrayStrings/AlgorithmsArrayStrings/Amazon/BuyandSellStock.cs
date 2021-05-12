using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
    public class BuyandSellStock
    {
        /// <summary>
        /// Best Time to Buy and Sell Stock
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int curr_min = prices[0];
            int max = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                curr_min = Math.Min(curr_min, prices[i]);
                max = Math.Max(max, prices[i] - curr_min);
            }
            return max > 0 ? max : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxTotalBuySellProfit(int[] prices)
        {
            var profit = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] - prices[i - 1] > 0)
                {
                    profit += prices[i] - prices[i - 1];
                }
            }
            return profit;
        }

        public int MaxTotalBuySellProfitIII(int[] prices)
        {
            int [] left = new int[prices.Length];
            int [] right = new int[prices.Length];

            // max profit for a transaction on the left
            int min = prices[0];
            int maxProfitL = 0;
            for (int i = 0; i < prices.Length; ++i)
            {
                min = Math.Min(min, prices[i]);
                maxProfitL = Math.Max(maxProfitL, prices[i] - min);
                left[i] = maxProfitL;
            }

            // max profit for a transaction on the right
            int max = prices[prices.Length - 1];
            int maxProfitR = 0;
            for (int i = prices.Length - 1; i > 0; --i)
            {
                max = Math.Max(max, prices[i]);
                maxProfitR = Math.Max(maxProfitR, max - prices[i]);
                right[i] = maxProfitR;
            }

            //Get max from left and right
            int maxProfit = 0;
            for(int i=0;i<prices.Length;i++)
            {
                maxProfit = Math.Max(maxProfit, left[i] + right[i]);
            }
            return maxProfit;
        }

        public int MaxProfitIV(int k, int[] prices)
        {
            // A transaction is defined as a Buy and a Sell
            if (prices == null || prices.Length == 0 || k == 0) return 0;
            int tranNumber = k * 2;
            int len = prices.Length;
            if (k >= len / 2) return QuickSolve(prices);

            int[] dp = new int[tranNumber];

            // Even indexed items in the array indicate purchases, odd indicate sales
            for (int i = 0; i < tranNumber; i++)
                dp[i] = i % 2 == 0 ? int.MinValue : 0;

            foreach (int price in prices)
            {
                // the first item in the array indicates the amount of money
                // we have after the first day. Notice this value must be negative, 
                // since on the first day we have no choice but to buy. 
                dp[0] = Math.Max(dp[0], -price);

                // On each day, we update all of our values for each of our possible transactions. 
                for (int i = 1; i < tranNumber; i++)
                {
                    // Recall from earlier comment that even indexed values are purchases, hence we deduct the price 
                    // of the stock from our total amount. (Think of it like "I bought a $10 stock, therefor I have 10 less dollars)
                    int dif = i % 2 == 0 ? -price : price;

                    // Now we have a choice to make. Is it better to simply hold with what we have,
                    // or is it better to apply the difference to the previous transacation? 
                    // A further explanation of this is as follows....

                    // I can apply today' buy or sell to my previous transaction, but I'll only do that if 
                    // I experience a net gain as a result. Otherwise, I'm not going to do anything - I'll just hold with what I have
                    dp[i] = Math.Max(dp[i], dp[i - 1] + dif);
                }
            }

            return dp[tranNumber - 1];
        }

        private int QuickSolve(int[] prices)
        {
            // If we reach here, it means we are allowed more transactions 
            // then there are days, so we can just buy and sell for every single 
            // valley and peak. 

            int len = prices.Length;
            int profit = 0;
            for (int i = 1; i < len; i++)
                if (prices[i] > prices[i - 1])
                    profit += prices[i] - prices[i - 1];
            return profit;
        }

        public int MaxProfitIV_2(int k, int[] prices)
        {
            int n = prices.Length;
            if (n < 2 || k == 0) return 0;

            // if k==1
            if (k == 1)
            {
                int sum = 0;
                int min = prices[0];
                for (int i = 1; i < n; i++)
                {
                    int temp = prices[i] - min;
                    if (sum < temp)
                    {
                        sum = temp;
                    }
                    else if (temp < 0)
                    {
                        min = prices[i];
                    }
                }
                return sum;
            }

            /* max transaction one can do is n/2 and if k is greater than that then simply use the solution of multiple transactions on this problem*/
            if (k >= n / 2)
            {
                int sum = 0;
                for (int i = 1; i < n; i++)
                {
                    int temp = prices[i] - prices[i - 1];
                    if (temp > 0)
                    {
                        sum += temp;
                    }
                }
                return sum;
            }

            // if 1<k<n/2
            // array to store max profit if (0-k) transactions are being done at any given index; 
            //max values will get updated as we traverse the prices array
            int[] trans = new int[k];
            //array to store max value if (0-k) transactions are being done with one buy;
            //max values will get update as we traverse the prices array
            int[] transOneBuy = new int[k]; 

            for (int j = 0; j < k; j++)
            {
                transOneBuy[j] = -prices[0];
            }

            /* so the logic is: For any given day (index i), we will check 1) if a transations if being made on ith day 2) 
             * if we are buying stock on ith day; will compare both of these value with prev day value;*/

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (j > 0)
                    {
                        transOneBuy[j] = Math.Max(transOneBuy[j], trans[j - 1] - prices[i]);
                    }
                    else
                    {
                        transOneBuy[j] = Math.Max(transOneBuy[j], -prices[i]);
                    }
                    trans[j] = Math.Max(trans[j], transOneBuy[j] + prices[i]);
                }
            }
            return trans[k - 1];
        }

    }
}
