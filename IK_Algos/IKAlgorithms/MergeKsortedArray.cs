using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    public class MergeKsortedArray
    {
        public static int[] mergeArrays(int[][] arr)
        {
            int[] res = new int[arr.Length * arr[0].Length];
            int x = 0;
            while(x<arr[0].Length)
            {
                res[x] = arr[0][x];
                x++;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                res = Merge(res, arr[i], arr.Length);
            }

            return res;
        }

        private static int[] Merge(int[] a, int[] b, int k)
        {
            int i = 0;
            int j = 0;
            int[] res = new int[b.Length * k];
            int m = 0;
            while (i < a.Length && j < b.Length && m<res.Length)
            {
                if (i > 0 && a[i] == 0)
                    break;
                if (a[i] < b[j])
                {
                    res[m] = a[i];
                    i++;
                }
                else if (a[i] > b[j])
                {
                    res[m] = b[j];
                    j++;
                }
                else if(a[i]==b[j])
                {
                    res[m] = a[i];
                    m++;
                    res[m] = b[j];
                    i++;
                    j++;
                }
                m++;
            }

            while (j < b.Length && m<res.Length)
            {
                res[m] = b[j];
                m++;
                j++;
            }
            while (i < a.Length && m < res.Length)
            {
                res[m] = a[i];
                m++;
                i++;
            }
            return res;
        }
    }
}
