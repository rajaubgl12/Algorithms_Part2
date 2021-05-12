using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
   public class QueueLinkedList
    {
        ListNode start;
        ListNode end;
        public QueueLinkedList()
        {
            //start = new ListNode(0);
            end = start;
        }
        public void Enqueue(int data)
        {
            //start.next = new ListNode(data);
            //start = start.next;
            if (start == null)
            {
                start = new ListNode(data);
               end = start;
            }
               
            else
            {
                start.next = new ListNode(data);
                start = start.next;
            }
            //end = start;
        }
        public int Dequeue()
        {
            if(end!=null)
            {
                int data= end.val;
                end = end.next;
                start = end;
                return data;
            }
            else
            {
                return -1;   
            }
        }
    }
}
