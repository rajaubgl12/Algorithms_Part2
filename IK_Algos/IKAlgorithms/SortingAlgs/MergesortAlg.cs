using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.SortingAlgs
{
   public class MergesortAlg
    {
        public void MergeSort(int [] a)
        {
           int [] res =  MergeHelper(a);
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=jlHkDBEumP0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="startInd"></param>
        /// <param name="endInd"></param>
        /// <returns></returns>
        private int []  MergeHelper(int[] a)
        {
            int[] left;
            int[] right;           

            if (a.Length <= 1)
                return a;
            
            //divide array
            int mid = a.Length / 2;
            left = new int[mid];

            if (a.Length % 2 == 0)
            {
               right = new int[mid];
            }                
            else
            {
                right = new int[mid + 1];
            }

            //populate left array
            for(int i=0;i<mid;i++)
            {
                left[i] = a[i];
            }

            //populate right array
            int x = 0;
            for (int i = mid; i < a.Length; i++)
            {
                right[x++] = a[i];
            }

            left = MergeHelper(left);
            right = MergeHelper(right);
            return MergeSortHelper(left, right);

        }

        private int[] MergeSortHelper(int[] left, int[] right)
        {
            int[] res = new int[left.Length + right.Length];

            int li = 0;
            int ri = 0;
            int resi = 0;
            while(li<left.Length && ri<right.Length)
            {
                if(left[li]<=right[ri])
                {
                    res[resi] = left[li];
                    li++;
                }
                else 
                {
                    res[resi] = right[ri];
                    ri++;
                }
                resi++;
            }
           while(li<left.Length)
            {
                res[resi] = left[li];
                resi++;
                li++;
            }
            while (ri < right.Length)
            {
                res[resi] = right[ri];
                resi++;
                ri++;
            }

            return res;
        }

        public int[] MergeSortMyCode(int [] a)
        {
           
           MergeSortHelpMyCode(a, 0, a.Length - 1);
            
            return a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void MergeSortHelpMyCode(int[] a, int start, int end)
        {
            if(start<end)
            {
                int mid = (start + end) / 2;
                MergeSortHelpMyCode(a, start, mid);
                MergeSortHelpMyCode(a, mid+1, end);
                MergeSortArray(a, start, mid, end);
                //MergeSortHelpMyCode()
            }
            
        }

        private void MergeSortArray(int[] a, int start, int mid, int end)
        {
            int lb = start;
            int k = start;
            int rb = mid + 1;
            int ub = end;
            int[] b = new int[a.Length];
            while(lb<=mid && rb<=end)
            {
                if(a[lb]<=a[rb])
                {
                    b[k] = a[lb];
                    lb++;
                }
                else
                {
                    b[k] = a[rb];
                    rb++;
                }
                k++;
            }

            while(lb<=mid)
            {
                b[k++] = a[lb++];
            }

            while (rb <= end)
            {
                b[k++] = a[rb++];
            }

            //copy the merged elements to the original array
            for(int i = start;i<=end;i++)
            {
                a[i] = b[i];
            }
        }

        public  List<int> merge_sort(List<int> arr)
        {
            MergeSortListHelper(arr, 0, arr.Count-1);
            return arr;
        }

        public  void MergeSortListHelper(List<int> arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;

                MergeSortListHelper(arr, start, mid);
                MergeSortListHelper(arr, mid + 1, end);
                Merge2List(arr, start, mid, end);
            }
        }

        private void Merge2List(List<int> arr, int start, int mid, int end)
        {
            int lb = start;
            int k = start;
            int ub = end;
            int rStart = mid + 1;
            int [] lst = new int[arr.Count];

            while (lb <= mid && rStart <= ub)
            {
                if(arr[lb]<=arr[rStart])
                {
                    lst[k] = arr[lb];
                    lb++;
                }
                else
                {
                    lst[k] = arr[rStart];
                    rStart++;
                }
                k++;                
            }

            while (lb <= mid)
            {
                lst[k++] = arr[lb++];
            }

            while (rStart <= ub)
            {
                lst[k++] = arr[rStart++];
            }

            for (int i = start;i<=end;i++)
            {
                arr[i] = lst[i];
            }
        }
    }
}
