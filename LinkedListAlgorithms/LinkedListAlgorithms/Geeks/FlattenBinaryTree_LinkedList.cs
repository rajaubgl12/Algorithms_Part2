using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithms.Geeks
{

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class FlattenBinaryTree_LinkedList
    {
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;

            var left = root.left;
            var right = root.right;

            root.left = null;
            Flatten(left);
            Flatten(right);

            root.right = left;
            TreeNode current = root;

            while (current.right != null)
            {
                current = current.right;
            }

            current.right = right;
            //Pre order traversal root, left and right
            //ListNode listNode = new ListNode(0);
            //POT(root, listNode);
        }

        private void POT(TreeNode treeNode, ListNode listNode)
        {
            if (treeNode == null)
                return;
            //Console.WriteLine(treeNode.val);
            ListNode node = new ListNode(treeNode.val);
            listNode.next = node;
            POT(treeNode.left, listNode);
            POT(treeNode.right, listNode);
        }
    }
}
