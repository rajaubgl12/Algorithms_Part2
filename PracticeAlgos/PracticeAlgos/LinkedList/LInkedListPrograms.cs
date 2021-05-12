using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgos.LinkedList
{
    class LInkedListPrograms
    {
        public LinkedList RevLinkedList(LinkedList node)
        {
            LinkedList currNode = node;
            LinkedList nextNode = null;
            LinkedList prevNode = null;
            while(currNode!=null)
            {
                nextNode = currNode.next;
                currNode.next = prevNode;
                prevNode = currNode;
                currNode = nextNode;

            }
            return prevNode;
        }

        public LinkedList RevLinkedListInGroup(LinkedList head, int k)
        {
            LinkedList curNode = head;
            LinkedList next = null;
            LinkedList prev = null;
            int count = 0;

            //Reverse first K group of linked list
            while (count< k && curNode != null)
            {
                next = curNode.next;
                curNode.next = prev;
                prev = curNode;
                curNode = next;
                count++;
            }

            /*next is now a pointer to (k+1)th node  
             Recursively call for the list starting from current.  
             And make rest of the list as next of first node */
            if (next != null)
                head.next = RevLinkedListInGroup(next, k);
            // prev is now head of input list  
            return prev;
        }
        public LinkedList reverse(LinkedList head, int k)
        {
            LinkedList current = head;
            LinkedList next = null;
            LinkedList prev = null;

            int count = 0;

            /* Reverse first k nodes of linked list */
            while (count < k && current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                count++;
            }

            /* next is now a pointer to (k+1)th node  
                Recursively call for the list starting from current.  
                And make rest of the list as next of first node */
            if (next != null)
                head.next = reverse(next, k);

            // prev is now head of input list  
            return prev;
        }

    }
}
