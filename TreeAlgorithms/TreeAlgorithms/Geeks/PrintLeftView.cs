using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Geeks
{
   public class PrintLeftView
    {
        public void PrintLeftTree1(TNode node)
        {
            Console.WriteLine("===========Printing Left View===========");
            PrintLeftTreeRec(node, true);
            Console.WriteLine("===========End Printing Left View===========");
        }

        private void PrintLeftTreeRec(TNode node, bool v)
        {
            //throw new NotImplementedException();
            if (node == null)
                return;
            if(v)
            {
                
                Console.WriteLine(node.value);
                
            }
            
            PrintLeftTreeRec(node.left, true);
            PrintLeftTreeRec(node.right, false);
        }
    }
}
