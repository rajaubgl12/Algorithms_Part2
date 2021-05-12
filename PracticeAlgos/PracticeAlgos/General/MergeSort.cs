using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgos.General
{
    public class MergeSort
    {
        public void MergeSortAlg(int [] a)
        {
            int start = 0;
            int end = a.Length - 1;
            MergeSortHelper(a, start, end);
        }

        private void MergeSortHelper(int[] a, int start, int end)
        {
            if (start == end)
                return;
            int mid = (start + end) / 2;

            MergeSortHelper(a, start, mid);
            MergeSortHelper(a, mid+1, end);

            MergeArray(a, start, mid, end);
        }

        private void MergeArray(int[] a, int start, int mid, int end)
        {
            int a1Start = start;
            int a1End = mid;

            int a2Start = mid + 1;
            int a2End = end;

            while (a1Start <= a1End && a2Start <= a2End)
            {
                if(a[a1Start]>a[a2Start])
                {
                    int temp = a[a1Start];
                    a[a1Start] = a[a2Start];
                    a[a2Start] = temp;
                    a2Start++;
                }
                else if((a[a1Start] == a[a2Start]))
                {
                    a1Start++;
                    a2Start++;
                }
                else
                {
                   
                    a1Start++;
                }
            }

            while (a1Start < a1End && a1Start <a.Length && a1End<a.Length)
            {
                if (a[a1Start] > a[a1End])
                {
                    int temp = a[a1Start];
                    a[a1Start] = a[a1End];
                    a[a1End] = temp;
                    a1End++;
                }
                else if ((a[a1Start] == a[a1End]))
                {
                    a1Start++;
                    a1End++;
                }
                else
                {

                    a1Start++;
                }
            }
            while (a2Start < a2End && a2Start < a.Length &&a2End<a.Length)
            {
                if (a[a2Start] > a[a2End])
                {
                    int temp = a[a2Start];
                    a[a2Start] = a[a2End];
                    a[a2End] = temp;
                    a2End++;
                }
                else if ((a[a2Start] == a[a2End]))
                {
                    a2Start++;
                    a2End++;
                }
                else
                {
                    a2Start++;
                }
            }
        }

        public int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            int left = 0;
            int right = nums.Length - 1;
            if (nums[right] > nums[0])
            {
                return nums[0];
            }
            while (right >= left)
            {
                int mid = (left + right) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    return nums[mid + 1];
                }
                if (nums[mid] < nums[mid - 1])
                {
                    return nums[mid];
                }
                if (nums[mid] > nums[0])
                {

                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;


        }

        public int FindCelebrity(int n)
        {            

            SortedList<int, int> srtdLst = new SortedList<int, int>();
            bool iknowsj = true;
            for(int i=0;i<n;i++)
                for(int j=0;j<n;j++)
                {
                    if (i == j)
                        continue;
                    if(iknowsj)
                    {
                        if(srtdLst.ContainsKey(j))
                        {
                            srtdLst[j]++;
                        }
                        else
                        {
                            srtdLst.Add(j, 1);
                        }
                        iknowsj = false;

                    }
                }

            return srtdLst[srtdLst.Values[0]] >0? srtdLst.Values[0]:-1;
        }

        public int MinValue = int.MaxValue;
        public string RemoveKdigits(string num, int k)
        {
            int min = int.MaxValue;
            string temp = "";
            int index = 0;
            RemoveHelper(num.ToArray(), index, temp, k, min);
            return min.ToString();
        }
        private void RemoveHelper(char[] num, int index, string temp, int k, int min)
        {
            if (index >= num.Length)
                return;
            if (temp.Length == num.Length - k)
            {
                min = Math.Min(min, Convert.ToInt32(temp.Trim()));
                MinValue = Math.Min(min, MinValue);
                return;
            }

            RemoveHelper(num, index + 1, temp + num[index].ToString(), k, min);
            RemoveHelper(num, index + 1, temp, k, min);

        }
    }
}
