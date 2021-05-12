using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Google
{
    class DynamicProgramming
    {
        

        /// <summary>
        /// https://www.geeksforgeeks.org/coin-change-dp-7/
        /// Given a value N, if we want to make change for N cents, and we have infinite supply of each of 
        /// S = { S1, S2, .. , Sm} valued coins, how many ways can we make the change? The order of coins doesn’t matter.
        ///For example, for N = 4 and S = { 1, 2, 3 }, there are four solutions: {1,1,1,1},{1,1,2},{2,2},{1,3}. 
        ///So output should be 4. For N = 10 and S = { 2, 5, 3, 6 }, there are five solutions: {2,2,2,2,2}, {2,2,3,3}, {2,2,6}, {2,3,5} 
        ///and {5,5}. So the output should be 5.
        /// </summary>
        /// <returns></returns>
        public int  CoinChangeGeeks(int [] denom, int amount)
        {
            return CoinChangeGeeksSub(denom, denom.Length, amount);

        }

        private int CoinChangeGeeksSub(int[] denom, int length, int amount)
        {
            //subtracting the amount, if it becomes zero
            if (amount == 0)
                return 1;
            //if amount becomes less than zero , then so solution exists.
            if (amount < 0)
                return 0;
            //if subtracting from denom gets over meaning no coins exists
            //and remaining amount still greater than zero then no combination exists.
            if (length <= 0 && amount > 0)
                return 0;
            return CoinChangeGeeksSub(denom, length - 1, amount)
                + CoinChangeGeeksSub(denom, length, amount - denom[length - 1]);
        }
    }
}