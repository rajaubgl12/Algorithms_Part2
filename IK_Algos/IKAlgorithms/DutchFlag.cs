using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
   public  class DutchFlag
    {
        public static void dutch_flag_sort(List<char> balls)
        {
            
            char R = 'R';
            char G = 'G';
            char B = 'B';
            int i = 0;
            int j = balls.Count - 1;
            int index = 0;
            int greenCount = 0;
            while(i<j && index<j)
            {
                if(balls[index]=='R')
                {
                    balls[i] = 'R';
                    i++;
                }
                else if (balls[index] == 'B')
                {
                    balls[j] = 'B';
                    j--;
                }
                index++;
            }

            while (i == j)
            {
                balls[i] = 'G';
                i++;
                
            }
        }

       public static void Sort(List<char> balls)
        {
            
            int left = 0;
            int right = balls.Count - 1;
            int mid = 0;
            char temp = ' ';
            
            while (mid <= right)
            {
                switch (balls[mid])
                {
                    case 'R':
                        {
                            temp = balls[left];
                            balls[left] = balls[mid];
                            balls[mid] = temp;
                            left++;
                            mid++;
                            break;
                        }
                    case 'G':
                        mid++;
                        break;
                    case 'B':
                        {
                            temp = balls[mid];
                            balls[mid] = balls[right];
                            balls[right] = temp;
                            right--;
                            break;
                        }
                }
            }
        }

        public static void merger_first_into_second(int[] arr1, int[] arr2)
        {
            int i = arr2.Length - 1, j = arr1.Length - 1, k = i + j - 1;
            while (i >= 0 && j >= 0)
            {
                if (arr2[i] > arr1[j])
                {
                    arr2[k] = arr2[i];
                    i--;
                }
                else
                {
                    arr2[k] = arr1[j];
                    j--;
                }
                k--;
            }
            while (k >= 0 && j >= 0)
            {
                arr2[k] = arr1[j];
                j--;
                k--;
            }

        }
    }
}
