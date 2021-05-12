using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public class TNodeLvl
    {
       public TNodeLvl left;
       public TNodeLvl right;
       public TNodeLvl nextRight;
       public int data;
        public TNodeLvl(int val)
        {
            this.data = val;
        }
    }

    class GeeksForGeeks
    {      

        int maxLevel = 0;
        // head --> Pointer to head node of  
        // created doubly linked list  
        public TNode head;

        // Initialize previously visited node  
        // as NULL. This is static so that the 
        // same value is accessible in all  
        // recursive calls  
        private static TNode prev1 = null;

        // A simple recursive function to  
        // convert a given Binary tree  
        // to Doubly Linked List  
        // root --> Root of Binary Tree 
        public virtual void BinaryTree2DoubleLinkedList(TNode root)
        {
            // Base case  
            if (root == null)
            {
                return;
            }

            // Recursively convert left subtree  
            BinaryTree2DoubleLinkedList(root.left);

            // Now convert this node  
            if (prev1 == null)
            {
                head = root;
            }
            else
            {
                root.left = prev1;
                prev1.right = root;
            }
            prev1 = root;

            // Finally convert right subtree  
            BinaryTree2DoubleLinkedList(root.right);
        }

        public int LeastCommonAncestorNode(TNode node, int n1, int n2)
        {
            if (node == null)
                return -1;
            if(node.value>n1&&node.value>n2)
            {
                LeastCommonAncestorNode(node.left, n1, n2);
            }
            if (node.value < n1 && node.value < n2)
            {
                LeastCommonAncestorNode(node.right, n1, n2);
            }
            return node.value;
        }

        public void ConnectNodesSameLevel(TNodeLvl node)
        {
            Queue<TNodeLvl> q = new Queue<TNodeLvl>();
            q.Enqueue(node);

            // null marker to represent end of current level  
            q.Enqueue(null);

            // Do Level order of tree using NULL markers  
            while (q.Count != 0)
            {
                TNodeLvl p = q.Peek();
                q.Dequeue();
                if (p != null)
                {

                    // next element in queue represents next  
                    // node at current Level  
                    p.nextRight = q.Peek();

                    // push left and right children of current  
                    // node  
                    if (p.left != null)
                        q.Enqueue(p.left);
                    if (p.right != null)
                        q.Enqueue(p.right);
                }

                // if queue is not empty, push NULL to mark  
                // nodes at this level are visited  
                else if (q.Count != 0)
                    q.Enqueue(null);
            }
        }

        public void PrintSpralUsingStack(TNode node)
        {
            Stack<TNode> sLeft = new Stack<TNode>();
            Stack<TNode> sRight = new Stack<TNode>();
            sLeft.Push(node);
            while(sLeft.Count>0||sRight.Count>0)
            {
                while(sLeft.Count>0)
                {
                    TNode tempNode = sLeft.Peek();
                    sLeft.Pop();
                    Console.Write(tempNode.value);
                    if(tempNode.right!=null)
                    {
                        sRight.Push(tempNode.right);                        
                    }
                    if(tempNode.left!=null)
                    {
                        sRight.Push(tempNode.left);
                    }
                }
                while (sRight.Count > 0)
                {
                    TNode tempNode = sRight.Peek();
                    sRight.Pop();
                    Console.Write(tempNode.value);
                    if (tempNode.left != null)
                    {
                        sLeft.Push(tempNode.left);                       
                    }
                    if (tempNode.right != null)
                    {
                        sLeft.Push(tempNode.right);
                    }
                }
            }
        }

        public void PrintNodesSpiral(TNode node)
        {
            int heightTree = Treeheight(node);
            bool printLeftRight = false;
            for(int i=1;i<=heightTree;i++)
            {                
                LOTSpiral(node, i,printLeftRight);
                printLeftRight = !printLeftRight;
            }
        }

        private void LOTSpiral(TNode node, int nodeLevel, bool printLeftRight)
        {
            if (node == null)
                return;
            if(nodeLevel==1)
            {
                Console.Write(node.value);
            }
            else if(nodeLevel>1)
            {
                if(printLeftRight != false)
                {
                    LOTSpiral(node.left, nodeLevel - 1, printLeftRight);
                    LOTSpiral(node.right, nodeLevel - 1, printLeftRight);
                }
                else
                {
                    LOTSpiral(node.right, nodeLevel - 1, printLeftRight);
                    LOTSpiral(node.left, nodeLevel - 1, printLeftRight);
                }
            }
        }

        private int Treeheight(TNode node)
        {
            if (node == null)
                return 0;
            int lHeight = Treeheight(node.left);
            int rHeight = Treeheight(node.right);
            if(lHeight>rHeight)
            {
                return lHeight+1;
            }
            else
            {
                return rHeight + 1;
            }
        }

        Dictionary<int, IList<int>> dictVertOrd = new Dictionary<int, IList<int>>();

        public void PrintVerticalTreeNodeUsingPreOrder(TNode node)
        {
            int hd = 0;
            PVO(node, hd);
            foreach(KeyValuePair<int,IList<int>>  keyValuePair in dictVertOrd)
            {
                //Console.WriteLine(keyValuePair.Key);
                Console.WriteLine();
                foreach (int OrderNode in keyValuePair.Value)
                {
                    Console.Write(OrderNode+",");
                }
                Console.WriteLine();
            }
        }

        private void PVO(TNode node, int hd)
        {
            if (node == null)
                return;
            if(dictVertOrd.ContainsKey(hd))
            {
                dictVertOrd[hd].Add(node.value);
            }
            else
            {
                IList<int> lstNode = new List<int>();
                lstNode.Add(node.value);
                dictVertOrd.Add(hd, lstNode);
            }
            PVO(node.left, hd - 1);
            PVO(node.right, hd + 1);
        }

        public void PrintLeftViewBinaryTree(TNode node)
        {
            int level = 1;
            PrintLeftView(node, level);
        }

        private void PrintLeftView(TNode node, int level)
        {
            if (node == null)
                return;
            if (level > maxLevel)
            {
                maxLevel = level;
                Console.WriteLine(node.value);
            }
            PrintLeftView(node.left, level + 1);
            PrintLeftView(node.right, level + 1);
        }
                
        public bool IsValidBST(TNode root)
        {
            if (root == null) return true;
            return IsValidBSTRec(root, int.MinValue, int.MaxValue);
        }

        private bool IsValidBSTRec(TNode root, int? min, int? max)
        {
            if (root == null)
                return true;

            // current node data should be within a range. if not return false
            if (root.value < min || root.value > max)
                return false;
            
            return IsValidBSTRec(root.left, min, root.value) && IsValidBSTRec(root.right, root.value, max);
        }       

        private bool IsSymmetricSub(TNode node1, TNode node2)
        {
            
            if (node1 == null && node2 == null)
                return true;


            // For two trees to be mirror images,  
            // the following three conditions must be true  
            // 1 - Their root node's key must be same  
            // 2 - left subtree of left tree and right subtree  
            //       of right tree have to be mirror images  
            // 3 - right subtree of left tree and left subtree  
            //       of right tree have to be mirror images
            if (node1 != null && node2 != null && node1.value == node2.value)
                return IsSymmetricSub(node1.left, node2.right)
                     && IsSymmetricSub(node1.right, node2.left);

            return false;
        }        

        /// <summary>
        /// isSymmetric is same as Mirror
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsSymmetric(TNode node)
        {
            return IsSymmetricSub(node, node);
        }

      
    }
    
}
