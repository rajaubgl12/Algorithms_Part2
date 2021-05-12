using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    /// <summary>
    /// https://www.geeksforgeeks.org/cutting-a-rod-dp-13/
    /// Given a rod of length n inches and an array of prices that contains prices of all pieces of size smaller than n. 
    /// Determine the maximum value obtainable by cutting up the rod and selling the pieces. 
    /// For example, if length of the rod is 8 and the values of different pieces are given as following,
    /// then the maximum obtainable value is 22 (by cutting in two pieces of lengths 2 and 6) 
    //length   | 1   2   3   4   5   6   7   8  
    //--------------------------------------------
    //price    | 1   5   8   9  10  17  17  20
    //And if the prices are as following, then the maximum obtainable value is 
    ///24 (by cutting in eight pieces of length 1) 
    /// </summary>
    public class CuttingRod
    {
        public int CutRod(int [] price, int len)
        {
            int maxPrice = CutRodMaxHelper(price, len);
            return maxPrice;
        }

        private int CutRodMaxHelper(int [] price, int len )
        {
            //when len is 0 then price is zero. so return zero.
            if (len <= 0)
                return 0;
            //initialize
            int maxPrice = -1;

            for (int i = 0; i < len; i++)
            {
                //calculate price at 
                maxPrice = Math.Max( maxPrice , price[i] + CutRodMaxHelper(price, len - i-1));
            }

            return maxPrice;
        }

        private int CutRodMaxTopDownDP(int[] price, int len, int [] dp)
        {
            //when len is 0 then price is zero. so return zero.
            if (len <= 0)
                return 0;

            if (dp[len] != 0)
                return dp[len];


            //initialize
            int maxPrice = -1;
            
            for (int i = 0; i < len; i++)
            {
                //calculate price at 
                maxPrice = Math.Max(maxPrice, price[i] + CutRodMaxHelper(price, len - i - 1));
            }
            dp[len] = maxPrice;
            return maxPrice;
        }

        /// <summary>
        /// dp len will be len+1 because it needs initial value dp[0] = 0
        /// </summary>
        /// <param name="price"></param>
        /// <param name="len"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        private int CutRodMaxBottomeUpIterativeDP(int[] price, int L, int[] dp)
        {
            
            dp[0] = 0;
            dp[1] = price[1];

            for (int len = 2; len < L+1; len++)
            {
                int result = -1;
                for(int cut=0;cut<len;cut++)
                {
                    result = Math.Max(result, price[cut] + dp[len - cut]);
                }
                dp[len] = result;
            }
            
            return dp[L];
        }

    }
}
