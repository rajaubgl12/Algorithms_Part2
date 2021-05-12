using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    class Sort0s1s2sList
    {
        public void Sort012s(ListNode head)
        {
            // initialise count of 0 1 and 2 as 0 
            int[] count = { 0, 0, 0 };

            ListNode ptr = head;

            /* count total number of '0', '1' and '2' 
            * count[0] will store total number of '0's 
            * count[1] will store total number of '1's 
            * count[2] will store total number of '2's */
            while (ptr != null)
            {
                count[ptr.val]++;
                ptr = ptr.next;
            }

            int i = 0;
            ptr = head;

            /* Let say count[0] = n1, count[1] = n2 and count[2] = n3 
            * now start traversing list from head node, 
            * 1) fill the list with 0, till n1 > 0 
            * 2) fill the list with 1, till n2 > 0 
            * 3) fill the list with 2, till n3 > 0 */
            while (ptr != null)
            {
                if (count[i] == 0)
                    i++;
                else
                {
                    ptr.val = i;
                    --count[i];
                    ptr = ptr.next;
                }
            }
        }
    }
}
