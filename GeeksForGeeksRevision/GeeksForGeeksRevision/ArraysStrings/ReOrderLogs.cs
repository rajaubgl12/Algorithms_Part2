using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.ArraysStrings
{
   public class ReOrderLogs
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            customcompare obj = new customcompare();
            Array.Sort(logs, obj);
            return logs;
        }
        class customcompare : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                string[] s1 = x.Split(' ');
                string[] s2 = y.Split(' ');
                if (char.IsLetter(s1[1][0]) && char.IsDigit(s2[1][0]))
                    return -1;
                else
                    return 1;
            }
        }
    }
}
