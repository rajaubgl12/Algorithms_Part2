using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class TestPrograms
    {
        //public int BuySellStock(int [] arrStock)
        //{

        //}

        public Dictionary<string, int> map;

        public void TestCompareList()
        {
            string[] wrds = { "i love you", "island", "ironman", "i love leetcode" };
            int[] counts = { 5, 3, 2, 2 };
            CustomCompareTest obj1 = new CustomCompareTest();
            map = new Dictionary<string, int>();
           
            List<string> lstFreq = new List<string>();
            //map = new Dictionary<string, int>();
            for(int i=0;i<wrds.Length;i++)
            {
                map.Add(wrds[i], counts[i]);
                lstFreq.Add(wrds[i]);
            }

            lstFreq.Sort((a, b) => map[a] == map[b]
                ? string.Compare(a, b, StringComparison.Ordinal)
                : map[b] - map[a]);

            //lstFreq.Sort(obj1);
        }

        public void FloodFillAlgorithm(int[,] matrix, int x, int y, int prevC, int newC)
        {
            if (x > matrix.GetUpperBound(0) || y > matrix.GetLowerBound(0))
                return;
            if (matrix[x,y] != prevC)
            {
                return;
            }
            matrix[x,y] = newC;
            FloodFillAlgorithm(matrix, x + 1, y, prevC, newC);
            FloodFillAlgorithm(matrix, x - 1, y, prevC, newC);
            FloodFillAlgorithm(matrix, x, y + 1, prevC, newC);
            FloodFillAlgorithm(matrix, x, y - 1, prevC, newC);
        }
    }
    public class CustomCompareTest : IComparer<KeyValuePair<string,int>>
    {
        
        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            if (x.Value==y.Value)
            {
                return x.Key.CompareTo(y.Key);
            }
            else
                return x.Value > y.Value ? 1 : -1;
        }
    }
}
