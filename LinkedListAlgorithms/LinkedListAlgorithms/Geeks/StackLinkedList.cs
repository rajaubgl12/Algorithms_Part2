using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    /// <summary>
    /// insert node at front
    /// 4->3->2->1->null
    /// usual insertion will be 1->2->3->4->null
    /// </summary>
    public class StackLinkedList
    {
        ListNode front;
        ListNode top;
        public StackLinkedList()
        {
            front = top = null;
        }
        public void push(int data)
        {
            if(top==null)
            {
                ListNode temp = new ListNode(data);
                front = top = temp;
            }
            else
            {
                ListNode temp2 = new ListNode(data);
                temp2.next = top;
                top = temp2;
                //top.next = new ListNode(data);
                //top = top.next;
            }
        }

        public ListNode Pop()
        {
            if (top == null)
                return null;
            else
            {
                ListNode remvNode = top;
                top = top.next;
                return remvNode;
            }
        }
    }
}
