using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    class QueueArray
    {
        int capacity = 0;
        int rear = 0;
        int first = 0;
        int[] a;
        public QueueArray(int size)
        {
            first = rear = 0;
            capacity = size;
            a = new int[capacity];
        }

        private bool IsFull()
        {
            if (rear == capacity)
                return true;
            else
                return false;
        }
        private bool IsEmpty()
        {
            if (rear == first)
                return true;
            else
                return false;
        }
        public void Enqueue(int data)
        {
            if (!IsFull())
            {
                a[rear] = data;
                rear++;
            }
            else
                throw new Exception("Queue is full");
        }
        public int Dequeue()
        {
            if (!IsEmpty())
            {

                int fifoItem = a[first];
                a[first] = 0;
                first++;
                return fifoItem;
            }                
            else
                throw new Exception("Queue is empty");
        }
    }
}
