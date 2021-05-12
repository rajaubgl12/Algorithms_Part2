using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    class TreeTraverrsal
    {
        public static void IOT(TNode node)
        {
            if (node == null)
            {
                return;
            }
            IOT(node.left);
            Console.WriteLine(node.value);
            IOT(node.right);
        }
        public static void POT(TNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.value);
            POT(node.left);
            POT(node.right);
        }
        public static void PST(TNode node)
        {
            if (node == null)
            {
                return;
            }
            PST(node.left);
            PST(node.right);
            Console.WriteLine(node.value);
        }

        #region LevelOrderTraversal
        
        public static int HeightOfTree1(TNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int lHeight = HeightOfTree1(node.left);
                int rHeight = HeightOfTree1(node.right);
                if (lHeight > rHeight)
                    return lHeight + 1;
                else
                    return rHeight + 1;

               
            }
        }

        public class CheckCount
        {
           public int countHeight = 0;
        }
       

      
        public static void PrintLevelOrder1(TNode rootNode)
        {
            int hTree = HeightOfTree1(rootNode);
            for (int i = 1; i <= hTree; i++)
            {
                Lot1(rootNode, i);
            }
        }

        private static void Lot1(TNode rootNode, int i)
        {
            if (rootNode == null)
                return;
            if (i == 1)
            {
                Console.WriteLine(rootNode.value);
            }
            else
            {
                Lot1(rootNode.left, i - 1);
                Lot1(rootNode.right, i - 1);
            }
        }

        public static void PrintLevelOrderUsingQueue(TNode node)
        {
            TNode root = node;
            Queue<TNode> queueNode = new Queue<TNode>();
            queueNode.Enqueue(root);
            Console.WriteLine("==============Level order traversal using queue==============");
            while(queueNode.Count>0)
            {
                TNode nodeTemp = queueNode.Dequeue();
                if (nodeTemp == null)
                    return;
                Console.WriteLine(nodeTemp.value);
                if(nodeTemp!=null)
                {
                    queueNode.Enqueue(nodeTemp.left);
                    queueNode.Enqueue(nodeTemp.right);
                }                
            }
            Console.WriteLine("==============End of Level order traversal using queue==============");
        }
        #endregion

    }
}
