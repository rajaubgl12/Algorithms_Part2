using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Facebook
{
   public class FaceBookTreesAlgos
    {
        public bool IsBST(TNode root)
        {
            return IsBstHelper(root);
        }

        private bool IsBstHelper(TNode root)
        {
            if (root == null)
                return true;

            if(root.left != null)
            if (root.left.value > root.value )
                return false;

            if (root.right != null)
                if (root.right.value < root.value)
                    return false;
            return IsBstHelper(root.left) && IsBstHelper(root.right);
        }

        public bool IsValidBST(TNode root)
        {
            return DFS(root, long.MinValue, long.MaxValue);
        }

        private bool DFS(TNode root, long min, long max)
        {
            if (root == null) return true;
            if (min < root.value && root.value < max)
            {
                var leftResult = DFS(root.left, min, root.value);
                var rightResult = DFS(root.right, root.value, max);

                if (leftResult && rightResult)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/flatten-binary-tree-to-linked-list/solution/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TNode FlattenTree(TNode root)
        {
            if (root == null)
                return null;
            if (root.left == null || root.right == null)
                return root;

            TNode left = FlattenTree(root.left);
            TNode right = FlattenTree(root.right);


            if(left!=null)
            {
                left.right = root.right;
                root.right = root.left;
                root.left = null;
            }

            //// We need to return the "rightmost" node after we are
            // done wiring the new connections. Return tail that will point to root node right
            return right == null ? left : right;
        }


        /// <summary>
        /// https://www.youtube.com/watch?v=_wUz0XKQ5JM
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// 

        public int maxPathSum = int.MinValue;
        public int MaxPathSum(TNode root)
        {

            if (root == null)
                return 0;

            int left = MaxPathSum(root.left);

            int right = MaxPathSum(root.right);

            //maximum single
            int maxSingle =Math.Max(0,Math.Max(left, right) + root.value);

            //including parent and two child nodes.
            int maxTop = left + right + root.value;

            maxPathSum = Math.Max(maxPathSum, maxTop);

            return maxSingle;
        }

        public IList<int> RightSideView(TNode root)
        {
            IList<int> lst = new List<int>();
            PrintRightView(root, 1, lst);
            return lst;
        }
        int maxLevel = 0;
        private void PrintRightView(TNode node, int level,IList<int> lst)
        {
            if (node == null)
                return;
            if (level > maxLevel)
            {
                maxLevel = level;
                lst.Add(node.value);
            }

            PrintRightView(node.right, level + 1, lst);
            PrintRightView(node.left, level + 1, lst);            
        }

       
        public IList<string> BinaryTreePaths(TNode root)
        {
            IList<string> lstPaths = new List<string>();
            BinaryTreepathHelper(root, "", lstPaths);
            return lstPaths;
        }

        private void BinaryTreepathHelper(TNode root, string currPath, IList<string> lstPaths)
        {
            if (root == null)
                return;

            currPath += root.value;

            if (root.left == null && root.right == null)
            {
                lstPaths.Add(currPath);
            }
            else
            {
                currPath += "->";
                BinaryTreepathHelper(root.left, currPath, lstPaths);
                BinaryTreepathHelper(root.right, currPath, lstPaths);
            }

        }
    }
}
