using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Graphs
{
    public class CourseSchedule
    {
        /// <summary>
        /// how to detect cycle in a graph https://www.youtube.com/watch?v=rKQaZuoUR4M
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //Build a graph using Adjacency list.
            List<int>[] adjLst = BuildGraphAdjacencyList(numCourses, prerequisites);

            //0= not visited, 1= visited and in stack or queue , 2= processed.            
            int[] visitedState = new int[numCourses];

            for(int i=0;i<numCourses;i++)
            {
                if(visitedState[i]==0)
                {
                    if (IsCycleDFS(adjLst, i, visitedState))
                        return false;
                }                
            }
            return true;
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            //Build a graph using Adjacency list.
            List<int>[] adjLst = BuildGraphAdjacencyList(numCourses, prerequisites);
            int[] visited = new int[numCourses];

            Stack<int> topoOrder = new Stack<int>();
            bool isCycle = false;
            //Traverse the graph and 
            for(int i=0;i<numCourses;i++)
            {
                if(visited[i]==0)
                {
                    isCycle= DFSTopologicalOrderCheckCycle(adjLst, i, visited, topoOrder);
                }
            }

            int[] orderOfCourse = new int[numCourses];
            int j = 0;

            if (!isCycle)
            {
                while (topoOrder.Count > 0)
                {
                    orderOfCourse[j] = topoOrder.Pop();
                    j++;
                }
                return orderOfCourse;
            }
            else
            {
                return new int[0];
            }
            
        }

        private bool DFSTopologicalOrderCheckCycle(List<int>[] adjLst, int i, int[] visited, Stack<int> topoOrder)
        {
            visited[i] = 1;

            foreach(var neighbor in adjLst[i])
            {
                if(visited[neighbor]==0)
                {
                    if (DFSTopologicalOrderCheckCycle(adjLst, neighbor, visited, topoOrder))
                        return true;

                }
                if (visited[neighbor] != 2)
                    return true;
            }
            visited[i] = 2;
            topoOrder.Push(i);
            return false;
        }

        private bool IsCycleDFS(List<int>[] adjLst, int i, int[] visitedState)
        {
            visitedState[i] = 1;

            //loop through a list[i] which means, 
            //list[i] is one single list, so you are looping through one single list.

            foreach(var neighbor in adjLst[i])
            {
                if(visitedState[neighbor]==0)
                {
                    if (IsCycleDFS(adjLst, neighbor, visitedState))
                        return true;
                }
                else
                {
                    if (visitedState[neighbor] != 2)
                        return true;
                }
            }

            //after traversing through all the child nodes make the node as explored.
            visitedState[i] = 2;

            return false;
        }

        private List<int>[] BuildGraphAdjacencyList(int numCourses, int[][] prerequisites)
        {
            List<int>[] lstAdj = new List<int>[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                lstAdj[i] = new List<int>();
            }

            for(int i=0;i<prerequisites.Length;i++)
            {
                int u = prerequisites[i][0];
                int v = prerequisites[i][1];

                //V has to be completed first to complete the u
                lstAdj[v].Add(u);   
            }

            return lstAdj;
        }

       
    }

    
}
