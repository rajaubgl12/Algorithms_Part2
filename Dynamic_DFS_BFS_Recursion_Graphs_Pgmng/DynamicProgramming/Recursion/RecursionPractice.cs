using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProramming.Recursion
{
   public class RecursionPractice
    {
        public int CountNum(int num)
        {
            //base condition
            int count = 0;
            while(num>0)
            {
                num = num / 10;
                count++;
            }
            return count;
        }

        public int CountNumRecursive(int num)
        {
            if (num <= 0)
                return 0;
            return 1 + CountNumRecursive(num / 10);
        }

        public int LengthOfLinkedList(ListNode node)
        {
            int count = 0;
            while(node!=null)
            {
                node = node.next;
                count++;
            }

            return count;
        }

        public int LengthOfLinkedListRecursive(ListNode node)
        {
            if (node == null)
                return 0;
            if (node.next == null)
                return 1;

            return 1 + LengthOfLinkedListRecursive(node.next);
        }

        public int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        public string Reverse(string s, int len)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;

            return s[len] + Reverse(s.Substring(0,len),len-1);
        }

        public int TotalVowels(string str, int len)
        {
            int count = 0;
            if (len < 0)
                return 0;

            if(str[len]=='A' || str[len] == 'E' || str[len] == 'I' || str[len] == 'O' || str[len] == 'U')
            {
                count++;
                
            }

            return count + TotalVowels(str, len - 1);
        }

    }
}
