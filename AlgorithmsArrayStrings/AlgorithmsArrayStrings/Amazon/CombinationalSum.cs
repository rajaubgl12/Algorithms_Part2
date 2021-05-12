using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
    /// <summary>
    /// https://leetcode.com/problems/combination-sum/
    /// Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), 
    /// find all unique combinations in candidates where the candidate numbers sums to target.
    ///The same repeated number may be chosen from candidates unlimited number of times.
    ///Input: candidates = [2,3,6,7], target = 7,
    ///A solution set is:[ [7],[2,2,3]]
    /// </summary>
    public class CombinationalSum
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=irFtGMLbf-s
        /// combination sum with duplicates.
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationalSumDuplicate(int [] a, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> currLst = new List<int>();
            Array.Sort(a);
            CombinationalSumHelper(a, 0,0, target, currLst, res);

            return res;
        }

        private void CombinationalSumHelper(int[] a, int index, int currSum, int target, IList<int> currLst, IList<IList<int>> res)
        {
            if (currSum == target)
            {
                res.Add(new List<int>(currLst));                
            }
            else if (currSum > target)
                return;
            else
            {
                for (int i = index; i < a.Length; i++)
                {

                    if (a[i] > target)
                        break;
                    currSum = currSum + a[i];
                    currLst.Add(a[i]);
                    CombinationalSumHelper(a, i, currSum, target, currLst, res);
                    currLst.Remove(a[i]);
                    currSum = currSum - a[i];
                }
            }
            
        }

        //Combination Sum II
        //Find all unique combination, just add i+1 in recursive function 
        public IList<IList<int>> CombinationalSumUnique(int[] a, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> currLst = new List<int>();
            Array.Sort(a);
            CombinationalSumUniqueHelper(a, 0, 0, target, currLst, res);

            return res;
        }

        private void CombinationalSumUniqueHelper(int[] a, int index, int currSum, int target, IList<int> currLst, IList<IList<int>> res)
        {
            if (currSum == target)
            {
                res.Add(new List<int>(currLst));
            }
            else if (currSum > target)
                return;
            else
            {
                for (int i = index; i < a.Length; i++)
                {

                    if (a[i] > target)
                        break;
                    if (i > index && a[i] == a[i - 1])
                        continue;
                    currSum = currSum + a[i];
                    currLst.Add(a[i]);
                    CombinationalSumUniqueHelper(a, i+1, currSum, target, currLst, res);
                    currLst.Remove(a[i]);
                    currSum = currSum - a[i];
                }
            }

        }

        //Combination Sum III
        //Find all unique combination, just add i+1 in recursive function 
        public IList<IList<int>> CombinationalSumIII(int k, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> currLst = new List<int>();
            
            CombinationalSumIIIHelper(k, 1, 0, target, currLst, res);

            return res;
        }

        private void CombinationalSumIIIHelper(int k, int index, int currSum, int target, IList<int> currLst, IList<IList<int>> res)
        {
            if (currSum == target && currLst.Count==k)
            {
                res.Add(new List<int>(currLst));
            }
            else if (currSum > target)
                return;
            else
            {
                for (int i = index; i < 10; i++)
                {

                    if (i > target)
                        break;
                    currSum = currSum + i;
                    currLst.Add(i);
                    CombinationalSumIIIHelper(k, i + 1, currSum, target, currLst, res);
                    currLst.Remove(i);
                    currSum = currSum - i;
                }
            }

        }
    }
}
