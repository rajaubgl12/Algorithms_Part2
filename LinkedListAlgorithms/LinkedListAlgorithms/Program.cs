using LinkedListAlgorithms.Amazon;
using LinkedListAlgorithms.Geeks;
using LinkedListAlgorithms.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            #region playground
            HashSet<char> strVal = new HashSet<char>("ABCC");
            int len = strVal.Count;
            #endregion

            #region Amazon
            #endregion

            #region Google
            #endregion

            #region Facebook
            #endregion

            #region Microsoft
            LinkedListPgms();
            #endregion

            #region Geeks
            //FindMiddleNodeMain();
            SwapKthElementsMain();
            #endregion

            #region General
            #endregion
        }

       

        #region Amazon
        private static void AddNumbersListMain()
        {
            AmznLinkedList lcList = new AmznLinkedList();
            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);
            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);
            ListNode res = lcList.AddTwoNumbers(l1, l2);
        }
        #endregion

        #region Google
        #endregion

        #region Facebook
        #endregion

        #region Microsoft

        private static void LinkedListPgms()
        {
            ListNode l1 = new ListNode(7);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);
            l1.next.next.next = new ListNode(3);

            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);

            AddNumber2 add = new AddNumber2();

            add.AddTwoNumbers(l1, l2);


        }
        #endregion

        #region Geeks
        #region LinkedList
        private static void FindMiddleNodeMain()
        {
            FindMiddleElement find = new FindMiddleElement();
            ListNode listNode = new ListNode(1);
            listNode.next = new ListNode(2);
            listNode.next.next = new ListNode(3);
            listNode.next.next.next = new ListNode(4);
            listNode.next.next.next.next = new ListNode(5);
            listNode.next.next.next.next.next = new ListNode(6);
            find.GetMiddleNode(listNode);
        }

        private static void ReverseLinkedListMain()
        {
            RevLinkedListLList revLst = new RevLinkedListLList();

            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            ListNode res = revLst.ReverseList(l1);
        }
        private static void AddNumbersLinkedListMain()
        {
            AddTwoNumbersLList revLst = new AddTwoNumbersLList();

            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            ListNode l2 = new ListNode(4);
            l2.next = new ListNode(5);
            l2.next.next = new ListNode(6);
            ListNode res = revLst.AddTwoNumbers(l1, l2);
        }
        private static void RemoveNthFromEndMain()
        {
            RemoveNthFromEndCls remN = new RemoveNthFromEndCls();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            l1.next.next.next.next = new ListNode(5);
            ListNode res = remN.RemoveNthFromEnd(l1, 2);
        }
        private static void IntersectionNodeMain()
        {
            IntersectionNode remN = new IntersectionNode();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(6);
            ListNode l2 = new ListNode(4);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(6);
            ListNode res = remN.GetIntersectionNode(l1, l2);
        }

        #region geeksforgeeks
        private static void DetectAndRemoveLoopMain()
        {
            ListNode list = new ListNode(50);
            list.next = new ListNode(20);
            list.next.next = new ListNode(15);
            list.next.next.next = new ListNode(4);
            list.next.next.next.next = new ListNode(10);


            // Creating a loop for testing  
            list.next.next.next.next.next = list.next.next;

            RemoveLoop remLp = new RemoveLoop();
            remLp.DetectLoopAndRemove(list);
        }
        private static void MergeLinkedListMain()
        {
            MergeLinkedList remN = new MergeLinkedList();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(6);
            ListNode l2 = new ListNode(4);
            l2.next = new ListNode(5);
            l2.next.next = new ListNode(7);
            ListNode res = remN.MergeTwoLists(l1, l2);
        }
        private static void SwapKthElementsMain()
        {
            PairwiseSwapList remN = new PairwiseSwapList();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            l1.next.next.next.next = new ListNode(5);
            l1.next.next.next.next.next = new ListNode(6);

            //ListNode res1 = remN.PairwiseSwap(l1);
            ListNode res = remN.ReverseInGroups(l1, 2);
        }
        private static void IsPalindromeListMain()
        {
            PalindromeLinkedList remN = new PalindromeLinkedList();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(1);
            l1.next.next.next = new ListNode(1);
            l1.next.next.next.next = new ListNode(2);
            l1.next.next.next.next.next = new ListNode(1);

            //ListNode res = remN.PairwiseSwap(l1);
            bool isPalindrome = remN.IsPalindrome(l1);
        }
        private static void QueueUsingArrayMain()
        {
            QueueArray queueArray = new QueueArray(5);
            queueArray.Enqueue(1);
            queueArray.Enqueue(2);
            queueArray.Enqueue(3);
            queueArray.Enqueue(4);
            queueArray.Enqueue(5);

            int deqItem = queueArray.Dequeue();
            int deqItem2 = queueArray.Dequeue();
        }
        private static void StackUsingArrayMain()
        {
            StackUsngArray stackUsngArray = new StackUsngArray(6);
            stackUsngArray.Push(1);
            stackUsngArray.Push(2);
            stackUsngArray.Push(3);
            stackUsngArray.Push(4);
            stackUsngArray.Push(5);
            stackUsngArray.Push(6);
            int lifo = stackUsngArray.Pop();
        }
        private static void QueueUsingLinkedList()
        {
            QueueLinkedList q = new QueueLinkedList();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Dequeue();
            q.Dequeue();
            q.Enqueue(30);
            q.Enqueue(40);
            q.Enqueue(50);

            Console.WriteLine("Dequeued item is " +
                                q.Dequeue());
        }
        private static void StackUsingLinkedListMain()
        {
            StackLinkedList q = new StackLinkedList();
            q.push(10);
            q.push(20);
            q.Pop();
            q.Pop();
            q.push(30);
            q.push(40);
            q.push(50);
            q.Pop();
            Console.WriteLine("Dequeued item is " +
                                q.Pop().val);
        }
        #endregion
        #endregion
        #endregion

        #region General
        #endregion
    }
}
