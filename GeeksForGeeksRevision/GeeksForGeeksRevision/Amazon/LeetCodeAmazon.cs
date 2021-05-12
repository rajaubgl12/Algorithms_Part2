using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
   
    class Solution
    {
        public int MyAtoi(string str)
        {
            str = "-91283472332";
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(str))
                return -1;

            str = str.Trim();
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && (str[0] == '+' || str[0] == '-'))
                    sb.Append(str[0].ToString());

                if (i == 0 && Char.IsLetter(str[i]))
                    return 0;

                else if (Char.IsDigit(str[i]))
                {
                    sb.Append(str[i].ToString());
                }
            }
            var val = (long)Convert.ToDouble(sb.ToString());
            if (val > int.MaxValue || val<int.MinValue)
                return int.MaxValue;

            return Convert.ToInt32(sb.ToString());
        }

        public static int ascii_deletion_distance(string str1, string str2)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str1.Length; i++)
            {
                if (!str2.Contains(str1[i]))
                {
                    sb.Append(str1[i]);
                }
            }
            int sum = 0;
            for (int j = 0; j < sb.ToString().Length; j++)
            {
                sum = sum + sb[j];
            }
            return sum;
        }

        String[] SingleNum = new String[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        String[] DoubleNum = new String[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
        String[] HundredNum = new String[] { "", " Hundred" };
        String[] ThousandNum = new String[] { "", " Thousand" };
        String[] MillionNum = new String[] { "", " Million" };
        String[] BillionNum = new String[] { "", " Billion" };
        String[] SpaceNum = new String[] { "", " " };

        public String numberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            String retStr;

            int B = 1000000000;
            int M = 1000000;
            int K = 1000;
            retStr = SingleNum[num / B] + BillionNum[num >= B ? 1 : 0] + SpaceNum[num > B && (num % B / M != 0) ? 1 : 0] +
                    ConvertHundred(num % B / M) + MillionNum[num >= M && (num % B / M) != 0 ? 1 : 0] + SpaceNum[(num >= M && (num % M / K) != 0) ? 1 : 0] +
                    ConvertHundred(num % M / K) + ThousandNum[num >= K && (num % M / K) != 0 ? 1 : 0] + SpaceNum[num > K && (num % K != 0) ? 1 : 0] +
                    ConvertHundred(num % K);
            
            return retStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private String ConvertHundred(int num)
        { //num < 1000
            String retStr;
            if (num % 100 < 20)
                retStr = SingleNum[(num % 20)];
            else
                retStr = DoubleNum[(num % 100 / 10)] + SpaceNum[(num % 10 != 0) ? 1 : 0] + SingleNum[(num % 10)];
            retStr = SingleNum[num / 100] + HundredNum[num >= 100 ? 1 : 0] + SpaceNum[(num > 100 && num % 100 != 0) ? 1 : 0] + retStr;
            return retStr;
        }
    }

    public class LeetCodeAmazon
    {

        //https://www.youtube.com/watch?v=MzEW-DBBQTE
        //https://www.geeksforgeeks.org/word-ladder-length-of-shortest-chain-to-reach-a-target-word/

        public IList<IList<String>> FindLadders(String start, String end, IList<String> wordList)
        {
            HashSet<String> dict = new HashSet<String>(wordList);
            IList<IList<String>> res = new List<IList<String>>();
            Dictionary<String, List<String>> nodeNeighbors
                = new Dictionary<String, List<String>>();// Neighbors for every node
            Dictionary<String, int> distance = new Dictionary<String, int>();// Distance of every node from the start node
            List<String> solution = new List<String>();

            dict.Add(start);
            bfs(start, end, dict, nodeNeighbors, distance);
            List<String> solution2 = new List<String>();
            dfs(start, end, dict, nodeNeighbors, distance, solution2, res);
            return res;
        }

        // BFS: Trace every node's distance from the start node (level by level).
        private void bfs(String start, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance)
        {
            foreach (String str in dict)
                nodeNeighbors.Add(str, new List<String>());

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);
            distance.Add(start, 0);

            while (queue.Count != 0)
            {
                int count = queue.Count;
                bool foundEnd = false;
                for (int i = 0; i < count; i++)
                {
                    String cur = queue.Dequeue();
                    int curDistance = distance[cur];
                    //get the next matching words.
                    List<String> neighbors = getNeighbors(cur, dict);

                    foreach (String neighbor in neighbors)
                    {
                        nodeNeighbors[cur].Add(neighbor);
                        if (!distance.ContainsKey(neighbor))
                        {
                            // Check if visited
                            distance.Add(neighbor, curDistance + 1);
                            if (end.Equals(neighbor))// Found the shortest path
                                foundEnd = true;
                            else
                                queue.Enqueue(neighbor);
                        }
                    }
                }

                if (foundEnd)
                    break;
            }
        }

        // Find all next level nodes.    
        private List<String> getNeighbors(String node, HashSet<String> dict)
        {
            List<String> res = new List<String>();
            char[] chs = node.ToCharArray();

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                for (int i = 0; i < chs.Length; i++)
                {
                    if (chs[i] == ch) continue;
                    char old_ch = chs[i];
                    chs[i] = ch;
                    if (dict.Contains(new String(chs)))
                    {
                        res.Add(new String(chs));
                    }
                    chs[i] = old_ch;
                }

            }
            return res;
        }

        // DFS: output all paths with the shortest distance.
        private void dfs(String cur, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance, List<String> solution, IList<IList<String>> res)
        {
            solution.Add(cur);
            if (end.Equals(cur))
            {
                res.Add(new List<String>(solution));
            }
            else
            {
                foreach (String next in nodeNeighbors[cur])
                {
                    if (distance[next] == distance[cur] + 1)
                    {
                        dfs(next, end, dict, nodeNeighbors, distance, solution, res);
                    }
                }

            }
            //solution.Remove((solution.Count - 1).ToString());
            solution.RemoveAt(solution.Count - 1);
        }

        public static IList<string> FindLaddersMyCode(string beginWord, string endWord, IList<string> wordList)
        {
            //HashSet<string> visited = new HashSet<string>();
            //Queue<string> queue = new Queue<string>();
            HashSet<string> unvisited = new HashSet<string>(wordList);
            IList<string> lstLadders = new List<string>();
            unvisited.Remove(beginWord);
            if (!unvisited.Contains(endWord))
                return null;

            //queue.Enqueue(beginWord);
            string searchNextWrd = beginWord;
            foreach (string str in unvisited)
            {
                // if(queue.Count>0)
                if (WordCompareContains(searchNextWrd, str))
                {
                    lstLadders.Add(str);
                    searchNextWrd = str;
                }
            }


            return lstLadders;
        }

        public static bool WordCompareContains(string source, string dest)
        {
            int count = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == dest[i])
                {
                    count++;
                }
                if (count == dest.Length - 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static int FindLaddersCount(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            HashSet<string> unvisited = new HashSet<string>(wordList);
            unvisited.Remove(beginWord);
            if (!unvisited.Contains(endWord))
                return 0;

            int distance = 2;
            queue.Enqueue(beginWord);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    char[] word = queue.Dequeue().ToCharArray();
                    for (int j = 0; j < word.Length; j++)
                    {
                        char temp = word[j];
                        for (int k = 0; k < 26; k++)
                        {
                            word[j] = (char)('a' + k);
                            string nextWord = new string(word);
                            if (unvisited.Contains(nextWord))
                            {
                                if (nextWord.Equals(endWord))
                                {
                                    return distance;
                                }
                                else
                                {
                                    queue.Enqueue(nextWord);
                                    unvisited.Remove(nextWord);
                                }
                            }
                        }
                        word[j] = temp;
                    }
                }
                distance++;
            }
            return 0;
        }

        public int FindKthLargest(int[] nums, int k)
        {
            if (nums == null || nums.Length < 1)
                return -1;
            Array.Sort(nums);
            return k - 1 > -1 ? nums[k - 1] : -1;
        }

        /// <summary>
        /// Quick Search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIdx"></param>
        /// <param name="endIdx"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int QuickSearch(int[] nums, int startIdx, int endIdx, int k)
        {
            if (endIdx == startIdx)
                return nums[startIdx];

            int iPivotIdx = (startIdx + endIdx) / 2;
            int pivot = nums[iPivotIdx];

            int temp = nums[startIdx];
            nums[startIdx] = nums[iPivotIdx];
            nums[iPivotIdx] = temp;

            int left = startIdx + 1;
            int right = endIdx;
            while (left <= right)
            {
                while (left <= right && nums[left] <= pivot)
                    left++;

                while (left <= right && nums[right] > pivot)
                    right--;

                if (left <= right)
                {
                    temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                    left++;
                    right--;
                }
            }
            temp = nums[startIdx];
            nums[startIdx] = nums[right];
            nums[right] = temp;

            if (right == k)
                return nums[k];
            else if (k > right)
                return QuickSearch(nums, right + 1, endIdx, k);
            else
                return QuickSearch(nums, startIdx, right - 1, k);
        }


        /// <summary>
        /// https://www.geeksforgeeks.org/find-possible-words-phone-digits/
        /// https://www.youtube.com/watch?v=h6FmiyYDjmk
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static List<String> LetterCombinations(String digits)
        {
            Dictionary<char, char[]> map = new Dictionary<char, char[]>();
            map.Add('2', new char[] { 'a', 'b', 'c' });
            map.Add('3', new char[] { 'd', 'e', 'f' });
            map.Add('4', new char[] { 'g', 'h', 'i' });
            map.Add('5', new char[] { 'j', 'k', 'l' });
            map.Add('6', new char[] { 'm', 'n', 'o' });
            map.Add('7', new char[] { 'p', 'q', 'r', 's' });
            map.Add('8', new char[] { 't', 'u', 'v' });
            map.Add('9', new char[] { 'w', 'x', 'y', 'z' });
            List<String> result = new List<String>();
            if (digits.Equals(""))
                return result;
            //helper(result, new StringBuilder(), digits, 0, map);
            char[] arr = new char[digits.Length];
            PhoneCharacterCombinations(digits, 0, map, result, arr);
            return result;
        }

        private static void PhoneCharacterCombinations(String digits, int index, Dictionary<Char,
            char[]> dict, List<String> result, char[] combinationChar)
        {
            if (index == digits.Length)
            {
                result.Add(new String(combinationChar));
                return;
            }
            char number = digits[index];
            char[] charactersForNumber = dict[number];
            for (int i = 0; i < charactersForNumber.Length; i++)
            {
                combinationChar[index] = charactersForNumber[i];
                PhoneCharacterCombinations(digits, index + 1, dict, result, combinationChar);
            }
        }

        /// <summary>
        /// not used
        /// </summary>
        /// <param name="result"></param>
        /// <param name="sb"></param>
        /// <param name="digits"></param>
        /// <param name="index"></param>
        /// <param name="map"></param>
        public static void helper(List<String> result, StringBuilder sb, String digits, int index, Dictionary<Char, char[]> map)
        {
            if (index >= digits.Length)
            {
                result.Add(sb.ToString());
                return;
            }
            char c = digits[index];
            char[] arr = map[c];
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
                helper(result, sb, digits, index + 1, map);
                sb.Remove(i, sb.Length - 1);
            }
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=irFtGMLbf-s
        /// combination sum with duplicates.
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (target <= 0)
            {
                return new List<IList<int>>();
            }

            if (candidates == null || candidates.Length == 0)
            {
                return new List<IList<int>>();
            }

            Array.Sort(candidates);
            List<int> lstCombination = new List<int>();
            FindCombination2Target(result, lstCombination, candidates, 0, target);
            return result;
        }

        private static void FindCombination2Target(IList<IList<int>> result, List<int> combinations, int[] candidates, int index, int target)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combinations));
                return;
            }
            else
            {
                //important to have i=index to remove the duplicate sum e.g 2,2,3 is 2,3,2
                for (int i = index; i < candidates.Length && target >= candidates[i]; i++)
                {
                    if (candidates[i] > target)
                        break;
                    combinations.Add(candidates[i]);
                    FindCombination2Target(result, combinations, candidates, i, target - candidates[i]);
                    combinations.RemoveAt(combinations.Count - 1);
                }
            }
        }

        public static int[] ProductArrayExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            int left = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = left;
                left *= nums[i];
            }
            int right = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= right;
                right *= nums[i];
            }
            return result;
        }

        public static int FindDuplicate(int[] a)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (dict.ContainsKey(a[i]))
                {
                    return a[i];
                }
                else
                {
                    dict.Add(a[i], i);
                }
            }
            return -1;
        }

        /// <summary>
        /// 1. have two pointers left and right start from zero.
        /// 2. first while loop check consecutive characterrs are same , if yes increment right++.
        /// 3. 2nd while
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
                return s;
            var index = 0;
            var len = 0;
            string result = null;
            while (index < s.Length)
            {
                //initialize two pointer left and right
                var left = index;
                var right = index;

                //&& right + 1 < s.Length
                // move the right pointer if there are consequitive same letters.
                while (s[right + 1] == s[index])
                {
                    right++;
                }

                //increment right pointer.
                index = right + 1;

                // decrement left pointer and increment right pointer, if same then decrement left pointer
                // increment right pointer.
                //diff of left and right and start from left
                //&& left - 1 >= 0 && right + 1 < s.Length
                while (left - 1 >= 0 && right + 1 < s.Length && s[left - 1] == s[right + 1] && left - 1 >= 0)
                {
                    left--;
                    right++;
                }
                var l = right - left + 1;
                if (l > len)
                {
                    len = l;
                    result = s.Substring(left, l);
                }
            }
            return result;
        }

        public static string LongestPalSubstr2(String str)
        {
            int n = str.Length;   // get length of input string

            // table[i][j] will be false if substring str[i..j]
            // is not palindrome.
            // Else table[i][j] will be true
            bool[,] table = new bool[n, n];

            // All substrings of length 1 are palindromes
            int maxLength = 1;
            for (int i = 0; i < n; ++i)
                table[i, i] = true;

            // check for sub-string of length 2.
            int start = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                if (str[i] == str[i + 1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            // Check for lengths greater than 2. k is length
            // of substring
            for (int k = 3; k <= n; ++k)
            {
                int endIn = n - k + 1;
                // Fix the starting index
                for (int i = 0; i < endIn; ++i)
                {
                    // Get the ending index of substring from
                    // starting index i and length k
                    int j = i + k - 1;

                    // checking for sub-string from ith index to
                    // jth index iff str.charAt(i+1) to 
                    // str.charAt(j-1) is a palindrome
                    if (table[i + 1, j - 1] && str[i] ==
                                              str[j])
                    {
                        table[i, j] = true;

                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }
            Console.WriteLine("Longest palindrome substring is; ");
            //printSubStr(str, start, start + maxLength - 1);
            string strPalin = str.Substring(start, maxLength);
            return strPalin; // return length of LPS
        }

        public static int CompareVersion(string version1, string version2)
        {
            var numsa = version1.Split('.');
            var numsb = version2.Split('.');
            var maxLen = Math.Max(numsa.Length, numsb.Length);
            for (var i = 0; i < maxLen; ++i)
            {
                var a = i < numsa.Length ? Convert.ToInt32(numsa[i]) : 0;
                var b = i < numsb.Length ? Convert.ToInt32(numsb[i]) : 0;
                if (a > b)
                {
                    return 1;
                }
                else if (b > a)
                {
                    return -1;
                }
            }
            return 0;

        }

        public static int MaxSizeSubArrSum(int[] nums, int k)
        {
            var result = 0;
            if (nums == null || nums.Length == 0)
            {
                return result;
            }
            var dic = new Dictionary<int, int>();

            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
                if (sum == k)
                {
                    result = Math.Max(result, i + 1);
                }
                else if (dic.ContainsKey(sum - k))
                {
                    //diff of current index and the index of (sum-k) value
                    result = Math.Max(result, i - dic[sum - k]);
                }
                if (!dic.ContainsKey(sum))
                {
                    dic.Add(sum, i);
                }
            }
            return result;
        }

        public static void ReverseWords(char[] s)
        {
            int i = 0;

            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == ' ')
                {
                    reverse(s, i, j - 1);
                    i = j + 1;
                }
            }
            reverse(s, i, s.Length - 1);

            reverse(s, 0, s.Length - 1);
        }

        private static void reverse(char[] s, int i, int j)
        {
            while (i < j)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
        }

        public static string ReverseString(String s)
        {
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0, j = s.Length - 1; i < s.Length / 2; i++, j--)
            {
                char t = sb[i];
                sb[i] = sb[j];
                sb[j] = t;
            }

            return sb.ToString();
        }

        public static int UniqueCharString(string str)
        {
            Dictionary<char, int> dictStr = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {

                if (dictStr.ContainsKey(str[i]))
                {
                    dictStr[str[i]]++;
                }
                else
                {
                    dictStr.Add(str[i], 1);
                }
            }

            foreach (KeyValuePair<char, int> keyPair in dictStr)
            {
                if (keyPair.Value == 1)
                {
                    return str.IndexOf(keyPair.Key);
                }
            }
            return -1;
        }

        public static int FindUnique(string s)
        {
            char[] alphArray = new char[256];
            foreach (char c in s)
            {
                alphArray[c]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (alphArray[s[i]] == 1)
                    return i;
            }
            return -1;
        }
    }

    public class Solution2
    {
        List<List<String>> results;
        List<String> list;
        Dictionary<String, List<String>> map;
        public List<List<String>> findLadders(String start, String end, HashSet<String> dict)
        {
            results = new List<List<String>>();
            if (dict.Count == 0)
                return results;

            int curr = 1, next = 0;
            bool found = false;
            list = new List<String>();
            map = new Dictionary<String, List<String>>();

            Queue<String> queue = new Queue<String>();
            HashSet<String> unvisited = new HashSet<String>(dict);
            HashSet<String> visited = new HashSet<String>();

            queue.Enqueue(start);
            unvisited.Add(end);
            unvisited.Remove(start);
            //BFS
            while (!(queue.Count!=0))
            {

                String word = queue.Dequeue();
                curr--;
                for (int i = 0; i < word.Length; i++)
                {
                    StringBuilder builder = new StringBuilder(word);
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        builder.Replace("", ch.ToString(),i,1);
                        String new_word = builder.ToString();
                        if (unvisited.Contains(new_word))
                        {
                            //Handle queue
                            if (visited.Add(new_word))
                            {//Key statement,Avoid Duplicate queue insertion
                                next++;
                                queue.Enqueue(new_word);
                            }

                            if (map.ContainsKey(new_word))//Build Adjacent Graph
                                map[new_word].Add(word);
                            else
                            {
                                List<String> l = new List<String>();
                                l.Add(word);
                                map.Add(new_word, l);
                            }

                            if (new_word.Equals(end) && !found) found = true;

                        }

                    }//End:Iteration from 'a' to 'z'
                }//End:Iteration from the first to the last
                if (curr == 0)
                {
                    if (found) break;
                    curr = next;
                    next = 0;
                    //unvisited.Remove(visited);
                    unvisited.Clear();
                    visited.Clear();
                }
            }//End While

            backTrace(end, start);

            return results;
        }
        private void backTrace(String word, String start)
        {
            if (word.Equals(start))
            {
                list.Add(start);
                results.Add(new List<String>(list));
                list.RemoveAt(0);
                return;
            }
            list.Add(word);
            if(map!=null&& map.Count>0)
            if (map[word] != null)
                foreach (String s in map[word])
                    backTrace(s, start);
            list.RemoveAt(0);
        }
    }

}
