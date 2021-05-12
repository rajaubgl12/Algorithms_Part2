using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.Graphss
{
   public class NoOfIslands
    {
        public int NoOfIslandsCount(int [,] islands)
        {
            int count = 0;
            int rows = islands.GetLength(0);
            int cols = islands.GetLength(1);
            bool[,] isVisited = new bool[rows, cols];
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if (islands[i, j]==1 && !isVisited[i, j])
                    {
                        
                        CheckSarroundingIslands(islands, i, j,isVisited);

                        count++;
                    }
                }
            }

            return count;
        }

        private void CheckSarroundingIslands(int[,] islands, int i, int j, bool[,] isVisited)
        {
            if (i < 0 || j < 0 || i >= islands.GetLength(0) ||
                j >= islands.GetLength(1) || islands[i, j] == 0 || (isVisited[i, j]))
                return;
            else
            {
                isVisited[i, j] = true;
                CheckSarroundingIslands(islands, i, j + 1, isVisited);
                CheckSarroundingIslands(islands, i, j - 1, isVisited);
                CheckSarroundingIslands(islands, i + 1, j, isVisited);
                CheckSarroundingIslands(islands, i - 1, j, isVisited);
            }
        }

        class RowsCols
        {
            public int row;
            public int col;
        }

        

        public int NoOfIslandsCountDistinct(int[,] islands)
        {
            int count = 0;
            int rows = islands.GetLength(0);
            int cols = islands.GetLength(1);
            bool[,] isVisited = new bool[rows, cols];
            List<RowsCols> lstIsland;// = new List<RowsCols>();
            List<List<RowsCols>> lstOfIslandLst = new List<List<RowsCols>>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (islands[i, j] == 1 && !isVisited[i, j])
                    {
                        lstIsland = new List<RowsCols>();
                        CheckSarroundingIslandsDistinct(islands, i, j, isVisited,lstIsland);
                        //count++;
                        lstOfIslandLst.Add(new List<RowsCols>(lstIsland));
                    }
                }
            }
            return DistinctIslands(lstOfIslandLst);            
        }

        private int DistinctIslands(List<List<RowsCols>> lstOfIslandLst)
        {
            lstOfIslandLst.Sort();
            int countRemove = 0;
            for(int i=1;i<lstOfIslandLst.Capacity;i++)
            {
                if(lstOfIslandLst[i-1].Capacity==lstOfIslandLst[i].Capacity)
                {
                    if (CompareTwoList(lstOfIslandLst[i - 1], lstOfIslandLst[i]))
                        countRemove++;
                }
            }

            return lstOfIslandLst.Count- countRemove;
        }

        private bool CompareTwoList(List<RowsCols> list1, List<RowsCols> list2)
        {
            for(int i=1;i<list1.Count;i++)
            {
                int lstCount1 = CompareTwoRowCols(list1[i - 1], list1[i]);
                int lstCount2 = CompareTwoRowCols(list2[i - 1], list2[i]);
                if(lstCount1!=lstCount2)
                {
                    return true;
                }
            }
            return false;
        }

        private int CompareTwoRowCols(RowsCols rowsCols1, RowsCols rowsCols2)
        {
            // throw new NotImplementedException();
            int countDiff = 0;
            if (Math.Abs(rowsCols1.row - rowsCols2.row) > 0)
                countDiff++;
            if (Math.Abs(rowsCols1.col - rowsCols2.col) > 0)
                countDiff++;
            return countDiff;
        }

        private void CheckSarroundingIslandsDistinct(int[,] islands, int i, int j, bool[,] isVisited, List<RowsCols> lstIsland)
        {
            if (i < 0 || j < 0 || i >= islands.GetLength(0) ||
                j >= islands.GetLength(1) || islands[i, j] == 0 || (isVisited[i, j]))
                return;
            else
            {
                isVisited[i, j] = true;
                RowsCols objRC = new RowsCols();
                objRC.row = i;
                objRC.col = j;                
                lstIsland.Add(objRC);

                CheckSarroundingIslandsDistinct(islands, i, j + 1, isVisited, lstIsland);
                CheckSarroundingIslandsDistinct(islands, i, j - 1, isVisited, lstIsland);
                CheckSarroundingIslandsDistinct(islands, i + 1, j, isVisited, lstIsland);
                CheckSarroundingIslandsDistinct(islands, i - 1, j, isVisited, lstIsland);
            }
        }

    }
}
