using System.Collections.Generic;
using System.Text;
using AlgorithmsArrayStrings.Amazon;
using AlgorithmsArrayStrings.Facebook;
using AlgorithmsArrayStrings.General;
using AlgorithmsArrayStrings.Sorting_Searching;

namespace AlgorithmsArrayStrings
{
    class Program
    {
        
        static void Main(string[] args)
        {

            #region amazon

            //NumberToWordsMain();
            //LetterCombinationMain();
            //ProductOfArrayExceptSelfMain();
            //ProductOfArrayExceptSelfMain();
            //CompareVersionMain();
            //CombinationalSumDuplicateMain();
            //LongestPalindromeSubstringMain();
            //MaxSubArraySumMain();
            //DegreeOfAnArrayMain();
            //BuyandSellStocksMain();
            //MaxWaterContainerMain();
            //ReverseArrayInGroupMain();
            //MaximumPlatformNeededMain();
            //EquilibriumIndexMain();
            //SubArraySumMain();
            //LargestContiguousSubArrMain();
            #endregion

            #region SortingAndSearching
            //MergeSortingMain();
            //HeapSortMain();
            #endregion

            #region facebook

            StringBuilder sb = new StringBuilder();
            sb.Insert(0, 1);
            sb.Insert(0, 2);
            sb.Insert(0, 3);
            string res = sb.ToString();

            var sb2 = new StringBuilder();
            sb2.Append(1);
            sb2.Append(2);
            sb2.Append(3);
            string res2 = sb2.ToString();

            FacebookMainArrayString();
            //FacebookMainDynamic();
            #endregion

            #region google
            #endregion

            #region microsoft
            #endregion

            #region geeksgeeks
            #endregion

            #region leetcode
            #endregion

            #region general
            //KnapsackMain();
            //CoinChangeMain();
            #endregion
        }


        #region SortingAndSearching

        private static void HeapSortMain()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            int n = arr.Length;

            HeapSortClass ob = new HeapSortClass();
            ob.HeapSort(arr);

        }

        private static void MergeSortingMain()
        {
            int[] a = { 7, 8, 1, 4, 5, 2, 3, 6 };
            Mergesort obj = new Mergesort();
            obj.sort(a,0,a.Length-1);
        }
        #endregion

        #region amazon
        private static void LargestContiguousSubArrMain()
        {
            int[] a = { -2, -3, 4, -1, -2, 1, 5 };
            SmallPrograms obj = new SmallPrograms();
            int largestNum = obj.LargestSumContiguousArray(a);
        }
        //Subarray with given sum
        private static void SubArraySumMain()
        {
            int[] a = { 1, 4, 20, 3, 10, 5 };
            int sum = 33;
            SmallPrograms obj = new SmallPrograms();
            obj.SubarrayForGivenSum(a, sum);
        }
        private static void EquilibriumIndexMain()
        {
            //int[] a = { 1, 7, 3, 6, 5, 6 };//{ -7, 1, 5, 2, -4, 3, 0 };
            int[] a = { -7, 1, 5, 2, -4, 3, 0 };
            SmallPrograms pgm = new SmallPrograms();
            int equiIndex = pgm.PivotIndex(a);
        }

        private static void MaximumPlatformNeededMain()
        {
            //int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
            //int[] dep = { 910, 1120, 1130, 1200, 1900, 2000 };
            int[] arr = {900, 940, 950, 1100,1500, 1800};
            int[] dep = {910, 1200, 1120, 1130,1900, 2000};
            SmallPrograms obj = new SmallPrograms();
            int k = obj.MaximumPlatformNeeded(arr, dep);
        }
        private static void ReverseArrayInGroupMain()
        {
            SmallPrograms pgm = new SmallPrograms();
            int[] a = { 1,2,3,4,5,6,7,8};
            int[] b = pgm.ReverseArrayInGroup(a, 3);
        }

        private static void MaxWaterContainerMain()
        {
            ContainerWithWater obj = new ContainerWithWater();
            //int[] a = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            //int res = obj.ContainerWithMostWaterI(a);

            int[] b = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int res = obj.ContainerWithMostWaterII(b);
        }

        private static void BuyandSellStocksMain()
        {
            BuyandSellStock obj = new BuyandSellStock();
            int[] a = { 7, 1, 5, 3, 6, 4 };
            int res = obj.MaxProfit(a);

            int[] b = { 3, 3, 5, 0, 0, 3, 1, 4 };
            int re2 = obj.MaxTotalBuySellProfitIII(b);

            //int[] c = { 3, 2, 6, 5, 0, 3 };
            int[] c = { 3, 2, 6, 7, 0, 3 };
            int re3 = obj.MaxProfitIV(2,c);
            int re4 = obj.MaxProfitIV_2(2, c);
        }
        private static void DegreeOfAnArrayMain()
        {
            MaxSumSubArrayRelated obj = new MaxSumSubArrayRelated();

            int[] a = { 1, 2, 2, 3, 1, 4, 2 };//{ 1, 2, 2, 3, 1 };

            int res = obj.DegreeOfAnArray(a);
        }

        private static void MaxSubArraySumMain()
        {
            MaxSumSubArrayRelated obj = new MaxSumSubArrayRelated();
            int[] a = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int res = obj.MaxSubArray(a);
        }

        private static void LongestPalindromeSubstringMain()
        {
            LongestPalindrome obj = new LongestPalindrome();
            string str = "forgeeksskeegfor";
            string res = obj.DynamicPgmngMyCode(str);//obj.DynamicPgnmgLongestPalindromeSubstring(str);
            string res2 = obj.LongestPalindromeCentre(str);
            string res3 = obj.longestPalindromicSubstringLinear(str);
            string res4 = obj.LongestPalindromeSubstrBruteForce("forgeeksskeegfor");

            string res5 = obj.LongPalinDynamic("forgeeksskeegfor");
        }

        private static void CombinationalSumDuplicateMain()
        {
            CombinationalSum obj = new CombinationalSum();
            //int[] a = { 2, 3, 6, 7 };
            //int target = 7;
            //IList<IList<int>> res =  obj.CombinationalSumDuplicate(a, target);

            //int[] a = { 10, 1, 2, 7, 6, 1, 5 };
            //int target = 8;
            //IList<IList<int>> res = obj.CombinationalSumUnique(a, target);

            int a = 3;
            int target = 9;
            IList<IList<int>> res = obj.CombinationalSumIII(a, target);
        }

        private static void AtoIMain()
        {
            //StringToInt obj = new StringToInt();
           // string str = "-91283472332";
            //str = "";
            //str = "332";
            //int res = obj.MyAtoi(str);
            //facebook
            Facebook.ArrayStringFB obj = new Facebook.ArrayStringFB();
            string str = "-4193 with words";
            int res2 = obj.MyAtoi(str);
        }

        private static void NumberToWordsMain()
        {
            StringToInt obj = new StringToInt();
            int str = 1283472332;
            //str = "";
            //str = "332";
            string res = obj.Number2WordsMyCode(str);
        }

        private static void LetterCombinationMain()
        {
            AllCombinationAlgs obj = new AllCombinationAlgs();
            string str = "23";
            
            IList<string> res = obj.LetterCombinations(str);
        }
        private static void ProductOfArrayExceptSelfMain()
        {
            ProductOfArrayExceptSelf obj = new ProductOfArrayExceptSelf();
            int [] nums = new int[] {1,2,3,4 };

            int [] res = obj.ProductSelf(nums);
        }
        /* Compare two version numbers version1 and version2.
        If version1 > version2 return 1; if version1 < version2 return -1;otherwise return 0.

        You may assume that the version strings are non-empty and contain only digits and the . character.
        The . character does not represent a decimal point and is used to separate number sequences.
        For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.

        Example 1:
        Input: version1 = "0.1", version2 = "1.1"
        Output: -1
        Example 2:

        Input: version1 = "1.0.1", version2 = "1"
        Output: 1 */

        private static void CompareVersionMain()
        {
            SmallPrograms smPgm = new SmallPrograms();
            //Input: version1 = "7.5.2.4", version2 = "7.5.3"
            //Output: -1
            string version1 = "1", version2 = "1.1";
            int result = smPgm.CompareVersion(version1, version2);
        }
        #endregion

        #region facebook
        private static void FacebookMainArrayString()
        {
            //AtoIMain();
            ArrayStringFB obj = new ArrayStringFB();
            //string s = "IV";//"III";
            //int res = obj.RomanToInt(s);

            //int[] a = { -1, 0, 1, 2, -1, -4 };
            //IList<IList<int>> res = obj.ThreeSum(a);

            //next greater number
            //int[] a = { 2, 3, 1 };// {2,1,8,7,6,5 };
            //obj.NextPermutation(a);
            //string num1 = "123", num2 = "456";
            //Output: "56088"
            //string res2 = obj.Multiply(num1, num2);

            //Group Anagrams
            //Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
            //Output:[["ate", "eat", "tea"],["nat","tan"],["bat"]]
            //string[] anagrams = { "eat", "tea", "tan", "ate", "nat", "bat" };
            //IList<IList<string>> lst = obj.GroupAnagrams(anagrams);

            string str = "ADOBECODEBANC";// "ab";
            string pat = "ABC";// "a";
            string res = obj.MinWindowDictionary(str,pat);//obj.MinWindow(str,pat);

            //merge sort 
            //int[] a = { 1, 2, 3, 0, 0, 0 };
            //int[] b = { 2, 5, 6 };

            // obj.Merge(a,a.Length,b,b.Length);

            //ProductexceptSelf
            //int[] a = { 1, 2, 3, 4 };
            //int [] result = obj.ProductExceptSelf(a);

            //LengthOfLongestSubstringKDistinct
            //string s = "eceba";
            //int k = 2;
            //int res = obj.LengthOfLongestSubstringKDistinct(s,k);
            //int[] nums = {-1,-1,1 };//{1,2,3 };
            //int k = 1;//0;//3;
            //int res = obj.SubarraySum(nums, k);

            //LengthOfLongestSubstring
            string a = "abcaaa"; //"abcabcbb";
            int longSub = obj.LengthOfLongestSubstring(a);

            //Letter combination
            //IList<string> lstRes = obj.LetterCombinations("23");

            //permutation of numbers
            //int[] a = { 1,1,2};//{ 1, 2, 3 };
            //IList<IList<int>> resPermut = obj.Permute(a);

            //Subsets
            //int[] a = {1,2,3 };
            //IList<IList<int>> resSubset = obj.Subsets(a);;

            //search item
            //int[] a = { 4, 5, 6, 7, 0, 1, 2 };
            //int target = 0;
            //int resPivot = obj.Search(a, target);

            //search the range item.
            //int[] a = { 5, 7, 7, 8, 8, 10 };
            //int target = 8;
            //int[] range = obj.SearchRange(a, target);

            //Given a collection of intervals, merge all overlapping intervals.
            // int[][] intervals = { new int[]{ 1, 3 }, new int[] { 2, 6 }, new int[] { 15, 18 }, new int[] { 8, 10 } };

            //int[][] res = obj.Merge(intervals);

            //find the peak. A peak element is an element that is greater than its neighbors.
            //int[] a = { 1, 2, 1, 3, 5, 6, 4 };//{ 1, 2, 3, 1 };
            //int res = obj.FindPeakElement(a);

            //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
            //Output: [4, 9]
            //int[] nums1 = { 4, 9, 5 };
            //int[] nums2 = { 9, 4, 9, 8, 4 };
            //int[] res = obj.Intersection(nums1, nums2);

            //string s1 = "((())";//"(()";
            //int resCount = obj.LongestValidParentheses(s1);

            //Num decoding
            //string s = "226";
            //int res12 = obj.NumDecodingsDpIterativememo(s);

            //Input: s = "leetcode", wordDict = ["leet", "code"]
            //"applepenapple" ["apple","pen"]
            // string s = "applepenapple";
            // IList<string> lst = new List<string>();
            //lst.Add("apple");
            //lst.Add("pen");
            // bool res = obj.WordBreak(s,lst);
            //bool res2 = obj.WordBreakdynamic(s, lst);


        }

        private static void FacebookMainDynamic()
        {
            DynamicFb obj = new DynamicFb();
            int[] num = { 23, 2, 4, 6, 7 };
            int k = 6;
            bool isCheck = obj.CheckSubarraySum(num,k);
        }
        #endregion

        #region google
        #endregion

        #region microsoft
        #endregion

        #region geeksgeeks
        #endregion

        #region leetcode
        #endregion

        #region general
        private static void KnapsackMain()
        {
            Knapsack_CoinChange obj = new Knapsack_CoinChange();
            int[] val = new int[] { 60, 100, 120 };
            int[] wt = new int[] { 10, 20, 30 };
            int W = 50;
            int n = val.Length;
            float res = obj.KnapsackAlg(W, wt, val, n);

        }
        /// <summary>
        /// 
        /// </summary>
        private static void CoinChangeMain()
        {
            // Two sections 1. Number of ways to get the coin change
            // 2. min coins change required for the amount.
            int[] coins = { 1, 2, 5 };//{186,419,83,408};//{ 5,2,1};
            int amount = 11;//6249;//11;


            CoinChangeAlg obj = new CoinChangeAlg();
            //int res = obj.NoOfWaysCoinChangeRecursive(coins, amount);
            int[] coins2 = { 1, 2, 3 }; //{ 2, 4, 6 };//{1,2,3};
            int amount2 = 4;// 7;//4;
            int res = obj.NoOfWaysCoinChangeDynamic(coins2, amount2);

            //2. min coins change required for the amount.
            int res2 = obj.MinCoinsAmount(coins2, amount2);
        }

        #endregion
    }
}
