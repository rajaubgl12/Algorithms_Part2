using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeDeserializeDesignMain();
        }

        private static void SerializeDeserializeDesignMain()
        {
            TNode root = ConstructTreeNode(1, 2, 3, 4, 5, 6, 7);
            SerializeDeserialize obj = new SerializeDeserialize();
            string result = obj.serialize(root);

            TNode deserNode = obj.deserialize(result);
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
    }
}
