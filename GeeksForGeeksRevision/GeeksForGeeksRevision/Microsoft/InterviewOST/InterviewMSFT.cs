using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Microsoft.InterviewOST
{
    public class InterviewMSFT
    {
       

            public int solution(string S)
            {
                HashSet<string> lst = new HashSet<string>();

                for (int i = 0; i < S.Length; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (!lst.Contains(S.Substring(j, i + 1)))
                        {
                            lst.Add(S.Substring(j, i + 1));
                        }
                    }
                }

                return lst.Count;
            }
            /// <summary>
            /// "abacdecf" delete 
            /// total substring , divide substring if you find a character repeates
            /// ans: ab acde cf 
            /// </summary>
            /// <param name="S"></param>
            /// <returns></returns>
            public int solution2(string S)
            {

                HashSet<char> visited = new HashSet<char>();

                List<string> lst = new List<string>();
                int startIndex = 0;

                for (int i = 0; i < S.Length; i++)
                {
                    if (!visited.Contains(S[i]))
                    {
                        visited.Add(S[i]);
                    }
                    else
                    {
                        string subStr = S.Substring(startIndex, i - startIndex);
                        startIndex = i;
                        lst.Add(subStr);
                        visited.Clear();
                        visited.Add(S[i]);

                    }

                }

                return visited.Count > 0 ? lst.Count + 1 : lst.Count;
            }

            /// <summary>
            /// https://leetcode.com/problems/maximal-network-rank/
            /// </summary>
            /// <param name="A"></param>
            /// <param name="B"></param>
            /// <param name="N"></param>
            /// <returns></returns>
            public int solution(int[] A, int[] B, int N)
            {
                // write your code in C# 6.0 with .NET 4.5 (Mono)
                int[] count = new int[N];
                int m = A.Length;
                int maxRank = int.MinValue;

                for (int i = 0; i < m; i++)
                {
                    count[A[i] - 1]++;
                    count[B[i] - 1]++;
                }

                for (int i = 0; i < m; i++)
                {
                    int rank = count[A[i] - 1] + count[B[i] - 1] - 1;
                    if (rank > maxRank)
                    {
                        maxRank = rank;
                    }
                }
                return maxRank;
            }

            /// <summary>
            /// Using arrays
            /// </summary>
            /// <param name="n"></param>
            /// <param name="roads"></param>
            /// <returns></returns>
            public int MaximalNetworkRank(int n, int[][] roads)
            {


                int[] countRank = new int[n];
                bool[,] isConnected = new bool[n, n];

                foreach (int[] var in roads)
                {
                    countRank[var[0]]++;
                    countRank[var[1]]++;

                    isConnected[var[0], var[1]] = true;
                    isConnected[var[1], var[0]] = true;
                }

                int max = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        int rank = countRank[i] + countRank[j] - (isConnected[i, j] == true ? 1 : 0);

                        max = Math.Max(max, rank);
                    }
                }

                return max;

            }

            /// <summary>
            /// https://leetcode.com/problems/minimum-deletion-cost-to-avoid-repeating-letters/submissions/
            /// </summary>
            /// <param name="s"></param>
            /// <param name="c"></param>
            /// <returns></returns>
            public int MinCost(string s, int[] cost)
            {
                int minCost = 0;

                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == s[i - 1])
                    {

                        minCost += Math.Min(cost[i], cost[i - 1]);
                        //delete the min cost taken above, reset with the max cost.
                        cost[i] = cost[i - 1] = Math.Max(cost[i], cost[i - 1]);
                    }

                }

                return minCost;
            }
        
    }
}
