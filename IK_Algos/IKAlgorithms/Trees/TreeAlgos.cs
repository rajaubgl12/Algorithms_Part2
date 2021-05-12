using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Trees
{
    public class TreeAlgos
    {
        //BFS to print left most node at every level.
        public void PrintLeftMostNode(Tree tNode)
        {
            PrintLeftBFS(tNode);            
        }

        /// <summary>
        /// Level order traversal
        /// 
        /// </summary>
        /// <param name="tNode"></param>
        private void PrintLeftBFS(Tree tNodes)
        {
            Queue<Tree> queueTNodes = new Queue<Tree>();
            queueTNodes.Enqueue(tNodes);
           

            while(queueTNodes.Count>0)
            {
                bool isFirstNode = true;

                //Level size
                int levelNodeCount = queueTNodes.Count;
                
                //traverse all the elements in that particular tree level and print only the left most first node.
                
                // This below while loop execute all the childrens the a loop
                while(levelNodeCount-->0)
                {
                    Tree node = queueTNodes.Dequeue();
                    if (isFirstNode)
                    {
                        Console.WriteLine(node.value);
                        isFirstNode = false;
                    }
                    //Enqueue the child elements left and right
                    if (node.left!=null&&node.left.value != null)
                    {
                        queueTNodes.Enqueue(node.left);
                    }
                    if (node.right != null && node.right.value != null)
                    {
                        queueTNodes.Enqueue(node.right);
                    }                    
                }
                                
            }
        }

        public bool IsUniValue(Tree tNode, ref int  counter)
        {
            if(tNode==null)
            {                
              return true;
            }

            bool left = IsUniValue(tNode.left, ref counter);
            bool right = IsUniValue(tNode.right, ref counter);

            if (!left || !right)
                return false;

            if (tNode.left != null && tNode.left.value != tNode.value)
            {
                return false;
            }

            if (tNode.right != null && tNode.right.value != tNode.value)
            {
                return false;
            }
            counter++;
            return true;
        }

        public bool IsLeafNodesSame(Tree t1, Tree t2)
        {
            Stack<Tree> st1 = new Stack<Tree>();
            Stack<Tree> st2 = new Stack<Tree>();

            st1.Push(t1);
            st2.Push(t2);

            while(st1.Count>0&&st2.Count>0)
            {
                //Loop first tree until you get leaf node.

                Tree treeNode1 = st1.Pop();

                while(treeNode1.left!=null&& treeNode1.right!=null)
                {

                    //push right
                    if (treeNode1.right.value!=null&&treeNode1.right != null)
                        st1.Push(treeNode1.right);

                    //push left 
                    if (treeNode1.left.value!=null&&treeNode1.left!=null)
                    st1.Push(treeNode1.left);

                   

                    treeNode1= st1.Pop();

                }

                Tree treeNode2 = st2.Pop();
                while (treeNode2.left != null && treeNode2.right != null)
                {

                    //push right
                    if (treeNode2.right.value!=null&&treeNode2.right != null)
                        st2.Push(treeNode2.right);

                    //push left 
                    if (treeNode2.left.value!=null&&treeNode2.left != null)
                        st2.Push(treeNode2.left);


                    treeNode2 = st2.Pop();
                }

                if (treeNode1.value != treeNode2.value)
                    return false;

            }

            return true;
        }


        Tree prev = null;
        Tree startNode = null;
        Tree endNode = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tNode"></param>
        /// <returns></returns>
        public Tree ConvertTree2DoublyLinkedList(Tree tNode)
        {
            ConvertTree2DoublyLinkedListHelper(tNode);
            //Tree tmp = endNode;
            Tree endNode = prev;
            startNode.left = endNode;
            endNode.right = startNode;
            return startNode;
            
        }

        private void ConvertTree2DoublyLinkedListHelper(Tree tNode)
        {
            if (tNode == null)
                return;

            ConvertTree2DoublyLinkedListHelper(tNode.left);

            if (tNode == null)
            {
                prev = tNode;
            }
            else
            {

                tNode.left = prev;
                if (prev == null)
                {
                    startNode = tNode;
                }
                else
                    prev.right = tNode;
            }
            prev = tNode;
            endNode = prev;
            ConvertTree2DoublyLinkedListHelper(tNode.right);
            
           
        }

        bool isPathFound = false;
        public bool TreePathSum(Tree tNode, int targetSum)
        {
            int sumSofar = 0;
           
             TreePathSumHelper(tNode, targetSum, sumSofar);
            return isPathFound;
        }

        private void TreePathSumHelper(Tree tNode, int targetSum, int sumSofar)
        {
            if (tNode.right== null&&tNode.left==null)
            {
                if (targetSum == (sumSofar+tNode.value))
                    isPathFound = true;

                return;
            }

            if (isPathFound)
                return;
            else
            {
                sumSofar += (int)tNode.value;

                if (tNode.left != null)
                    TreePathSumHelper(tNode.left, targetSum, sumSofar);

                if (tNode.right != null)
                    TreePathSumHelper(tNode.right, targetSum, sumSofar);
            }
            

        }
    }
}
