using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Google
{
    class ArrayStringLeetCode
    {
        public int NumUniqueEmails(string[] emails)
        {
            var hs = new HashSet<string>();

            foreach (var email in emails)
            {
                var plusIndex = email.IndexOf('+');
                var domainIndex = email.IndexOf('@');

                var c = string.Empty;
                if (plusIndex != -1)
                    c = email.Substring(0, plusIndex).Replace(".", "") + "@" + email.Substring(domainIndex + 1);
                else
                    c = email.Substring(0, domainIndex).Replace(".", "") + "@" + email.Substring(domainIndex + 1);

                hs.Add(c);
            }

            return hs.Count;
        }

        /// <summary>
        /// 
        /// You are given an integer array A.  From some starting index, you can make a series of jumps.  The (1st, 3rd, 5th, ...) jumps in the series are called odd numbered jumps, and the (2nd, 4th, 6th, ...) jumps in the series are called even numbered jumps.
        /*
        You may from index i jump forward to index j(with i < j) in the following way:
        During odd numbered jumps(ie.jumps 1, 3, 5, ...), you jump to the index j such that A[i] <= A[j] and A[j]
        is the smallest possible value.If there are multiple such indexes j, you can only jump to the smallest such 
        index j.

        During even numbered jumps (ie.jumps 2, 4, 6, ...), you jump to the index j such that A[i] >= A[j] and A[j]
        is the largest possible value.If there are multiple such indexes j, you can only jump to the smallest such
        index j.
        (It may be the case that for some index i, there are no legal jumps.)
        A starting index is good if, starting from that index, you can reach the end of the array(index A.length - 1) by jumping some number of times(possibly 0 or more than once.)
        Return the number of good starting indexes. 
        */
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        /*
        Take[5, 1, 3, 4, 2] as example.

   If we start at 2,
   we can jump either higher first or lower first to the end,
because we are already at the end.
higher(2) = true
lower(2) = true

If we start at 4,
we can't jump higher, higher(4) = false
we can jump lower to 2, lower(4) = higher(2) = true

If we start at 3,
we can jump higher to 4, higher(3) = lower(4) = true
we can jump lower to 2, lower(3) = higher(2) = true

If we start at 1,
we can jump higher to 2, higher(1) = lower(2) = true
we can't jump lower, lower(1) = false

If we start at 5,
we can't jump higher, higher(5) = false
we can jump lower to 4, lower(5) = higher(4) = false

Java:
Suggested by @zhangchunlei0813, I use ceilingEntry and floorEntry instead of ceilingKey and floorKey, to avoid O(logN) query.

            */


        public int OddEvenJump(int[] a)
        {
            int len = a.Length;
            bool[] odd = new bool[len];
            bool[] even = new bool[len];
            odd[len - 1] = true;
            even[len - 1] = true;
            Dictionary<int, int> map = new Dictionary<int, int>();

            map.Add(a[len - 1], len - 1);
            for (int i = len - 2; i >= 0; i--)
            {
                int num = a[i];
                int lower = map.Where(x => x.Key <= num).OrderByDescending(x => x.Key).FirstOrDefault().Key;
                int higher = map.Where(x => x.Key >= num).OrderByDescending(x => x.Key).FirstOrDefault().Key;
                // int lower = map.Keys[num].First();
                //int higher = map.Keys.Last();
                if (lower != 0)
                {
                    int t = lower;
                    even[i] = odd[map[t]];
                }
                if (higher != 0)
                {
                    odd[i] = even[map[higher]];
                }

                if (!map.ContainsKey(a[i]))
                    map.Add(a[i], i);
            }
            int count = 0;
            for (int i = 0; i < odd.Length; i++)
            {
                if (odd[i])
                    count++;
            }

            return count;
        }

        public int oddEvenJumps(int[] A)
        {
            int N = A.Length;
            bool[] starting = new bool[N];
            bool[] evenStarting = new bool[N];
            starting[N - 1] = true;
            evenStarting[N - 1] = true;
            int count = 1;
            for (int start = N - 2; start >= 0; start--)
            {
                int o = oddJump(start, A);
                int e = evenJump(start, A);
                if (o != -1 && evenStarting[o])
                {
                    starting[start] = true;
                    count++;
                }
                evenStarting[start] = (e != -1 && starting[e]);
            }
            return count;
        }

        public int oddJump(int i, int[] A)
        {
            int v = A[i];
            int max = 100001;
            int jmax = -1;
            for (int j = i + 1; j < A.Length; j++)
            {
                if (A[j] >= v && A[j] < max)
                {
                    max = A[j];
                    jmax = j;
                }
            }
            return jmax;
        }

        public int evenJump(int i, int[] A)
        {
            int v = A[i];
            int min = -1;
            int jmin = -1;
            for (int j = i + 1; j < A.Length; j++)
            {
                if (A[j] <= v && A[j] > min)
                {
                    min = A[j];
                    jmin = j;
                }
            }
            return jmin;
        }

        public string LicenseKeyFormatting3(string S, int K)
        {
            var i = 0;
            var sb = new StringBuilder();
            for (var j = S.Length - 1; j >= 0; j--)
            {
                if (S[j] == '-')
                {
                    continue;
                }
                if (i > 0 && i % K == 0)
                {
                    sb.Append('-');
                }
                sb.Append(S[j]);
                i++;
            }

            //Reverse the array
            var ca = sb.ToString().ToUpper().ToCharArray();
            Array.Reverse(ca);
            return new string(ca);

            //return Reverse(sb.ToString()).ToUpperInvariant();
        }

        public string LicenseKeyFormatting(string S, int K)
        {
            if (String.IsNullOrWhiteSpace(S) || K < 1) { return String.Empty; }

            S = S.Replace("-", "").ToUpper();
            int offset = S.Length % K;

            StringBuilder result = new StringBuilder(S.Substring(0, offset) + (offset > 0 ? "-" : ""), 12000);
            for (int t = 0; t < S.Length / K; t++)
            {
                result.Append(S.Substring(t * K + offset, K) + "-");
            }

            return result.ToString().TrimEnd('-');
        }

        public int TotalFruit1(int[] tree)
        {
            int maxFruits = 0;
            int firstIndex = 0;
            int secondIndex = 0;
            int fruitType1 = -1;
            int fruitType2 = -1;
            for (int i = 0; i < tree.Length; i++)
            {

                if (tree[i] == fruitType1 || tree[i] == fruitType2)
                {
                    continue;
                }
                if (fruitType1 == -1)
                {
                    fruitType1 = tree[i];
                    firstIndex = i;
                    continue;
                }
                if (fruitType2 == -1)
                {
                    fruitType2 = tree[i];
                    secondIndex = i;
                    continue;
                }

                {
                    maxFruits = Math.Max(maxFruits, i - firstIndex);
                    firstIndex = i - 1;
                    fruitType1 = tree[firstIndex];
                    secondIndex = i;
                    fruitType2 = tree[secondIndex];
                }
            }
            maxFruits = Math.Max(maxFruits, tree.Length - firstIndex);
            return maxFruits;
        }

       
        

        public int MaxArea(int[] a)
        {
            int maxWater = 0;
            int l = 0; int r = a.Length - 1;
            while (l < r)
            {
                int minNum = Math.Min(a[l], a[r]);
                maxWater = Math.Max(maxWater, minNum * (r - l));
                if (a[l] < a[r])
                    l++;
                else
                    r--;
            }
            return maxWater;
        }

        /// <summary>
        /// 1. list of list
        /// 2. two loops.
        /// 3.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
       

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums.Length < 3)
            {
                return result;
            }

            Array.Sort(nums);

            for (int first = 0; first < nums.Length - 2; first++)
            {
                int second = first + 1;
                int third = nums.Length - 1;

                if (first != 0 && nums[first] == nums[first - 1])
                {
                    continue;
                }

                while (second < third)
                {
                    //since first is constant in entire loop, if second is also same as previous iteration, then 3rd value will also be same. This will help optimization and removing duplicate results
                    if (second > first + 1 && nums[second] == nums[second - 1])
                    {
                        second++;
                        continue;
                    }

                    int sum = nums[first] + nums[second] + nums[third];

                    if (sum == 0)
                    {
                        var triple = new List<int>();
                        triple.Add(nums[first]);
                        triple.Add(nums[second]);
                        triple.Add(nums[third]);
                        result.Add(triple);
                        second++;
                        third--;
                    }
                    else if (sum > 0)
                    {
                        third--;
                    }
                    else
                    {
                        second++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 1. save the index of small number in left starting reverse order I mean starting from len-1
        /// 2. if index is -1 it means there is no small number on the left side , so you need to reverse the complete number e.g 3,2,1
        /// 3. reverse the nums starting from last number to saved index and break
        /// 4. saved index +1 and len-1 reverse rest.
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            var index = -1;

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Reverse(nums, 0, nums.Length - 1);
                return;
            }

            for (var i = nums.Length - 1; i > index; i--)
            {
                if (nums[index] < nums[i])
                {
                    var temp = nums[index];
                    nums[index] = nums[i];
                    nums[i] = temp;
                    break;
                }
            }

            Reverse(nums, index + 1, nums.Length - 1);
        }

        private void Reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                var temp = nums[left];
                nums[left++] = nums[right];
                nums[right--] = temp;
            }
        }

        public string Multiply(string num1, string num2)
        {
            int n1 = num1.Length;
            int n2 = num2.Length;
            int[] products = new int[n1 + n2];

            for (int i = n1 - 1; i >= 0; i--)
            {
                for (int j = n2 - 1; j >= 0; j--)
                {
                    int p1 = i + j;
                    int p2 = p1 + 1;
                    int sum = (num1[i] - '0') * (num2[j] - '0') + products[p2];

                    products[p1] += sum / 10;
                    products[p2] = sum % 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int num in products)
            {
                if (!(sb.Length == 0 && num == 0))
                {
                    sb.Append(num);
                }
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }

        public string Multiply2(string num1, string num2)
        {
            
            int num1Convert1 = 0;
            
            int m = 1;
            for (int i = num1.Length - 1; i >= 0; i--)
            {

                num1Convert1 = num1Convert1 + (num1[i] - '0') * m;
                m = m * 10;
            }

            return num1Convert1.ToString();
        }

        public void RotateMatrix2(int[,] matrix)
        {
            if (matrix.Length == 0)
                return;
            int n = matrix.GetLength(0);
            int n1 = matrix.GetLength(1);
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    //save top
                    int top = matrix[first, i];

                    //left->top
                    matrix[first, i] = matrix[last - offset, first];

                    //bottom-->left
                    matrix[last - offset, first] = matrix[last, last - offset];

                    //right -> bottom
                    matrix[last, last - offset] = matrix[i, last];

                    //top -> right
                    matrix[i, last] = top;
                }
            }
        }

        // i -> newJ(i); j -> newI(n - 1 - j)
        public void Rotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n / 2 + 1; i++)
                for (int j = i; j < n - 1 - i; j++)
                {
                    int tmp = matrix[i, j];
                    matrix[i, j] = matrix[n - 1 - j, i];
                    matrix[n - 1 - j, i] = matrix[n - 1 - i, n - 1 - j];
                    matrix[n - 1 - i, n - 1 - j] = matrix[j, n - 1 - i];
                    matrix[j, n - 1 - i] = tmp;
                }
        }

        public bool CanJump(int[] nums)
        {
            int lastPos = nums.Count() - 1;
            for (int i = nums.Count() - 1; i >= 0; i--)
            {
                if (i + nums[i] >= lastPos)
                    lastPos = i;
            }
            return lastPos == 0;
        }

        public int[] PlusOne(int[] digits)
        {
            int[] a = new int[digits.Length];
            int carry = 1;
            for (int i = digits.Length - 1; i > -1; i--)
            {
                a[i] = (digits[i] + carry) % 10;
                carry = (digits[i] + carry) / 10;
            }
            if (carry > 0)
            {
                int[] aResult = new int[digits.Length + 1];
                aResult[0] = carry;
                return aResult;
            }

            return a;
        }

        public string MinWindow(string src, string pat)
        {
            //base conditions
            int counter = 0;
            int startIndex = src.Length - 1;
            int minSubstring = int.MaxValue;
            int[] Allchars = new int[128];
            int head = startIndex;
            for (int i = 0; i < pat.Length; i++)
            {
                Allchars[pat[i]]++;
            }

            for (int i = 0; i < src.Length; i++)
            {
                if (Allchars[src[i]] > 0)
                {
                    counter++;
                    if (counter == 1)
                    {
                        startIndex = i;
                    }
                }
                if (counter == pat.Length)
                {
                    if (minSubstring > i - startIndex)
                        minSubstring = (i - (head = startIndex));

                    counter = 0;

                    if (Allchars[src[startIndex++]]++ == 0)
                    {
                        counter++;
                    }

                }
            }

            return minSubstring == int.MaxValue ? "" : src.Substring(head, minSubstring);
        }

        public string MinWindow2(string s, string t)
        {
            int[] map = new int[128];
            int begin = 0, end = 0, head = 0, d = int.MaxValue;
            int counter = t.Length;

            foreach (char ch in t)
                map[ch]++;

            while (end < s.Length)
            {
                if (map[s[end++]]-- > 0)

                    counter--;

                while (counter == 0)
                {
                    if (d > end - begin)
                        d = end - (head = begin);

                    if (map[s[begin++]]++ == 0)
                        counter++;
                }
            }
            return d == int.MaxValue ? "" : s.Substring(head, d);
        }

        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            int distinctChars = 0;
            int[] counter = new int[256];
            int maxLength = 0;
            int start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (counter[s[i]] == 0)
                {
                    distinctChars++;
                }

                counter[s[i]]++;

                if (distinctChars > 2)
                {
                    while (start < i && distinctChars > 2)
                    {
                        counter[s[start]]--;
                        if (counter[s[start]] == 0)
                        {
                            distinctChars--;
                        }

                        start++;
                    }
                }

                maxLength = Math.Max(maxLength, i - start + 1);
            }

            return maxLength;
        }

        public int LengthOfLongestSubstringTwoDistinct2(string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.Length < 3) return s.Length;

            var left = 0;
            var right = 0;
            var maxLength = 2;

            var included = new Dictionary<char, int>();

            while (right < s.Length)
            {
                var currentCharacter = s[right];
                if (included.ContainsKey(currentCharacter))
                {
                    included[currentCharacter] = right;
                }
                else
                {
                    included.Add(currentCharacter, right);
                }

                if (included.Count > 2)
                {
                    var lowestIndex = included.OrderBy(x => x.Value).First();
                    included.Remove(lowestIndex.Key);
                    left = lowestIndex.Value + 1;
                }

                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }

            return maxLength;
        }

        public int LengthOfLongestSubstringTwoDistinct3(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;
            if (s.Length <= 2) return s.Length;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            int left = 0, gLeft = 0, gLen = int.MinValue, k = 2;
            for (int right = 0; right < s.Length; right++)
            {
                if (!dict.ContainsKey(s[right])) dict[s[right]] = 1;
                else dict[s[right]]++;

                while (dict.Count() > k)
                {
                    if (--dict[s[left]] == 0) dict.Remove(s[left]);

                    left++;
                }

                int len = right - left + 1;
                if ((right == s.Length - 1 || dict.Count == k) && len > gLen)
                {
                    gLen = len;
                    gLeft = left;
                }
            }

            Console.WriteLine("\"{0}\" is the longest substring with {1} distinct chars", s.Substring(gLeft, gLen), k);
            return gLen;
        }

        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            IList<string> lstMissingRange = new List<string>();

            if (nums[0] > lower)
            {
                lstMissingRange.Add((nums[0] - 1).ToString() + "->" + lower);
            }
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] >= lower && upper >= nums[i])
                {
                    if (nums[i + 1] - nums[i] == 1)
                        continue;
                    else
                    {
                        if (nums[i] + 1 == nums[i + 1] - 1)
                        {
                            lstMissingRange.Add((nums[i] + 1).ToString());
                        }
                        else
                        {
                            lstMissingRange.Add((nums[i] + 1).ToString() + "->" + (nums[i + 1] - 1).ToString());
                        }

                    }
                }
            }
            if (nums[nums.Length - 1] < upper)
            {
                lstMissingRange.Add((nums[nums.Length - 1] + 1).ToString() + "->" + upper);
            }

            return lstMissingRange;
        }

        public IList<string> FindMissingRanges2(int[] nums, int lower, int upper)
        {
            IList<string> res = new List<string>();
            long next = (long)lower;

            for (int i = 0; i < nums.Length; i++)
            {
                if (next < nums[i])
                {
                    // nums[i] > next, there's a preceding missing range
                    res.Add(GetRange(next, nums[i] - 1));
                }

                next = (long)nums[i] + 1;
            }

            if (next <= upper)
            {
                res.Add(GetRange(next, upper));
            }

            return res;
        }

        private string GetRange(long lo, long hi)
        {
            return lo == hi ? lo.ToString() : lo + "->" + hi;
        }

        /// <summary>
        /// Convert to minutes
        /// Add all the digits to hash set
        /// increment by 1 min and check if its valid time
        /// </summary>
        /// <param name="sTime"></param>
        /// <returns></returns>
        public string NextClosestTime(string sTime)
        {
            string[] times = sTime.Split(':');
            int min = Convert.ToInt32(times[0]) * 60 + Convert.ToInt32(times[1]);
            HashSet<int> timeDigits = new HashSet<int>();
            for (int i = 0; i < sTime.Length; i++)
            {
                if (sTime[i] != ':')
                {
                    timeDigits.Add(sTime[i] - '0');
                }
            }
            //increment by one and check its valid

            while (true)
            {
                bool isValid = true;
                min = (min + 1) % (24 * 60);
                int[] timeValues = { (min / 60) / 10, (min / 60) % 10, (min % 60) / 10, (min % 60) % 10 };
                for (int i = 0; i < timeValues.Length; i++)
                {
                    if (!timeDigits.Contains(timeValues[i]))
                        isValid = false;
                }
                if (isValid)
                {
                    string res = string.Format("{0}:{1}", min / 60, min % 60);

                    return res;
                }
            }
        }

        /// <summary>
        /// copy the count to dictionary and then compare
        /// </summary>
        /// <param name="S"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int ExpressiveWords(string S, string[] words)
        {
            Dictionary<char, int> sourceCount = new Dictionary<char, int>();
            //Dictionary<char, int>
            return 1;
        }


        /// <summary>
        /// Input: [1,0,0,0,1,0,1]
        /*        Output: 2
        Explanation: 
        If Alex sits in the second open seat(seats[2]), then the closest person has distance 2.
        If Alex sits in any other open seat, the closest person has distance 1.
        Thus, the maximum distance to the closest person is 2.
        Example 2:

        Input: [1,0,0,0]
                Output: 3
        Explanation: 
        If Alex sits in the last seat, the closest person is 3 seats away.
        This is the maximum distance possible, so the answer is 3.*/
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        /// 

        public int MaxDistToClosest(int[] seats)
        {
            int startIndex = 0;
            int diff = 0;
            int maxDistIndex = 0;
            int zeroCount = 0;
            int maxZeroCount = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    if (diff < i - startIndex)
                    {
                        diff = i - startIndex;
                        maxDistIndex = (diff) / 2;

                        if (zeroCount > maxZeroCount)
                        {
                            maxZeroCount = zeroCount;
                        }
                    }
                    startIndex = i;
                    zeroCount = 0;
                }
                else
                {
                    zeroCount++;
                }
            }
            if (zeroCount > maxZeroCount)
                maxDistIndex = seats.Length - 1;

            return maxDistIndex;
        }

        public int MaxDistToClosest2(int[] seats)
        {
            int maxDis = 0, pre = -1, cur = 0;
            for (cur = 0; cur < seats.Length; cur++)
            {
                if (seats[cur] == 1)
                {
                    //for the case like {0,0,0,1}
                    if (pre == -1 && seats[0] == 0)
                    {
                        maxDis = Math.Max(maxDis, cur);
                    }
                    else
                    {
                        maxDis = Math.Max(maxDis, (cur - pre) / 2);
                    }
                    pre = cur;
                }
                //this is the case for {1,0,0,0,0}
                if (cur == seats.Length - 1 && seats[cur] == 0)
                {
                    maxDis = Math.Max(maxDis, cur - pre);
                }
            }
            return maxDis;
        }

        /// <summary>
        /// Input: "{[]}"
        /// Output: true
        /// </summary>
        /// <param name="strWord"></param>
        /// <returns></returns>
        public bool IsValidParanthesis(string strWord)
        {
            Stack<char> stackParanthesis = new Stack<char>();
            for (int i = 0; i < strWord.Length; i++)
            {
                if (strWord[i] == '{' || strWord[i] == '[' || strWord[i] == '(')
                {
                    stackParanthesis.Push(strWord[i]);
                }
                else if (strWord[i] == '}' || strWord[i] == ']' || strWord[i] == ')')
                {
                    if (stackParanthesis.Count == 0)
                        return false;

                    if (!IsMatchingPair(stackParanthesis.Pop(), strWord[i]))
                    {
                        return false;
                    }
                }
            }
            if (stackParanthesis.Count == 0)
                return true;
            else
                return false;

        }

        private bool IsMatchingPair(char src, char dest)
        {
            if (src == '(' && dest == ')')
                return true;
            if (src == '[' && dest == ']')
                return true;
            if (src == '{' && dest == '}')
                return true;
            else
                return false;
        }

        public string ShortString(string s)
        {
            int maxCount = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                {
                    maxCount = 1;
                }
                else
                {
                    maxCount++;
                }
                if (maxCount < 3)
                    sb.Append(s[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 1. Get left maximum
        /// 2. Get right maximum
        /// 3. get min left and right
        /// 4. run through loop keep adding diff between s3 - s[i]
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int TotalTrappedWater(int[] height)
        {
            int totalWater = 0;
            int[] leftMax = new int[height.Length];
            int[] rightMax = new int[height.Length];
            int[] minLandR = new int[height.Length];
            leftMax[0] = height[0];
            for (int i = 1; i < height.Length; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            }
            rightMax[height.Length - 1] = height[height.Length - 1];
            for (int i = height.Length - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            }
            for (int i = 0; i < height.Length; i++)
            {
                minLandR[i] = Math.Min(leftMax[i], rightMax[i]);
            }
            for (int i = 0; i < height.Length; i++)
            {
                totalWater = totalWater + (minLandR[i] - height[i]);
            }
            return totalWater;
        }

        /// <summary>
        /// 1. Sort the start intervals and end intervals
        /// 2. first Starttime is less than end time , need meeting room.
        ///     a) meeting room ++
        ///   
        /// 3. Increment the start time ++ always
        /// 4. start time is ahead and end time behind by one index
        /// 5. if next start time is less than previous end time then meeting room required ++
        /// 6. else endIndex increment ++
        /// 
        /// 
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms(int[][] intervals)
        {
            int[] startTimes = new int[intervals.Length];
            int[] endTimes = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                startTimes[i] = intervals[i][0];
                endTimes[i] = intervals[i][1];
            }
            Array.Sort(startTimes);
            Array.Sort(endTimes);
            int startIndex = 0; int endIndex = 0; int len = startTimes.Length - 1;
            int minMeetingRms = 0;
            while (startIndex < len)
            {
                if (startTimes[startIndex] < endTimes[endIndex])
                {
                    minMeetingRms++;
                }
                else
                {
                    endIndex++;
                }
                startIndex++;
            }

            return minMeetingRms;
        }

        public bool BackspaceCompare(string S, string T)
        {
            StringBuilder sModified = new StringBuilder();
            StringBuilder tModified = new StringBuilder();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '#')
                {
                    sModified.Remove(sModified.Length - 1, 1);
                }
                else
                {
                    sModified.Append(S[i]);
                }
            }
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] == '#')
                {
                    tModified.Remove(tModified.Length - 1, 1);
                }
                else
                {
                    tModified.Append(T[i]);
                }
            }
            return tModified.ToString() == sModified.ToString() ? true : false;
        }

        public bool BackspaceCompare2(string s, string t)
        {
            return Build(s).Equals(Build(t));
        }

        private string Build(string s)
        {
            Stack<char> stk = new Stack<char>();
            foreach (char ch in s)
            {
                if (ch == '#' && stk.Count > 0)
                {
                    stk.Pop();
                }
                else if (ch != '#')
                {
                    stk.Push(ch);
                }
            }
            Console.WriteLine(new string(stk.ToArray()));
            return new string(stk.ToArray());
        }

        public int[][] KClosest(int[][] points, int K)
        {
            int len = points.Length, l = 0, r = len - 1;
            while (l <= r)
            {
                int mid = helper(points, l, r);
                if (mid == K) break;
                if (mid < K)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            var closest = new int[K][];
            for (int i = 0; i < K; i++)
            {
                closest[i] = points[i];
            }
            return closest;
        }

        private int helper(int[][] A, int l, int r)
        {
            int[] pivot = A[l];
            while (l < r)
            {
                while (l < r && compare(A[r], pivot) >= 0) r--;
                A[l] = A[r];
                while (l < r && compare(A[l], pivot) <= 0) l++;
                A[r] = A[l];
            }
            A[l] = pivot;
            return l;
        }

        private int compare(int[] p1, int[] p2)
        {
            return p1[0] * p1[0] + p1[1] * p1[1] - p2[0] * p2[0] - p2[1] * p2[1];
        }

        public IList<string> LetterCombinations(string digits)
        {
            List<string> result = new List<string>();
            //base conditions
            if(string.IsNullOrWhiteSpace(digits) ||digits.Length==0)
            {
                return null;
            }
            string[] groupLetters = { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            
            CombinationRecursive(digits,groupLetters, 0,"",result);

            return result;
        }

        private void CombinationRecursive(string digits, string [] grps, int index, string temp, List<string> result)
        {
            if(index==digits.Length)
            {
                result.Add(temp);
                return;
            }
            string grpLetters = grps[digits[index]-'0'];
            for(int i=0;i<grpLetters.Length;i++)
            {
                CombinationRecursive(digits, grps, index + 1, grpLetters[i] + temp, result);
            }
        }

        public int[][] MergeIntervals(int[][] intervals)
        {
            int[] startInterval = new int[intervals.Length];
            int[] endInterval = new int[intervals.Length];

            for(int i=0;i<intervals.Length;i++)
            {
                startInterval[i] = intervals[i][0];
                endInterval[i] = intervals[i][1];
            }
            Array.Sort(startInterval);
            Array.Sort(endInterval);
            List<int[]> lst = new List<int[]>();
            for(int i=1;i<intervals.Length;i++)
            {
                int prevInterval = startInterval[i - 1];
                if(endInterval[i-1]>=startInterval[i])
                {
                    lst.Add(new int[] { prevInterval, endInterval[i] });
                    i++;
                }
                else
                {
                    lst.Add(new int[] { prevInterval, endInterval[i-1] });
                }
            }
            return lst.ToArray();
        }

        public string LongestPalindromeDynamic(string s)
        {
            int sLen = s.Length;
            int[,] table = new int[sLen, sLen];
            int maxLength = 1;
            //// Strings of length 1 are 
            // palindrome of lentgh 1 
            for (int i=0;i<sLen;i++)
            {
                table[i, i] = 1;
            }
            // check for sub-string of length 2. 
            int start = 0;
            for (int i = 0; i < sLen - 1; ++i)
            {
                if (s[i] == s[i + 1])
                {
                    table[i,i + 1] = 1;
                    start = i;
                    maxLength = 2;
                }
            }
            // Check for lengths greater than 2. k is length 
            // of substring 
            for (int k = 3; k <= sLen; ++k)
            {

                // Fix the starting index 
                for (int i = 0; i < sLen - k + 1; ++i)
                {
                    // Get the ending index of substring from 
                    // starting index i and length k 
                    int j = i + k - 1;

                    // checking for sub-string from ith index to 
                    // jth index iff str.charAt(i+1) to  
                    // str.charAt(j-1) is a palindrome 
                    if (table[i + 1,j - 1]==1 && s[i] == s[j])
                    {
                        table[i,j] = 1;

                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }

            }

            return s.Substring(start, maxLength);
        }
    }
}
