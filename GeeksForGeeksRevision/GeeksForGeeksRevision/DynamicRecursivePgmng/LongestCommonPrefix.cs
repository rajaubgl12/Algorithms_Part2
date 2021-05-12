using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.DynamicRecursivePgmng
{
    class LongestCommonPrefix
    {
        public string LongestCommonPrefixString(string [] strArrays)
        {
            string prefixStr = strArrays[0];
            for(int i=1;i<strArrays.Length;i++)
            {
                prefixStr = CommonPrefixString(strArrays[i], prefixStr);
            }
            return prefixStr;
        }

        private string CommonPrefixString(string s1, string s2)
        {
            int startIndex = 0;
            string strPrefix = "";
            if (string.IsNullOrWhiteSpace(s1) && string.IsNullOrWhiteSpace(s2))
                return "";
            if(string.IsNullOrWhiteSpace(s1))
            {
                return s2;
            }
            if(string.IsNullOrWhiteSpace(s2))
            {
                return s1;
            }

            while(startIndex<s1.Length&&startIndex<s2.Length)
            {
                if(s1[startIndex]!=s2[startIndex])
                {
                    break;
                }
                strPrefix += s1[startIndex];
                startIndex++;
            }
            return strPrefix;
        }

        //improvement
        // Get min len among the array of strings
        //find common prefix string accross all strings
        public string LongestCommonPrefixStringImprove(string [] strArrays)
        {
            int minLen = int.MaxValue;
            for(int i=0;i<strArrays.Length;i++)
            {
                minLen = Math.Min(minLen, strArrays[i].Length);
            }

            string commonPref = "";
            for(int i=0;i<minLen;i++)
            {
                for(int j=1;j<strArrays.Length;j++)
                {
                    if(strArrays[j-1][i]!= strArrays[j][i])
                    {
                        return commonPref;
                    }
                }
                commonPref += strArrays[0][i];
            }

            return commonPref;
        }
    }
}
