using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook
{
   public class Interval
    {
        public int start;
        public int end;
        public Interval(int pStart, int pEnd)
        {
            start = pStart;
            end = pEnd;
        }
        public Interval()
        {
            start = 0;
            end = 0;
        }
    }
   public class LC_FaceBk_SortingSearch
    {
        //Search in Rotated Sorted Array
        //The idea is to find out the rotating point (index newStart)
        //then use newStart as starting point
        //and newStart + nums.Length - 1 as ending point to do log(n) search.
        
            public int Search(int[] nums, int target)
            {
                int begin = 0, end = nums.Length - 1;
                int len = nums.Length;
                int newStart;

                //1. Loop to find out rotating point newStart
                while (begin < end)
                {
                    if (nums[(begin + end) / 2] < nums[len - 1])
                        end = (begin + end) / 2;
                    else if (nums[(begin + end) / 2] > nums[len - 1])
                        begin = (begin + end + 1) / 2;
                }
                newStart = nums[begin] < nums[len - 1] ? begin : end;

                //2. Loop to find out target value from newStart
                //    if the index is larger than nums.Length then subtract nums.Length to get the real index
                begin = newStart;
                end = newStart + len - 1;
                while (begin < end)
                {
                    int mid = (begin + end) / 2 > len - 1 ? ((begin + end) / 2 - len) : (begin + end) / 2;
                    if (nums[mid] > target)
                        end = (begin + end) / 2;
                    else if (nums[mid] < target)
                        begin = (begin + end + 1) / 2;
                    else
                        return mid;
                }

                if (end > len - 1) end -= len;
                return nums[end] == target ? end : -1;

            }
        

        public void MergeSortedArray(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length;
            int len2 = nums2.Length;
            int[] mergeArr = new int[len1+len2];
            int l1 = 0; int l2 = 0;
            int m = 0;
            while(l1<len1&&l2<len2)
            {
                if(nums1[l1]<nums2[l2])
                {
                    mergeArr[m] = nums1[l1];
                    m++; l1++;
                }
                else
                {
                    mergeArr[m] = nums2[l2];
                    m++;l2++;
                }
            }
            if(len1<len2)
            {
                for(int i =l2;i<len2;i++)
                {
                    mergeArr[m] = nums2[i];
                    m++;
                }
            }
            else
            {
                for (int i = l1; i < len1; i++)
                {
                    mergeArr[m] = nums1[i];
                    m++;
                }
            }
            
        }
            public int MinMeetingRooms(Interval[] intervals)
        {
            int len = intervals.Length;

            int[] starts = new int[len];
            int[] ends = new int[len];

            for (int i = 0; i < len; i++)
            {
                starts[i] = intervals[i].start;
                ends[i] = intervals[i].end;
            }

            Array.Sort(starts);
            Array.Sort(ends);

            int pStart = 0;
            int pEnd = 0;

            int roomCount = 0;
            int maxRoomCount = 0; // default is 0, so when intervals.Length == 0 we return 0

            while (pStart < len) // by design starts finish earlier than ends.
            {
                if (starts[pStart] < ends[pEnd])
                {
                    roomCount++;
                    maxRoomCount = Math.Max(roomCount, maxRoomCount);
                    pStart++;
                }
                else
                {// starts[pStart] >= ends[pEnd]
                    roomCount--;
                    pEnd++;
                }
            }

            return maxRoomCount;
        }    

        public int FirstBadVersion(int n)
        {
            int first = 1;
            int mid;

            int count = n;
            int step;

            while (count > 0)
            {
                step = count / 2;
                mid = first + step;
                if (!IsBadVersion(mid))
                {
                    first = mid + 1;
                    count -= (step + 1);
                }
                else
                {
                    count = step;
                }
            }

            return first;
        }
        private bool IsBadVersion(int n)
        {
            return true; //new Random()
        }
    }
}
