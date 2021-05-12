using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class LeetcodeGeneral
    {
        public int LongestValidParentheses(string s)
        {
            Stack<char> st = new Stack<char>();
            int countClose = 0;
            int countOpen = 0;
            int countSeqClose = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    st.Push('(');
                    countOpen++;
                }
                else if (s[i] == ')')
                {
                    if (st.Count > 0)
                    {
                        if (st.Pop() == '(')
                        {
                            countSeqClose++;
                        }
                    }

                    countClose++;
                }
            }
                if (countSeqClose == 0 && st.Count==0)
                    return 0;
            int maxCount = Math.Max(countClose, countOpen);
            int minCount = Math.Min(countClose, countOpen);
            int diffParCount = maxCount - minCount;
            return diffParCount == 0 ? countClose * 2 : minCount * 2;
        }
    }
}
