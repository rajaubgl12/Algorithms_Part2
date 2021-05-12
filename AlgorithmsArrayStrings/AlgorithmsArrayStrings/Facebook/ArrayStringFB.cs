using AlgorithmsArrayStrings.Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Facebook
{
    public class ArrayStringFB
    {
        /// <summary>
        /// abcdafgh
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0 || s.Length == 1)
            {
                return s.Length;
            }

            Dictionary<char, int> existChars = new Dictionary<char, int>();

            int ans = 0;
            int i = 0;
            int j = 0;
            while (j < s.Length)
            {
                if (existChars.ContainsKey(s[j]))
                {
                    ans = Math.Max(ans, j - i);
                    i = Math.Max(i, existChars[s[j]] + 1);
                    existChars[s[j]] = j;
                }
                else
                {
                    existChars.Add(s[j], j);
                }
                j++;
            }
            ans = Math.Max(ans, j - i);

            return ans;
        }

        public int MyAtoi(string str)
        {
            int startIndex = 0;
            long convertedValue = 0;
            int sign = 1;
            //remove white spaces.
            str = str.Trim();
            if (str[startIndex] == '+' || str[startIndex] == '-')
            {
                if (str[startIndex] == '-')
                    sign = -1;
                startIndex++;
            }

            //loop the through the string
            for (; startIndex < str.Length; startIndex++)
            {
                //check if it's not integer.
                if (str[startIndex] < '0' || str[startIndex] > '9')
                {
                    break;
                }
                convertedValue = convertedValue * 10;
                convertedValue = convertedValue + str[startIndex] - '0';
            }
            if (convertedValue < int.MaxValue || convertedValue > int.MinValue)
                return (int)convertedValue;
            else
                return 0;

        }

        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanDictionary = new Dictionary<char, int>();
            romanDictionary.Add('I', 1);
            romanDictionary.Add('V', 5);
            romanDictionary.Add('X', 10);
            romanDictionary.Add('L', 50);
            romanDictionary.Add('C', 100);
            romanDictionary.Add('D', 500);
            romanDictionary.Add('M', 1000);

            int result = romanDictionary[s[s.Length - 1]];

            for (int i = s.Length - 1; i > 0; i--)
            {
                if (romanDictionary[s[i]] <= romanDictionary[s[i - 1]])
                {
                    result += romanDictionary[s[i - 1]];
                }
                else
                {
                    result -= romanDictionary[s[i - 1]];
                }
            }

            return result;
        }

        /// <summary>
        /// Three sum to zero
        /// Using two pointers.
        /// 1. Sort the array.
        /// 2. Use for loop
        /// 3. Use while loop inside for loop.
        /// 4. Use left and right pointer.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] a)
        {
            Array.Sort(a);
            List<IList<int>> lst = new List<IList<int>>();

            for (int i = 0; i < a.Length; i++)
            {
                if (i > 0 && a[i] == a[i - 1])
                    continue;

                int left = i + 1;
                int right = a.Length - 1;

                while (left < right)
                {
                    int sum = a[i] + a[left] + a[right];
                    if (sum == 0)
                    {
                        lst.Add(new List<int> { a[i], a[left], a[right] });
                    }
                    if (sum > 0)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return lst;
        }

        /// <summary>
        /// Using hashset
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSumHashset(int[] a)
        {
            int sum = 0;
            var lst = new List<IList<int>>();

            Array.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                if (i > 0 && a[i] == a[i - 1])
                    continue;

                HashSet<int> hashValues = new HashSet<int>();
                for (int j = i + 1; j < a.Length; j++)
                {
                    var trplValues = new List<int>();
                    int tempSum = a[i] + a[j];
                    if (hashValues.Contains(sum - tempSum))
                    {
                        trplValues.Add(a[i]);
                        trplValues.Add(a[j]);
                        trplValues.Add(sum - tempSum);
                    }
                    hashValues.Add(a[j]);
                    if (trplValues != null && trplValues.Count > 0)
                        lst.Add(trplValues);
                }
            }
            return lst;
        }

        /// <summary>
        /// have two pointer i = 0 and j=1 , if a[i]!=a[j]  copy to a[i] increment i 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {

            int right = nums.Length - 1;
            int startIndex = 0;
            //swap
            //check if its greater if yes break 
            //else swap back and move to next.
            for (int j = right - 1; j > -1; j--)
            {
                if (nums[right] > nums[j])
                {
                    //swap
                    int temp = nums[j];
                    nums[j] = nums[right];
                    nums[right] = temp;
                    //start ascending order
                    startIndex = j + 1;
                    break;
                }
            }

            //Reverse
            int end = nums.Length - 1;
            while (startIndex < end)
            {
                int temp = nums[end];
                nums[end] = nums[startIndex];
                nums[startIndex] = temp;
                startIndex++;
                end--;
            }

        }

        /// <summary>
        /// Start from the right, find the decreasing element in the right most
        /// swap with the next immediate bigger element
        /// reverse the remaining element.
        /// </summary>
        /// <param name="nums"></param>
        public void nextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i + 1] <= nums[i])
            {
                i--;
            }
            //found decreasing element at i
            //swap with next immediate greater element.
            if (i >= 0)
            {
                //start from right you will find immediate next bigger element.
                int j = nums.Length - 1;
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                swap(nums, i, j);
            }
            //reverse the remaining elements.
            reverse(nums, i + 1);
        }

        private void reverse(int[] nums, int start)
        {
            int i = start, j = nums.Length - 1;
            while (i < j)
            {
                swap(nums, i, j);
                i++;
                j--;
            }
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }


        public string Multiply(string num1, string num2)
        {
            //convert to integer.
            int intnum1 = 0;
            int intnum2 = 0;
            for (int i = 0; i < num1.Length; i++)
            {
                intnum1 = intnum1 * 10;
                intnum1 = intnum1 + num1[i] - '0';
            }
            for (int i = 0; i < num2.Length; i++)
            {
                intnum2 = intnum2 * 10;
                intnum2 = intnum2 + num2[i] - '0';
            }
            StringBuilder sb = new StringBuilder();
            string str = "";
            string st = new String(str.ToCharArray().Reverse().ToArray());
            return (intnum2 * intnum1).ToString();
        }

        /// <summary>
        /// Use sort technique, when sorted all the string chars should be same.
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> groupAnagramsLst = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] strArray = strs[i].ToCharArray();
                Array.Sort(strArray);
                string isExists = new string(strArray);
                if (groupAnagramsLst.ContainsKey(isExists))
                {
                    groupAnagramsLst[isExists].Add(strs[i]);
                }
                else
                {
                    groupAnagramsLst.Add(isExists, new List<string>() { strs[i] });
                }
            }

            IList<IList<string>> lst = new List<IList<string>>();

            foreach (KeyValuePair<string, List<string>> keyValuePair in groupAnagramsLst)
            {
                lst.Add(keyValuePair.Value);
            }

            return lst;
        }

        /// <summary>
        /// minmum window string 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pat"></param>
        /// <returns></returns>
        public string MinWindow(string str, string pat)
        {

            int len1 = str.Length;
            int len2 = pat.Length;

            // check if string's length is less than pattern's 
            // length. If yes then no such window can exist 
            if (len1 < len2)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            int[] hash_pat = new int[126];
            int[] hash_str = new int[126];

            // store occurrence ofs characters of pattern 
            for (int i = 0; i < len2; i++)
                hash_pat[pat[i]]++;

            int start = 0, start_index = -1, min_len = int.MaxValue;

            // start traversing the string 
            int count = 0; // count of characters 
            for (int j = 0; j < len1; j++)
            {
                // count occurrence of characters of string 
                hash_str[str[j]]++;

                // If string's char matches with pattern's char 
                // then increment count 
                if (hash_pat[str[j]] != 0 &&
                    hash_str[str[j]] <= hash_pat[str[j]])
                    count++;

                // if all the characters are matched 
                if (count == len2)
                {
                    // Try to minimize the window i.e., check if 
                    // any character is occurring more no. of times 
                    // than its occurrence in pattern, if yes 
                    // then remove it from starting and also remove 
                    // the useless characters. 
                    while (hash_str[str[start]] > hash_pat[str[start]]
                        || hash_pat[str[start]] == 0)
                    {

                        if (hash_str[str[start]] > hash_pat[str[start]])
                            hash_str[str[start]]--;
                        start++;
                    }

                    // update window size 
                    int len_window = j - start + 1;
                    if (min_len > len_window)
                    {
                        min_len = len_window;
                        start_index = start;
                    }
                    //move the starting pointer and decrement the counter
                    //We found the desirable window move the start pointer by 1 and decrement the counter
                    if (hash_str[str[start]] == 1 && j < str.Length)
                    {
                        hash_str[str[start]]--;
                        start++;
                        count--;
                    }

                }
            }

            // If no window found 
            if (start_index == -1)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            // Return substring starting from start_index 
            // and length min_len 
            return str.Substring(start_index, min_len);
        }

        public string MinWindowDictionary(string str, string pat)
        {
            //base condition
            if (pat.Length > str.Length)
                return "";

            if (pat.Length == str.Length && str.Equals(pat))
                return str;

            if (string.IsNullOrWhiteSpace(str) 
                || string.IsNullOrWhiteSpace(pat))
                return "";


            //copy the dest into the dictionary
            Dictionary<char, int> patDict = new Dictionary<char, int>();
            for(int i=0;i<pat.Length;i++)
            {
                if (patDict.ContainsKey(pat[i]))
                {
                    patDict[pat[i]]++;
                }
                else
                    patDict.Add(pat[i], 1);
            }

            // initilize variables
            int start = 0;
            int end = 0;
            int minWindow = int.MaxValue;
            int countMatching = 0;
            string minWindowSubstring = "";
            Dictionary<char, int> strDict = new Dictionary<char, int>();
            for(int i=0;i<str.Length;i++)
            {
                if (strDict.ContainsKey(str[i]))
                {
                    strDict[str[i]]++;
                }
                else
                {
                    strDict.Add(str[i], 1);
                }

                //increment count when it matches with the pattern
                if (patDict.ContainsKey(str[i]) && strDict[str[i]] <= patDict[str[i]] && strDict[str[i]]>0)
                    countMatching++;

                if(countMatching==pat.Length)
                {
                    //start index is in 0. move to the place where the first matching happened.

                    while (!patDict.ContainsKey(str[start])|| strDict[str[start]] > patDict[str[start]]
                         )
                    {
                        strDict[str[start]]--;
                        start++;
                        
                    }

                    //find the min window
                    if(minWindow>i-start+1)
                    {
                        minWindow = i - start + 1;
                        minWindowSubstring = str.Substring(start, minWindow);
                    }

                    // decrement counter and move the window
                    strDict[str[start]]--;
                    start++;
                    countMatching--;


                }

            }

            return minWindowSubstring;
        }

        /// <summary>
        /// Merge two sorted arrays
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
                k--;
            }
            while (k >= 0 && j >= 0)
            {
                nums1[k] = nums2[j];
                j--;
                k--;
            }
        }

        public bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length;
            while (start < end)
            {
                while (!IsAlphaNumeric(s[start]))
                    start++;
                while (!IsAlphaNumeric(s[end]))
                    end--;
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                    return false;

            }
            return true;
        }

        private bool IsAlphaNumeric(char c)
        {
            if (c >= 'A' && c <= 'Z'
                || c >= 'a' && c <= 'z'
                || c >= '0' && c <= '9')
            {
                return true;
            }
            else
                return false;
        }

        public bool IsOneEditDistance(string s, string t)
        {
            if (s.Equals(t))
                return true;
            if (string.IsNullOrWhiteSpace(t) && s.Length > 2)
                return false;
            int count = 0;
            if(s.Length==t.Length)
            {
                //replace
                for(int i=0;i<s.Length;i++)
                {
                    if(s[i]!=t[i])
                    {
                        count++;
                    }
                }
                if (count > 1)
                    return false;
                else
                    return true;
            }
            else if(Math.Abs(s.Length-t.Length)>1)
            {
                return false;
            }
            else
            {
                count = 0;
                for (int i = 0; i < t.Length; i++)
                {
                    if(i<s.Length&&s[i]!=t[i])
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Algorithm
        /// Initialize two empty arrays, L and R where for a given index i, L[i] would contain the
        /// product of all the numbers to the left of i and R[i] would contain the product of all the 
        /// numbers to the right of i.
        /// We would need two different loops to fill in values for the two arrays.
        ///For the array L, L[0] L[0] would be 1 since there are no elements to the left of the first element. 
        ///For the rest of the elements, 
        ///we simply use L[i] = L[i - 1] * nums[i - 1] L[i]= L[i−1]∗nums[i−1]. 
        ///Remember that L[i] represents product of all the elements to the left of element at index i.
        ///For the other array, we do the same thing but in reverse i.e.we start with the initial value of
        ///1 in R[length - 1] R[length−1] where lengthlength is the number of elements in the array, 
        ///and keep updating R[i] in reverse.Essentially, R[i] = R[i + 1] * nums[i + 1]R[i]= R[i + 1]∗nums[i + 1]. Remember that R[i] represents product of all the elements to the right of element at index i.
        /// Once we have the two arrays set up properly, we simply iterate over the input array one element at a time, and for each element at index i, we find the product except self as L[i] * R[i] L[i]∗R[i].
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int [] ProductExceptSelf(int [] a)
        {
            int[] result = new int[a.Length];
            int[] left = new int[a.Length];
            int[] right = new int[a.Length];
            left[0] = 1;
            right[a.Length-1] = 1;
            for (int i = 1; i < a.Length; i++)
            {
                left[i] = left[i - 1] * a[i - 1];
            }

            for (int i = a.Length-2; i > -1; i--)
            {
                right[i] = right[i + 1] * a[i + 1];
            }

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }

        /// <summary>
        /// sliding window with dictionary.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            if (k == 0)
                return 0;
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            int left = 0;
            int right = 0;
            int maxLen = 0;
            Dictionary<char, int> keyValues = new Dictionary<char, int>();
            while(right<s.Length)
            {
                if(keyValues.ContainsKey(s[right]))
                {
                    keyValues[s[right]]++;
                }
                else
                {
                    keyValues.Add(s[right], 1);
                }

                while (left < right && keyValues.Count > k)
                {
                    keyValues[s[left]]--;
                    
                    if(keyValues[s[left]]==0)
                    {
                        keyValues.Remove(s[left]);
                    }
                    left++;
                }
                maxLen = Math.Max(maxLen, right - left + 1);
                right++;
            }

            return maxLen;
        }

        public string ValidIPAddress(string IP)
        {
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {
            int left = 0;
            int right = 0;
            int count = 0;
            int currSum = 0;
            while (right < nums.Length)
            {
                currSum += nums[right];

                while (left < right && (currSum > k || currSum<0) )
                {
                    currSum -= nums[left];
                    left++;
                }

                if (currSum == k)
                {
                    count++;
                }
                right++;
            }

            return count;
        }

        public int SubarraySumOrderOfN(int[] nums, int k)
        {

            Dictionary<int, int> prevSum = new Dictionary<int, int>();

            int res = 0;

            // Sum of elements so far 
            int currsum = 0;

            for (int i = 0; i < nums.Length; i++)
            {

                currsum += nums[i];

                if (currsum == k)
                    res++;


                if (prevSum.ContainsKey(currsum - k))
                    res += prevSum[currsum - k];

                if (!prevSum.ContainsKey(currsum))
                    prevSum.Add(currsum, 1);
                else
                {
                    int count = prevSum[currsum];
                    prevSum[currsum] = count + 1;
                }
            }
            return res;
        }

        /// <summary>
        /// Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while(left<right)
            {
                if (s[left] != s[right]) return (CheckPalindrome(s,left+1, right) || CheckPalindrome(s, left, right-1));
                left++;
                right--;
            }
            return true;
        }

        private bool CheckPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, IList<char>> keyValuePairs = new Dictionary<char, IList<char>>()
            {
                { '2', new List<char>() {'a', 'b', 'c'} },
                { '3', new List<char>() {'d', 'e', 'f'} },
                { '4', new List<char>() {'g', 'h', 'i'} },
                { '5', new List<char>() {'j', 'k', 'l'} },
                { '6', new List<char>() {'m', 'n', 'o'} },
                { '7', new List<char>() {'p', 'q', 'r', 's'} },
                { '8', new List<char>() {'t', 'u', 'v'} },
                { '9', new List<char>() {'w', 'x', 'y', 'z'} },
            };

            IList<string> result = new List<string>();
            LetterCombinationRecursive(keyValuePairs,digits, 0, string.Empty, result);
            return result;
        }

        private void LetterCombinationRecursive(Dictionary<char,IList<char>> phonePairs,
            string digits, int index, string temp, IList<string> result)
        {
            if(temp.Length==digits.Length)
            {
                result.Add(temp);
                return;
            }

            IList<char> charLst = phonePairs[digits[index]];


            for(int i=0;i<charLst.Count;i++)
            {
                LetterCombinationRecursive(phonePairs, digits, index+1, charLst[i]+ temp, result);
            }
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> lstResult = new List<IList<int>>();
            //Array.Sort(nums);
            PermutationArray(nums,0,lstResult);
            return lstResult;
        }

        private void PermutationArray(int[] nums, int index, List<IList<int>> lstResult)
        {
            if(index==nums.Length-1)
            {
                lstResult.Add(new List<int>(nums));
                return;
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i=index;i<nums.Length;i++)
            {
                if (map.ContainsKey(nums[i]))
                    continue;
                else
                    map.Add(nums[i], 1);
                int temp = nums[i];
                nums[i] = nums[index];
                nums[index] = temp;
                PermutationArray(nums, index + 1, lstResult);
                int temp2 = nums[i];
                nums[i] = nums[index];
                nums[index] = temp2;
            }
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> lstResult = new List<IList<int>>();
            SubsetRecursive(nums,lstResult,0, new List<int>());
            return lstResult;
        }

        private void SubsetRecursive(int[] nums, IList<IList<int>> lstResult, int index, List<int> currList)
        {
            lstResult.Add(new List<int>(currList));
            for (int i = index; i < nums.Length; i++)
            {
                currList.Add(nums[i]);
                SubsetRecursive(nums, lstResult, i + 1, currList);
                currList.RemoveAt(currList.Count - 1);
            }
        }

        public IList<string> FindStrobogrammatic(int n)
        {
            IList<string> ans = FindStrobogrammaticRec(n);
            if (n > 1)
            {
                while (ans[ans.Count - 1][0] == '0')
                    ans.RemoveAt(ans.Count - 1);
            }
            return ans;
        }

        private IList<string> FindStrobogrammaticRec(int n)
        {
            if (n == 1)
                return new List<string>(new string[] { "1", "8", "0" });
            if (n == 2)
                return new List<string>(new string[] { "11", "69", "88", "96", "00" });

            List<string> ans = new List<string>();
            IList<string> rec = FindStrobogrammaticRec(n - 2);
            foreach (string s in rec)
            {
                ans.Add("1" + s + "1");
                ans.Add("6" + s + "9");
                ans.Add("8" + s + "8");
                ans.Add("9" + s + "6");
            }
            foreach (string s in rec)
                ans.Add("0" + s + "0");

            return ans;
        }

        /// <summary>
        /// Suppose an array sorted in ascending order is rotated at 
        /// some pivot unknown to you beforehand.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            return SearchPivotHelper(nums, target, 0, nums.Length - 1);
        }

        private int SearchPivotHelper(int[] nums, int target, int start, int end)
        {
            int mid = (start + end) / 2;
            if (nums[mid] == target)
                return mid;

            if((nums[mid]>=nums[start])&&(target>=nums[start]&&target<nums[mid]))
            {
                return SearchPivotHelper(nums, target, start, mid-1);
            }
            else
            {
                return SearchPivotHelper(nums, target, mid+1, end);
            }
        }

        /// <summary>
        /// Given an array of integers nums sorted in ascending order, 
        /// find the starting and ending position of a given target value.
        /// time complexity log(n)
        /// Using linear time its easy to find the first target number.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            int startRange = SearchLeftExtreme(nums, start, end, target);

            int endRange = SearchRightExtreme(nums, start, end, target);

            return new int[] { startRange, endRange };
        }

        private int SearchRightExtreme(int[] nums, int start, int end, int target)
        {
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target && (nums[mid + 1] > target))
                {
                    return mid;
                }
                else if (nums[mid] == target && (nums[mid + 1] <= target))
                {
                    start = mid;
                }
                else if (nums[mid] > target)
                {
                    end = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    start = mid + 1;
                }
            }
            return -1;
        }

        private int SearchLeftExtreme(int[] nums, int start, int end, int target)
        {
            while(start<end)
            {
                int mid = (start + end) / 2;
                if(nums[mid]==target && (nums[mid - 1] < target))
                {
                    return mid;
                }
                else if(nums[mid]==target && (nums[mid - 1] <= target))
                {
                    end = mid;
                }
                else if(nums[mid]>target)
                {
                    end = mid - 1;
                }
                else if(nums[mid]<target)
                {
                    start = mid + 1;
                }
            }
            return -1;
        }

        public int[][] Merge(int[][] intervals)
        {
            var n = intervals.Length;

            if (n <= 1)
            {
                return intervals;
            }

            /* NOTE:
                better, because it does not modify the input (try best to immutability)
                but Time Limit Exceeded :(
            */
            // var sortedIntervals = intervals.OrderBy(interval => interval[0]);
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            var result = new List<int[]>();
            result.Add(intervals.ElementAt(0));
            for (int i = 1; i < n; i++)
            {
                var cur = intervals.ElementAt(i);
                var lastFromResult = result.Last();

                if (lastFromResult[1] >= cur[0])
                {
                    //updates the array in result list.
                    lastFromResult[1] = Math.Max(lastFromResult[1], cur[1]);
                }
                else
                {
                    result.Add(cur);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// A peak element is an element that is greater than its neighbors.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[mid + 1])
                    r = mid;
                else
                    l = mid + 1;
            }
            return l;
        }
        public int findPeakElementRec(int[] nums)
        {
            return search(nums, 0, nums.Length - 1);
        }
        public int search(int[] nums, int l, int r)
        {
            if (l == r)
                return l;
            int mid = (l + r) / 2;
            if (nums[mid] > nums[mid + 1])
                return search(nums, l, mid);
            return search(nums, mid + 1, r);
        }

        /// <summary>
        /// Given two arrays, write a function to compute their intersection.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            //find the shorter array
            int[] shorter = nums1.Length > nums2.Length ? nums2 : nums1;
            int[] longer = nums1.Length > nums2.Length ? nums1 : nums2;
            Dictionary<int, int> shortKeyPair = new Dictionary<int, int>();
            for(int i=0;i<shorter.Length;i++)
            {
                if(shortKeyPair.ContainsKey(shorter[i]))
                {
                    shortKeyPair[shorter[i]]++;
                }
                else
                {
                    shortKeyPair.Add(shorter[i], 1);
                }
            }
            IList<int> lstIntersection = new List<int>();
            for(int i=0;i<longer.Length;i++)
            {
                if(shortKeyPair.ContainsKey(longer[i])&& shortKeyPair[longer[i]] >0)
                {
                    lstIntersection.Add(longer[i]);
                    shortKeyPair[longer[i]]--;
                }
            }
            return lstIntersection.ToArray();
        }

        /// <summary>
        /// Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
        /// Logic:
        /// Push the index to stack, start with -1 index, push if '(' pop else and subtract from index in 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            int count = 0;
            Stack<int> st = new Stack<int>();
            st.Push(-1);
            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='(')
                {
                    st.Push(i);
                }
                else
                {
                    st.Pop();
                    if(st.Count>0)
                    {
                        count = Math.Max(count, i - st.Peek());
                    }
                    else
                    {
                        st.Push(i);
                    }
                }
                
            }
            return count;
        }

        /// <summary>
        /// https://leetcode.com/explore/interview/card/facebook/55/dynamic-programming-3/264/
        /// https://www.youtube.com/watch?v=cQX3yHS0cLo
        /// https://www.youtube.com/watch?v=aCKyFYF9_Bg
        /// https://www.youtube.com/watch?v=GuTPwotSdYw
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            return NumDecodingRecDpHelper(s, 0);
        }
        Dictionary<int, int> memo = new Dictionary<int, int>();
        private int NumDecodingRecDpHelper(string s, int index)
        {
            if (index == s.Length || index == s.Length - 1)
                return 1;

            if (s[index] == '0')
                return 0;
            if (memo.ContainsKey(index))
                return memo[index];
                        
            int count = NumDecodingRecDpHelper(s, index + 1);
            if (int.Parse(s.Substring(index, 2)) <= 26)
            {
                count+= NumDecodingRecDpHelper(s, index + 2);
            }
            memo.Add(index, count);
            return count;
        }

        public int NumDecodingsDpIterativememo(string s)
        {
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = s[0] == '0' ? 0 : 1;
            if (s.Length == 2)
                return dp[0] + dp[1];

            for(int i=2;i<=s.Length;i++)
            {
                int oneDigit = int.Parse(s.Substring(i-1, 1));
                int twoDigit = int.Parse(s.Substring(i-2, 2));
                if(oneDigit>0)
                {
                    dp[i] += dp[i - 1];
                }
                if (twoDigit <= 26)
                    dp[i] += dp[i - 2];
            }

            return dp[s.Length];
        }

        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int curr_min = prices[0], max = 0;
            for (int i = 1; i < prices.Length; i++)
            {

                curr_min = Math.Min(curr_min, prices[i]);
                max = Math.Max(max, prices[i] - curr_min);


            }
            return max > 0 ? max : 0;
        }

        public bool WordBreakRec_BruteForce(string s, IList<string> wordDict)
        {
            if (s.Length == 0)
                return true;
          
            if (string.IsNullOrWhiteSpace(s))
                return false;

            for(int i=1;i<s.Length;i++)
            {
                
                string subString = s.Substring(0, i);

                if (wordDict.Contains(subString) 
                    && WordBreakRec_BruteForce(subString, wordDict))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// check the result
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool wordBreak_Rec_Memo(String s, List<String> wordDict)
        {
            return word_Break(s, wordDict, 0, new Boolean[s.Length+1]);
        }
        public bool word_Break(String s, List<String> wordDict, int start, bool[] memo)
        {
            if (start == s.Length)
            {
                return true;
            }
            if (memo[start] != null)
            {
                return memo[start];
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                if (wordDict.Contains(s.Substring(start, end)) && word_Break(s, wordDict, end, memo))
                {
                    return memo[start] = true;
                }
            }
            return memo[start] = false;
        }

        public bool WordBreakdynamic(String s, IList<String> wordDict)
        {
            HashSet<string> wordDictSet = new HashSet<string>();
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordDictSet.Contains(s.Substring(j, i)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }


    }
}

