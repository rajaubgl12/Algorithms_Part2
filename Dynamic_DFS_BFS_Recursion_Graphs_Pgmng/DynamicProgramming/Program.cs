using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProgramming.Algorithms;
using DynamicProramming;
using DynamicProramming.Algorithms;
using DynamicProramming.GeeksGeeks;
using DynamicProramming.Recursion;

namespace DynamicProgramming
{
    class Program
    {
        
        static void Main(string[] args)
        {

            #region GraphsAlgorithms_IK

            #region recursive
            //RecursiveAlgoMain();
            #endregion

            #region amazon
            #endregion

            #region facebook
            #endregion

            #region google
            #endregion

            #region microsoft
            #endregion

            #region geeksgeeks

            GeeksAlgosMain();
            
            #endregion

            #region leetcode

            #endregion

            #region general
            //CoinsChangeSimilarPgmMain();
            //SubstringsAlgorithmMain();
            //SubstringsAlgorithmMain();
            //SubsequenceAlgorithmMain();
            #endregion
        }

        #region recursive
        private static void RecursiveAlgoMain()
        {
            RecursionPractice practice = new RecursionPractice();

            //int res1 = practice.CountNum(1234);
            //int res2 = practice.CountNumRecursive(1234);

            ////Linked list node

            //ListNode node = new ListNode(1);
            //node.next = new ListNode(2);
            //node.next.next = new ListNode(3);
            //node.next.next.next = new ListNode(4);
            //node.next.next.next.next = new ListNode(5);

            //int res3 = practice.LengthOfLinkedList(node);
            //int res4 = practice.LengthOfLinkedListRecursive(node);

            int res5 = practice.GCD(24,18);
            string revStr = "abcd";
            string rev = practice.Reverse(revStr, revStr.Length-1);

            string strVow = "HELLOAIR";
            int count = practice.TotalVowels(strVow,strVow.Length-1);
        }
        #endregion

        #region amazon
        #endregion

        #region facebook
        #endregion

        #region google
        #endregion

        #region microsoft
        #endregion

        #region geeksgeeks
        private static void GeeksAlgosMain()
        {
            AlgosGeeks obj = new AlgosGeeks();
            //obj.GenerateAllBinaryStrings(3);
            
            Backtracking objBack = new Backtracking();
            //int[] a = { 1,2,3};
            //IList<IList<int>> res =  objBack.Permute(a);

            // int [,] a = objBack.SolveNQueens(4);

            int[,] maze = { { 1, 0, 0, 0 },
                         { 1, 1, 0, 1 },
                         { 0, 1, 0, 0 },
                         { 1, 1, 1, 1 } };
            int[,] res = objBack.RatInMaze(maze);
            
        }
        #endregion

        #region leetcode
        #endregion

        #region general
        private static void SubsequenceAlgorithmMain()
        {
            SubsequenceAlgos subSeq = new SubsequenceAlgos();
            //int[] a = {10,9,2,5,3,4};//{ 10, 9, 2, 5, 3, 7, 101, 18 };
            //int res = subSeq.LengthOfLIS(a);
            //int[] a = { 1, 2, 3, 4 };
            //IList<IList<int>> lstRes = subSeq.FindIncreasingSubsequences(a);
            //string s1 = "ace";
            //string s2 = "abcde";
            //int res = subSeq.LongestCommonSubsequence(s1, s2);
            //string s3 = "bbbab";
            //int res2 = subSeq.LongestPalindromeSubseq(s3);

            //Input: 
            //string S = "abcdebdde"; string T = "bde";//Output: "bcde"
            string S = "jmeqksfrsdcmsiwvaovztaqenprpvnbstl";
            string T = "k";
            string s4 = subSeq.MinWindowSubsequnce(S, T);

        }
        private static void SubstringsAlgorithmMain()
        {
            SubstringAlgos substrings = new SubstringAlgos();
            //string str = "geekeg";
            //string res = substrings.LongestPalindromeDynamic(str);
            //string res2 = substrings.LongestPalindromeNonDynamic(str);

            //minimum window substring
            string s = "ADOBECODEBANC";
            string t = "ABC";
            //string res3 =  substrings.MinWindowSubstring(s, t);

            // K length substring with no repeated characters.
            //Input: S = "havefunonleetcode", K = 5
            //output: 6
            //Explanation:
            //There are 6 substrings they are: 'havef','avefu','vefun','efuno','etcod','tcode'

            //string s1 = "home"; //"havefunonleetcode";
            //int k = 5;
            //int res4 = substrings.NumKLenSubstrNoRepeats(s1, k);

            string s3 = "eceeeeba"; 
            int k = 2;
            int res5 = substrings.LengthOfLongestSubstringKDistinct(s3, k);
        }

        private static void CoinsChangeSimilarPgmMain()
        {
            CoinsChange obj = new CoinsChange();
            //int[] steps = { 1,2};
            //int numSteps = 3;
            //int res = obj.ClimbStairs(steps, numSteps);
            //dynamic
            //int res2 = obj.ClimbStairsCountDynamicBottomUp(2, new int[2 + 1]);
            int[] coinsDenom = { 1, 2, 5 };
            int amount = 5;
            int res3 = obj.MinCoinsAmount(coinsDenom, amount);
        }

        private static void QueensInChessBoardMain()
        {
            QueenNcrossN queenNcrossN = new QueenNcrossN();
            queenNcrossN.solveNQ();
            // int[,] chessBoard = new int[4, 4];
            //queenNcrossN.PlaceQueens(0,new int[4],new System.Collections.ArrayList(),4);
        }

        private static void CoinsChangeMain()
        {
            CoinsChange coinsChange = new CoinsChange();
            //int count = coinsChange.CoinChangeCount(30);
            int amount = 4;
            int[] denoms = { 1, 2, 3 };
            // int countWays= coinsChange.CountWaysGeeks2(denoms,amount);

            //Dynamic memoization.

        }

        private static void PaintFillMain()
        {
            PaintFill paintFill = new PaintFill();
            int[,] screen = { { 1, 1, 1, 1 }, { 1, 2, 1, 1 }, { 1, 2, 2, 1 }, { 1, 2, 2, 1 } };
            int x = 1; int y = 1;
            int newColor = 3;
            paintFill.FloodFill(screen, x, y, newColor);
        }

        private static void StringPermutationMain()
        {
            Permutations permutations = new Permutations();
            permutations.PermuteString1("ABC");
        }
        #endregion


    }
}
