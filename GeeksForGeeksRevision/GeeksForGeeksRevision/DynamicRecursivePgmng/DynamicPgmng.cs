using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class DynamicPgmng
    {
        public int StairCaseSteps(int n)
        {
            int[] memo = new int[n + 1];
            return StairCaseStepsRec(n, memo);
        }

        private int StairCaseStepsRec(int n, int[] memo)
        {
            if (n <0)
                return 0;
            if (n == 0)
                return 1;
            if (memo[n] > 0)
                return memo[n];
            else
            {
                memo[n] = StairCaseStepsRec(n - 1, memo) + StairCaseStepsRec(n - 2, memo) + StairCaseStepsRec(n - 3, memo);
                return memo[n];
            }
        }

        private int StairCaseStepsIterative(int n, int[] memo)
        {
            memo[0] = 1;
            memo[1] = 1;
            memo[2] = 1;
            for(int i=3;i<=n;i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2] + memo[i-3];
            }

            return memo[n];
        }

        public List<List<int>> SubsetsRecursive(int [] a)
        {
            var res = SubsetsRecursiveSub(0,a,new List<int>(), new List<List<int>>());
            return res;
        }

        private List<List<int>> SubsetsRecursiveSub(int index, int[] a, List<int> currSet, List<List<int>> subsetList)
        {
            subsetList.Add(new List<int>(currSet));
            for(int i=index;i<a.Length;i++)
            {
                currSet.Add(a[i]);
                SubsetsRecursiveSub(i + 1, a, currSet, subsetList);
                currSet.Remove(currSet.Count - 1);
            }
            return subsetList;
        }

        public List<List<int>> GetSubset(int [] a)
        {
            List<List<int>> allSubsets = new List<List<int>>();
            int max = 1 << a.Length;
            for(int i=0;i<max;i++)
            {
                List<int> currList = GetSubsetOfSets(i,a);
                allSubsets.Add(currList);
            }
            return allSubsets;
        }

        private List<int> GetSubsetOfSets(int m, int[] a)
        {
            int index = 0;
            List<int> subset = new List<int>();
            for(int k = m;k>0;k>>=1)
            {
                if((k&1)==1)
                {
                    subset.Add(a[index]);
                }
                index++;
            }
            return subset;
        }
    }
}
