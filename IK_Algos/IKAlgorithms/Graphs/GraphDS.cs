using IK_Algorithms.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Graphs
{
    /// <summary>
    /// 1. Adjacency Matrix
    /// 2. Adjacency List
    /// 3. Adjacency Map.
    /// </summary>
    public class GraphDS
    {        

    }

    public class GraphAdjaMatrx
    {
        int[,] matrx = null;
        int size;
        public GraphAdjaMatrx(int n)
        {
            matrx = new int[n, n];
            size = n;
        }
        public void AddEdge(int start, int end)
        {
            matrx[start, end] = 1;
        }
    }

    public class GraphAdjaLst
    {
        IList<int>[] lst;
        int size;
        public GraphAdjaLst(int n)
        {
            size = n;
            
            lst = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                lst[i] = new List<int>();
            }
        }

        public void AddEdge(int start, int end)
        {
            lst[start].Add(end);
        }
    }

    public class GraphAdjaMapOfMap
    {
        string [] vertices;
        int size;
        Dictionary<string, Dictionary<string, int>> mapOfMap;

        public GraphAdjaMapOfMap(string[] vertices)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                mapOfMap[vertices[i]] =  new Dictionary<string, int>();
            }
        }

        public void AddEdge(string start, string end, int weight)
        {
            mapOfMap[start].Add(end, weight);
        }
    }

    public class BuildGrapFromTree
    {
        GraphAdjaMapOfMap graphMap = null;
        public void ConvertTree2Graph( Tree root, Tree child, Dictionary<int ?, IList<Tree>> graph)
        {
            if (child != null)
            {
                graph.Add(child.value, new List<Tree>());

                if(root!=null)
                {
                    graph[root.value].Add(child);
                    graph[child.value].Add(root);
                }
            }

            ConvertTree2Graph(root, root.left, graph);
            ConvertTree2Graph(root, root.right, graph);
        }
    }   

}
