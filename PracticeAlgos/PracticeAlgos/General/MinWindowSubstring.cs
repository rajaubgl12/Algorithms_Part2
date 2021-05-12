using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgos.General
{
    public class MinWindowSubstring
    {
        /// <summary>
        /// In any sliding window based problem we have two pointers. One rightright pointer whose job is to expand the current window and then we have the leftleft pointer whose job is to contract a given window. At any point in time only one of these pointers move and the other one remains fixed.

        //The solution is pretty intuitive.We keep expanding the window by moving the right pointer.When the window has all the desired characters, we contract (if possible) and save the smallest window till now.

        //The answer is the smallest desirable window.

        //For eg.S = "ABAACBAB" T = "ABC".Then our answer window is "ACB" and shown below is one of the possible desirable windows.
        ///Algorithm

        //We start with two pointers, leftleft and rightright initially pointing to the first element of the string SS.

        //We use the rightright pointer to expand the window until we get a desirable window i.e.a window that contains all of the characters of TT.


        //Once we have a window with all the characters, we can move the left pointer ahead one by one. If the window is still a desirable one we keep on updating the minimum window size.


        //If the window is not desirable any more, we repeat step \; 2step2 onwards.

        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
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
    }
}
