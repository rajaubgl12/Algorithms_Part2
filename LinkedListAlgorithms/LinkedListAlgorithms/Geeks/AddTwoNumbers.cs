using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

    /*You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        Example:
        Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        Explanation: 342 + 465 = 807.
    */
    /// </summary>
    class AddTwoNumbersLList
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode nodeResult = new ListNode(0);
            int carry = 0;
            while (l1 != null && l2 != null)
            {
                int a = l1.val;
                int b = l2.val;                
                int sum = a + b + carry;
                carry = sum / 10;
                nodeResult.next = new ListNode(sum % 10);
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if (carry > 0)
                nodeResult.next = new ListNode(carry);
            return nodeResult;
        }
        
    }
}
