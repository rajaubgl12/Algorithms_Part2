using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IK_Algorithms.Graphs
{
    public class CriticalConnection
    {
        /// <summary>
        /// https://leetcode.com/problems/critical-connections-in-a-network/solution/
        /// https://www.youtube.com/watch?v=CsGP_s_3GWg
        /// </summary>
        /// <param name="n"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            //build a adjacency list graph

            List<int>[] graphAdj = BuildGraph(n, connections);
            IList<IList<int>> criticalConn = new List<IList<int>>();
            int[] visitTime = new int[n];
            int[] lowTime = new int[n];

            DFSCriticalConnHelper(graphAdj, 0,-1, visitTime, lowTime, 0, criticalConn);

            return criticalConn;
        }

        private void DFSCriticalConnHelper(List<int>[] graph, int node, int parent, int[] visTimes
            , int[] lowTimes, int time, IList<IList<int>> criticals)
        {
            visTimes[node] = lowTimes[node] = time++;
            
            foreach (var adj in graph[node])
            {
                if (adj == parent)
                    continue;

                if (visTimes[adj] == 0)
                {
                    DFSCriticalConnHelper(graph, adj, node,visTimes,lowTimes,time,criticals);

                    //backtrack check if adj rank is more than curr node then there is a bridge exist
                    // if you take the connection node will not be reachable.
                    lowTimes[node] = Math.Min(lowTimes[node], lowTimes[adj]);
                    if (visTimes[node] < lowTimes[adj])
                        criticals.Add(new List<int> { adj, node });
                }
                else
                {
                    //if visited then take the lowest adj node rank not from parent
                    lowTimes[node] = Math.Min(lowTimes[adj], lowTimes[node]);
                }
            }

        }

        private List<int>[] BuildGraph(int n, IList<IList<int>> connections)
        {
            List<int>[] graphAdj = new List<int>[n];
            
            for (int i = 0; i < n; i++)
            {
                graphAdj[i] = new List<int>();
            }

            
            foreach(var lst in connections)
            {
                //Add edge
                graphAdj[lst[0]].Add(lst[1]);
                graphAdj[lst[1]].Add(lst[0]);
            }
            return graphAdj;
        }
    }
}
