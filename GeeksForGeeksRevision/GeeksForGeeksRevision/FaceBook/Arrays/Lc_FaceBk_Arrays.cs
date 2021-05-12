using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class Lc_FaceBk_Arrays
    {

        /// <summary>
        /// Regular Expression Matching
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            /*DP[i,j] = s[o...i] matches with p[0...j]

            Base cases:
            DP[i,0] = false for i > 0 => p = emptyStr ONLY mathes with emptyStr
            DP[0,j] => s = emptyStr, Should be set in the loop, e.g. if p = '.*'/'a*' - DP should be true

            Subproblems:
            1. P[i][j] = P[i - 1][j - 1], if p[j - 1] != '*' && (s[i - 1] == p[j - 1] || p[j - 1] == '.');
            2. P[i][j] = P[i][j - 2], if p[j - 1] == '*' and the pattern repeats for 0 times;
            3. P[i][j] = P[i - 1][j] && (s[i - 1] == p[j - 2] || p[j - 2] == '.'), if p[j - 1] == '*' and the pattern repeats for at least 1 times.
            */

            int sN = s.Length, pN = p.Length;
            bool[,] DP = new bool[sN + 1, pN + 1];
            DP[0, 0] = true;

            for (int i = 0; i <= sN; i++)
            {
                for (int j = 1; j <= pN; j++)
                {
                    if (p[j - 1] == '*')
                        DP[i, j] = (j > 1 && DP[i, j - 2]) //prev repeated 0 times
                                    || (i > 0 && j > 1 && (s[i - 1] == p[j - 2] || p[j - 2] == '.') && DP[i - 1, j]); //prev repeated >=1 times. REMEMBER: "&& DP[i - 1,j]"
                    else if (i > 0 && (s[i - 1] == p[j - 1] || p[j - 1] == '.'))
                        DP[i, j] = DP[i - 1, j - 1];
                    else
                        DP[i, j] = false;
                }
            }
            return DP[sN, pN];
        }
        /// <summary>
        /// Wildcard Matching
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch2(string s, string p)
        {
            //s = "adceb"
            //p = "*a*b"
            int i = 0;
            int j = 0;
            int asteriskInd = -1;
            int lastMatchInd = -1;
            int n = s.Length;
            int m = p.Length;

            while (i < n)
            {
                if (j < m && p[j] == '*')
                {
                    asteriskInd = j++;
                    lastMatchInd = i;
                }
                else if (j < m && (p[j] == '?' || s[i] == p[j]))
                {
                    i++; j++;
                }
                else if (asteriskInd != -1)
                {
                    j = asteriskInd + 1;
                    i = ++lastMatchInd;
                }
                else return false;
            }

            while (j < m && p[j] == '*') j++;

            return j == m;
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=Q-k3Ucoy6qk
        /// https://www.geeksforgeeks.org/remove-invalid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RemoveInvalidParentheses(string s)
        {
            IList<string> ans = new List<string>();
            remove(s, ans, 0, 0, new char[] { '(', ')' });
            return ans;
        }

        public void remove(string s, IList<string> ans, int last_i, int last_j, 
            char[] par)
        {
            for (int stack = 0, i = last_i; i < s.Length; ++i)
            {
                if (s[i] == par[0])
                    stack++;
                if (s[i] == par[1])
                    stack--;
                if (stack >= 0)
                    continue;
                for (int j = last_j; j <= i; ++j)
                {


                    if (s[j] == par[1] && (j == last_j || s[j - 1] != par[1]))
                        remove(s.Substring(0, j) + s.Substring(j + 1, s.Length - j - 1),
                            ans, i, j, par);
                }
                return;
            }
            var a = s.ToCharArray();
            Array.Reverse(a);

            string reversed = new string(a);
            if (par[0] == '(') // finished left to right
                remove(reversed, ans, 0, 0, new char[] { ')', '(' });
            else // finished right to left
                ans.Add(reversed);
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=LdtQAYdYLcE
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            var ans = new List<IList<int>>();
            ans.Add(new List<int>());
            foreach (var num in nums)
            {
                var l = ans.Count;
                for (var i = 0; i < l; i++)
                {
                    var a = ans[i].ToList();
                    a.Add(num);
                    ans.Add(a);
                }
            }
            return ans;
        }

        public List<String> LetterCombinations(String digits)
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

        private void PhoneCharacterCombinations(String digits, int index, Dictionary<Char, char[]> dict, List<String> result, char[] arr)
        {
            if (index == digits.Length)
            {
                result.Add(new String(arr));
                return;
            }
            char number = digits[index];
            char[] candidates = dict[number];
            for (int i = 0; i < candidates.Length; i++)
            {
                arr[index] = candidates[i];
                PhoneCharacterCombinations(digits, index + 1, dict, result, arr);
            }
        }
        public int TrappingRainWaterPr(int [] arr)
        {
            int totalTrapWater = 0; int maxLeftBar = 0;
            int maxRightBar = 0; int leftIndex = 0; int rightIndex = arr.Length-1;
            while(leftIndex<=rightIndex)
            {
                if(arr[leftIndex]<arr[rightIndex])
                {
                    if (arr[leftIndex] > maxLeftBar)
                        maxLeftBar = arr[leftIndex];
                    else
                    {
                        totalTrapWater = totalTrapWater + maxLeftBar - arr[leftIndex];
                        leftIndex++;
                    }
                }
                else
                {
                    if (arr[rightIndex] > maxRightBar)
                        maxRightBar = arr[rightIndex];
                    else
                    {
                        totalTrapWater = totalTrapWater + maxRightBar - arr[rightIndex];
                        rightIndex--;                       
                    }
                }                
            }
            return totalTrapWater;
        }
        public int MinSubArrayLenPr(int [] nums, int k)
        {
            int startIndex = 0; int endIndex = nums.Length;
            int minLen = nums.Length;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                while (sum >= k && startIndex < nums.Length)
                {
                    minLen = Math.Min(minLen, (i - startIndex + 1));
                    sum = sum - nums[startIndex];
                    startIndex++;                    
                }
            }
            return minLen;
        }
        public static int TrappingRainWater(int[] arr, int n)
        {
            // left[i] contains height of tallest bar to the
            // left of i'th bar including itself
            int[] left = new int[n];

            // Right [i] contains height of tallest bar to
            // the right of ith bar including itself
            int[] right = new int[n];

            // Initialize result
            int water = 0;

            // Fill left array
            left[0] = arr[0];
            for (int i = 1; i < n; i++)
                left[i] = Math.Max(left[i - 1], arr[i]);

            // Fill right array
            right[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], arr[i]);

            // Calculate the accumulated water element by element
            // consider the amount of water on i'th bar, the
            // amount of water accumulated on this particular
            // bar will be equal to min(left[i], right[i]) - arr[i] .
            for (int i = 0; i < n; i++)
                water += Math.Min(left[i], right[i]) - arr[i];

            return water;
        }
        public bool IsValidParanthesis(string strWord)
        {
            Stack<char> stParanthesis = new Stack<char>();
            if (strWord.Length == 1)
                return false;
            for (int i = 0; i < strWord.Length; i++)
            {
                if (strWord[i] == '(' || strWord[i] == '{' || strWord[i] == '[')
                {
                    stParanthesis.Push(strWord[i]);
                }
                /* If exp[i] is an ending parenthesis then pop from stack and check if the popped parenthesis is a matching pair*/
                if (strWord[i] == '}' || strWord[i] == ')' || strWord[i] == ']')
                {
                    if (stParanthesis.Count == 0)
                        return false;
                    else if (!isMatchingPair(stParanthesis.Pop(), strWord[i]))
                    {
                        return false;
                    }
                }
            }
            if (stParanthesis.Count == 0)
                return true;
            else
                return false;
        }
        static bool isMatchingPair(char character1, char character2)
        {
            if (character1 == '(' && character2 == ')')
                return true;
            else if (character1 == '{' && character2 == '}')
                return true;
            else if (character1 == '[' && character2 == ']')
                return true;
            else
                return false;
        }
        public int MaxSubArrayLen(int[] nums, int k)
        {
            int max = 0, sum = 0;
            Dictionary<int, int> sumDic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {   // Add current number to previous sum
                sum = sum + nums[i];
                if (sum == k)
                    max = i + 1; // Found, and it starts from index 0
                if (sumDic.ContainsKey(sum - k))
                    max = Math.Max(max, i - sumDic[sum - k]);

                if (!sumDic.ContainsKey(sum))
                    sumDic.Add(sum, i); //keep only 1st duplicate as we want first index as left as possible
            }

            return max;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int s, int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int returnVal = nums.Length + 1;
            int start, end, sum;
            start = end = sum = 0;

            while (end < nums.Length)
            {
                sum += nums[end];

                // maintain the valid window, ditch the item at start point if it is not needed .
                if (sum >= s)
                {
                    while (sum - s >= nums[start])
                    {
                        sum -= nums[start++];
                    }

                    // update once we finsihed filtering. 
                    returnVal = Math.Min(returnVal, end - start + 1);
                }
                end++;
            }

            return returnVal == nums.Length + 1 ? 0 : returnVal;
        }
        public bool IsValidNumber(string s)
        {
            s = s.Trim();

            bool pointSeen = false;
            bool eSeen = false;
            bool numberSeen = false;
            bool numberAfterE = true;
            for (int i = 0; i < s.Length; i++)
            {
                if ('0' <= s[i] && s[i] <= '9')
                {
                    numberSeen = true;
                    numberAfterE = true;
                }
                else if (s[i] == '.')
                {
                    if (eSeen || pointSeen)
                    {
                        return false;
                    }
                    pointSeen = true;
                }
                else if (s[i] == 'e')
                {
                    if (eSeen || !numberSeen)
                    {
                        return false;
                    }
                    numberAfterE = false;
                    eSeen = true;
                }
                else if (s[i] == '-' || s[i] == '+')
                {
                    if (i != 0 && s[i - 1] != 'e')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return numberSeen && numberAfterE;
        }
        public bool ValidPalindrome(string s)
        {
            int startIndex = 0;
            int endIndex = s.Length - 1;            
            while(startIndex<endIndex)
            {
                if (s[startIndex] == s[endIndex])
                {
                    startIndex++;
                    endIndex--;
                    continue;
                }                    
                else
                {
                    //skip right
                    int tempStartIndex = startIndex;
                    int tempEndIndex = endIndex - 1;
                    while(tempStartIndex<tempEndIndex)
                    {
                        if(s[tempEndIndex]!=s[tempStartIndex])
                        {
                            break;
                        }
                        tempStartIndex++;
                        tempEndIndex--;
                        if (tempStartIndex >= tempEndIndex)
                            return true;
                    }

                    //skip left
                    startIndex++;
                    while(startIndex<endIndex)
                    {
                        if (s[startIndex] != s[endIndex])
                            return false;
                        startIndex++;
                        endIndex--;
                    }
                }
            }
            return true;
        }
        
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    // Computed before.
                    continue;
                }
                int x = i + 1;
                int j = nums.Length - 1;
                while (x < j)
                {
                    int a = nums[i];
                    int b = nums[x];
                    int c = nums[j];
                    int sum = a + b + c;
                    if (0 == sum)
                    {
                        res.Add(new List<int>() { a, b, c });
                        x++;
                        j--;
                        // We found a result, move cursor inward
                        while (x < j && nums[x] == nums[x - 1])
                        {
                            x++;
                        }
                        while (x < j && nums[j] == nums[j + 1])
                        {
                            j--;
                        }
                    }
                    else if (sum < 0)
                    {
                        x++;
                    }
                    else
                    {
                        j--;
                    }
                }
            }

            return res;
        }
        
        
       

    }
}
