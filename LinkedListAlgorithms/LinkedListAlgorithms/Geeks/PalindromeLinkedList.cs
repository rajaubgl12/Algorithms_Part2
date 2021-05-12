using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    class PalindromeLinkedList
    {
        public bool IsPalindrome(ListNode head)
        {

            ListNode slowPtr = head, fastPtr = head;
            while (fastPtr != null && fastPtr.next != null)
            {
                slowPtr = slowPtr.next;
                fastPtr = fastPtr.next.next;
            }

            ListNode middle = Reverse(slowPtr);

            while (middle != null && head != null)
            {
                if (head.val != middle.val)
                    return false;
                head = head.next;
                middle = middle.next;
            }
            return true;

        }
        public ListNode Reverse(ListNode head)
        {
            ListNode prev = null, next = null, curr = head;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
    }
}
