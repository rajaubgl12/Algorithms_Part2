using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    
    class Lc_Amzn_LinkedList
    {
        /// <summary>
        /// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        //Output: 7 -> 0 -> 8
        //Explanation: 342 + 465 = 807.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode current = result; // pointer to the address of the result
            int carry = 0;
            ListNode list1 = l1;
            ListNode list2 = l2;
            while (list1 != null || list2 != null)
            {
                int p = list1 != null ? list1.val : 0;
                int q = list2 != null ? list2.val : 0;

                int sum = p + q + carry;
                carry = sum / 10;
                current.next = new ListNode(sum % 10); // create node with value = sum 
                current = current.next; //current contains the address of the next node

                if (list1 != null)
                    list1 = list1.next;

                if (list2 != null)
                    list2 = list2.next;
            }
            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }
            return result.next;
        }

        public ListNode AppendNewNodeAtEnd(int new_data)
        {
            ListNode newNodeLast = new ListNode(new_data);
            newNodeLast.next = null;
            if (newNodeLast == null)
            {
                newNodeLast.next = newNodeLast;
                return newNodeLast;
            }

            ListNode last = newNodeLast;
            while (last.next != null)
            {
                last = last.next;
            }
            last.next = newNodeLast;
            return newNodeLast;
        }

        public long ReturnNumFromList(ListNode listNode)
        {
            StringBuilder sb = new StringBuilder();
            while (listNode != null)
            {
                sb.Append(listNode.val);
                listNode = listNode.next;
            }
            string firstNumbers = new string(sb.ToString().Reverse().ToArray());
            long num = Convert.ToInt64(firstNumbers);
            sb.Clear();

            return num;
        }

    }
}