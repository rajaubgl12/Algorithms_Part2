using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IK_Algorithms.Recursion
{
    public class SubsetsAlg
    {
        public IList<IList<int>> Subsets(int [] a)
        {
            Array.Sort(a);
            IList<IList<int>> subsetLst = new List<IList<int>>();
            IList<int> currLst = new List<int>();
            int index = 0;
            HelperSubsets(a,index, currLst,subsetLst);
           // HelperSubSetForLoop(a, index, currLst, subsetLst);
            //DFS(a, 0, currLst, subsetLst);
            return subsetLst;
        }


    
        private void HelperTrial(string s, List<string> result, string currPali, int startIndex)
        {
            //var partition = new List<string>(p);
            
            result.Add(currPali);

            for (var i = startIndex; i < s.Length; i++)
            {
                var sub = s.Substring(startIndex, i - startIndex+1);
                HelperTrial(s, result, sub, startIndex+1);
            }
        }

        public IList<IList<int>> SubsetSum(int [] a, int sum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> currLst = new List<int>();
            int index = 0;
            int currSum = 0;
            HelperSubsetSum(a, index, currLst, result, currSum, sum );
            return result;
        }

        private void HelperSubsetSum(int[] a, int index, IList<int> currLst, IList<IList<int>> result, int currSum, int sum)
        {
            if(currSum == sum)
            {
                result.Add(new List<int>(currLst));
                return;
            }
            if(currSum>sum)
            {
                return;
            }
          
            if(index>=a.Length)
            {
                return;
            }

            currLst.Add(a[index]);
            HelperSubsetSum(a,index+1,currLst,result,currSum+a[index],sum);

            currLst.Remove(a[index]);
            HelperSubsetSum(a, index + 1, currLst, result, currSum, sum);
        }

        private void HelperSubsets(int[] a, int index, IList<int> currLst, IList<IList<int>> subsetLst)
        {

            if (index == a.Length)
            {
                subsetLst.Add(new List<int>(currLst));
                return;
            }

            //same numbers
            int next = index +1;
            while (next <a.Length && a[next] == a[index])
            {
                next++;
            }

            //inclusion 
            //if(next < a.Length)           
            currLst.Add(a[index]);
            HelperSubsets(a, next, currLst, subsetLst);
            //remove
            currLst.Remove(a[index]);
            
            //exclusion currlist will not append anything.
            HelperSubsets(a, index + 1, currLst, subsetLst);
            
        }

        private void HelperSubSetForLoop(int[] a, int index, IList<int> currList, IList<IList<int>> subsetList)
        {
           // if(index==a.Length)
            //{
                subsetList.Add(new List<int>(currList));
               // return;
            //}
            
            for (int i=index; i<a.Length;i++)
            {
                if (i > index && a[i-1] == a[i]) continue;
                
                    currList.Add(a[i]);
                    HelperSubSetForLoop(a, i + 1, currList, subsetList);
                //currList.Remove(a[i]);
                currList.RemoveAt(currList.Count-1);
            }
        }

        private void DFS(int[] nums, int startIndex, IList<int> oneResult, IList<IList<int>> result)
        {
            result.Add(new List<int>(oneResult));

            var n = nums.Length;

            for (int i = startIndex; i < n; i++)
            {
                if (i > startIndex && nums[i - 1] == nums[i]) continue;

                oneResult.Add(nums[i]);
                DFS(nums, i + 1, oneResult, result);
                oneResult.RemoveAt(oneResult.Count - 1);
            }
        }


        /// <summary>
        /// As per IK problem
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string[] generate_all_subsets(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return new string[] { "" };

            List<string> lst = new List<string>();
           
            HelperIK_Subsets(s,0, "", lst);

            //string[] res = subsetList.ToArray();

            return lst.ToArray();
        }

        /// <summary>
        /// output for 123, [[],[1],[1,2],[1,2,3],[1,3],[2],[2,3],[3]]
        /// construct the string on the fly, so don't have to have remove backtrack
        /// </summary>
        /// <param name="a"></param>
        /// <param name="index"></param>
        /// <param name="currList"></param>
        /// <param name="subsetList"></param>
        private void HelperIK_Subsets(string a, int index, string currList, IList<string> subsetList)
        {
            // if(index==a.Length)
            //{
                subsetList.Add((currList));
            // return;
            //}

            for (int i = index; i < a.Length; i++)
            {
                if (i > index && a[i - 1] == a[i]) continue;
                
                HelperIK_Subsets(a, i + 1, currList+a[i], subsetList);
                //currList.Remove(a[i]);
               // currList.Remove(currList.Length-1);
            }
        }
    }
}
