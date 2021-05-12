using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    public class RemoveLoop
    {
        public void DetectLoopAndRemove(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    //Remove Loop
                    //move one ptr to begining of the list
                    slow = head;
                    while(slow.next!=fast.next)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }
                    //fast.next is the looping point so make fast.next to point to null, its removing the loop.
                    fast.next = null;
                }
            }
            
        }
    }
}
