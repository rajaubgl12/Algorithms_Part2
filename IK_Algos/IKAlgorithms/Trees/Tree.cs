using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Trees
{
    public class Tree
    {
        public Tree left;
        public Tree right;
        public int ? value;
        public Tree(int? data)
        {
            value = data;
        }
    }
}
