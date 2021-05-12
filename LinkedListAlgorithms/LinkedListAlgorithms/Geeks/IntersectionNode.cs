using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    class IntersectionNode
    {
        /// <summary>
        /// Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,0,1,8,4,5], skipA = 2, skipB = 3
        //Output: Reference of the node with value = 8
        //Input Explanation: The intersected node's value is 8 (note that this must not be 0 if the two 
        //lists intersect). From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads 
        //as [5,0,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before 
        //the intersected node in B. Detect a loop
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            if (headA == null || headB == null) return null;
            var nodeA = headA;
            var nodeB = headB;

            while (nodeA != null || nodeB != null)
            {
                if (nodeA == nodeB) return nodeA;
                nodeA = nodeA != null ? nodeA.next : headB;
                nodeB = nodeB != null ? nodeB.next : headA;
            }
            return null;

        }

    }
}
