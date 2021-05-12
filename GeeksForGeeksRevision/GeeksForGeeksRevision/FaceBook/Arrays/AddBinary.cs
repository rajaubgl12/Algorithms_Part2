using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
    /// <summary>
    /// /*
    /// two binary strings, return their sum (also a binary string).
   /*
    *The input strings are both non-empty and contains only characters 1 or 0.
     Example 1:
     Input: a = "11", b = "1"
     Output: "100"
        Example 2:
        Input: a = "1010", b = "1011"
        Output: "10101"

         Logic:
        a)	Loop through the one array after ending small array it will just add zero to the sum
        b)	Have the carry initialized to zero
        c)	Add the digits from last index
        d)	A+b+carry
        e)	Carry = 1 if result is >1
        f)	If we add binary the possible values can be either 0,1,2,3.  The modulus of the number will be 1 for the number 3,   for the number 2 its zero.Less than 2 is the number itself.
        g)  Add the result into stringbuilder.sb.Insert(0, 1);method not append.
        */

    /// */
    /// </summary>
    public class AddBinaryCls
    {
        public string AddBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();
            int indexA = a.Length - 1;
            int indexB = b.Length - 1;

            bool isPlusOne = false;
            while (indexA >= 0 || indexB >= 0)
            {
                int nA = indexA >= 0 ? (a[indexA] == '0' ? 0 : 1) : 0;
                int nB = indexB >= 0 ? (b[indexB] == '0' ? 0 : 1) : 0;

                int n = nA + nB + (isPlusOne ? 1 : 0);

                isPlusOne = n >= 2;

                sb.Insert(0, n % 2);

                indexA--;
                indexB--;
            }

            if (isPlusOne)
                sb.Insert(0, 1);

            return sb.ToString();

        }
    }
}
