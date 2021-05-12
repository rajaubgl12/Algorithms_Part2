using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DataStructure
{
    class AutoCompleteWord
    {
        private readonly TrieNode root;

        public readonly Dictionary<string, int> map;

        private TrieNode curNode;

        private StringBuilder curSb;

        public AutoCompleteWord(string[] sentences, int[] times)
        {
            root = new TrieNode();
            curNode = root;
            curSb = new StringBuilder();
            map = new Dictionary<string, int>();

            for (int i = 0; i < sentences.Length; i++)
            {
                string curSent = sentences[i];
                int curTimes = times[i];
                var node = root;
                map.Add(curSent, curTimes);
                foreach (char ch in curSent)
                {
                    int charIndex = ch == ' ' ? 26 : ch - 'a';
                    if (node.children[charIndex] == null)
                    {
                        node.children[charIndex] = new TrieNode();
                    }

                    node = node.children[charIndex];
                    OrderFrequentSentences(node, curSent);
                }
            }
        }

        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                string sent = curSb.ToString();
                AddSentence(sent);
                curNode = root;
                curSb = new StringBuilder();
                return new List<string>();
            }
            else
            {
                curSb.Append(c);
                int charIndex = c == ' ' ? 26 : c - 'a';

                if (curNode == null || curNode.children[charIndex] == null)
                {
                    curNode = null;
                    return new List<string>();
                }

                curNode = curNode.children[charIndex];
                return curNode.mostFrequentSents;
            }
        }

        private void AddSentence(string sent)
        {
            map[sent] = map.ContainsKey(sent) ? map[sent] + 1 : 1;
            var node = root;
            foreach (char ch in sent)
            {
                int charIndex = ch == ' ' ? 26 : ch - 'a';
                if (node.children[charIndex] == null)
                {
                    node.children[charIndex] = new TrieNode();
                }

                node = node.children[charIndex];
                OrderFrequentSentences(node, sent);
            }
        }

        private void OrderFrequentSentences(TrieNode node, string sent)
        {
            if (!node.mostFrequentSents.Contains(sent))
            {
                node.mostFrequentSents.Add(sent);
            }

            //if frequency same then order by alphabetic
            node.mostFrequentSents.Sort((a, b) => map[a] == map[b]
                ? string.Compare(a, b, StringComparison.Ordinal)
                : map[b] - map[a]);
            //CustomCompare objComp = new CustomCompare();
            //node.mostFrequentSents.Sort(objComp);

            if (node.mostFrequentSents.Count > 3)
            {
                node.mostFrequentSents.RemoveAt(3);
            }
        }

        private class TrieNode
        {
            public readonly List<string> mostFrequentSents;

            public readonly TrieNode[] children;

            public TrieNode()
            {
                mostFrequentSents = new List<string>();
                children = new TrieNode[27];
            }
        }

      
    }
}
