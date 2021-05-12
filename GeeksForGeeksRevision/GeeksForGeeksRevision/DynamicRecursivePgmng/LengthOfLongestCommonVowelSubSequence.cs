using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    public class LengthOfLongestCommonVowelSubSequence
    {
        public int LcsVowels(string s1, string s2)
        {
            int[,] lcsMatrix = new int[s1.Length + 1, s2.Length + 1];
            
            for(int i=0;i<s1.Length;i++)
            {
                for(int j=0;j<s2.Length;j++)
                {
                    if (i == 0 || j == 0)
                        lcsMatrix[i, j] = 0;

                    else if ((s1[i - 1] == s2[j - 1])&&IsVowel(s1[i - 1]))
                    {
                        lcsMatrix[i, j] = lcsMatrix[i - 1, j - 1] + 1;
                    }
                    else
                        lcsMatrix[i, j] = Math.Max(lcsMatrix[i, j - 1], lcsMatrix[i - 1, j]);
                }
            }
            return lcsMatrix[s1.Length-1, s2.Length-1];
        }

        private bool IsVowel(char ch)
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                return true;
            }
            else
                return false;
        }

        //Longest Ordered Subsequence of Vowels
        //
        //
         // * Input :  str = "aeiaaioooaauuaeiou" 
         //   Output :  {a, a, a, a, a, a, e, i, o, u}
         //   There are two possible outputs in this case: 
         //   {a, a, a, a, a, a, e, i, o, u} and, 
         //   {a, e, i, i, o, o, o, u, u, u}
         //   each of length 10

         //   Input : str = "aaauuiieeou"
         //   Output : No subsequence possible
         //* /

            
        public int LongestSubSeqVowels(string s)
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
    }
}
