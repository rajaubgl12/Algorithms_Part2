using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    /// <summary>
    /// Given a linked list, determine if it has a cycle in it.
    //To represent a cycle in the given linked list, we use an integer pos which represents 
    //the position(0-indexed) in the linked list where tail connects to.If pos is -1, then there is no 
    //cycle in the linked list.
    //Input: head = [3,2,0,-4], pos = 1
    //Output: true
    //Explanation: There is a cycle in the linked list, where tail connects to the second node.
    /// </summary>
    class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }
            return false;
        }
    }
}
