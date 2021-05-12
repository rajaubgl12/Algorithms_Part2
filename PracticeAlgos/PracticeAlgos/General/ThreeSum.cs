using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgos.General
{
    public class ThreeSumCls
    {
        public IList<IList<int>> ThreeSum(int[] a)
        {
            IList<IList<int>> lstRes = new List<IList<int>>();
            IList<int> currLst = new List<int>();
            int index = 0;
            int sum = 0;
            
            ThreeSumRec(a, currLst, lstRes, sum, index);
            return lstRes;
        }

        private void ThreeSumRec(int[] a, IList<int> currLst, IList<IList<int>> lstRes, int targteSum, int index)
        {
            if(targteSum==0 && currLst.Count==3)
            {
                lstRes.Add(new List<int>(currLst));
                return;
            }
           if(currLst.Count>3)
            {
                return;
            }
            for (int i = index; i < a.Length; i++)
            {

                if (i == index || a[i] != a[i - 1])
                {
                    currLst.Add(a[i]);
                    ThreeSumRec(a, currLst, lstRes, a[i] + targteSum, index + 1);
                    currLst.RemoveAt(currLst.Count - 1);
                }
                    
            }           
        }

        public IList<IList<int>> ThreeSum(int[] a, int sum)
        {
            var lst = new List<IList<int>>();
            for (int i = 0; i < a.Length; i++)
            {
                // int tempSum = sum - a[i];
                HashSet<int> hashValues = new HashSet<int>();
                for (int j = i + 1; j < a.Length; j++)
                {
                    var trplValues = new List<int>();
                    int tempSum = a[i] + a[j];
                    if (hashValues.Contains(sum - tempSum))
                    {
                        trplValues.Add(a[i]);
                        trplValues.Add(a[j]);
                        trplValues.Add(sum - tempSum);
                    }
                    hashValues.Add(a[j]);
                    if (trplValues != null && trplValues.Count > 0)
                        lst.Add(trplValues);
                }
            }
            return lst;
        }
    }
}
