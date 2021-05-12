using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TreeAlgorithms.Stacks_Queues
{
    public class QueueImpl
    {
        private static int maxSize = 0;
        public QueueImpl(int size)
        {
            maxSize = size;
        }
        int[] queueArray = new int[maxSize];
        private int front = 0;
        private int rear = 0;
        public void Enqueue(int data)
        {
            if(rear>=maxSize)
            {
                throw new Exception();
            }
            queueArray[rear++] = data;
        }
        public int Dequeue()
        {
            if (front >= maxSize)
            {
                throw new Exception();
            }
            return queueArray[front++];
        }
    }

    public class QueueImCircularArray
    {
        static int  maxSize = 0;
        int front = -1;
        int rear = -1;
        int[] queueArray = new int[maxSize];
        public QueueImCircularArray(int size)
        {
            maxSize = size;
        }

        public void Enqueue(int data)
        {
            if(front== -1 && rear==-1)
            {
                front = rear = 0;
                queueArray[front] = data;
                return;
            }
            //check queue is full
            int indexNext = front % maxSize + 1;
            front = indexNext;
            if (front == rear)
            {
                throw new Exception();
            }
            queueArray[front] = data;
            
        }
        public int Dequeue()
        {
            //check queue is empty;
            if(front ==-1&&rear ==-1)
                throw new Exception();
            if (front == rear)
            {
                front = rear = -1;
                return queueArray[rear];
            }
            
            int retData =  queueArray[rear];
            rear = rear % maxSize + 1;
            return retData;
        }
    }

    public class QueueUsing2Stack
    {
        /* class of queue having two stacks */
        public class Queue
        {
            public Stack<int> stack1;
            public Stack<int> stack2;
        }

        /* Function to push an item to stack*/
        static void push(Stack<int> top_ref, int new_data)
        {
            // Push the data onto the stack 
            top_ref.Push(new_data);
        }

        /* Function to pop an item from stack*/
        static int pop(Stack<int> top_ref)
        {
            /*If stack is empty then error */
            if (top_ref.Count == 0)
            {
                Console.WriteLine("Stack Underflow");
                Environment.Exit(0);
            }

            // pop the data from the stack 
            return top_ref.Pop();
        }

        // Function to enqueue an item to the queue 
        static void enQueue(Queue q, int x)
        {
            push(q.stack1, x);
        }

        /* Function to deQueue an item from queue */
        static int deQueue(Queue q)
        {
            int x;

            /* If both stacks are empty then error */
            if (q.stack1.Count == 0 && q.stack2.Count == 0)
            {
                Console.WriteLine("Q is empty");
                Environment.Exit(0);
            }

            /* Move elements from stack1 to stack 2 only if 
            stack2 is empty */
            if (q.stack2.Count == 0)
            {
                while (q.stack1.Count != 0)
                {
                    x = pop(q.stack1);
                    push(q.stack2, x);
                }
            }
            x = pop(q.stack2);
            return x;
        }
    }

    public class QueueUsing1Stack
    {
        private static int maxSize =0;
        private Stack<int> st;
        public QueueUsing1Stack(int size)
        {
            maxSize = size;
            st = new Stack<int>(maxSize);
        }

        public void Enqueue(int data)
        {
            //check for overflow
            if (st.Count == maxSize)
                 throw new OverflowException();
            st.Push(data);
        }

        public int Dequeue()
        {
            int xPop = 0;
            int retDeq = 0;

            //check for underflow
            if (st.Count == 1)
                return st.Pop();

            xPop = st.Pop();
            retDeq =  Dequeue();
            st.Push(xPop);

            return retDeq;
        }
    }
}
