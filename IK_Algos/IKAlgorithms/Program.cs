using IK_Algorithms.Amazon;
using IK_Algorithms.DynamicProgramming;
using IK_Algorithms.Graphs;
using IK_Algorithms.MockTests;
using IK_Algorithms.Recursion;
using IK_Algorithms.SortingAlgs;
using IK_Algorithms.Trees;
using SortingAlgorithms.IK_TimedTests;
using SortingAlgorithms.SortingAlgs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            #region GraphIK
            //GraphAlgos();
            #endregion

            #region recursive-backtracking
            //Console.WriteLine("Hello World!");
            //SortingAlgorithmsMain();
            //RecurivePgmsMain();
            //AmazonPrograms();
            #endregion

            #region MockTest
            MockTestAlgorithms();
            #endregion

            #region Trees
            //CallTreeFunctions();
            #endregion

            #region DynamicPgmng
            //DynamicProgrammingAlgosMain();
            #endregion
        }

        #region GraphIK
        private static void GraphAlgos()
        {
            //ShortestPath graphDS = new ShortestPath();

            //int[][] grid = new int[][]
            //                {
            //                    new int[]{0,0,0 },
            //                    new int[]{1,1,0 },
            //                    new int[]{1,1,0 },
            //                };

            int[][] grid = new int[][]
                            {
                                new int[]{0,1 },
                                new int[]{1,0 },
                            };

            //int res = graphDS.ShortestPathBinaryMatrix(grid);

            //Bipartite bpAlg = new Bipartite();

            //bool res = bpAlg.IsBipartite(grid);

            //KeysAndRooms keysAndRooms = new KeysAndRooms();
            //IList<IList<int>> lstofLst = new List<IList<int>>();
            //IList<int> lst = new List<int>();
            ////[1,3],[3,0,1],[2],[0]
            //lst.Add(1);
            //lst.Add(3);
            //lstofLst.Add(new List<int>(lst));

            //lst = new List<int>();
            //lst.Add(3);
            //lst.Add(0);
            //lst.Add(1);
            //lstofLst.Add(new List<int>(lst));

            //lst = new List<int>();
            //lst.Add(2);
            //lstofLst.Add(new List<int>(lst));

            //lst = new List<int>();
            //lst.Add(0);
            //lstofLst.Add(new List<int>(lst));


            //bool reskey = keysAndRooms.CanVisitAllRooms(lstofLst);


            EvaluateDivision objEvaluate = new EvaluateDivision();
            //https://leetcode.com/problems/evaluate-division/
            //Input: equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0], queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
            //Output: [3.75000, 0.40000, 5.00000, 0.20000]

            // Input: equations = [["a", "b"],["b","c"]], values = [2.0,3.0],
            //queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
            //Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
            //IList<IList<string>> equations = new List<IList<string>>();
            //IList<string> lst = new List<string>();
            ////[1,3],[3,0,1],[2],[0]
            //lst.Add("a");
            //lst.Add("b");
            //equations.Add(new List<string>(lst));

            //lst = new List<string>();
            //lst.Add("b");
            //lst.Add("c");
            //equations.Add(new List<string>(lst));

            //double[] values = new double[] { 2.0, 3.0 };

            //IList<IList<string>> queries = new List<IList<string>>();
            //IList<string> lstquery = new List<string>();

            //lstquery.Add("a");
            //lstquery.Add("c");
            //queries.Add(new List<string>(lst));

            //lstquery = new List<string>();
            //lstquery.Add("b");
            //lstquery.Add("a");
            //queries.Add(new List<string>(lst));

            //lstquery = new List<string>();
            //lstquery.Add("a");
            //lstquery.Add("e");
            //queries.Add(new List<string>(lst));

            //lstquery = new List<string>();
            //lstquery.Add("a");
            //lstquery.Add("a");
            //queries.Add(new List<string>(lst));

            //objEvaluate.CalcEquation(equations,values,queries);

            //number of Island
            NumOfIslands numOfIslands = new NumOfIslands();

            //        Input: grid = [
            //  ["1", "1", "1", "1", "0"],
            //  ["1","1","0","1","0"],
            //  ["1","1","0","0","0"],
            //  ["0","0","0","0","0"]
            //]
            //Output: 1
            //Example 2:
            //Input: grid = [
            //  ["1","1","0","0","0"],
            //  ["1","1","0","0","0"],
            //  ["0","0","1","0","0"],
            //  ["0","0","0","1","1"]
            //]
            //Output: 3

            //char[,] grd = { 
            //    { '1', '1', '1', '1', '0' }
            //   ,{ '1', '1', '0', '1', '0' }
            //   ,{ '1', '1', '0', '0', '0' }
            //   ,{ '0', '0', '0', '0', '0' }
            //};

            //char[,] grd2 = {
            //    { '1', '1', '0', '0', '0' }
            //   ,{ '1', '1', '0', '0', '0' }
            //   ,{ '0', '0', '1', '0', '0' }
            //   ,{ '0', '0', '0', '1', '1' }
            //};

            //NumOfIslands objIsland = new NumOfIslands();
            //int ret = objIsland.NumIslands(grd2);

            //int[][] board = { new int[] { -1, -1, -1, -1, -1, -1 }
            //                  , new int[] { -1, -1, -1, -1, -1, -1 }
            //                  , new int[] { -1, -1, -1, -1, -1, -1 }
            //                  , new int[] { -1, 35, -1, -1, 13, -1 }
            //                  , new int[] { -1, -1, -1, -1, -1, -1 }
            //                  , new int[] { -1, 15, -1, -1, -1, -1 }
            //                };

            //SnakeAndLadder objSnake = new SnakeAndLadder();
            //objSnake.SnakesAndLadders(board);


            CourseSchedule courseSchedule = new CourseSchedule();
            //int numCourses = 2;
            //int[][] prerequisites = { new int[] { 1, 0 } };
            //int[][] prerequisites = { new int[] { 1, 0 }
            //                          ,new int[] { 0, 1 }};
            //int numCourses = 3;

            //int[][] prerequisites = { new int[] { 0, 2 }
            //                          ,new int[] { 1, 2 }
            //                          ,new int[] { 2, 0 }};
            //bool res = courseSchedule.CanFinish(numCourses, prerequisites);
            //Input: numCourses = 4, prerequisites = [[1, 0],[2,0],[3,1],[3,2]]
            //    Output: [0, 2, 1, 3]
            //numcourses: 3
            //prerequisite: [[0,2],[1,2],[2,0]] 
            //int[][] prerequisites2 = { new int[] { 1, 0 }
            //                                ,new int[] { 2, 0 }
            //                                ,new int[] { 3, 1 }
            //                                ,new int[] { 3, 2 }};
            //int[] orderOfCourse = courseSchedule.FindOrder(numCourses, prerequisites);

            CriticalConnection conn = new CriticalConnection();

            List<IList<int>> lst = new List<IList<int>>();
            
            IList<int> lstInner = new List<int>();
            lstInner.Add(0);
            lstInner.Add(1);
            lst.Add(lstInner);

            IList<int> lstInner2 = new List<int>();
            lstInner2.Add(1);
            lstInner2.Add(2);
            lst.Add(lstInner2);

            IList<int> lstInner3 = new List<int>();
            lstInner3.Add(2);
            lstInner3.Add(0);
            lst.Add(lstInner3);

            IList<int> lstInner4 = new List<int>();
            lstInner4.Add(3);
            lstInner4.Add(0);
            lst.Add(lstInner4);

            IList<int> lstInner5 = new List<int>();
            lstInner5.Add(3);
            lstInner5.Add(4);
            lst.Add(lstInner5);

            
            conn.CriticalConnections(5, lst);

        }


        #endregion


        #region MockTest
        /// <summary>
        /// 
        /// </summary>
        private static void MockTestAlgorithms()
        {

            //IK_Algorithms.MockTests.ArraysStrings objMocktest = new IK_Algorithms.MockTests.ArraysStrings();

            //int[] speed = { 2, 10, 3, 1, 5, 8 };
            //int[] proficiency = { 5, 4, 3, 9, 7, 2 };
            //int countwrkr = 3;
            //objMocktest.CalculateTeamQuality(speed, proficiency, countwrkr);
            //string str = "abc";
            // objMocktest.GenerateAbbrivation(str);

            DecodeWays decodeWays = new DecodeWays();
            string input = "226";
            int res = decodeWays.NumDecodings(input);

        }

        #endregion

        #region Trees
        private static void CallTreeFunctions()
        {
            TreeAlgos treeAlgos = new TreeAlgos();



            //Print first leftmost node in a tree
            //Tree root = ConstructTreeNode(5, 3, 7, null, 4, 6, 8);
            //root.right.right.right = new Tree(9);
            //treeAlgos.PrintLeftMostNode(root);

            //Tree root = ConstructTreeNode(5, 2, 7, 2, 2, null, null);//ConstructTreeNode(5, 1, 5, 5, 5, null, 5);
            //int  counter = 0;
            //treeAlgos.IsUniValue(root, ref counter);

            //Tree root1 = ConstructTreeNode(1, 2, 3, 4, null, 6, 7);
            //Tree root2 = ConstructTreeNode(1, 5, 8, null, 4, 6, 7);

            //bool isSame = treeAlgos.IsLeafNodesSame(root1,root2);

            //Tree root = ConstructTreeNode(5, 3, 7, 2, 4, 6, 8);

            //treeAlgos.ConvertTree2DoublyLinkedList(root);

            //Tree root = ConstructTreeNode(5, 3, 7, 2, 4, 6, 8);
            //bool ret = treeAlgos.TreePathSum(root, 12);

        }


        /// <summary>
        ///    a
        ///   /  \
        ///   b   c
        ///  /\   /\
        ///  d e  f g
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        private static Tree ConstructTreeNode(int? a, int? b, int? c, int? d, int? e, int? f, int?  g)
        {
            Tree treeNode = new Tree(a);
            treeNode.left = new Tree(b);
            treeNode.right = new Tree(c);
            treeNode.left.left = new Tree(d);
            treeNode.left.right = new Tree(e);

            treeNode.right.left = new Tree(f);
            treeNode.right.right = new Tree(g);

            return treeNode;
        }

        #endregion

        #region AmazonPgms
        private static void AmazonPrograms()
        {
            AmazonAlgo amazonAlgo = new AmazonAlgo();
            int instances = 2;
            int[] avgUtilArr = { 25, 23, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 76, 80 };
            List<int> avgUtil = new List<int>(avgUtilArr);
            int res = amazonAlgo.finalInstances(instances, avgUtil);

            string s = "|**|*|*";
            int[] startIndices = { 1,1};
            int[] endIndices = { 5,6};
            
           List<int> lst = amazonAlgo.numberOfItems(s,new List<int>(startIndices), new List<int>(endIndices));

        }

        #endregion

        #region DynamicPgmng
        private static void DynamicProgrammingAlgosMain()
        {
            int []arr = new int[] {1, 5, 8, 9, 10, 17, 17, 20}; 
            int size = arr.Length;

            CuttingRod cuttingRod = new CuttingRod();
            int res = cuttingRod.CutRod(arr, size);


            ///ClimbingStairs obj1 = new ClimbingStairs();
            ////int resRec = obj1.ClimbStairsRec(5);
            ////int resDP = obj1.ClimbStairsDP(5);
            //int[] a = { 10, 15, 20 };
            ////int[] a = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            //int resCostStairs = obj1.MinCostClimbingStairs(a);
            //int n = 7; int[] steps = { 2, 3 };

            // int n = 5; int[] steps = { 1,2, 3,4,5 };
            //int n = 1; int[] steps = { 1, 2 };
            //long numWays = obj1.CountWaysToClimb(steps, n);

            //CombinationSubsetOfSizeK obj2 = new CombinationSubsetOfSizeK();
            ////int res2 = obj2.SubsetOfSizeKRec(4, 2);
            ////int resdp2 = obj2.SubsetOfSizeKDP(4, 2);

            //UniquePathGrid obj3 = new UniquePathGrid();
            //int res3 = obj3.UniquePathsRec(7,3);
            //int res3dp = obj3.UniquePathsDP(3, 3);

            //int[][] grid = new int[][] { new int[] {0,0,0 }
            //                            , new int[] {0,1,0 }
            //                            , new int[] {0,0,0 }};
            //int res3dp2 = obj3.UniquePathsWithObstacles(grid);


            //int[][] gridSum = new int[][] { new int[] {1,3,1 }
            //                            , new int[] {1,5,1 }
            //                            , new int[] {4,2,1 }};

            //int maxPathSum = obj3.MaxPathSum(gridSum);

            //CoinChange coinChange = new CoinChange();
            //int[] coins = { 1, 2, 3}; //{ 9, 6, 5, 1 };  
            //int amount = 5;//12;//4;
            //int numCoins = coinChange.CoinChangeRec(coins,amount);

            //int numCoinsdp = coinChange.CoinChangeDP(coins, coins.Length, amount);

            //int numCoinsdpBU = coinChange.CoinChangeDP_TopDown(coins, amount);

            //int numCoinsDFS = coinChange.CoinchangeDP_TopDown_DFS(coins, amount);

            //int numCoinsDpBottomUp = coinChange.CoinChangeDP_MatrixBottomUp(coins, amount);
            
            //int minCoins = coinChange.CoinchangeMinRec(coins, amount);

            //int minCoinsDPBU = coinChange.MinCoins_DP_bottomup(coins, amount);

            //int[] coins2 = {1,2,3 };
            //int amount2 = 4;
            //int minCoins2 = coinChange.minCoins(coins2, coins2.Length, amount2);

            //LevenshteinDistanceAlg objEditDist = new LevenshteinDistanceAlg();
            //string word1 = "horse";// "intention"; 
            //string word2 = "ros";//"execution";

            //int editDistance = objEditDist.LevenshteinDistance(word1, word2);

            //Robber objRob = new Robber();
            //int[] rb = {9,1,1,1,1,1,9 };
            //objRob.Rob(rb);

            //PartitionSubset objSubset = new PartitionSubset();
            //int[] partSubset = { 1, 5, 11, 5 };//{1,2,3,5 };//{ 1, 2, 5 };// { 1, 2, 3, 4, 5, 6, 7 };
            //bool isSubset = objSubset.CanPartition(partSubset);

            //bool isSubsetDynamic = objSubset.CanPartition_DP_TopDwn(partSubset);

            //bool isSubsetDynamicBtmUp = objSubset.CanPartition_DP_BottomUp(partSubset);

            //bool isSubsetDynamicBtmUp1D = objSubset.CanPartition_DP_BottomUp1DArray(partSubset);

            //bool isSubsetDynamicBtmUpArray = objSubset.CanPartition_DP_BottomUpArray(partSubset);

        }
        #endregion

        #region Recursive_backtracking
        private static void RecurivePgmsMain()
        {
            //DigitsCombination obj = new DigitsCombination();
            //obj.DigitsCombinationN(2);
            //RecursionTest obj = new RecursionTest();
            //long[] a = { 2, 4, 8 };
            //long sum = 6;
            //bool res = RecursionTest.check_if_sum_possible(a,sum);

            //LetterCaseAlg ltrCaseAlg = new LetterCaseAlg();
            //IList<string> lst = ltrCaseAlg.LetterCasePermutation("a1b2");

            //TelephoneNumLetterCombinatoin telephone = new TelephoneNumLetterCombinatoin();
            //telephone.LetterCombinations("23");

            //PermuteStringAlg permute = new PermuteStringAlg();
           // List<string> lst = permute.PermuteString("ABC");

             //SubsetsAlg subsetsAlg = new SubsetsAlg();
            //int[] a = { 1,2,2};//{ 1,2,3};
            // int[] a = { 1, 5, 11, 5 }; int sum = 11;
            // IList<IList<int>> lst = subsetsAlg.SubsetSum(a,sum);

            //PalindromeSubsets paliSubsets = new PalindromeSubsets();
            //string palindrome = "abaaba"; //"aab";//"ab";// //"aab";
            //char[] charArray = palindrome.ToCharArray();
            //IList<IList<string>> lst = paliSubsets.Partition(palindrome);

            //string[] res = paliSubsets.generate_palindromic_decompositions(palindrome);

            //NQueen nQueen = new NQueen();

            //nQueen.SolveNQueens(4);
            //nQueen.SolveNQueensOneDimensionalArray(4);
            //NQueen.find_all_arrangements(4);

            //calculate expression
            //TargetSum_AllExpression objTargetSum = new TargetSum_AllExpression();
            ////string inputExpr = "1+2*3+4*10+2";
            ////int resultCalculate = objTargetSum.Calculate(inputExpr);

            ////IList<IList<string>> lstComb =  objTargetSum.CombinationNumbers("1234");

            //string numExpr = "123";
            //int target =6;
            //IList<string> lstRes = objTargetSum.AddOperators(numExpr, target);

            SubsetsAlg subsetsAlg = new SubsetsAlg();

            //string res = "123";

            //string[] lstStr = subsetsAlg.generate_all_subsets(res);
           // int[] a = { 1, 2, 3 };
          // IList<IList<int>> lst =  subsetsAlg.Subsets(a);

        }

        #endregion

        private static void SortingAlgorithmsMain()
        {
            int[] a = { 9, 4, 10, 22, 1, 6 };

            InsertionSortAlg obj = new InsertionSortAlg();
            //int[] res = obj.InsertionSort(a);
            //int[] res = obj.SelectionSortMyCode(a);


            //BubbleSortAlg obj = new BubbleSortAlg();
            //int[] res = obj.BubbleSort(a);

            //SelectionSortAlg obj = new SelectionSortAlg();
            //int[] res = obj.SelectionSort(a);

            //MergeKsortedArray objMrg = new MergeKsortedArray();


            //int[][] arr = new int[][]{new int[]{1, 3, 5, 7 }, new int[]{ 2, 4, 6, 8 }, new int[]{ 0, 9, 10, 11 } };

            //int[] res = MergeKsortedArray.mergeArrays(arr);
            //List<char> lst = new List<char>();
            //lst.Add('G');
            //lst.Add('B');
            //lst.Add('G');
            //lst.Add('G');
            //lst.Add('R');
            //lst.Add('B');
            //lst.Add('R');
            //lst.Add('G');
            //DutchFlag.Sort(lst);
            //int[] c = { 1,3,5};
            //int[] b = {2,4,6,0,0,0 };
            //DutchFlag.merger_first_into_second(c,b);

            // MergesortAlg objMerge = new MergesortAlg();

            //int[] sort = { 2, 6, 5, 4, 3, 1 };

            //objMerge.MergeSort(sort);

            // objMerge.MergeSortMyCode(sort);
            //List<int> lst = new List<int>();
            //lst.Add(2);
            //lst.Add(6);
            //lst.Add(5);
            //lst.Add(4);
            //lst.Add(3);
            //lst.Add(1);
            //objMerge.merge_sort(lst);

            //int[] sortQk =  { 10, 7, 8, 9, 1, 5 }; //{ 2, 6, 5, 4, 3, 1 };
            //QuickSortAlg objQuickSrt = new QuickSortAlg();
            //objQuickSrt.QuickSort(sortQk);

            //int[] sortQk = {12, 11, 13, 5, 6, 7};//{ 10, 7, 8, 9, 1, 5 };

            //HeapSortAlg objHeapSrt = new HeapSortAlg();
            //objHeapSrt.HeapifySort(sortQk);

            //KthLargest kthLargest = new KthLargest();
            //int[] kLrgst = { 1, 5, 4, 8, 2 };
            //kthLargest.topK(kLrgst, 2);

            int[] arrThreeSum = { -1, 0, 1, 2, -1, -4 }; //{ 10, 3, -4, 1, -6, 9 };
            ThreeSum threeSum = new ThreeSum();
            threeSum.findZeroSum(arrThreeSum);

        }
    }
}
