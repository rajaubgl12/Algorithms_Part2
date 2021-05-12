using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DataStructure
{
    public class Trie
    {
        public class TrieNode
        {
            public TrieNode[] children;
            public bool isWord;

            public TrieNode()
            {
                children = new TrieNode[26];
                isWord = false;
            }
        }

        private TrieNode root;

        /** Initialize your data structure here. */
        public Trie()
        {
            this.root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var node = root;
            foreach (var c in word.ToCharArray())
            {
                if (node.children[c - 'a'] == null)
                {
                    node.children[c - 'a'] = new TrieNode();
                }
                node = node.children[c - 'a'];
            }
            node.isWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var node = root;
            foreach (var c in word.ToCharArray())
            {
                if (node.children[c - 'a'] == null)
                    return false;
                node = node.children[c - 'a'];
            }
            return node.isWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var node = root;
            foreach (var c in prefix.ToCharArray())
            {
                if (node.children[c - 'a'] == null)
                    return false;
                node = node.children[c - 'a'];
            }
            return true;
        }
    }

}
