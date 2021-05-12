using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    class FindMiddleElement
    {
        /// <summary>
        /// use 2 pointers one is slow and other is fast
        /// when fast become null then slow would have reached the middle.
        /// </summary>
        /// <param name="node"></param>
        public void GetMiddleNode(ListNode node)
        {
            ListNode slowPtr = node;
            ListNode fastPtr = node;
            while (fastPtr != null&&fastPtr.next!=null)
            {
                fastPtr = fastPtr.next.next;
                slowPtr = slowPtr.next;
                
            }
            Console.WriteLine(slowPtr.val);
        }


    }
}
