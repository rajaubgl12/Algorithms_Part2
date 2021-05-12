using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Recursion
{
    public class LetterCaseAlg
    {
        public IList<string> LetterCasePermutation(string S)
        {
            if (string.IsNullOrWhiteSpace(S))
                return null;
            
            IList<string> lst = new List<string>();

            LetterCaseHelper(S.ToCharArray(), 0, lst);

            return lst;
        }

        private void LetterCaseHelper(char[] charArray, int index, IList<string> lst)
        {
            if(index==charArray.Length)
            {
                lst.Add(new string(charArray));
                return;
            }

            if(char.IsDigit(charArray[index]))
            {
                LetterCaseHelper(charArray, index + 1, lst);
            }
            else
            {
                charArray[index] = char.ToUpper(charArray[index]);
                LetterCaseHelper(charArray, index + 1, lst);

                charArray[index] = char.ToLower(charArray[index]);
                LetterCaseHelper(charArray, index + 1, lst);
            }
        }
    }
}
