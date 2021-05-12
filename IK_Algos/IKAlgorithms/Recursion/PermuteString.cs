using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Recursion
{
    public class PermuteStringAlg
    {
        public List<string> PermuteString(string str)
        {
            List<string> lst = new List<string>();

            PermuteStringHelper(str.ToCharArray(),0,lst);

            return lst;
        }

        private void PermuteStringHelper(char[] arr, int index, List<string> lst)
        {
            if(index==arr.Length-1)
            {
                lst.Add(new string(arr));
                return;
            }

            for(int i=index;i<arr.Length;i++)
            {
                //swap
                char temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;

                PermuteStringHelper(arr, index + 1, lst);

                //swap
                char temp2 = arr[i];
                arr[i] = arr[index];
                arr[index] = temp2;
            }
        }
    }
}