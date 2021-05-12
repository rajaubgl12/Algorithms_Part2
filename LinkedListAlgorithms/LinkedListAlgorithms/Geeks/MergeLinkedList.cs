using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    class MergeLinkedList
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //create a new list with the length biggest of l1 and l2.

            ListNode tmp = new ListNode(0);
            ListNode result = tmp;
            while(l1!=null&&l2!=null)
            {
                if(l1.val>l2.val)
                {
                    tmp.next = new ListNode(l2.val);
                    
                    l2 = l2.next;
                }
                else
                {
                    tmp.next = new ListNode(l1.val);
                    l1 = l1.next;
                }
                tmp = tmp.next;
            }

            if(l1!=null)
            {
                tmp.next = l1;
            }
            if (l2 != null)
            {
                tmp.next = l2;
            }
            return result.next;
        }
    }
}
