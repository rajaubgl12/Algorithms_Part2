using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Stacks_Queues
{
    /// <summary>
    /// 
    /// </summary>
    public class StackImplUsingArray
    {
        private static int max = 0;
        public StackImplUsingArray(int size)
        {
            max = size;
        }

        int[] stackArray = new int[max];
        int top = -1;
        
        public void Push(int data)
        {
            //check overflow
            if (top >= max)
            {
                throw new StackOverflowException();
            }
            //push the data
            stackArray[++top] = data;
        }

        public int Pop()
        {
            //check overflow
            if (top <= -1)
            {
                throw new Exception();
            }
            return stackArray[top--];
        }


    }

    /// <summary>
    /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
    /// if currMin is less the push value , keep CurrMin as it is and push the value to stack
    /// if CurrMin is greater the push the difference value and keep the min in CurrMin.
    /// 
    /// While poping the value , if the pop value is less than currMin,difference with currMin -(pop value)  
    /// </summary>
    public class MinStack
    {
        private Stack<int> _stk;
        private int minSofar = int.MaxValue;
        /** initialize your data structure here. */
        public MinStack()
        {
            _stk = new Stack<int>();
        }

        public void Push(int x)
        {
            if (_stk.Count == 0)
            {
                _stk.Push(x);
                minSofar = x;
                return;
            }
                

            if(x>minSofar)
            {
                _stk.Push(x);
            }
            else
            {
                _stk.Push(x - minSofar);
                minSofar = x;
            }
        }

        public void Pop()
        {
            int popVal = _stk.Pop();
            if (popVal<minSofar)
            {
                //return minsofar and then update minsofar with next min value
                minSofar = minSofar - popVal;
            }
            else
            {
                //return popval
            }
        }

        public int Top()
        {
            return _stk.Peek();
        }

        public int GetMin()
        {
            return minSofar;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
