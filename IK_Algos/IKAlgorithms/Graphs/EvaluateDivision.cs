using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IK_Algorithms.Graphs
{
    /// <summary>
    /// https://leetcode.com/problems/evaluate-division/
    /// </summary>
    public class EvaluateDivision
    {
        public double[] CalcEquation(IList<IList<string>> equations
            , double[] values, IList<IList<string>> queries)
        {

            Dictionary<string, Dictionary<string, double>> graph = BuildGraphFromEquation(equations, values);

            //Loop through the equations
            double[] result = new double[queries.Count];
            

            for(int i=0;i< queries.Count;i++)
            {
                HashSet<string> visited = new HashSet<string>();
                
                result[i] = CalculateDFSEquationHelper(queries[i][0], queries[i][1], visited, graph);
            }

           

            return result;
        }

        private double CalculateDFSEquationHelper(string start, string end, HashSet<string> visited
            , Dictionary<string, Dictionary<string, double>> graph)
        {
            //exit condition
            if (!graph.ContainsKey(start) || !graph.ContainsKey(end))
            {
                return -1.0;
            }

            //meet condition
            if (graph[start].ContainsKey(end))
                return graph[start][end];

            if(!visited.Contains(start))
            visited.Add(start);

            foreach(var neighbour in graph[start])
            {
                if (!visited.Contains(neighbour.Key))
                {
                    double productWeight = CalculateDFSEquationHelper(neighbour.Key, end, visited, graph);

                    if(productWeight != -1.0)
                    {
                        return productWeight * neighbour.Value;
                    }
                }  
            }
            return -1.0;
        }

        private Dictionary<string, Dictionary<string, double>> BuildGraphFromEquation(IList<IList<string>> equations
            , double[] values)
        {
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
            for(int i=0;i<equations.Count;i++)
            {
                string u = equations[i][0];
                string v = equations[i][1];
                if(!graph.ContainsKey(u))
                {
                    graph.Add(u, new Dictionary<string, double>());
                    graph[u].Add(v, values[i]);
                }
                else
                {
                    graph[u].Add(v, values[i]);
                }
                if (!graph.ContainsKey(v))
                {
                    //reverse direction a-->b =>3.0 b-->a 1/3.0;
                    graph.Add(v, new Dictionary<string, double>());
                    graph[v].Add(u, 1/values[i]);
                }
                else
                {
                    graph[v].Add(u, 1 / values[i]);
                }
            }

            return graph;
        }
    }
}
