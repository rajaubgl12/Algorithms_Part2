using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{

    /// <summary>
    /// 1->2->3->4->5->6->7->null
    /// null<-1<-2<-3<-4<-5<-6<-7
    /// </summary>
    class RevLinkedListLList
    {
        public ListNode ReverseList(ListNode head)
        {
            //check base cases
            if (head == null)
                return null;

            //ListNode listNode = head;

            ListNode currNode = head;
            ListNode prevNode = null;
            ListNode nextNode = null;
            while(currNode != null)
            {
                nextNode = currNode.next;
                currNode.next = prevNode;
                prevNode = currNode;
                currNode = nextNode;                
            }
            head = prevNode;
            return head;
        }

        private ListNode pReverseHead;
        public ListNode ReverseList2(ListNode head)
        {

            if (head == null)
                return pReverseHead;

            if (pReverseHead == null)
            {
                pReverseHead = head;
                head = head.next;
                pReverseHead.next = null;
            }
            else
            {
                ListNode tmp = head.next;
                head.next = pReverseHead;
                pReverseHead = head;
                head = tmp;
            }
            return ReverseList2(head);
        }

    }
}
