using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
   public class TNode
    {
        public int value;
        public TNode left;
        public TNode right;
        public TNode(int d)
        {
            this.value = d;
            left = right = null;
        }
    }
    public class TreeNode
    {
        public TNode root;
    }
}
