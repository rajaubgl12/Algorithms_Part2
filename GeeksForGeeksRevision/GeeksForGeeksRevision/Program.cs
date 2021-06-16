using GeeksForGeeksRevision.DynamicRecursivePgmng;
using GeeksForGeeksRevision.FaceBook;
using GeeksForGeeksRevision.FaceBook.Arrays;
using GeeksForGeeksRevision.FaceBook.BackTracking;
using GeeksForGeeksRevision.General;
using GeeksForGeeksRevision.General.Recursion;
using GeeksForGeeksRevision.Google;
using GeeksForGeeksRevision.LeetCode;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using GeeksForGeeksRevision.DesignAlgos;
using GeeksForGeeksRevision.DataStructure;
using GeeksForGeeksRevision.Microsoft.InterviewOST;

namespace GeeksForGeeksRevision
{
    class Program
    {
        static Recursion recObj = new Recursion();
        ArraysAlgorithms arrAlg = new ArraysAlgorithms();
        static void Main(string[] args)
        {
            #region MicrosoftInterview
            TestProgramMSFT();
            #endregion

            #region general1
            //PermuteStringMain();
            //AtoIMain();
            //GroupAnagramMain();
            //ReOrderLogsMain();
            //MinWindowSubstrAnyOrderMain();
            //CoinChangeMain();
            //LongestNonRepeatingSubstringMain();
            //LengthOfSubstringWithKDistinctMain();
            //LongestPalindromeMain();
            //FindLongestCommonSubsequenceMain();
            //MinWindowSubstringMain();
            //NumOfIslandsMain();
            //NumOfDistinctIslandsMain();
            #endregion

            #region Datastructures
            //SortedSetMain();
            //TrieBasicOperationsMain();
            //TrieAutoComplete();
            //TrieWordSearch();
            MostCommonWord();
            #endregion

            #region Design
            //LRUCacheMain();
            //LFUCacheMain();
            #endregion

            #region Clean
            #region exceptiontest
            //ThrowExceptionMain();
            // WriteLogsToEventViewer();
            #endregion

            #region leetCode General Pgmng
            //LongestValidParenthesesMain();
            #endregion
            //int n = FibSeries(82);

            #region LeetCodeAmazon
            //ReverseWordsMain();
            //ReverseStringMain();
            //UniqueCharStringMain();
            //Maximum Size Subarray Sum Equals k
            /*  Input: nums = [1, -1, 5, -2, 3], k = 3
                Output: 4 Explanation: The subarray [1, -1, 5, -2] sums to 3 and is the longest.
             */
            //MaxSizeSubArrSumMain();
            //CompareVersionMain();
            //LongestPalindromeMain();
            //ProductArrayExceptSelfMain();
            //CombinationSumMain();
            //LetterCombinationsMain();
            //FindLaddersCountMain();
            //ClimbStairsMain();
            //BuySellStockMain();
            //MaxSubArrayMain();
            //SingleNumberMain();
            //NumOfIslandsMain();
            //MaxSubArraySizeK();
            //MinWindowSubstringMain();
            #endregion

            #region ArrayAlgorithms

            //https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
            // Kadane’s Algorithm
            //LargestContiguousSubArrMain();
            //SubArraySumMain();
            //Sort012Main();
            //EquilibriumIndexMain();
            //MaxSumIncreasingSubSeqMain();
            //LeaderInArrayMain();
            //MaximumPlatformNeededMain();
            //ReverseArrayInGroupMain();
            //TrapRainWaterMain();

            /*Sliding Window Maximum (Maximum of all subarrays of size k)
            do this while praccticing linked list
            //https://www.geeksforgeeks.org/sliding-window-maximum-maximum-of-all-subarrays-of-size-k/
             */
            #endregion

            #region recursion
            //int n = 9;
            //int fibNum = CallRecursion(n);
            //int n = 36;
            //int m = 60;
            //int k = CallGCD(m, n);
            //int m = CallNumOfPaths();
            //CombinationSum2Main();
            //PrintMaxNumOfAs();            
            #endregion

            #region microsoft
            //MaxRepeatingChar();
            // MergeSort();
            // PushNegetiveNumLeftMain();
            //CheckAnagramString();
            // MaxNonRepeatingSubstringMain();
            // ArrangeLargestNum();
            //CheckZeroSumSubArrayExistsMain();
            #endregion

            #region FaceBook

            #region Backtracking
            //PermutationMain();
            //PermuteStringMain();
            //LetterCombinationMain();
            //SubsetArrayMain();
            //PermutationUniqueMain();
            #endregion

            #region DynamicProgramming
            //BuySellStockMain2();
            //NumDecodingsMain();
            // MinWindowSubstrMain();
            // LongestIncreasingSubSeq();
            #endregion

            #region SortingSearching
            //MeetingRoomMain();
            //MergeSortedArrayMain();

            #endregion

            #region General
            //DivideMain();
           // MinWindowSubstrAnyOrderMain();
            #endregion

            #region Arrays
            //MoveZerosMain();
            //AddBinaryMain();
            //IntersectMain();
            //ThreeSumMain();
            //IsPalindromeMain();
            //IsValindPalindromeMain();
            //IsValidNumberMain();
            //MinSubArrayMain();
            //MaxSubArrayMain1();
            //ValidParenthesesMain();
            //TrappingRainWater();
            //SubsetsMain();
            //RemoveInvalidParenthesesMain();
            #endregion

            #endregion

            #endregion          

            #region Google
            //CoinChangeMain();
            //OrderByFrequencyMain();
            //NumUniqueEmailsMain();
            //OddEvenJumpsMain();
            //LicenseKeyFormatMain();
            //TotalFruitMain();
            //LengthOfLongestSubstringMain();
            //MaxAreaMain();
            //ThreeSumMainGoogle();
            //NextPermutationMain();
            //MultiplyMain();
            //RotateMatrixMain();
            //CanJumpMain();
            //MinWindowMain();
            //LengthOfLongestSubstringTwoDistinctMain();
            //FindMissingRangesMain();
            //NextClosestTimeMain();
            //MaxDistToClosestMain();
            //ShortStringMain();
            // TotalTrappedWaterMain();
            // MinMeetingRoomMain();
            //BackspaceCompareMain();
            // KClosestMain();
            //LetterCombinationsMain1();
            //MergeIntervalsMain();
            //LongestPalindromeDynamicMain();
            #endregion

            #region GayleLakmann
            //URLify();
            //PermutationStringPalindrome();
            //OneAwayMain();
            //StringComparisonMain();

            #endregion

            #region general
            //CharToIntMain();
            SortByValueAndIndexMain();
            //ReorderArrayBasedOnIndexMain();

            #endregion

            #region generalPractice
            //RainWaterTestMain();
            //MaxProductMain();
            //FloodFillAlgoMain();
            //SortByValueAndIndexMain();
            //SpecialKeyBoardMain();
            //LongestIncreasingSubSeqMain();
            //LongestIncSubOddEvenMain();
            //MaxSumIncreasingSubSeqMain2();
            //MaxPairChainLengthMain();
            //FindMinInsertionsPalindromeMain();
            //FindLongestCommonSubsequenceMain();
            //FindLongestCommonSubstring();
            //LongestNonRepeatingSubstringMain();
            //LengthOfSubstringWithKDistinctMain();
            //LongestCommonPrefixMain();
            //LongestCommonSubSeqVowelsMain();
            //LongestOrderedSequenceVowelsMain();
            //LongestPalindromeSubStrMain();
            #endregion

            #region Thomson
            SeggregateOddEvenMain();
            #endregion

            #region Gayle Lakmann
            #region Dynamic and Recursion
            // StairCaseSteps();
            //SubsetsMain();
            //SubsetsMain2();
            #endregion
            #endregion

            #region LeetCode
            //CombinationSumMain2();
            #endregion

            #region geeksforgeeks
            //CoinChangeGeeksMain();
            #endregion

            #region Expedia

            #endregion
        }

        private static void TestProgramMSFT()
        {
            InterviewMSFT mSFT = new InterviewMSFT();
            LinkedList<int> lst = new LinkedList<int>();
            
        }

        #region general1
        private static void AtoIMain()
        {
            GeeksForGeeksRevision.Solution obj = new GeeksForGeeksRevision.Solution();
            obj.MyAtoi("");
        }
        private static void ReOrderLogsMain()
        {
            //Input: logs = ["dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"]
            //Output: ["let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6"]
            string[] arr = { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            ArraysStrings.ReOrderLogs obj = new ArraysStrings.ReOrderLogs();

            string[] res = obj.ReorderLogFiles(arr);

        }

        private static void GroupAnagramMain()
        {
            string[] arr = { "eat", "tea", "tan", "ate", "nat", "bat" };
            ArraysStrings.GroupAnagram obj = new ArraysStrings.GroupAnagram();
            IList<IList<string>>  res = obj.GroupAnagrams(arr);
        }
        #endregion

        #region DataStructures
        private static void MostCommonWord()
        {
            CommonWord obj1 = new CommonWord();
            //paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
            //banned = ["hit"]
            //Output: "ball"
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string [] banned = { "ball" };
            string res = obj1.MostCommonWord(paragraph,banned);
        }

        private static void TrieWordSearch()
        {
            //addWord("bad")
            //addWord("dad")
            //addWord("mad")
            //search("pad")-> false
            //search("bad")-> true
            //search(".ad")-> true
            //search("b..")-> true
            AddSearchWord obj = new AddSearchWord();
            //Trie tObj = new Trie();
            //tObj.Insert("bad");
            //tObj.Insert("dad");
            //tObj.Insert("mad");

            //bool res = tObj.Search("bad");

            obj.AddWord("bad");
            obj.AddWord("dad");
            obj.AddWord("mad");
            bool r1 = obj.Search("pad");
            bool r2 = obj.Search("bad");
            bool r3 = obj.Search(".ad");
            bool r4 = obj.Search("b..");
        }
        private static void TrieAutoComplete()
        {

            //Example:
            //Operation: AutocompleteSystem(["i love you", "island", "ironman", "i love leetcode"], [5,3,2,2])
            string[] wrds = { "i love you", "island", "ironman", "i love leetcode" };
            int[] counts = { 5, 3, 2, 2 };
            //AutoCompleteWrd2 obj = new AutoCompleteWrd2(wrds, counts);
            AutoCompleteWord obj = new AutoCompleteWord(wrds, counts);
            IList<string> lst = obj.Input('i');
        }

        private static void TrieBasicOperationsMain()
        {

        }

        private static void SortedSetMain()
        {
            SortedSet<int> srtLst = new SortedSet<int>();
            srtLst.Add(4);
            srtLst.Add(8);
            srtLst.Add(4);
            srtLst.Add(8);
            srtLst.Add(3);
            srtLst.Add(1);
            srtLst.Add(1);
        }
        #endregion

        #region Design
        private static void LFUCacheMain()
        {
            LFUCache2 cache = new LFUCache2(4 /* capacity */ );
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Put(2, 2);
            cache.Put(1, 1);
            cache.Get(1);       // returns 1
            cache.Put(4, 4);    // evicts key 2
            cache.Get(2);       // returns -1 (not found)
            cache.Get(3);       // returns 3.
            cache.Put(4, 4);    // evicts key 1.
            cache.Get(1);       // returns -1 (not found)
            cache.Get(3);       // returns 3
            cache.Get(4);       // returns 4
            //cache.Put(1, 1);
            //cache.Put(2, 2);
            //cache.Get(1);       // returns 1
            //cache.Put(3, 3);    // evicts key 2
            //cache.Get(2);       // returns -1 (not found)
            //cache.Get(3);       // returns 3.
            //cache.Put(4, 4);    // evicts key 1.
            //cache.Get(1);       // returns -1 (not found)
            //cache.Get(3);       // returns 3
            //cache.Get(4);       // returns 4
        }
        private static void LRUCacheMain()
        {
            DesignAlgos.LRUCache obj = new DesignAlgos.LRUCache(4);
            obj.Put(1,1);
            obj.Put(2, 2);
            obj.Put(3, 3);
            obj.Put(4, 4);
            obj.Put(5, 5);
            Console.WriteLine(obj.Get(1));
            Console.WriteLine(obj.Get(2));
            Console.WriteLine(obj.Get(3));
            Console.WriteLine(obj.Get(4));
            Console.WriteLine(obj.Get(5));
        }

        #endregion

        #region Expedia

        #endregion

        #region LeetCode
        private static void CombinationSumMain2()
        {
            //   candidates = [10,1,2,7,6,1,5], target = 8, Solution:  [1, 7],  [1, 2, 5],  [2, 6],  [1, 1, 6]
            //  Example 2:
            //Input: candidates = [2,5,2,1,2], target = 5, A solution set is: [1,2,2], [5]
            //int[] a = { 2, 4, 6, 8 }; //int[] a = { 10, 1, 2, 7, 6, 1, 5 };
            //int target = 8;
            //LeetCode.CombinationSumII combination = new CombinationSumII();
            //IList<IList<int>> lst = combination.CombinationSum2(a, target);
            //int[] a = { 1,2,3,4,5,6,7,8,9};
            //int n = 7;
            //int k = 3;
            //LeetCode.CombinationSumII combination = new CombinationSumII();
            //IList<IList<int>> lst = combination.CombinationKSum(a, n, k);
            int[] a = { 1,2,3 }; //int[] a = { 10, 1, 2, 7, 6, 1, 5 };
            int target = 4;
            LeetCode.CombinationSumII combination = new CombinationSumII();
            IList<IList<int>> lst = combination.CombinationSum2(a, target);
        }
        #endregion

        #region geeksforgeeks        

        private static void LongestPalindromeSubStrMain()
        {
            LongestPalindromeSubstring obj = new LongestPalindromeSubstring();
            string str = "forgeeksskeegfor";
            int res = obj.LongestPalindrome(str);
        }

        private static void LongestOrderedSequenceVowelsMain()
        {

            //Input :  str = "aeiaaioooaauuaeiou" Output :  {a, a, a, a, a, a, e, i, o, u}
            //There are two possible outputs in this case: 
            //{a, a, a, a, a, a, e, i, o, u} and, 
            //{a, e, i, i, o, o, o, u, u, u}
            //each of length 10
            //Input : str = "aaauuiieeou" Output : No subsequence possible
            
            LengthOfLongestCommonVowelSubSequence obj = new LengthOfLongestCommonVowelSubSequence();
            string X = "aeiaaioooaauuaeiou";
            int res = obj.LongestSubSeqVowels(X);
        }

        private static void LongestCommonSubSeqVowelsMain()
        {
            //Input: X = "aieef" Y = "klaief" output: aie
            //Input : X = "geeksforgeeks" Y = "feroeeks" Output: eoee
            LengthOfLongestCommonVowelSubSequence obj = new LengthOfLongestCommonVowelSubSequence();
            string X = "geeksforgeeks"; string  Y = "feroeeks";
            int res = obj.LcsVowels(X, Y);
        }
        /// <summary>
        /// 
        /// </summary>
        private static void LongestCommonPrefixMain()
        {
          //Input  : {“geeksforgeeks”, “geeks”, “geek”, “geezer”}  Output: "gee"
         //Input: { "apple", "ape", "april"} Output: "ap"
         //Input: { "abcd"} Output: "abcd"
            LongestCommonPrefix prefix = new LongestCommonPrefix();
            string[] strs =  {"geeksforgeeks", "geeks", "geek", "geezer"};//{ "apple", "ape", "april" };////{ "abcd" };//
            string res = prefix.LongestCommonPrefixStringImprove(strs);//prefix.LongestCommonPrefixString(strs);
        }

        private static void CoinChangeMain()
        {
            CoinChangeAlg dynm = new CoinChangeAlg();
            //int[] a = { 1, 5, 10, 25 };
            //int amount = 18;
            //int combination = dynm.CoinChange(a, amount);
            //[186,419,83,408]
            //6249
            //int[] arr = { 186, 419, 83, 408 };
            //int m = arr.Length;
            //int amount = 6249;
            //[1,2,5]
            //11
            int[] arr = { 1, 2, 5 };            
            int amount = 11;
            int res = dynm.CoinChangeDynamic(arr, amount);
        }


        private static void LengthOfSubstringWithKDistinctMain()
        {
            string s = "eceba";//abcabcbb
            //string s = "bbbbb";
            //string s = "pwwkew";
            //string s = "dvdf";
            //int res = arrayStringLeetCode.LongestSubstringNonRepeating(s);
            LongestSubstringWithKDistinctChars obj = new LongestSubstringWithKDistinctChars();
            int res = obj.LengthOfLongestSubstringKDistinct(s,2);
        }

        private static void LongestNonRepeatingSubstringMain()
        {
            string nonRepeating = "CODINGISAWESOME";//"GEEKSFORGEEKS";//"ABDEFGABEF"; //bbbbbbbb
            //string maxSubstring = MicrosoftAlg.LargestNonRepeatingSubstr(nonRepeating);//MicrosoftAlg.LargestNonRepeatingSubstr_2(nonRepeating);
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            string s = "ABDEFGABEF"; //"abcabcbb";//abcabcbb
            //string s = "bbbbb";
            //string s = "pwwkew";
            //string s = "dvdf";
            //int res = arrayStringLeetCode.LongestSubstringNonRepeating(s);
            LongestSubstringNonRepeatingCls obj = new LongestSubstringNonRepeatingCls();
            // int res = obj.LongestSubstringNonRepeating(s);
            string res = obj.LargestNonRepeatingSubstr(s);
        }

        /// <summary>
        /// /// Input : X = “GeeksforGeeks”, y = “GeeksQuiz”
        //Output : 5
        //The longest common substring is “Geeks” and is of length 5.
        //Input : X = “abcdxyz”, y = “xyzabcd”
        //Output : 4
        //The longest common substring is “abcd” and is of length 4.
        //Input : X = “zxabcdezy”, y = “yzabcdezx”
        //Output : 6
        /// </summary>
        private static void FindLongestCommonSubstring()
        {
            LongestCommonSubstring obj = new LongestCommonSubstring();
            string s1 = "zxabcdezy";
            string s2 = "yzabcdezx";
            int m = s1.Length;
            int n = s2.Length;
            int res = obj.LcsubstrDynamic(s1, s2, m, n);//obj.Lcs(s1,s2,m,n);
        }

        /// <summary>       

        /// </summary>
        private static void FindLongestCommonSubsequenceMain()
        {
            LongestCommonSeqInString obj = new LongestCommonSeqInString();
            string s1 = "aeiaaioooaauuaeiou";//"zxabcdezy"; //"ABCDGH";//"AGGTAB";
            string s2 = "aeiou";//"yzabcdezx";//"AEDFHR";//"GXTXAYB";
            int m = s1.Length;
            int n = s2.Length;
            int res = obj.LcsDynamic(s1, s2, m, n);//obj.Lcs(s1,s2,m,n);
        }

        private static void FindMinInsertionsPalindromeMain()
        {
            MinInsertionPalindrome obj = new MinInsertionPalindrome();
            int res = obj.FindMinInsertionsPalindromeDynamic("abcda");//("abcde");
        }


        private static void MaxPairChainLengthMain()
        {
            Pair[] arr = new Pair[] {new Pair(5,24), new Pair(15, 25),
                                 new Pair (27, 40), new Pair(50, 60)};
            MaxLenChainPairs obj = new MaxLenChainPairs();
            int res = obj.MaxChainLength(arr);
        }

        /// <summary>
        /// For example, if input is {1, 101, 2, 3, 100, 4, 5}, then output should be 106 (1 + 2 + 3 + 100), 
        /// if the input array is {3, 4, 5, 10}, then output should be 22 (3 + 4 + 5 + 10) and 
        /// if the input array is {10, 5, 4, 3}, then output should be 10
        /// </summary>
        private static void MaxSumIncreasingSubSeqMain2()
        {
            MaxSumIncreasingSubSeq obj = new MaxSumIncreasingSubSeq();
            int[] a = { 1, 101, 2, 3, 100, 4, 5 };
            int res = obj.MaxSumIncSubSeq(a);
        }
        /// <summary>
        /// Input : arr[] = {5, 6, 9, 4, 7, 8}
        //Output : 4
        //{5, 6, 7, 8} is the required longest
        //increasing odd even subsequence.
        //Input : arr[] = {1, 12, 2, 22, 5, 30, 31, 14, 17, 11}
        //Output : 5
        /// </summary>
        private static void LongestIncSubOddEvenMain()
        {
            IncreasingSubSeqOddEvenCls obj = new IncreasingSubSeqOddEvenCls();
            int[] a = { 1, 12, 2, 22, 5, 30, 31, 14, 17, 11 };
            int res = obj.IncreasingSubSeqOddEven(a);
        }

        private static void LongestIncreasingSubSeqMain()
        {
            LongestIncreasingSubSeqCls obj = new LongestIncreasingSubSeqCls();
            int[] a = {10,9,2,5,3,4};// { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            int len = obj.LongsetIncrSubSeqLenRecur(a);//obj.LongsetIncreasingSubSequenceLength(a);
        }

        private static void SpecialKeyBoardMain()
        {
            SpecialKeyBoard specialKey = new SpecialKeyBoard();
            int res = specialKey.maxA(7);
        }
        private static void CoinChangeGeeksMain()
        {
            DynamicProgramming programming = new DynamicProgramming();
            int[] arr = { 1, 2, 3 };
            int m = arr.Length;
            int sum = 4;
            int count = programming.CoinChangeGeeks(arr,sum);
        }
        #endregion

        #region Gayle Lakmann

        #region Dynamic and Recursion
        private static void SubsetsMain2()
        {
            DynamicPgmng dynamicPgmng = new DynamicPgmng();
            int[] a = {1,2,3 };
            List<List<int>> lst =  dynamicPgmng.GetSubset(a);//dynamicPgmng.SubsetsRecursive(a);
        }
        private static void StairCaseSteps()
        {
            DynamicPgmng dynamicPgmng = new DynamicPgmng();
            int steps = 4;
           int numberOfWays = dynamicPgmng.StairCaseSteps(steps);
        }
        #endregion

        #endregion

        #region Thomson
        /// <summary>
        /// Input : 1 9 5 3 2 6 7 11
        ///Output : 2 6 5 3 1 9 7 11
        ///Input : 1 3 2 4 7 6 9 10
        ///Output : 2 4 6 10 7 1 9 3
        /// </summary>
        private static void SeggregateOddEvenMain()
        {
            Thomson.ArrayString arrayString = new Thomson.ArrayString();
            int[] a = { 1, 9, 5, 3, 2, 6, 7, 11 };
            int [] b = arrayString.SeggregateEvenOdd(a);
        }
        #endregion

        #region generalPractice
        private static void FloodFillAlgoMain()
        {
            int[,] screen = {{1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 0, 0},
                            {1, 0, 0, 1, 1, 0, 1, 1},
                            {1, 2, 2, 2, 2, 0, 1, 0},
                            {1, 1, 1, 2, 2, 0, 1, 0},
                            {1, 1, 1, 2, 2, 2, 2, 0},
                            {1, 1, 1, 1, 1, 2, 1, 1},
                            {1, 1, 1, 1, 1, 2, 2, 1}};
            int x = 4, y = 4, newC = 3;
            TestPrograms testPrograms = new TestPrograms();
            testPrograms.FloodFillAlgorithm(screen, x, y, 2, newC);
        }

        private static void MaxProductMain()
        {
            GeneralPractice gen = new GeneralPractice();
            int[] a = { -2, 0, 1, 3 };// {-1,2,3,0 };//{2,-5,-2,-4,3};// {1,8,6,2,5,4,8,3,7 };
            int max = gen.MaxProduct(a);
        }

        private static void RainWaterTestMain()
        {
            GeneralPractice gen = new GeneralPractice();
            int[] a = { 2, 3, 4, 5, 18, 17, 16 };// {1,8,6,2,5,4,8,3,7 };
            int max = gen.RainWaterSet1(a);
        }
        #endregion

        #region general
                
        private static void ReorderArrayBasedOnIndexMain()
        {
            ArrayStringGen stringGen = new ArrayStringGen();
            int[] a = { 10, 11, 12 };
            int[] b = {1, 0, 2};

            int[] temp = stringGen.ReOrderBasedOnIndex(a,b);
        }

        /*
        Write the business logic that takes an unknown sized array of the 
        years all movies were released and 
        returns the nth newest in the order they were originally given.
        Example: 2 of [2001, 1985, 1959, 2018] returns [2001, 2018]
        Example: 3 of [2019, 1948, 1959, 2017, 2018, 2001] returns [2019, 2017, 2018]
        */
            private static void SortByValueAndIndexMain()
        {
            int[] a = { 2019, 1948, 1959, 2017, 2018, 2001 };//{ 2001, 1985, 1959, 2018 };
            int count = 3;//2;
            ArrayStringGen stringGen = new ArrayStringGen();
            // List<int> lst = stringGen.GetLatestMovie(a, count);
            //int[] temp = stringGen.GetLatestMovie(a, count);//stringGen.GetLatestMovie2(a, count);
            int [] temp2 = stringGen.GetLatestMovie2(a, count);
        }

        private static void CharToIntMain()
        {
            ArrayStringGen stringGen = new ArrayStringGen();
            int res = stringGen.CharToInt("9128");
        }
        #endregion

        #region Google

        #region dynamicPgmng
        //private static void CoinChangeMain()
        //{
        //    Google.DynamicProgramming dynm = new Google.DynamicProgramming();
        //    int[] a = { 1, 5, 10, 25 };
        //    int amount = 18;
        //    int combination = dynm.CoinChange(a, amount);
        //}
        
        #endregion

        private static void OrderByFrequencyMain()
        {
            Google.ArrayStrings arrayStrings = new Google.ArrayStrings();
            int[] a = { 2, 5, 2, 8, 5, 6, 8, 8 }; //Input : arr[] = {2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8}
            int[] res=arrayStrings.SortByFrequency(a);
        }
        private static void LongestPalindromeDynamicMain()
        {
            Google.ArrayStringLeetCode arrayStrings = new Google.ArrayStringLeetCode();
            string s = "forgeeksskeegfor";//o/p : geeksskeeg
            string res = arrayStrings.LongestPalindromeDynamic(s);
        }
        private static void MergeIntervalsMain()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            int [][] arr =  { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 },new int[]{15,18 } };
           int [][] arrres =  googleArr.MergeIntervals(arr);
        }
        private static void LetterCombinationsMain1()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            IList<string> res = googleArr.LetterCombinations("23");
        }
        private static void KClosestMain()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            int[][] arr = { new int[] { 1, 3 }, new int[] { -2, 2 } };
            googleArr.KClosest(arr,1);
        }
        private static void BackspaceCompareMain()
        {
            //Input: S = "ab##", T = "c#d#"
            // S = "a#c", T = "b"
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            string S = "a#c"; //"ab##";//"ab#c";
            string T = "b";//"c#d#"; //"ad#c";
            bool res = googleArr.BackspaceCompare(S, T);
        }
        private static void MinMeetingRoomMain()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            int[][] meetingRms = { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } }; //{new int[]{0,30},new int[]{5,10}, new int[]{15,20} };
            int res = googleArr.MinMeetingRooms(meetingRms);
        }
        private static void TotalTrappedWaterMain()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            int[] a = { 0,1,0,2,1,0,1,3,2,1,2,1};
            int res = googleArr.TotalTrappedWater(a);
        }
        private static void ShortStringMain()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            string s = "aaaabbccccdefbbbhcck";
            string res = googleArr.ShortString(s);
        }
        private static void IsValidParanthesisMain()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            string s = "()[]{}";
            googleArr.IsValidParanthesis(s);
        }
        private static void MaxDistToClosestMain()
        {
            Google.ArrayStringLeetCode googleArr = new Google.ArrayStringLeetCode();
            int[] a = {1,0,0,0,0 };//{ 0, 0, 1 };//{ 1, 0, 0, 0, 1, 0, 1 };//{ 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1 }; // // output 2
            int index = googleArr.MaxDistToClosest2(a);
        }
        private static void NextClosestTimeMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            string s = "02:30";//"19:34";
            string res = arrayStringLeetCode.NextClosestTime(s);
        }
        private static void FindMissingRangesMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            int[] a = { 0, 1, 3, 50, 75 };
            int lower = 0;
            int upper = 99;
            IList<string> missingRange =  arrayStringLeetCode.FindMissingRanges(a,lower,upper);
        }
        private static void LengthOfLongestSubstringTwoDistinctMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            string s = "eceebbb";//"eceba";//"aac";
            arrayStringLeetCode.LengthOfLongestSubstringTwoDistinct3(s);
        }

        /// <summary>
        /// 2,3,1,1,4
        /// </summary>
        private static void CanJumpMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            int[] a = { 3,3,1,0,4};//{2,0,2 };//{2,0 };// { 3, 2, 1, 0, 4 };//{ 2, 3, 1, 1, 4 };

            bool res = arrayStringLeetCode.CanJump(a);
        }

        /// <summary>
        /// Given input matrix = 
        //        [
        //  [1,2,3],
        //  [4,5,6],
        //  [7,8,9]
        //],

        //rotate the input matrix in-place such that it becomes:
        //[
        //  [7,4,1],
        //  [8,5,2],
        //  [9,6,3]
        //]
        //        Given input matrix =
        //[
        //  [ 5, 1, 9,11],
        //  [ 2, 4, 8,10],
        //  [13, 3, 6, 7],
        //  [15,14,12,16]
        //], 

        //rotate the input matrix in-place such that it becomes:
        //[
        //  [15,13, 2, 5],
        //  [14, 3, 4, 1],
        //  [12, 6, 8, 9],
        //  [16, 7,10,11]
        //]
        /// </summary>
        private static void RotateMatrixMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            int[,] a = new int [3,3 ] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }};

            arrayStringLeetCode.RotateMatrix2(a);
        }
        private static void MultiplyMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            string s1 = "123";
            string s2 = "789";
            arrayStringLeetCode.Multiply2(s1,s2);
        }
        private static void NextPermutationMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            //1,2,3 → 1,3,2   3,2,1 → 1,2,3    1,1,5 → 1,5,1  1,3,2 --> 2,1,3
            int[] a = { 1, 3,2 };//{1,2,3 };
            arrayStringLeetCode.NextPermutation(a);
        }
        private static void NumUniqueEmailsMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            string[] emails = { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }; 
            arrayStringLeetCode.NumUniqueEmails(emails);
        }
        private static void OddEvenJumpsMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            int[] a = { 10, 13, 12, 14, 15 };//{ 2, 3, 1, 1, 4 }
            int[] b = { 2, 3, 1, 1, 4 };
            int count = arrayStringLeetCode.OddEvenJump(b);
        }
        private static void LicenseKeyFormatMain()
        {
            string S = "132-5g-3-J"; int K = 2;
           // string S = "5F3Z-2e-9-w"; int K = 4;
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            string res = arrayStringLeetCode.LicenseKeyFormatting(S, K);
        }
        private static void TotalFruitMain()
        {
            int[] tree = { 0, 1, 2, 2 };//Output: 3
            //Explanation: We can collect[1, 2, 2].
            //If we started at the first tree, we would only collect[0, 1].
            //int[] tree = { 1,2,3,2,2 }; //Output: 4
            //Explanation: We can collect[2, 3, 2, 2].
            //int[] tree = { 3,3,3,1,2,1,1,2,3,3,4 }; //5
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            int res = arrayStringLeetCode.TotalFruit1(tree);
        }
        
        private static void MaxAreaMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            int[] a = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int res = arrayStringLeetCode.MaxArea(a);
        }
        private static void ThreeSumMainGoogle()
        {
            GeeksForGeeksRevision.FaceBook.Arrays.ThreeSumCls arrayStringLeetCode = new GeeksForGeeksRevision.FaceBook.Arrays.ThreeSumCls();
            int[] a = { -1, 0, 1, 2, -1, -4 };
            int sum = 0;
            IList<IList<int>> res = arrayStringLeetCode.ThreeSum(a,sum);            
        }

        private static void MinWindowMain()
        {
            Google.ArrayStringLeetCode arrayStringLeetCode = new Google.ArrayStringLeetCode();
            string s = "bdab";// "a";// "ab";//"a";//"ADOBECODEBANC";
            string pat = "ab";// "A";//"aa";//"ABC";
            string substring = arrayStringLeetCode.MinWindow2(s,pat);
        }

        #endregion

        #region GayleLakmann

        private static void StringComparisonMain()
        {
            string s = "aabcccccaaa";
            Google.ArrayStrngGayleLak arrayStrngGayleLak = new Google.ArrayStrngGayleLak();
            string result = arrayStrngGayleLak.StringCompression(s);
        }
        private static void OneAwayMain()
        {
            string s1 = "apple";//"pale"; //"pale";//"pales";//"pale";
            string s2 = "aple";//"bale";//"bake"; //"pale";//"ple";
            Google.ArrayStrngGayleLak arrayStrngGayleLak = new Google.ArrayStrngGayleLak();
            bool result = arrayStrngGayleLak.OneWay(s1, s2);
        }
        private static void PermutationStringPalindrome()
        {
            Google.ArrayStrngGayleLak arrayStrngGayleLak = new Google.ArrayStrngGayleLak();
            string str = "Tact Coa";
            bool isPalindrome = arrayStrngGayleLak.PermutationString(str);
        }
        private static void URLify()
        {
            string s = "Mr John Smith    ";
            int trueLen = 13;
            Google.ArrayStrings arrayStrings = new Google.ArrayStrings();
            string output = arrayStrings.Urlify(s, trueLen);
        }
        #endregion

        #region Clean

        #region Exception

        private static void WriteLogsToEventViewer()
        {
            //Create a byte array for binary data to associate with the entry.
            byte[] myByte = new byte[10];
            //Populate the byte array with simulated data.
            for (int i = 0; i < 10; i++)
            {
                myByte[i] = (byte)(i % 2);
            }
            // Write an entry to the event log that includes associated binary data.
            Console.WriteLine("Write from second source ");
            EventLog.WriteEntry("SecondSource", "Writing warning to event log.",
                                 EventLogEntryType.Error, 1, 1, myByte);
            EventLog.WriteEntry("", "Writing warning to event log.",
                                 EventLogEntryType.Error, 1, 1, myByte);
        }
        private static void ThrowExceptionMain()
        {
            try
            {
                ThrowException2();
            }
            catch (Exception ex)
            {
                //var exceptionDetails = String.Format("Exception Source: {0} ; Exception Message: {1} ;" 
                //    +Environment.NewLine + "Inner Exception: {2} ; Call Stack:{3}", ex.Source,ex.Message, ex.InnerException, ex.StackTrace);
                var excepSource = ex.Source;
                var excepMessage = ex.Message;
                var excepInner = ex.InnerException;
                var excepStackTrace = ex.StackTrace;
                Console.WriteLine($"Exception Source: {excepSource}, Exception Message: {excepMessage}, Inner Exception: {excepInner} Call Stack:.");
                Console.WriteLine($"Exception Source: {ex.GetType().FullName}, Inner Exception: {ex.ToString()}.");
            }
        }

        private static void ThrowException2()
        {
            try
            {
                throw new ArgumentNullException();
            }
            catch(Exception ex)
            {
                throw new DivideByZeroException();
            }
        }
        #endregion

        #region FaceBook

        #region General
        private static void MinWindowSubstrAnyOrderMain()
        {
            LC_FaceBk_General fb_Gen = new LC_FaceBk_General();
            string src = "ADOBECODEBANC";//"bdab";// "a";//"ADOBECODEBANC";
            string pat = "ABC";//"ab";//"a";//"ABC";
            //Input: S = "ADOBECODEBANC", T = "ABC"
            //Output: "BANC"
            string subStr = fb_Gen.MinWindow2(src, pat);
        }
        private static void DivideMain()
        {
            LC_FaceBk_General fb_Gen = new LC_FaceBk_General();
            int dividend = -2147483648;// 7;
            int divisor = -1;// -3;
            int quotient = fb_Gen.Divide(dividend,divisor);
        }
        #endregion

        #region DynamicProgramming
       
        private static void LongestIncreasingSubSeq()
        {
            LongestIncreasingSubSeqCls lcFbDy = new LongestIncreasingSubSeqCls();
            int[] a = { 22, 10, 11, 70, 21, 50, 41, 42, 43 };//{ 50, 3, 10, 7, 40, 80 };
            //{ 3, 10, 2, 1, 20 };////{ 10, 22, 9, 33, 21, 50, 41, 60 };
            //Input  : arr[] = {3, 10, 2, 1, 20}
           int maxCount = lcFbDy.LongestIncreasingSubsequenceLength(a,a.Length);//
            
        }
        private static void MinWindowSubstrMain()
        {
            //string str = "abcdebdde";
            //string t = "bde";
            string str = "abclmdekbde";
            string t = "bde";
            Lc_FaceBk_Dynamic lcFbDy = new Lc_FaceBk_Dynamic();
            string subString = lcFbDy.MinWindowSubSeq(str,t);
        }
        private static void BuySellStockMain2()
        {
            int[] a = { 7, 1, 5, 3, 6, 4 };
            Lc_FaceBk_Dynamic lcFbDy = new Lc_FaceBk_Dynamic();
            int maxProfit = lcFbDy.MaxBuySellStocks(a);
        }
        private static void NumDecodingsMain()
        {
            string s = "2293";
            Lc_FaceBk_Dynamic lcFbDy = new Lc_FaceBk_Dynamic();
            int maxProfit = lcFbDy.NumDecodings(s);
        }
        #endregion

        #region SortingSearching
        private static void MergeSortedArrayMaindev()
        {
            LC_FaceBk_SortingSearch lcSearch = new LC_FaceBk_SortingSearch();
            int[] l1 = {1,3,5,7 };
            int[] l2 = { 2,4,6,8,10};
            lcSearch.MergeSortedArray(l1,l2);
        }
        private static void MeetingRoomMain()
        {
            LC_FaceBk_SortingSearch lcSearch = new LC_FaceBk_SortingSearch();
            Interval[] intervals =  { new Interval(10, 11), new Interval(1, 2),
                new Interval(3, 6) ,new Interval(4, 6),new Interval(5, 7)};
           int meetCount = lcSearch.MinMeetingRooms(intervals);
        }

        #endregion

        #region BackTracking
        private static void PermutationUniqueMain()
        {
            PermuteString lcFbAr = new PermuteString();
            int[] a = { 1, 1, 2 };

            List<List<int>> lstValue = lcFbAr.PermuteUnique(a);
        }
        private static void SubsetArrayMain()
        {
            Lc_FaceBk_BackTracking lcFbAr = new Lc_FaceBk_BackTracking();
            int [] a = { 1,2,3};

            IList<IList<int>> lstValue = lcFbAr.SubsetsArrayInt(a);
        }
        private static void LetterCombinationMain()
        {
            Lc_FaceBk_BackTracking lcFbAr = new Lc_FaceBk_BackTracking();
            String str = "28";

            IList<string> lstValue = lcFbAr.LetterCombinations(str);
        }
        private static void PermuteStringMain()
        {            
            PermuteString  lcFbAr = new PermuteString();
            String str = "ABC";
            int n = str.Length;
            lcFbAr.Permute(str);
        }
        private static void PermutationMain()
        {
            //Input: [1, 2, 3] Output:[[1, 2, 3],[1,3,2],[2,1,3],
            //[2,3,1],[3,1,2],[3,2,1]]
            int[] a = { 1, 2, 3 };
            PermuteString lcFbAr = new PermuteString();
            lcFbAr.Permute(a);
        }
        #endregion
        
        #region Arrays

        private static void ValidParenthesesMain()
        {
            ValidParanthesis lcFbAr = new ValidParanthesis();
            string strInput = "()())()";
            bool val = lcFbAr.IsValid(strInput);
        }
        private static void RemoveInvalidParenthesesMain()
        {
            Lc_FaceBk_Arrays lcFbAr = new Lc_FaceBk_Arrays();
            string strInput = "()())()";
            lcFbAr.RemoveInvalidParentheses(strInput);
        }        
        private static void SubsetsMain()
        {
            int[] a = { 1, 2, 3 };
            Lc_FaceBk_BackTracking lcFbAr = new Lc_FaceBk_BackTracking();
            lcFbAr.SubsetsArrayInt(a);
        }
        private static void TrappingRainWater()
        {
            TrappingRainWater lcFbAr = new TrappingRainWater();
            //Input: [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]
            //Output: 6 int []arr = new int[]{0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
            int[] a = { 3, 0, 0, 2, 0, 4 };//{ 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int total = lcFbAr.TrapOptmz(a);
        }
        private static void MaxSubArrayMain1()
        {
            //1, -1, 5, -2, 3], k = 3
            //[-2, -1, 2, 1], k = 1
            MaxSubArraySumLen lcFbAr = new MaxSubArraySumLen();
            int[] a = { -2, -1, 2, 1 };
            //{ 1, -1, 5, -2, 3 };//
            int k = 1;//3;
            lcFbAr.MaxSubArrayLen(a, k);
        }
        /// <summary>
        /// Input: s = 7, nums = [2,3,1,2,4,3]
        //Output: 2
        //Explanation: the subarray[4, 3] has the minimal length under the problem constraint.
        /// </summary>
        private static void MinSubArrayMain()
        {
            MinSizeSubArraySum lcFbAr = new MinSizeSubArraySum();
            int[] a = { 1, 1 };//{ 1,2,3,4,5};//{ 2, 3, 1, 2, 4, 3 };
            int k =  3;//11;//7;
            int res = lcFbAr.MinSubArrayLen(a,k);
        }
        /// <summary>
        /// /We start with trimming.
        //If we see[0 - 9] we reset the number flags.
        //We can only see. if we didn't see e or ..
        //We can only see e if we didn't see e but we did see a number. We reset numberAfterE flag.
        //We can only see + and - in the beginning and after an e
        //any other character break the validation.
        //At the and it is only valid if there was at least 1 number and if we did see an e then a number after it as well.
        //So basically the number should match this regular expression:
        //[-+]?(([0 - 9]+(.[0-9]*)?)|.[0-9]+)(e[-+]?[0 - 9]+)?
        /// </summary>
        private static void IsValidNumberMain()
        {
            string number = "123";
            ValidNumber lcFbAr = new ValidNumber();
            bool isValid = lcFbAr.IsNumber(number);
        }

        /// <summary>
        /// Input: "abca"
        //Output: True
        //Explanation: You could delete the character 'c'.
        //Input: "aba"
        //Output: True
        /// </summary>
        private static void IsValindPalindromeMain()
        {
            string palindrString = "abca";
            ValidPalindrome2 lcFbAr = new ValidPalindrome2();
            bool isValid = lcFbAr.IsValidPalindrome2(palindrString);
        }
        /// <summary>
        /// //            Valid Palindrome
        //  Go to Discuss
        //Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        //Note: For the purpose of this problem, we define empty string as valid palindrome.
        //Example 1:

        //Input: "A man, a plan, a canal: Panama"
        //Output: true
        //Example 2:

        //Input: "race a car"
        //Output: false
        /// </summary>
        private static void IsPalindromeMain()
        {
            ValidPalindrome lcFbAr = new ValidPalindrome();
            string palindromeString = "A man, a plan, a canal: Panama";
            bool isValid = lcFbAr.IsPalindrome(palindromeString);
        }
        private static void IntersectMain()
        {
            //Input: nums1 = [1,2,2,1], nums2 = [2,2]
            //Output: [2, 2]
            //Example 2:
            //Input: nums1 = [4, 9, 5], nums2 = [9, 4, 9, 8, 4]
            //Output: [4, 9]            //
            IntersectionOfTwoArrays2 lcFbAr = new IntersectionOfTwoArrays2();
            //int[] a = { 1, 2, 2, 1 };
            //int[] b = {2,2 };
            int[] a = { 4, 9, 5,9 };
            int[] b = { 9, 4, 9, 8, 4 };
            lcFbAr.ArrayIntersect(a, b);
        }
        private static void AddBinaryMain()
        {
            string a = "1";
            string b = "10";
            AddBinaryCls lcFbAr = new AddBinaryCls();
            string res = lcFbAr.AddBinary(a,b);
        }
        private static void MoveZerosMain()
        {
            //Input: [0,1,0,3,12]
            //Output: [1, 3, 12, 0, 0]
            MoveZerosCls lcFbAr = new MoveZerosCls();
            int[] a = { 0, 1, 0, 3, 12 };
            lcFbAr.MoveZeros(a);
        }
        private static void ThreeSumMain()
        {
            //Input: [0,1,0,3,12]
            //Output: [1, 3, 12, 0, 0]
            ThreeSumCls lcFbAr = new ThreeSumCls();
            // int[] a = { -1, 0, 1, 2, -1, -4 };
            //IList<IList<int>> lst =  lcFbAr.ThreeSum(a);
            int[] a = { 0, 2, 1, -3 };//{ 1,1,1,0};// { -1, 2, 1, -4 };
            int target = 1;//100;
            IList<IList<int>> lst = lcFbAr.ThreeSum(a,target);
        }
        #endregion

       
        #endregion

        #region leetCodeGeneralPgmng
        private static void LongestValidParenthesesMain()
        {
            LeetcodeGeneral lcG = new LeetcodeGeneral();
            string paranthesis = "(()";
            lcG.LongestValidParentheses(paranthesis);
        }

        public static int FibSeries(int n)
        {
            long a = 0;
            long b = 1;
            long fibSum = 0;
            for (int i = 2; i <= n; i++)
            {
                fibSum = a + b;
                if (fibSum % 2 != 0)
                    Console.Write(" {0} thats odd ", fibSum);
                else
                    Console.WriteLine(" {0} ", fibSum);
                a = b;
                b = fibSum;
            }
            return 0;
            //if (n == 1 || n == 0)
            //    return n;
            //else
            //    int m = FibSeries(n - 1)+FibSeries(n-2);
        }
        #endregion

        
        #region LeetCodeAmazon
        private static void MinWindowSubstringMain()
        {
            Others ot = new Others();
            //Input: S = "ADOBECODEBANC", T = "ABC"
            //Output: "BANC"
            //string s = "XMLABDCOBECODEBANC"; //"aa";// "ADOBECODEBANC";
            //string t = "ABC"; //"aa";// "ABC";
            //string res = ot.MinWindowSubstring(s,t);
            string s = "aeiaaioooaauuaeiou"; //"aa";// "ADOBECODEBANC";
            string t = "aeiou"; //"aa";// "ABC";
            string res = ot.MaxWindowSubstringOpt(s, t);
        }
        private static void MaxSubArraySizeK()
        {
            // int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int k = 3;
            //int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
            //int k = 3;
            int[] arr = { 9,11 };
            int k = 2;
            Others ot = new Others();
            int [] s = ot.MaxSlidingWindowSizeK(arr, k);
        }
        private static void NumOfIslandsMain()
        {
            int[,] M = new int[,] {{1, 1, 1, 1, 0},
                                   {1, 1, 0, 1, 0},
                                   {1, 1, 0, 0, 0},
                                   {0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0}};
            //output =5
            //Others oth = new Others();
            //int output = oth.NumOfIslands(M);
            Graphss.NoOfIslands obj = new Graphss.NoOfIslands();
            int res = obj.NoOfIslandsCount(M);

        }
        private static void NumOfDistinctIslandsMain()
        {
            int[,] M = new int[,] {{1, 1, 0, 1, 1},
                                   {1, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 1},
                                   {1, 1, 0, 1, 1} };
            //output =5
            //Others oth = new Others();
            //int output = oth.NumOfIslands(M);
            Graphss.NoOfIslands obj = new Graphss.NoOfIslands();
            int res = obj.NoOfIslandsCountDistinct(M);

        }
        private static void SingleNumberMain()
        {
            Others oth = new Others();
            int[] a = {1, 2, 1, 2,4 };
            oth.SingleNumber2(a);
        }
        private static void MaxSubArrayMain()
        {
            LcAmznDynamicPgmng lcDynmc = new LcAmznDynamicPgmng();
            int[] a = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int n = lcDynmc.MaxSubArray(a);
        }
        private static void BuySellStockMain()
        {
            LcAmznDynamicPgmng lcDynmc = new LcAmznDynamicPgmng();
            int[] a = { 7, 1, 5, 3, 6, 4 };
            int n =   lcDynmc.BuySellStock(a);
        }
        private static void ClimbStairsMain()
        {
            LcAmznDynamicPgmng lcDynmc = new LcAmznDynamicPgmng();
            int n = lcDynmc.ClimbStairs(4);
        }
        private static void FindLaddersCountMain()
        {
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordList = new List<string>();
            //{ "hot", "dot", "dog", "lot", "log", "cog" };
            //HashSet<string> wordList = new HashSet<string>();
            wordList.Add("hot");
            wordList.Add("dot");
            wordList.Add("dog");
            wordList.Add("lot");
            wordList.Add("log");
            wordList.Add("cog");
            //int res = LeetCodeAmazon.FindLaddersCount(beginWord,endWord,wordList);
            //LeetCodeAmazon ltAmz = new LeetCodeAmazon();
            LcAmazonSortSearch ltAmz = new LcAmazonSortSearch();
            IList<IList<String>> lst = ltAmz.FindLadders(beginWord, endWord, wordList);


            //Solution2 sol2 = new Solution2();
            //List<List<String>> lst = sol2.findLadders(beginWord, endWord, wordList);

            /*Dictionary = {POON, PLEE, SAME, POIE, PLEA, PLIE, POIN}
             start = TOON
             target = PLEA
             Output: 7
             Explanation: TOON - POON - POIN - POIE - PLIE - PLEE - PLEA */

            //string beginWord1 = "TOON";
            //string endWord1 = "PLEA";
            //string[] dict = { "POON", "PLEE", "SAME", "POIE", "PLEA", "PLIE", "POIN" };
            //Array.Sort(dict);
            //Array.Reverse(dict);
            //IList<String> lstDict = new List<String>();
            //for (int i = 0; i < dict.Length; i++)
            //{
            //    lstDict.Add(dict[i]);
            //}
            //IList<String> lstRes = LeetCodeAmazon.FindLaddersMyCode(beginWord1, endWord1, lstDict);
        }
        private static void LetterCombinationsMain()
        {
            List<string> lst = LeetCodeAmazon.LetterCombinations("23");
        }

        private static void CombinationSumMain()
        {
            //[2,3,6,7], target = 7,
            int[] a = { 2, 3, 6, 7 };
            int target = 7;
            IList<IList<int>> lst = LeetCodeAmazon.CombinationSum(a, target);
        }
        private static void ProductArrayExceptSelfMain()
        {
            int[] Input = { 1, 2, 3, 4 };
            //Output: [24, 12, 8, 6]
            int [] outPut = LeetCodeAmazon.ProductArrayExceptSelf(Input);
        }
        private static void LongestPalindromeMain()
        {
            String str = "bananas";//"forgeeksskeegfor";
            LeetCodeAmazon.LongestPalindrome(str);
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
            //Input: version1 = "7.5.2.4", version2 = "7.5.3"
            //Output: -1
            string version1 = "1", version2 = "1.1";
            int result = LeetCodeAmazon.CompareVersion(version1,version2);
        }

        private static void MaxSizeSubArrSumMain()
        {
            //Input: nums = [1, -1, 5, -2, 3], k = 3
            //Output: 4
            int[] a = { -2, -1, 2, 1 };//{ 1, -1, 5, -2, 3 };
            int k = 1;//3;
            int m = LeetCodeAmazon.MaxSizeSubArrSum(a, k);
        }
        private static void ReverseWordsMain()
        {
            char[] Input = { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' };

            //char[] Output = { 'b', 'l', 'u', 'e', ' ', 'i', 's', ' ', 's', 'k', 'y', ' ', 't', 'h', 'e' };

            LeetCodeAmazon.ReverseWords(Input);
        }
        private static void ReverseStringMain()
        {
            string s = LeetCodeAmazon.ReverseString("hello");
        }
        private static void UniqueCharStringMain()
        {
            string str = "loveleetcode";
            int index = LeetCodeAmazon.UniqueCharString(str);
        }

        #endregion

        #region ArrayAlg
        private static void TrapRainWaterMain()
        {
            int[] arr = { 3, 0, 0, 2, 0, 4 };
            ArraysAlgorithms.FindWater(arr, arr.Length);
        }
        private static void ReverseArrayInGroupMain()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int k = 3;
            ArraysAlgorithms.ReverseArrayInGroup(a, k);
        }
        private static void MaximumPlatformNeededMain()
        {
            int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
            int[] dep = { 910, 1120, 1130, 1200, 1900, 2000 };
            int k = ArraysAlgorithms.MaximumPlatformNeeded(arr, dep);
        }
        private static void LeaderInArrayMain()
        {
            int[] a = { 16, 17, 4, 3, 5, 2 };
            ArraysAlgorithms.LeadersArray(a);
        }

        //Subarray with given sum
        private static void SubArraySumMain()
        {
            int[] a = { 1, 4, 20, 3, 10, 5 };
            int sum = 33;
            ArraysAlgorithms.subArraySum(a, sum);
        }

        //Maximum sum increasing subsequence
        private static void MaxSumIncreasingSubSeqMain()
        {
            int[] a = { 1, 101, 2, 3, 100, 4, 5 };
            int sum = ArraysAlgorithms.MaximumIncreasingSubSeq1(a);
        }

        //--//Maximum of all subarrays of size k

        //Kadane Algorithm
        private static void LargestContiguousSubArrMain()
        {
            int[] a = { -2, -3, 4, -1, -2, 1, 5 };
            int largestNum = ArraysAlgorithms.LargestSumContiguousArray(a);
        }

        private static void EquilibriumIndexMain()
        {
            int[] a = { -7, 1, 5, 2, -4, 3, 0 };
            int equiIndex = ArraysAlgorithms.EquilibriumIndex(a);
        }

        private static void Sort012Main()
        {
            int[] a = { 0, 1, 2, 0, 1, 2 };
            ArraysAlgorithms.sort012(a, a.Length);
        }


        #endregion

        #region Microsoft
        private static void CheckZeroSumSubArrayExistsMain()
        {
            GeeksForGeeksRevision.Microsoft.Arrays.General general = new Microsoft.Arrays.General();

            int[] a = {7,4,2,-5,1,1,2,1,9,8 };
            bool res = general.CheckZeroSumSubArrayExists(a);
            bool res2 = general.subArrayExists(a);
        }

        private static void ArrangeLargestNum()
        {
            int[] a = { 54, 546, 548, 60 };
            MicrosoftAlg.ArrangeLargestNumFromArray(a);
        }
       

        private static void CheckAnagramString()
        {
            bool isAnagram = MicrosoftAlg.Anagram("SILENT1", "LISTEN");
        }
        private static void PushNegetiveNumLeftMain()
        {
            int[] input = { 4, -3, 2, -5, 5, -1, 3 };
            //output = { -3,-5, -1, 4, 2, 5, 3}

            MicrosoftAlg.PushNegativeNumLeft(input);
        }
        private static void MergeSort()
        {
            int[] A = { 1, 5, 7, 12, 18, 32 };
            int[] B = { 2, 4, 9, 16, 27, 76, 98 };
            MicrosoftAlg.MergeSortedArray(A, B);
        }
        private static void MaxRepeatingChar()
        {
            MicrosoftAlg.MaxRepeatingChar("aaaaaabbcbbbbbcbbbbddddddddddd");
        }
        #endregion

        #region recursion
        private static void PrintMaxNumOfAs()
        {
            int n = 9;
            int k = recObj.PrintMaxNumberOfA(n);
        }
       
        private static int CallNumOfPaths()
        {
            NumOfPathsMatrix obj = new NumOfPathsMatrix();
            return obj.NumberOfPathsMatrix(3, 3);
        }
        private static int CallRecursion(int n)
        {
            //Recursion recObj = new Recursion();
            return recObj.Fibonacci(n);
        }
        private static int CallGCD(int m, int n)
        {
            //Recursion recObj = new Recursion();
            return recObj.GCD(m, n);
        }
        private static void FloodFill()
        {

            int[,] screen = {{1, 1, 1, 1, 1, 1, 1, 1},
          {1, 1, 1, 1, 1, 1, 0, 0},
          {1, 0, 0, 1, 1, 0, 1, 1},
          {1, 2, 2, 2, 2, 0, 1, 0},
          {1, 1, 1, 2, 2, 0, 1, 0},
          {1, 1, 1, 2, 2, 2, 2, 0},
          {1, 1, 1, 1, 1, 2, 1, 1},
          {1, 1, 1, 1, 1, 2, 2, 1},
         };
            int x = 4, y = 4, newC = 3;
            FloodFill floodFill = new FloodFill();
            floodFill.FloodFillUtil(screen, x, y, 2, newC);

            Console.WriteLine("Updated screen after call to floodFill: n");
            int M = screen.GetUpperBound(0) + 1;
            int N = screen.GetUpperBound(1) + 1;
            for (int i = 0; i < M; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < N; j++)
                    Console.Write(screen[i, j]);
            }
        }

        #endregion

        #endregion

    }
}
