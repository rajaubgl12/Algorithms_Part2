using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    /// <summary>
    /// https://www.geeksforgeeks.org/recursion/
    /// </summary>
    public class CoinChange
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/coin-change-dp-7/
        /// Given a value N, if we want to make change for N cents, and we have infinite supply 
        /// of each of S = { S1, S2, .. , Sm} 
        /// valued coins, how many ways can we make the change? The order of coins doesn’t matter
        /// For example, for N = 4 and S = {1,2,3}, there are four solutions: {1,1,1,1},{1,1,2},{2,2},{1,3}.
        /// </summary>
        /// <returns></returns>
        public int CoinChangeRec(int[] a, int sum)
        {
            return CoinChangeRecHelper(a, a.Length - 1, sum);
        }

        private int CoinChangeRecHelper(int[] a, int length, int sum)
        {
            if (sum == 0)
                return 1;
            if (length < 0)
                return 0;
            if (sum < 0)
                return 0;
            else
            {
                return CoinChangeRecHelper(a, length, sum - a[length])
                    + CoinChangeRecHelper(a, length - 1, sum);
            }
        }


        #region Dynamic Top Down Approach

        /// <summary>
        /// https://www.youtube.com/watch?v=zAnD3AVufsI
        /// </summary>
        /// <param name="a"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int CoinChangeDP_TopDown(int[] a, int sum)
        {
            int[,] dp = new int[a.Length,sum + 1];
            
             CoinChangeDP_TopDown(a, a.Length-1,sum,dp);
            return dp[a.Length-1,sum];
        }

        private int CoinChangeDP_TopDown(int[] a, int length, int sum, int[,] dp)
        {

            if (sum == 0)
                return 1;
            if (sum < 0 || length < 0)
                return 0;

            if (dp[length,sum] == 0)
            {
                dp[length,sum] = CoinChangeDP_TopDown(a, length, sum - a[length], dp)
                      + CoinChangeDP_TopDown(a, length - 1, sum, dp);
            }

            return dp[length,sum];
        }

        public int CoinchangeDP_TopDown_DFS(int [] a, int sum)
        {
            //Array.Sort(a);
            int[,] dp = new int[a.Length,sum + 1];
            return CoinChangeHelperDFS(a, sum, 0, dp);
        }

        private int CoinChangeHelperDFS(int[] a, int sum, int index, int[,] dp)
        {
            if (sum == 0)
                return 1;
                        
            if (dp[index,sum] != 0)
                return dp[index,sum];

            int count = 0;
            for(int i=index;i<a.Length;i++)
            {
                if (sum - a[i] < 0)
                    continue;
                else
               count += CoinChangeHelperDFS(a, sum - a[i], i, dp);
               
            }
          
            return dp[index,sum] = count;
        }

        #endregion

        #region Dynamic bottom up approach
      
        /// <summary>
        /// Follow this
        /// </summary>
        /// <param name="a"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int CoinChangeDP_MatrixBottomUp(int [] coins, int sum)
        {
            int[,] dp = new int[coins.Length, sum + 1];
            //initialize, Number of ways to select amount 0 is one way.
            dp[0, 0] = 1;

            for(int i=0;i<coins.Length;i++)
            {
                dp[i, 0] = 1; //number of ways to select amount zero is one.

                for(int j=1;j<sum+1;j++)
                {
                    
                    if(i==0)
                    {
                        if (coins[i] <= j)
                            dp[i, j] = dp[i, j - coins[i]];
                    }
                    else 
                    {
                        if (coins[i] <= j)
                            dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i]]; // exclude coin + include coin
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }
            }

            return dp[coins.Length-1, sum];
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="length"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int CoinChangeDP(int[] a, int length, int sum)
        {
            int[] dp = new int[sum + 1];
            dp[0] = 1; // if nothing to change not select any coin is one way
            for (int i = 0; i < length; i++)
            {
                for (int j = a[i]; j < sum + 1; j++) // iterate j for all coins[i]
                {
                    {
                        dp[j] = dp[j] + dp[j - a[i]]; // selecting the coins[i - 1] for amount j
                    }
                }
            }
            return dp[sum];
        }

        #endregion

        

        #region minCoins
        /// <summary>
        /// not working.
        /// </summary>
        /// <param name="deno"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int CoinchangeMinRec(int[] deno, int sum)
        {
            int min = int.MaxValue;
            return CoinchangeMinRecHelper(deno, sum, deno.Length);
        }

        private int CoinchangeMinRecHelper(int[] deno, int sum, int len)
        {
            int min = int.MaxValue;

            if (sum == 0)
            {
                return 0;
            }
            if (len <= 0 || sum < 0)
                return 0;


            else
            {

                int res = CoinchangeMinRecHelper(deno, sum - deno[len - 1], len) +
                    CoinchangeMinRecHelper(deno, sum, len - 1);
                res = res + 1;
                if (min > res)
                {
                    min = res;
                }
            }

            return min;
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=J2eoCvk59Rc&t=531s
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="m"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        public int minCoins(int[] coins, int m, int V)
        {

            // base case 
            if (V == 0) return 0;

            // Initialize result 
            int res = int.MaxValue;

            // Try every coin that has 
            // smaller value than V 
            for (int i = 0; i < m; i++)
            {
                if (coins[i] <= V)
                {
                    int sub_res = minCoins(coins, m,
                                      V - coins[i]);

                    // Check for INT_MAX to  
                    // avoid overflow and see  
                    // if result can minimized 
                    if (sub_res + 1 < res)
                        res = sub_res + 1;
                }
            }
            return res;
        }

       public static int minCoins_dp_bottomUp(int[] coins,
                    int m, int V)
        {
            // table[i] will be storing  
            // the minimum number of coins 
            // required for i value. So  
            // table[V] will have result 
            int[] table = new int[V + 1];

            // Base case (If given 
            // value V is 0) 
            table[0] = 0;

            // Initialize all table 
            // values as Infinite 
            for (int i = 1; i <= V; i++)
                table[i] = int.MaxValue;

            // Compute minimum coins  
            // required for all 
            // values from 1 to V 
            for (int i = 1; i <= V; i++)
            {
                // Go through all coins 
                // smaller than i 
                for (int j = 0; j < m; j++)
                    if (coins[j] <= i)
                    {
                        int sub_res = table[i - coins[j]];
                        if (sub_res != int.MaxValue &&
                            sub_res + 1 < table[i])
                            table[i] = sub_res + 1;
                    }
            }
            return table[V];

        }

        /// <summary>
        /// https://www.youtube.com/watch?v=J2eoCvk59Rc&t=531s
        /// follow this
        /// 
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int MinCoins_DP_bottomup(int [] coins, int sum)
        {
            int[,] dp = new int[coins.Length, sum + 1];

            for(int i =0;i<coins.Length;i++)
            {
                
                for(int j=0;j<sum+1;j++)
                {
                    //min coins required to form a zero amount is zero.
                    dp[i, 0] = 0;
                    if (i == 0)
                    {
                        if (coins[i] <= j)
                            dp[i, j] = 1+ dp[i, j - coins[i]];
                    }
                    else
                    {
                        if (coins[i] <= j)
                        {
                            dp[i, j] = Math.Min(dp[i - 1, j], 1 + dp[i, j - coins[i]]);
                        }                            
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }
            }
            return dp[coins.Length-1, sum];
        }

        #endregion

    }
}
