using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.SortingAlgs
{
    public class ThreeSum
    {
        public List<List<int>> findZeroSum(int[] arr)
        {
            // Write your code here.
            Array.Sort(arr);
            List<int> lst = new List<int>();
            List<List<int>> lstLst = new List<List<int>>();
            

            for (int i=0;i<arr.Length;i++)
            {
                if (i > 0 && arr[i - 1] == arr[i])
                    continue;

                if (arr[i] > 0)
                    break;

                //int sum = arr[i];

                int left = i + 1;
                int right = arr.Length - 1;

                while (left < right)
                {
                    int sum = arr[i];
                    sum += arr[left] + arr[right];

                    if (sum < 0)
                    {
                        left++;
                    }
                    else if (sum > 0)
                    {
                        right--;
                        
                    }
                    else if (sum == 0)
                    {
                        lst.Add(arr[i]);
                        lst.Add(arr[left]);
                        lst.Add(arr[right]);                        
                        lstLst.Add(new List<int>(lst));
                        lst.Clear();                        
                        right--;
                    }
                }
            }

            return lstLst;
        }
    }

    
}
