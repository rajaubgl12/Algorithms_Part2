using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.MockTests
{
    public class DecodeWays
    {
        int numOfWays = 0;
        public int NumDecodings(string s)
        {
            NoOfWaysHelper(s, 0);
            return numOfWays;
        }

        private void NoOfWaysHelper(string s, int index)
        {


            if (index == s.Length - 1)
                numOfWays++;                     

            if (index >= s.Length) return;

            if (s[index] == '0') return;

            NoOfWaysHelper(s, index + 1);
            if (index + 2 > s.Length) return;

           
            
                string tempValid = s.Substring(index - 2, 2);
                int validNum = int.Parse(tempValid);

                if (validNum >= 10 && validNum <= 26)
                    NoOfWaysHelper(s, index + 2);
            

        }
    }
}
