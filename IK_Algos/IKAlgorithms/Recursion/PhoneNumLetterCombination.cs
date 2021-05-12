using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Recursion
{
    public class TelephoneNumLetterCombinatoin
    {
        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, char[]> keyPairs = new Dictionary<char, char[]>();
            keyPairs.Add('2', new char[] { 'a', 'b', 'c' });
            keyPairs.Add('3', new char[] { 'd', 'e', 'f' });
            keyPairs.Add('4', new char[] { 'g', 'h', 'i' });
            keyPairs.Add('5', new char[] { 'j', 'k', 'l' });
            keyPairs.Add('6', new char[] { 'm', 'n', 'o' });
            keyPairs.Add('7', new char[] { 'p', 'q', 'r', 's' });
            keyPairs.Add('8', new char[] { 't', 'u', 'v' });
            keyPairs.Add('9', new char[] { 'w', 'x', 'y', 'z' });


            //StringBuilder sb = new StringBuilder();
            string sb=string.Empty;
            IList<string> lst = new List<string>();
            LetterCombinationHelper(digits, keyPairs, 0, sb,lst);
            return lst;
        }

        private IList<string> LetterCombinationHelper(string digits, Dictionary<char, char[]> keyPairs
            , int index, string sb, IList<string> lst)        
        {
            if(index==digits.Length)
            {
                lst.Add(sb);
                
                return lst;
            }

            char[] PhoneArray = keyPairs[digits[index]];

            for(int i=0;i<PhoneArray.Length;i++)
            {
                LetterCombinationHelper(digits, keyPairs, index + 1, (sb+PhoneArray[i]), lst);
            }

            return lst;
        }
    }
}
