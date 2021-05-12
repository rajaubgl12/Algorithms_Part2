using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeAlgos.Microsoft;
using PracticeAlgos.LinkedList;
using PracticeAlgos.General;
using System.Collections;

namespace PracticeAlgos
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Mixed
            //GeneralPractice();
            //ThreesumMain();
            //MinWindowSubstringMain();
            RecursivePrograms();
            #endregion

            #region arrays
            //MaxRepeatingCharsMain();
            //MergeSortedArrayMain();
            //MoveNegativeIntLeftMain();
            //MoveZeroLeftMain();
            //FindDifferencePairMain();
            //CountAllPairsGivenSumMain();
            #endregion

            #region LinkedList
            //ReverseLinkedListMain();
            //ReverseLinkedListInGroupMain();
            #endregion

            #region Trees

            #endregion

            #region general
            //MaxRepeatedWrdsMain();
            //TopNRecordsBasedOnIndex();
            //CoinChangeMain();
            //deleteProducts(new List<int>(), 3);
            //longestVowelSubsequence("");
            //PermuteMainTest();
            //RecursiveExample(4,0,4);
            //int res = NumberOfPathsMatrix(3, 3);
            //CombinationSumII();
            //SortTwoCategory();
            #endregion
        }

        private static void RecursivePrograms()
        {
            RecursivePgmsEx objRec = new RecursivePgmsEx();
            int res = objRec.AddNumbers(4);
        }




        #region Mixed

        private static void GeneralPractice()
        {
            //MergeSort merge = new MergeSort();
            ////int[] arr = { 12, 11, 13, 5, 6, 7 , 4, 1,10, 3,9,2,8};

            ////merge.MergeSortAlg(arr);

            //// int[] arr = { 2,3,1};

            //SortedList<int, int> lst = new SortedList<int, int>();

            //lst.Add(9, 1);
            //lst.Add(10, 1);
            //lst.Add(1, 1);

            //lst.Add(6, 1);
            //lst.Add(2, 1);
            //lst.Add(3, 1);


            //merge.RemoveKdigits("1432219", 3);

            

        }

        //public List<int> SearchTree(TreeNode node, List<int> values)
        //{
        //    if (node != null)
        //    {
        //        if (node.left == null && node.right == null)
        //        {
        //            values.Add(node.val);
        //        }
        //        SearchTree(node.left, values);
        //        SearchTree(node.right, values);
        //    }
        //    return values;
        //}

        //public bool LeafSimilar(TreeNode root1, TreeNode root2)
        //{
        //    var treeValues1 = new List<int>();
        //    SearchTree(root1, treeValues1);
        //    var treeValues2 = new List<int>();
        //    SearchTree(root2, treeValues2);

        //    return treeValues1.SequenceEqual(treeValues2);
        //}

        private static void MinWindowSubstringMain()
        {
            MinWindowSubstring obj = new MinWindowSubstring();
            string s = "DXZCABKCDEFCGHIBAKMLNGJC";
            string t = "ABC";
            string res = obj.MinWindow(s, t);
        }

        private static void ThreesumMain()
        {
            ThreeSumCls obj = new ThreeSumCls();
            int[] a = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> res =  obj.ThreeSum(a,0);
        }

        #endregion

        #region LinkedList

        private static void ReverseLinkedListMain()
        {
            LInkedListPrograms obj = new LInkedListPrograms();
            LinkedList.LinkedList list = new LinkedList.LinkedList(2);
            list.next = new LinkedList.LinkedList(3);
            list.next.next = new LinkedList.LinkedList(4);
            list.next.next.next = new LinkedList.LinkedList(5);
            obj.RevLinkedList(list);
        }

        private static void ReverseLinkedListInGroupMain()
        {
            LInkedListPrograms obj = new LInkedListPrograms();
            LinkedList.LinkedList list = new LinkedList.LinkedList(1);
            list.next = new LinkedList.LinkedList(2);
            list.next.next = new LinkedList.LinkedList(3);
            list.next.next.next = new LinkedList.LinkedList(4);
            list.next.next.next.next = new LinkedList.LinkedList(5);
            list.next.next.next.next.next = new LinkedList.LinkedList(6);
            list.next.next.next.next.next.next = new LinkedList.LinkedList(7);
            list.next.next.next.next.next.next.next = new LinkedList.LinkedList(8);
            list.next.next.next.next.next.next.next.next = new LinkedList.LinkedList(9);
            LinkedList.LinkedList res = obj.RevLinkedListInGroup(list, 3);
        }

        #endregion

        #region Trees


        #endregion

        #region ArrayString
        private static void CountAllPairsGivenSumMain()
        {
            //int[] a = {1,1,1,1 };
            //int sum = 2;
            int[] a = { 1, 2, 3, 4, 4, 5, 5 };
            int sum = 8;
            ArraysAlgo arraysAlgo = new ArraysAlgo();
            int count = arraysAlgo.CountAllPairsGivenSum(a, sum);
        }

        private static void FindDifferencePairMain()
        {
            ArraysAlgo arraysAlgo = new ArraysAlgo();
            //Input: arr[] = {9, 29,10, 2, 50, 24, 100}, n = 50
            //Output: Pair Found: (50, 100)
            int[] a = { 9, 29, 10, 2, 50, 24, 100 }; int n = 50;
            arraysAlgo.FindPairForDiff(a,n);
        }

        private static void MoveZeroLeftMain()
        {
            ArraysAlgo arraysAlgo = new ArraysAlgo();
            int[] input = { 0, 1, 0, 1, 0, 0, 1, 1, 1, 0 }; //output = { -3,-5, -1, 4, 2, 5, 3}
            arraysAlgo.MoveZeroLeft(input);
        }
        private static void MoveNegativeIntLeftMain()
        {
            ArraysAlgo arraysAlgo = new ArraysAlgo();
            int[] input = { 4, -3, 2, -5, 5, -1, 3 }; //output = { -3,-5, -1, 4, 2, 5, 3}
            arraysAlgo.MoveNegativeLeft2(input);
        }

        private static void MergeSortedArrayMain()
        {
            ArraysAlgo arraysAlgo = new ArraysAlgo();
            int[] A = { 1, 5, 7, 12, 18, 32 };

            int[] B = { 2, 4, 9, 16, 27, 76, 98 };

            arraysAlgo.MergeSortedArray(A,B);
        }

        private static void MaxRepeatingCharsMain()
        {
            ArraysAlgo arraysAlgo = new ArraysAlgo();
            string str = "aaaaaabbcbbbbbcbbbb";
            char res = arraysAlgo.MaxRepeatingConsecutiveChars(str);

        }
        #endregion

        #region general

        private static void SortTwoCategory()
        {
            List<KeyValueData> lst = new List<KeyValueData>();
            KeyValueData obj1 = new KeyValueData("E",4);
            lst.Add(obj1);
            KeyValueData obj2 = new KeyValueData("D", 4);
            lst.Add(obj2);
            KeyValueData obj3 = new KeyValueData("C", 5);
            lst.Add(obj3);
            KeyValueData obj4 = new KeyValueData("A", 2);
            lst.Add(obj4);
            KeyValueData obj5 = new KeyValueData("B", 3);
            lst.Add(obj5);
            customcompare cust = new customcompare();
            lst.Sort(cust);
        }
        class customcompare : IComparer<KeyValueData>
        {
            public int Compare(KeyValueData x, KeyValueData y)
            {
                if (x.value < y.value)
                    return 1;
                if (x.value == y.value)
                    return string.CompareOrdinal(x.key, y.key);
                else
                    return -1;
            }
        }
        class KeyValueData
        {
            public int value;
            public string key;
            public KeyValueData(string key, int val)
            {
                this.value = val;
                this.key = key;
            }
        }

        public static void PermuteMainTest()
        {
            ArrayString arrayString = new ArrayString();
            arrayString.Permute("ABC");
            int[] a =  { 1, 2, 3 };
            //arrayString.PermuteArrayNumbersWithoutDups(a);
        }

        public static int deleteProducts(List<int> ids, int m)
        {
            m = 2;
            ids = new List<int>();
            ids.Add(4);
            ids.Add(1);
            ids.Add(1);
            ids.Add(1);
            ids.Add(1);
            //ids.Add(2);

            Dictionary<int, int> prodList = new Dictionary<int, int>();
            foreach (int item in ids)
            {
                if (prodList.ContainsKey(item))
                {
                    prodList[item]++;
                }
                else
                {
                    prodList.Add(item, 1);
                }
            }

            var orderByValue = prodList.OrderBy(x => x.Value);
            int minIdsCount = orderByValue.Count();

            foreach (KeyValuePair<int, int> keyVal in orderByValue)
            {
                if (m > 0)
                {
                    if (keyVal.Value == 1)
                    {
                        m--;
                        minIdsCount--;
                    }
                    else
                    {
                        int valueCount = keyVal.Value;
                        while (valueCount > 0 && m > 0)
                        {
                            m--;
                            valueCount--;
                        }
                        if (valueCount <= 0)
                            minIdsCount--;
                    }
                }


            }

            return minIdsCount;
        }


        //public static int longestVowelSubsequence(string s)
        //{
        //    if (s.Length <= 0) return -1;

        //    Dictionary<char, char> charPairs = new Dictionary<char,char>();
        //    charPairs.Add('u', 'o');
        //    charPairs.Add('o', 'i');
        //    charPairs.Add('i', 'e');
        //    charPairs.Add('e', 'a');

        //    Dictionary<char, String> currLongestSubMap = new Dictionary<char, string>();

        //    for (int i=0;i<s.Length;i++)
        //    {
        //        //get longest subs
        //        String currCharLongestSub;
        //        String precCharLongestSub = null;
        //        if (s[i] == 'a')
        //        {
        //            currCharLongestSub = currLongestSubMap.SingleOrDefault(s[i],"");
        //        }
        //        else
        //        {
        //            currCharLongestSub = runningLongestSubMap.get(currChar);
        //            char precChar = precCharMap.get(currChar);
        //            precCharLongestSub = runningLongestSubMap.get(precChar);
        //        }

        //        //update running longest subsequence map
        //        if (precCharLongestSub == null && currCharLongestSub != null)
        //        {
        //            updateRunningLongestSubMap(currCharLongestSub, currChar, runningLongestSubMap);
        //        }
        //        else if (currCharLongestSub == null && precCharLongestSub != null)
        //        {
        //            updateRunningLongestSubMap(precCharLongestSub, currChar, runningLongestSubMap);
        //        }
        //        else if (currCharLongestSub != null && precCharLongestSub != null)
        //        {
        //            //pick longer
        //            if (currCharLongestSub.length() < precCharLongestSub.length())
        //            {
        //                updateRunningLongestSubMap(precCharLongestSub, currChar, runningLongestSubMap);
        //            }
        //            else
        //            {
        //                updateRunningLongestSubMap(currCharLongestSub, currChar, runningLongestSubMap);
        //            }
        //        }
        //    }

        //    if (runningLongestSubMap.get('u') == null)
        //    {
        //        return 0;
        //    }
        //    return runningLongestSubMap.get('u').length();
        //}

        //private static void updateRunningLongestSubMap(String longestSub, char currChar,
        //                                               Map<Character, String> runningLongestSubMap)
        //{
        //    String currCharLongestSub = longestSub + currChar;
        //    runningLongestSubMap.put(currChar, currCharLongestSub);
        //}

        public static int longestVowelSubsequence(string s)
        {
            string str = "aeiaaioooaauuaeiou";
            
            int A = 0;
            int E = 0;
            int I = 0;
            int O = 0;
            int U = 0;
            int i = 0;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a')
                {
                    break;
                }
            }
            for (; i < str.Length; i++)
            {
                if (str[i] == 'a')
                {
                    A++;
                }
                else if (str[i] == 'e')
                {
                    E = Math.Max(A, E) + 1;
                }
                else if (str[i] == 'i')
                {
                    I = Math.Max(E, I) + 1;
                }
                else if (str[i] == 'o')
                {
                    O = Math.Max(I, O) + 1;
                }
                else if (str[i] == 'u')
                {
                    U = Math.Max(O, U) + 1;
                }
            }
            return U;
        }

        static bool IsVowel(char c)
        {
            return (c == 'a' || c == 'e' || c == 'i'
                    || c == 'o' || c == 'u');
        }

        private static void RecursiveExample(int n, int index, int len)
        {
            if (n < 1 || index == len)
                return;

            for (int i = index; i < len; i++)
            {
                n = n - 1;
                Console.WriteLine(n);

                RecursiveExample(n, index + 1, len);
                n = n - 1;
                Console.WriteLine("Raj"+n);
            }
                
        }
       

        private static int NumberOfPathsMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            matrix[0, 0] = 0;
            //initialize the rows to 1 , it takes 1 unique path to reach each cell of the row.
            for (int i = 1; i < rows; i++)
                matrix[i, 0] = 1;
            //initialize the cols to 1 , it takes 1 unique path to reach each cell of the col.
            for (int i = 1; i < cols; i++)
                matrix[0, i] = 1;

            for (int i = 1; i < rows; i++)
                for (int j = 1; j < cols; j++)
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
            return matrix[rows - 1, cols - 1];
        }

        private static void CoinChangeMain()
        {
            int[] denomination = {1,5,10,25};
            Array.Reverse(denomination);
            double amount = 1.38;
            ArrayString arrayString = new ArrayString();
            int count = arrayString.CoinChangeInterative(denomination, 138);
        }

        private static void TopNRecordsBasedOnIndex()
        {
            ArrayString arrayString = new ArrayString();
            int[] a = { 2016, 1948, 1959, 2019, 2017, 2001 };//{ 2001, 1985, 1959, 2018 };
            int count = 3;
            int[] b = arrayString.SortTopNbasedOnIndex(a, count);
        }

        private static void MaxRepeatedWrdsMain()
        {
            ArrayString arrayString = new ArrayString();
            string[] strWrds = {"geeks", "geeks", "geeks",
                "portal",  "learn", "computer", "science",
                 "computer", "computer", "science", "science",
                 "science", "computer", "geeks"};
            arrayString.GetMaxRepeatedString(strWrds);
        }
        #endregion
    }
}
