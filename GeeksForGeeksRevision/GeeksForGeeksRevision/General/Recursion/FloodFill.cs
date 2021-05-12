using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.General.Recursion
{
    class FloodFill
    {
        public void FloodFillUtil(int[,] screen, int x, int y, int prevC, int newC)
        {
            if (x < 0 || y < 0 || x > screen.GetUpperBound(0) || y > screen.GetUpperBound(1))
            {
                return;
            }
            if (screen[x, y] != prevC)
                return;
            //replace the color
            screen[x, y] = newC;

            //recurse function
            FloodFillUtil(screen, x + 1, y, prevC, newC);
            FloodFillUtil(screen, x - 1, y, prevC, newC);
            FloodFillUtil(screen, x, y + 1, prevC, newC);
            FloodFillUtil(screen, x, y - 1, prevC, newC);
        }
    }
}
