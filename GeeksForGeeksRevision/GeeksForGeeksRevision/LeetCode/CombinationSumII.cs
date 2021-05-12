using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.LeetCode
{
    class CombinationSumII
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=j9_qWJClp64
        /// https://www.youtube.com/watch?v=IER1ducXujU
        /// https://miafish.wordpress.com/2015/04/24/leetcode-ojc-combination-sum-ii/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            //CombinationSum2Recursive(candidates, 0, target, new List<int>(), result);
            CombinationSum3AddSameElement(candidates, 0, target, new List<int>(), result);
            return result;
        }

        public IList<IList<int>> CombinationKSum(int[] candidates, int target, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            
            CombinationalKSum(candidates, 0, target, new List<int>(), result,k);
            return result;
        }

        private void CombinationSum2Recursive(int[] candidates, int index, int target, List<int> currList, IList<IList<int>> result)
        {
           if(target==0)
            {
                result.Add(new List<int>(currList));
                return;
            }
           if(target<0)
            {
                return;
            }

           for(int i= index;i<candidates.Length;i++)
            {
                //i==index is for the first element just add into list after that add into list 
                //when there is no duplicate element in an array.
                if(i == index||candidates[i]!=candidates[i-1])
                {
                    currList.Add(candidates[i]);
                    CombinationSum2Recursive(candidates, i + 1, target - candidates[i], currList, result);
                    //when it returns clear the current list
                    currList.RemoveAt(currList.Count - 1);
                }
            }
        }

        /// <summary>
        /// Input : arr[] = 2, 4, 6, 8 
        /// x = 8 Output : [2, 2, 2, 2]  [2, 2, 4] [2, 6] [4, 4] [8]
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="index"></param>
        /// <param name="target"></param>
        /// <param name="currList"></param>
        /// <param name="result"></param>
        private void CombinationSum3AddSameElement(int[] candidates, int index, int target, List<int> currList, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(currList));
                return;
            }
            if (target < 0)
            {
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                //i==index is for the first element just add into list after that add into list 
                //when there is no duplicate element in an array.
                //if (i == index || candidates[i] != candidates[i - 1])
                {
                    currList.Add(candidates[i]);
                    CombinationSum3AddSameElement(candidates, i, target - candidates[i], currList, result);
                    //when it returns clear the current list
                    currList.RemoveAt(currList.Count - 1);
                }
            }
        }

        /// <summary>
        /// Find all possible combinations of k numbers that add up to a number n,
        /// given that only numbers from 1 to 9 can
        /// be used and each combination should be a unique set of numbers.
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="index"></param>
        /// <param name="target"></param>
        /// <param name="currList"></param>
        /// <param name="result"></param>
        private void CombinationalKSum(int[] candidates, int index, int target, List<int> currList, IList<IList<int>> result,int k)
        {
            if (target == 0)
            {
                if(currList.Count==k)
                result.Add(new List<int>(currList));
                return;
            }
            if (target < 0)
            {
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                //i==index is for the first element just add into list after that add into list 
                //when there is no duplicate element in an array.
               // if (i == index || candidates[i] != candidates[i - 1])
                {
                    currList.Add(candidates[i]);
                    CombinationalKSum(candidates, i+1, target - candidates[i], currList, result,k);
                    //when it returns clear the current list
                    currList.RemoveAt(currList.Count - 1);
                }
            }
        }
    }
}
