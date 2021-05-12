using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{

    /// <summary>
    /// 
    /// /*
    /// 
    /*Given linked list: 1->2->3->4->5, and n = 2.
      After removing the second node from the end, the linked list becomes 1->2->3->5.
     */
    /// </summary>
    class RemoveNthFromEndCls
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
                return null;
            ListNode fast = head;
            ListNode slow = head;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            //if remove the first node
            if (fast == null)
            {
                head = head.next;
                return head;
            }
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            return head;

        }
    }
}
