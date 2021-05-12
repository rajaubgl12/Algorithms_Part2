using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Timers;

namespace GeeksForGeeksRevision
{
    public class LcAmazonSortSearch
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/word-ladder-length-of-shortest-chain-to-reach-a-target-word/
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<string>> FindLadders(string begin, string end, IList<string> words)
        {

            var result = new List<IList<string>>();

            // levels store two information: 1) Whether word visited; 2) Word level in the graph
            var levels = new Dictionary<string, int>();
            foreach (var word in words)
            {
                levels[word] = int.MaxValue;
            }

            if (!levels.ContainsKey(end)) return result;

            levels[begin] = 0;

            var graph = new Dictionary<string, List<string>>();

            var queue = new Queue<string>();
            queue.Enqueue(begin);
            var min = int.MaxValue;

            while (queue.Any())
            {
                var node = queue.Dequeue();
                var level = levels[node] + 1;

                if (level > min) break;

                var chars = node.ToCharArray();

                for (var i = 0; i < node.Length; i++)
                {
                    for (var c = 'a'; c <= 'z'; c++)
                    {
                        if (node[i] == c) continue;

                        chars[i] = c;

                        var next = new string(chars);

                        // 1. Next word is not in the word list - skip
                        // 2. Next word level is less than current level - skip, avoid cycle in graph
                        if (!levels.ContainsKey(next) || levels[next] < level) continue;

                        if (next == end) min = level;

                        // Enqueue the node, if it's not visited
                        if (levels[next] == int.MaxValue)
                        {
                            levels[next] = level;
                            queue.Enqueue(next);
                        }

                        // build graph
                        if (!graph.ContainsKey(next)) graph[next] = new List<string>();
                        graph[next].Add(node);
                    }

                    chars[i] = node[i];
                }
            }

            Dfs(graph, end, begin, new List<string>(), result);

            return result;
        }

        private void Dfs(Dictionary<string, List<string>> graph, string begin, string end, IList<string> path, IList<IList<string>> result)
        {
            if (begin == end)
            {
                path.Add(end);
                result.Add(path.Reverse().ToList());
                path.Remove(end);

                return;
            }

            if (graph.ContainsKey(begin))
            {
                path.Add(begin);

                foreach (var word in graph[begin])
                {
                    Dfs(graph, word, end, path, result);
                }

                path.Remove(begin);
            }
        }
               
    }


    /// <summary>
    /// source code is based on 
    /// https://discuss.leetcode.com/topic/121128/c-easy-to-understand-solution-with-explanation-accepted
    /// Julia worked on April 3, 2018
    /// Plan to read line sweep algorithm 
    /// https://en.wikipedia.org/wiki/Sweep_line_algorithm
    /// </summary>
    class Program2
    {
        public class Interval
        {
            public int start;
            public int end;

            public Interval()
            {
                start = 0;
                end = 0;
            }

            public Interval(int s, int e)
            {
                start = s;
                end = e;
            }
        }

        /// <summary>
        /// line sweep algorithm
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms(Interval[] intervals)
        {
            int len = intervals.Length;

            int[] starts = new int[len];
            int[] ends = new int[len];

            for (int i = 0; i < len; i++)
            {
                starts[i] = intervals[i].start;
                ends[i] = intervals[i].end;
            }

            Array.Sort(starts);
            Array.Sort(ends);

            int pStart = 0;
            int pEnd = 0;

            int roomCount = 0;
            int maxRoomCount = 0; // default is 0, so when intervals.Length == 0 we return 0

            while (pStart < len) // by design starts finish earlier than ends.
            {
                if (starts[pStart] < ends[pEnd])
                {
                    roomCount++;
                    maxRoomCount = Math.Max(roomCount, maxRoomCount);
                    pStart++;
                }
                else
                {
                    // starts[pStart] >= ends[pEnd]
                    roomCount--;
                    pEnd++;
                }
            }

            return maxRoomCount;
        }
    }

}

