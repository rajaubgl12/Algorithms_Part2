using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DataStructure
{
    public class TrieNode3
    {
        public TrieNode3[] children;
        public bool isEndOfWord;
        public TrieNode3()
        {
            children = new TrieNode3[27];
            isEndOfWord = false;
        }
    }

    public class AddSearchWord
    {
        TrieNode3 root;
        /** Initialize your data structure here. */
        public AddSearchWord()
        {
            root = new TrieNode3();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            TrieNode3 temp = root;
            for(int i=0;i<word.Length;i++)
            {                
                if(temp.children[word[i]-'a']==null)
                {
                    temp.children[word[i] - 'a'] = new TrieNode3();
                }
                temp = temp.children[word[i] - 'a'];
            }
            temp.isEndOfWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            TrieNode3 temp = root;
            for (int i = 0; i < word.Length; i++)
            {
                //doesn't work solve it recursively.
                if (word[i] == '.')
                {
                    temp = temp.children[word[i] - 'a'];
                    continue;
                }
                
                if (temp.children[word[i] - 'a'] == null)
                {
                    return false;
                }
                temp = temp.children[word[i] - 'a'];
            }
            return true;
        }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
}
