using System;
using System.Collections.Generic;

namespace AlgorithmsArrayStrings.General
{
    #region Knapsack
    public class Knapsack_CoinChange
    {

        /// <summary>
        /// Fraction for last value
        /// </summary>
        /// <param name="Capacity"></param>
        /// <param name="wt"></param>
        /// <param name="val"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public float KnapsackAlg(int Capacity, int[] wt, int[] val, int n)
        {
            List<KnapsackData> lstKnapsacks = BuildKnapsackData(wt, val);

            int bagCapacity = 0;
            float totalValue = 0;
            foreach (KnapsackData data in lstKnapsacks)
            {
                //bagCapacity += data._weight;
                if (bagCapacity + data._weight < Capacity)
                {
                    bagCapacity += data._weight;
                    totalValue += data._value;
                }
                else
                {
                    if (bagCapacity < Capacity)
                    {
                        totalValue = totalValue + data._ratio * (Capacity - bagCapacity);
                    }
                    break;
                }
            }

            return totalValue;
        }


        private List<KnapsackData> BuildKnapsackData(int[] wt, int[] val)
        {
            List<KnapsackData> lst = new List<KnapsackData>();
            for (int i = 0; i < wt.Length; i++)
            {
                KnapsackData obj = new KnapsackData(wt[i], val[i], val[i] / wt[i]);
                lst.Add(obj);
            }
            CustComparer objComp = new CustComparer();
            lst.Sort(objComp);
            return lst;
        }

    }

    public class CustComparer : IComparer<KnapsackData>
    {
        
        public int Compare(KnapsackData a, KnapsackData b)
        {
            if (a._ratio > b._ratio)
                return -1;
            else
                return 1;
        }
    }

    public class KnapsackData
    {
        public int _weight;
        public int _value;
        public float _ratio;
        public KnapsackData(int weight, int value, int ratio)
        {
            _weight = weight;
            _value = value;
            _ratio = ratio;
        }
    }

    #endregion

    #region coinchange
    /*
     You are given coins of different denominations and a total amount of money amount. 
     Write a function to compute the fewest number of coins that you need to make up that amount. 
     If that amount of money cannot be made up by any combination of the coins, return -1.
        Example 1:
        Input: coins = [1, 2, 5], amount = 11
        Output: 3 
        Explanation: 11 = 5 + 5 + 1

     */
    public class CoinChangeAlg
    {
        /// <summary>
        /// This algorithm doesn't work in all the cases, it considers first coins to be always part of the denomination.
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            Array.Sort(coins);
            int minDenomCount = 0;
            for (int i = coins.Length - 1; i > -1; i--)
            {
                while (amount >= coins[i])
                {
                    amount -= coins[i];
                    minDenomCount++;
                }
                if (amount == 0)
                    return minDenomCount;
            }
            if (minDenomCount == 0 || amount > 0)
                return -1;

            return minDenomCount;
        }

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

        public int NoOfWaysCoinChangeDynamic(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
           //base case if a given value is zero.
            dp[0] = 1;
            for (int j = 0; j < coins.Length; j++)
            {

                for (int i = coins[j]; i < amount + 1; i++)
                {
                    dp[i] += dp[i - coins[j]];
                }
            }

            return dp[amount];
        }

        /// <summary>
        /// https://leetcode.com/problems/coin-change/solution/
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int MinCoinsAmount(int [] coins, int amount)
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
    }

    #endregion
}
