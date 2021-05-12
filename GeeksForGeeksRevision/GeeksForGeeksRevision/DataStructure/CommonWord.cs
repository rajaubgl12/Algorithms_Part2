using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DataStructure
{
    /// <summary>
    /// Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  It is guaranteed there is at least one word that isn't banned, and that the answer is unique.
    //Words in the list of banned words are given in lowercase, and free of punctuation.Words in the paragraph are not case sensitive.The answer is in lowercase.
    //Example:
    //Input: 
    //paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
    //banned = ["hit"]
    //Output: "ball"
    //Explanation: 
    //"hit" occurs 3 times, but it is a banned word.
    //"ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph.
    //Note that words in the paragraph are not case sensitive,
    //that punctuation is ignored (even if adjacent to words, such as "ball,"), 
    //and that "hit" isn't the answer even though it occurs more because it is banned.
    /// </summary>
    public class CommonWord
    {
        string mostCommonWord = "";
        int maxFreq = 0;
        TrieNode5 root;
        public CommonWord()
        {
            root = new TrieNode5();
        }
        public string MostCommonWord(string paragraph, string[] banned)
        {
            string[] wrds = paragraph.Split(' ');
            for (int i = 0; i < wrds.Length; i++)
            {
                AddWord(wrds[i].ToLower());
            }
            
            for(int i=0;i<banned.Length;i++)
            {
                AddBannedWord(banned[i].ToLower());
            }
            
            for (int i = 0; i < wrds.Length; i++)
            {
                SearchCommonWord(wrds[i].ToLower());
            }

            return mostCommonWord;
        }

        private void SearchCommonWord(string wrd)
        {
            TrieNode5 temp = root;
           
            for (int i = 0; i < wrd.Length; i++)
            {
                int charIndex = wrd[i] - 'a';
                if (charIndex > 26 || charIndex < 0)
                {
                    continue;
                }
                else if (temp.childrens[charIndex] != null)
                {
                    temp = temp.childrens[charIndex];
                }
               
            }
            if(temp.isEndofWord&&!temp.isBanned&&maxFreq<temp.freq)
            {
                maxFreq = temp.freq;
                mostCommonWord = temp.wrdName;
            }
            
        }


        private void AddWord(string wrd)
        {
            TrieNode5 temp = root;
            bool isRepeated = true;
            for(int i=0;i<wrd.Length;i++)
            {
                int charIndex = wrd[i] - 'a';
                if (charIndex > 26 || charIndex < 0)
                {
                    continue;
                }
                else if(temp.childrens[charIndex]==null)
                {
                    isRepeated = false;
                    temp.childrens[charIndex] = new TrieNode5();                    
                }

                temp = temp.childrens[charIndex];
            }
            temp.wrdName = wrd;
            temp.isEndofWord = true;
            temp.isBanned = false;
            if (isRepeated)
            {
                temp.freq += 1;
            }
            else
            {
                temp.freq = 1;
            }
            
        }

        private void AddBannedWord(string wrd)
        {
            TrieNode5 temp = root;
            
            for (int i = 0; i < wrd.Length; i++)
            {
                int charIndex = wrd[i] - 'a';
                if (charIndex > 26 || charIndex < 0)
                {
                    continue;
                }
                else if (temp.childrens[charIndex] == null)
                {            
                    temp.childrens[charIndex] = new TrieNode5();
                    
                }
                temp = temp.childrens[charIndex];
            }
            temp.isEndofWord = true;
            temp.isBanned = true;
            temp.wrdName = wrd;
        }
    }
    public class TrieNode5
    {
        public TrieNode5[] childrens;
        public bool isEndofWord;
        public bool isBanned;
        public int freq;
        public string wrdName;
        public TrieNode5()
        {
            childrens = new TrieNode5[26];
            isEndofWord = false;
            isBanned = false;
            freq = 0;
        }
    }
}
