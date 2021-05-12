using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Graphs
{
    public class Bipartite
    {
        public bool IsBipartite(int[][] graph)
        {
            int grpLength = graph.Length;

            //status = 0 is not visited, visited = 1 status = 1 is white group status = 2 black grp
            int[] status = new int[grpLength];

          
            for(int i=0;i<grpLength;i++)
            {
                if(status[i]==0)
                {
                    //enqueue each graph node
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(i);
                    status[i] = 1;

                    while (queue.Count > 0)
                    {
                        int grphNode = queue.Dequeue();
                        int[] neighbors = graph[grphNode];


                        for (int j = 0; j < neighbors.Length; j++)
                        {
                            //unvisited
                            if (status[neighbors[j]] == 0)
                            {
                                status[neighbors[j]] = (status[grphNode] == 1 ? 2 : 1);
                                queue.Enqueue(neighbors[j]);
                            }
                            else
                            {
                                if (status[neighbors[j]] == status[grphNode])
                                    return false;

                            }
                        }

                    }
                }
               

            }

            return true;

        }
    }
}
