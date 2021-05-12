using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Thomson
{
    class ArrayString
    {
        public bool IsAnagram(string s1, string s2)
        {
            ////Option1:
            ///sort both strings and compare both strings.
            ///Option2:
            ///Copy to hashtable and and check contains the letter.
            ///check length first and return if not equal.
            ///Option3:
            ///Copy to characters set and check
            return true;
        }

        public int[] SeggregateEvenOdd(int[] a)
        {
            int i = 0;
            int j = a.Length - 1;
            while (i < j)
            {
                while (a[i] % 2 == 0 && i < j)
                {
                    i++;
                }
                while (a[j] % 2 == 1 && i < j)
                {
                    j--;
                }

                //swap
                if (i < j)
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
            }
            return a;
        }
    }
}
