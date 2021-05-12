using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Microsoft
{
    public class AddNumber2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
           l1 = ReverseLinkedList(l1);
           l2 = ReverseLinkedList(l2);

           ListNode res = new ListNode(0);
            ListNode currSum = res;
            int carry = 0;
            while(l1!=null || l2!=null)
            {
                int a = l1 != null ? l1.val : 0;
                int b = l2 != null ? l2.val : 0;

                int sum = a + b + carry;

                carry = sum > 9 ? 1 : 0;

                currSum.next = new ListNode(sum % 10);

                currSum = currSum.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (carry > 0)
                currSum.next = new ListNode(carry);

            return res.next;
        }

        private ListNode ReverseLinkedList(ListNode l)
        {
            ListNode curr = l;
            ListNode prev = null;
            while (curr!=null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }
    }
}
