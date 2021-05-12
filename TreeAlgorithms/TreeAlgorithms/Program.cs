using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeAlgorithms.Facebook;
using TreeAlgorithms.Geeks;
using TreeAlgorithms.Stacks_Queues;

namespace TreeAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Amazon
            #endregion

            #region Google
            #endregion

            #region Facebook
            //FacebookAlgosMain();
            #endregion

            #region Microsoft
            #endregion

            #region Geeks
            //PrintBottomView();
            #endregion

            #region General
            //ConvertArrayToBSTMain();
            //FindMinMaxBSTMain();
            //GeneralTreeAlgosMain();

            #endregion

            #region geeksforgeeksTrees
            //PrintLeftViewMain();
            //IsBstMain();
            #endregion

            #region TreeTraversal
           TraverseTreeMain();
            #endregion
            //PrintVerticalOrder();
            //PrintSpiralMain();
            //ConnectSameLevelNodesMain();

            #region stacks and queues
            //QueueImpleMethodsMain();
            //StackImplMain();
            //StackAlgoMain();
            #endregion
        }

       

        #region stacks and queues
        private static void QueueImpleMethodsMain()
        {
            QueueUsing1Stack obj = new QueueUsing1Stack(3);
            obj.Enqueue(1);
            obj.Enqueue(2);
            obj.Enqueue(3);
            Console.WriteLine("dequeue first element {0}", obj.Dequeue());
            Console.WriteLine("dequeue second element {0}", obj.Dequeue());
            Console.WriteLine("dequeue third element {0}", obj.Dequeue());
        }

        private static void StackImplMain()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            int getMin1 = minStack.GetMin();
            minStack.Pop();
            int getmin2 = minStack.GetMin();
        }

        private static void StackAlgoMain()
        {
            OrangeRotten obj = new OrangeRotten();
            int[,] a = { {2,1,1},{0,1,1},{1,0,1} }; //{ { 2, 1, 1 }, { 1, 1, 0 }, { 0, 1, 1 } };
            int res = obj.OrangesRotting(a);
        }

        #endregion

        #region Amazon
        #endregion

        #region Google
        #endregion

        #region Facebook
        private static void FacebookAlgosMain()
        {
            FaceBookTreesAlgos fbAlg = new FaceBookTreesAlgos();
            TNode root = ConstructTreeNode(1,2,3,4,5,6,7);

            //fbAlg.MaxPathSum(root);
            //int maxSumPathVal = fbAlg.maxPathSum;

            //IList<int> lst = fbAlg.RightSideView(root);

            int[,] M = new int[,] {{1, 1, 1, 1, 0},
                                   {1, 1, 0, 1, 0},
                                   {1, 1, 0, 0, 0},
                                   {0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0}};
            int[,] N = new int[,] {{1, 1, 0, 0, 0},
                                   {1, 1, 0, 0, 0},
                                   {0, 0, 1, 0, 0},
                                   
                                   {0, 0, 0, 1, 1}};

            NumIslandsClass objIsland = new NumIslandsClass();

            int countDFS = objIsland.NumIslands(N);
            int counBFS = objIsland.NumIslandsBFS(N);

            IList<string> lst = fbAlg.BinaryTreePaths(root);
        }
        private static TNode ConstructTreeNode(int a, int b, int c, int d, int e, int f, int g)
        {
            TNode treeNode = new TNode(a);
            treeNode.left = new TNode(b);
            treeNode.right = new TNode(c);
            treeNode.left.left = new TNode(d);
            treeNode.left.right = new TNode(e);           

            treeNode.right.left = new TNode(f);
            treeNode.right.right = new TNode(g);

            return treeNode;
        }

        #endregion

        #region Microsoft
        #endregion

        #region Geeks
        #endregion

        #region General

        private static void GeneralTreeAlgosMain()
        {

            General obj = new General();

            TNode node = ConstructBinaryTreeNode();

            //int lca = obj.LCA_BT(node,4,7);

            //TNode nodeDia = ConstructBinaryTreeNodeDiameter();

            //int diameter = obj.DiameterOfTree(nodeDia);

            //int levelNode = obj.GetLevelOfNode(nodeDia,4,1);
            //obj.PrintNodesAtKdistanceFromGivenNode(node, node.left, 2);
            
        }

        private static void ConvertArrayToBSTMain()
        {
            General general = new General();
            int[] a = { 1,2,3,4,5,6};
            //TNode node =  general.SortedArrayToBST(a);
            TNode node = general.Array2LevelOrder(a);
        }

        private static void FindMinMaxBSTMain()
        {
            TNode tNode = ConstructTreeNode();
            General obj = new General();
            obj.FindMinMaxBinaryTree(tNode);
        }
        private static TNode ConstructTreeNode()
        {
            TNode treeNode = new TNode(1);
            treeNode.left = new TNode(2);
            treeNode.right = new TNode(3);
            treeNode.left.left = new TNode(4);
            treeNode.left.right = new TNode(5);

            treeNode.left.right.right = new TNode(8);

            treeNode.right.left = new TNode(6);
            treeNode.right.right = new TNode(7);
            return treeNode;
        }

        private static TNode ConstructBinaryTreeNode()
        {
            TNode treeNode = new TNode(1);
            treeNode.left = new TNode(2);
            treeNode.right = new TNode(3);
            treeNode.left.left = new TNode(4);
            treeNode.left.right = new TNode(5);           

            treeNode.right.left = new TNode(6);
            treeNode.right.right = new TNode(7);
            return treeNode;
        }

        private static TNode ConstructBinaryTreeNodeDiameter()
        {
            TNode treeNode = new TNode(1);
            treeNode.left = new TNode(2);
            treeNode.right = new TNode(3);
            treeNode.left.left = new TNode(4);
            treeNode.left.right = new TNode(5);
            treeNode.left.left.left = new TNode(6);

            treeNode.left.right.right = new TNode(7);
            treeNode.left.right.right.right = new TNode(8);
            treeNode.left.right.right.right.right = new TNode(9);
            return treeNode;
        }


        #endregion

        private static void ConnectSameLevelNodesMain()
        {
            //TNodeLvl root = new TNodeLvl(10);
            TNodeLvl root = new TNodeLvl(1);
            root.left = new TNodeLvl(2);
            root.right = new TNodeLvl(3);
            root.left.left = new TNodeLvl(7);
            root.left.right = new TNodeLvl(6);
            root.right.left = new TNodeLvl(5);
            root.right.right = new TNodeLvl(4);

            //root.left = new TNodeLvl(8);
            //root.right = new TNodeLvl(2);
            //root.left.left = new TNodeLvl(3);
            //root.right.right = new TNodeLvl(90);

            GeeksForGeeks geeksForGeeks = new GeeksForGeeks();
            // Populates nextRight pointer in all nodes  
            geeksForGeeks.ConnectNodesSameLevel(root);

            // Let us check the values of nextRight pointers  
            Console.WriteLine("Following are populated nextRight pointers in \n" +
        "the tree (-1 is printed if there is no nextRight)");
            Console.WriteLine("nextRight of " + root.data + " is " +
            ((root.nextRight != null) ? root.nextRight.data : -1));
            Console.WriteLine("nextRight of " + root.left.data + " is " +
            ((root.left.nextRight != null) ? root.left.nextRight.data : -1));
            Console.WriteLine("nextRight of " + root.right.data + " is " +
            ((root.right.nextRight != null) ? root.right.nextRight.data : -1));
            Console.WriteLine("nextRight of " + root.left.left.data + " is " +
            ((root.left.left.nextRight != null) ? root.left.left.nextRight.data : -1));
            Console.WriteLine("nextRight of " + root.right.right.data + " is " +
            ((root.right.right.nextRight != null) ? root.right.right.nextRight.data : -1));
        }

        private static void PrintSpiralMain()
        {
            TreeNode tree = new TreeNode();
            tree.root = new TNode(1);
            tree.root.left = new TNode(2);
            tree.root.right = new TNode(3);
            tree.root.left.left = new TNode(7);
            tree.root.left.right = new TNode(6);
            tree.root.right.left = new TNode(5);
            tree.root.right.right = new TNode(4);
            GeeksForGeeks geeksForGeeks = new GeeksForGeeks();
            //geeksForGeeks.PrintNodesSpiral(tree.root);
            geeksForGeeks.PrintSpralUsingStack(tree.root);

        }

        #region TreeTraversal
        private static void TraverseTreeMain()
        {
            /* creating a binary tree and entering the nodes */
            TreeNode tree = new TreeNode();
            tree.root = new TNode(1);
            tree.root.left = new TNode(2);
            tree.root.right = new TNode(3);
            tree.root.right.left = new TNode(6);
            tree.root.right.right = new TNode(7);
            tree.root.left.left = new TNode(4);
            tree.root.left.right = new TNode(5);

            TreeTraverrsal treeTraverrsal = new TreeTraverrsal();
            treeTraverrsal.HeightOfTree(tree.root);

            Console.WriteLine("In Order Traversal");
            TreeTraverrsal.IOT(tree.root);
            Console.WriteLine("===============================");
            Console.WriteLine("Pre Order Traversal");
            TreeTraverrsal.POT(tree.root);
            Console.WriteLine("===============================");
            Console.WriteLine("Post Order Traversal");
            TreeTraverrsal.PST(tree.root);
            Console.WriteLine("===============================");
            Console.WriteLine("Level Order Traversal");
            //TreeTraverrsal.PrintLevelOrder(tree.root);
            TreeTraverrsal.PrintLevelOrder1(tree.root);
            TreeTraverrsal.PrintLevelOrderUsingQueue(tree.root);
            Console.WriteLine("===============================");
        }
        #endregion

        #region geeksforgeeksTrees
        private static void PrintBottomView()
        {
            //TreeNode tree = new TNodeBottom();
            //Bottom view of the given binary tree:
            //5 10 4 14 25
            TNodeBottom root = new TNodeBottom(20);
            root.left = new TNodeBottom(8);
            root.right = new TNodeBottom(22);
            root.left.left = new TNodeBottom(5);
            root.left.right = new TNodeBottom(3);
            root.right.left = new TNodeBottom(4);
            root.right.right = new TNodeBottom(25);
            root.left.right.left = new TNodeBottom(10);
            root.left.right.right = new TNodeBottom(14);
            BottomViewTreeNodeCls obj = new BottomViewTreeNodeCls();
            obj.PrintBottomView(root);
        }
        private static void PrintVerticalOrder()
        {
            TreeNode tree = new TreeNode();
            //tree.root = new TNode(1);
            //tree.root.left = new TNode(2);
            //tree.root.right = new TNode(3);
            //tree.root.left.left = new TNode(4);
            //tree.root.left.right = new TNode(5);
            //tree.root.right.left = new TNode(6);
            //tree.root.right.right = new TNode(7);
            //tree.root.right.left.right = new TNode(8);
            //tree.root.right.right.right = new TNode(9);
            tree.root = new TNode(1);
            tree.root.left = new TNode(2);
            tree.root.right = new TNode(3);
            tree.root.left.left = new TNode(4);
            tree.root.left.right = new TNode(5);
            tree.root.right.left = new TNode(6);
            tree.root.right.right = new TNode(7);
            tree.root.right.left.right = new TNode(8);
            tree.root.right.right.right = new TNode(9);
            tree.root.right.right.left = new TNode(10);
            tree.root.right.right.left.right = new TNode(11);
            tree.root.right.right.left.right.right = new TNode(12);

            GeeksForGeeks geeksForGeeks = new GeeksForGeeks();
            geeksForGeeks.PrintVerticalTreeNodeUsingPreOrder(tree.root);
        }
        private static void PrintLeftViewMain()
        {
            /* creating a binary tree and entering the nodes */
            TreeNode tree = new TreeNode();
            tree.root = new TNode(12);
            tree.root.left = new TNode(10);
            tree.root.right = new TNode(30);
            tree.root.right.left = new TNode(25);
            tree.root.right.right = new TNode(40);
            GeeksForGeeks geeksForGeeks = new GeeksForGeeks();
            geeksForGeeks.PrintLeftViewBinaryTree(tree.root);
            TreeAlgorithms.Geeks.PrintLeftView printLeft = new Geeks.PrintLeftView();
            printLeft.PrintLeftTree1(tree.root);
        }
        private static void IsBstMain()
        {
            TreeNode tree = new TreeNode();
            tree.root = new TNode(4);
            tree.root.left = new TNode(2);
            tree.root.right = new TNode(5);
            tree.root.left.left = new TNode(1);
            tree.root.left.right = new TNode(3);
            GeeksForGeeks geeksForGeeks = new GeeksForGeeks();
            //if (geeksForGeeks.IsBST1(tree.root,null))
            //    Console.WriteLine("IS BST");
            //else
            //    Console.WriteLine("Not a BST");
        }
        #endregion
    }

}
