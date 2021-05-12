using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /// Given a string, determine if it is a palindrome, considering only alphanumeric 
    /// characters and ignoring cases.
    //Note: For the purpose of this problem, we define empty string as valid palindrome.

    //Example 1:
    //Input: "A man, a plan, a canal: Panama"
    //Output: true
    //Example 2:
    //Input: "race a car"
    //Output: false
    /*
     * Logic:
     * 1. Have a pointer left(0) and right(n-1)
     * 2. Have a while loop, left<right
     * 3. Get an alphanumeric character for both left and right pointer,
     *  if its not found increment the pointer.
     * 4. compare the letters if its not equal return false.
     * 5. return true if all characters are compared.
     * */
    /// </summary>
    class ValidPalindrome
    {       
        public bool IsPalindrome(string s)
        {
            if (s == String.Empty || s.Length < 1)
                return true;

            int startIndex = 0;
            int endIndex = s.Length - 1;
            while (startIndex < endIndex)
            {
                // ignore all other charcter except alphnumeric 
                if (!isAlphaNuemric(s[startIndex]))
                {
                    startIndex++;
                    continue;
                }

                if (!isAlphaNuemric(s[endIndex]))
                {
                    endIndex--;
                    continue;
                }

                if (Char.ToLower(s[startIndex]) == Char.ToLower(s[endIndex]))
                {
                    startIndex++;
                    endIndex--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private bool isAlphaNuemric(char ch)
        {
            if ((ch - 'a' >= 0 && ch - 'z' <= 0) || (ch - 'A' >= 0 && ch - 'Z' <= 0) || (ch - '0' >= 0 && ch - '9' <= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
