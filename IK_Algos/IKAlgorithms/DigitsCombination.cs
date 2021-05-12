using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SortingAlgorithms
{
   public class DigitsCombination
    {

        public void DigitsCombinationN(int n)
        {
            int index = 0;
            List<int> lst = new List<int>();
            List<IList<int>> res = new List<IList<int>>();
            HelperDigits(n, index, lst, res);
        }

        private void HelperDigits(int n, int index, List<int> cur, List<IList<int>> res)
        {
            if(index==n)
            {
                res.Add(new List<int>(cur));
                return;
            }
            for(int i=0;i<10;i++)
            {
                cur.Add(i);
                HelperDigits(n, index + 1, cur, res);
                cur.RemoveAt(index);
            }
        }

        private void HelperDiceSume(int numDice, int sum,int curSum, int index, List<int> cur, List<IList<int>> res)
        {
            if(curSum>sum)
            {
                return;
            }
            if (curSum == sum )
            {
                res.Add(new List<int>(cur));
                return;
            }

            for (int i = 1; i < 7; i++)
            {
                curSum +=i;
                cur.Add(i);
                HelperDiceSume(numDice,sum,curSum, index + 1, cur, res);
                cur.RemoveAt(index);
                //curSum = curSum - 
            }
        }
    }
}
