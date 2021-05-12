using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
   public class General
    {
        private static int MinValue = int.MaxValue;
        private static int MaxValue = int.MinValue;
        public void FindMinMaxBinaryTree(TNode node)
        {
            FindMinMaxBinaryTreeHelper(node, ref MinValue, ref MaxValue);
        }

        private void FindMinMaxBinaryTreeHelper(TNode node, ref int minValue, ref int maxValue)
        {
            if (node == null)
                return;
            if (node.left != null)
            {
                if (minValue > node.left.value)
                    minValue = node.left.value;
                FindMinMaxBinaryTreeHelper(node.left, ref minValue, ref maxValue);
            }
            

            if (node.right != null)
            {
                if (maxValue < node.right.value)
                    maxValue = node.right.value;
                FindMinMaxBinaryTreeHelper(node.right, ref minValue, ref maxValue);
            }
                
        }

        /// <summary>
        ///  /* A function that constructs Balanced Binary Search Tree   
        ///from a sorted array */
        ///1) Get the Middle of the array and make it root.
        /*  2) Recursively do same for left half and right half.
                a) Get the middle of left half and make it left child of the root
                    created in step 1.
                b) Get the middle of right half and make it right child of the
                    root created in step 1.
                    */
        /// </summary>
        int prev = -1;
        public TNode SortedArrayToBST(int [] a)
        {
            return Array2BST(a, 0, a.Length - 1);
        }

        private TNode Array2BST(int[] a, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            
            TNode node = new TNode(a[mid]);
            node.left = Array2BST(a, start, mid - 1);
            node.right = Array2BST(a, mid + 1, end);

            return node;
        }

        public TNode Array2LevelOrder(int [] a)
        {
            return Array2LevelOrderSub(a, 0);
        }

        private TNode Array2LevelOrderSub(int[] a, int start)
        {
            TNode node = null;
            if (start<a.Length)
            {
                 node = new TNode(a[start]);
                
                node.left = Array2LevelOrderSub(a, 2*start +1);
                
                node.right = Array2LevelOrderSub(a, 2*start+2);
            }
            
            return node;
        }

        public bool IsMirrorTree(TNode node)
        {
           return IsMirrorTreeHelper(node, node);
        }

        private bool IsMirrorTreeHelper(TNode node1, TNode node2)
        {
            if (node1 == null && node2 == null)
                return true;
            if (node1.value != node2.value)
                return false;
            return IsMirrorTreeHelper(node1.left, node2.right) &&
                IsMirrorTreeHelper(node1.right, node2.left);
        }

        /// <summary>
        /// for every node swap left subtree and right subtree.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public TNode ConvertTreeToMirror(TNode node)
        {
            if (node == null)
                return null;
            //Traverse
            TNode nodeL = ConvertTreeToMirror(node.left);
            TNode nodeR = ConvertTreeToMirror(node.right);

            //swap
            node.left = nodeR;
            node.right = nodeL;

            return node;
        }

        public TNode LCA_BST(TNode node, int n1, int n2)
        {
            if (node == null)
                return null;

            //traverse left only based on condition
            if (Math.Max(n1, n2) < node.value)
                LCA_BST(node.left, n1, n2);

            //traverse left only based on condition
            if (Math.Min(n1, n2) > node.value)
                LCA_BST(node.right, n1, n2);

            return node;
        }

        public int LCA_BT(TNode node, int n1, int n2)
        {
            if (node == null)
                return -1;
            if (node.value == n1 || node.value == n2)
                return node.value;
            
            int node1 = LCA_BT(node.left, n1, n2);
            int node2 = LCA_BT(node.right, n1, n2);

            if (node1 == -1 || node2 == -1)
                return node1 == -1?node2:node1;

            return node.value;
        }

        /// <summary>
        /// 1. convert left subtree to dll , use post order traversal
        /// 2. convert right subtree to dll
        /// 3. join 3 lists ( right extreme of left will point to root, 
        /// left extreme of right subtree will point to root.
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TNode ConvertTree2DoublyLinkedList(TNode root)
        {
            if (root == null)
                return null;

            if(root.left!=null)
            {
                TNode ndLeft = ConvertTree2DoublyLinkedList(root.left);

                //traverse to get to the tail of left subtree and point tail to root.
                for (; ndLeft.right != null; ndLeft = ndLeft.right)
                {
                    ;
                }
                ndLeft.right = root;
                //root would have already connected to left and right.
            }
            if (root.right!=null)
            {
                TNode ndRight = ConvertTree2DoublyLinkedList(root.right);

                // traverse right subtree to the left until head 
                for (; ndRight.left != null; ndRight = ndRight.left)
                {
                    ;
                }

                ndRight.left = root;
            }
            return root;
        }

        TNode headTnode = null;
        TNode prevTNode = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public void ConvertTree2DoublyLinkedListOptOrderofN(TNode root)
        {
            if (root == null)
                return;

            ConvertTree2DoublyLinkedListOptOrderofN(root.left);

            //In order traversal, First node is head. meaning first traversal 
            //and the last node in the traversal leaf node will become starting node that is head node
            if(prevTNode==null)
            {
                headTnode = root;
            }
            else
            {
                prevTNode.right = root;
                root.left = prevTNode;
            }
            // save prev node
            prevTNode = root;

            ConvertTree2DoublyLinkedList(root.right);

        }

        int htforDiamtr = 0;
        public int DiameterOfTree(TNode root)
        {
            return DiameterOfTreeHelper(root, htforDiamtr);
        }

        private int DiameterOfTreeHelper(TNode root, int htforDiamtr)
        {
            int leftDiameter = 0;
            int rightDiameter = 0;
            int leftHeight = 0;
            int rightHeight = 0;

            if (root == null)
                return 0;

            leftDiameter = DiameterOfTreeHelper(root.left, leftHeight);
            rightDiameter = DiameterOfTreeHelper(root.right, rightHeight);

            //compute height 
            htforDiamtr = Math.Max(leftHeight, rightHeight) + 1;

            return Math.Max(leftHeight + rightHeight + 1, Math.Max(leftDiameter, rightDiameter)) + 1;
        }


        private int lvlNode = 0;

       /// <summary>
       /// 
       /// </summary>
       /// <param name="node"></param>
       /// <param name="key"></param>
       /// <param name="level"></param>
       /// <returns></returns>
        public int GetLevelOfNode(TNode node, int key, int level)
        {
            if (node == null)
                return -1;
            if (node.value == key)
                return level;
            else
            {
               int  level2 = GetLevelOfNode(node.left, key, level + 1);
                if (level2 != -1)
                    return level2;
                else
                return GetLevelOfNode(node.right, key, level + 1);

            }            
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/print-nodes-distance-k-given-node-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public int PrintNodesAtKdistanceFromGivenNode(TNode root, TNode target, int distance)
        {
            if (root == null )
                return -1;
            if(root.value == target.value)
            {
                //print nodes down
                PrintNodesAtKdistanceHelper(root, distance);
                return 0;
            }

            //if node found in left subtree, this logic to print nodes passes through the root.
            int leftDist = PrintNodesAtKdistanceFromGivenNode(root.left, target, distance);
            //if it is not -1, then it is in left subtree.
            if(leftDist != -1)
            {
                if(leftDist + 1==distance)
                {
                    Console.WriteLine(root.value);
                }
                else
                    PrintNodesAtKdistanceFromGivenNode(root.right, target, distance-2- leftDist);

                return leftDist + 1;
            }

            //if node found in left subtree, this logic to print nodes passes through the root.
            int rightDist = PrintNodesAtKdistanceFromGivenNode(root.right, target, distance);
            //if it is not -1, then it is in left subtree.
            if (rightDist != -1)
            {
                if (rightDist + 1 == distance)
                {
                    Console.WriteLine(root.value);
                }
                else
                    PrintNodesAtKdistanceFromGivenNode(root.left, target, distance - 2 - rightDist);

                return rightDist + 1;
            }

            return -1;
        }

        private void PrintNodesAtKdistanceHelper(TNode findNode, int distance)
        {
            if (findNode == null || distance <0 )
                return;
            if (distance == 0)
            {
                Console.WriteLine(findNode.value);
            }
            PrintNodesAtKdistanceHelper(findNode.left, distance - 1);
            PrintNodesAtKdistanceHelper(findNode.right, distance - 1);
        }


        private TNode FindNodeFromGivenNdHelper(TNode root, TNode target)
        {
            if (root == null)
                return null;
            if (root.value == target.value)
                return root;
            
          TNode temp =   FindNodeFromGivenNdHelper(root.left, target);
            if (root != null)
                return temp;
            else
                return
                    FindNodeFromGivenNdHelper(root.right, target);
        }

     
    }
}
