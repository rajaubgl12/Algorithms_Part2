using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.DynamicProgramming
{
    /// <summary>
    /// Input: word1 = "horse", word2 = "ros"
    //Output: 3
    //Explanation: 
    //horse -> rorse(replace 'h' with 'r')
    //rorse -> rose(remove 'r')
    //rose -> ros(remove 'e')
    ///Input: word1 = "intention", word2 = "execution"
    ///Output: 5
    /// </summary>
   public class LevenshteinDistanceAlg
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=We3YDTzNXEk
        /// https://leetcode.com/problems/edit-distance/
        /// Formula : if (str1[i]==str2[j]) { dp[i,j] = dp[i-1, j-1];}
        ///           else {dp[i,j] = 1+ min(dp[i,j-1], dp[i-1,j-1],dp[i-1,j]) }
        /// </summary>
        /// <param name="strWord1"></param>
        /// <param name="strWord2"></param>
        /// <returns></returns>
        public int LevenshteinDistance(string strWord1, string strWord2)
        {
            int[,] dp = new int[strWord1.Length + 1, strWord2.Length + 1];
            
            for(int i=0;i<strWord1.Length+1;i++)
            {
                dp[i,0] = i;
            }

            for (int i = 0; i < strWord2.Length + 1; i++)
            {
                dp[0, i] = i;
            }

            for (int row=1;row<strWord1.Length+1;row++)
            {
                for(int col=1;col<strWord2.Length+1;col++)
                {
                    if(strWord1[row-1]==strWord2[col-1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        int leftVal = dp[row, col - 1];
                        int diagTopVal = dp[row - 1, col - 1];
                        int topVal = dp[row - 1, col];
                        dp[row, col] = 1 + Math.Min(Math.Min(leftVal, diagTopVal), topVal);
                    }
                }
            }

            return dp[strWord1.Length, strWord2.Length];
        }
    }
}
