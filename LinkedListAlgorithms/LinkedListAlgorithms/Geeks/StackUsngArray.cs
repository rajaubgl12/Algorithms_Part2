using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{
    class StackUsngArray
    {
        public int Size = 0;
        int[] a;
        int top = 0;
        
        public StackUsngArray(int size)
        {
            Size = size;
            a = new int[Size];
        }

        public void Push(int data)
        {
            if(top > Size)
            {
                throw new StackOverflowException();
            }
            else
            {
                a[top] = data;
                top++;
               
            }            
        }
        public int Pop()
        {
            if (top < 0)
            {
                throw new Exception("empty data");
            }
            else
            {
                int item =  a[top];
                top--;
                return item;
            }
        }
    }
}
