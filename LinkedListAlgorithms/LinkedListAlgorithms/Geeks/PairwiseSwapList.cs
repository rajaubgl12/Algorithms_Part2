using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    public class PairwiseSwapList
    {
        /// <summary>
        /// 1->2->3->4->5->6->7
        /// 2->1->4->3->6->5->7
        /// 1->4(next.next)
        /// </summary>
        /// <param name="listNode"></param>
        /// <returns></returns>
        public ListNode PairwiseSwap(ListNode listNode)
        {
            //initialize the nodes
            //prev = 1, curr= 2
            ListNode prev = listNode;
            ListNode curr = listNode.next;

            //change the head before proceeding
            //listnode = 2
            listNode = curr;

            while (true)
            {
                //store the node 3 because
                //1->2->3, now 2 will point to 1.
                //next = 3
                ListNode next = curr.next;

                //change the next of curr to prev
                // 2-->1
                curr.next = prev;
                if (next == null || next.next == null)
                {
                    prev.next = next;
                    break;
                }

                //change the next of prev to next to next
                //1-->4 //1 will point to 4 , it's next to next 
                // next.next = 4, prev.next  = 4
                prev.next = next.next;

                //update the prev and curr
                //prev should move to 3 and curr to ->4
                prev = next;
                curr = prev.next;
            }
            return listNode;
        }

        public ListNode ReverseInGroups(ListNode nodeA, int k)
        {
            ListNode curNode = nodeA;
            ListNode next = null;
            ListNode prev = null;
            int count = k;

            //Reverse first K group of linked list
            while (count-- > 0 && curNode != null)
            {
                next = curNode.next;
                curNode.next = prev;
                prev = curNode;
                curNode = next;
            }

            /*next is now a pointer to (k+1)th node  
             Recursively call for the list starting from current.  
             And make rest of the list as next of first node */
            if (next != null)
                nodeA.next = ReverseInGroups(next, k);
            // prev is now head of input list  
            return prev;
        }
    }
}
