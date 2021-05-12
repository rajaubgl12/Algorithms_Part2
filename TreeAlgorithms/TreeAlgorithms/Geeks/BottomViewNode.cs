using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms.Geeks
{
    public class TNodeBottom
    {
        public TNodeBottom left;
        public TNodeBottom right;
        public int data;
        public int hd;
        public TNodeBottom(int item)
        {
            data = item;
            hd = int.MaxValue;
        }

    }
    public class BottomViewTreeNodeCls
    {
        public void PrintBottomView(TNodeBottom node)
        {
            Queue<TNodeBottom> nodeQueue = new Queue<TNodeBottom>();
            SortedDictionary<int, TNodeBottom> pairNodes = new SortedDictionary<int, TNodeBottom>();
            TNodeBottom root = node;
            root.hd = 0;
            nodeQueue.Enqueue(root);
            while(nodeQueue.Count>0)
            {
                TNodeBottom nodeCurr = nodeQueue.Dequeue();
                if(nodeCurr!=null)
                {
                    if(pairNodes.ContainsKey(nodeCurr.hd))
                    {
                        pairNodes[nodeCurr.hd] = nodeCurr;
                    }
                    else
                    {
                        pairNodes.Add(nodeCurr.hd, nodeCurr);
                    }
                    if(nodeCurr.left!=null)
                    nodeCurr.left.hd = nodeCurr.hd + 1;
                    nodeQueue.Enqueue(nodeCurr.left);

                    if (nodeCurr.right != null)
                        nodeCurr.right.hd = nodeCurr.hd - 1;
                    nodeQueue.Enqueue(nodeCurr.right);
                }
                
            }

            foreach(KeyValuePair<int,TNodeBottom> pair in pairNodes)
            {
                Console.WriteLine(pair.Value.data);
            }
        }
    }
}
