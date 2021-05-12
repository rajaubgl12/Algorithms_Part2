using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Algorithms
{
    class PaintFill
    {
        public void FloodFill(int [,] screen, int x, int y, int newColor)
        {
            int prevColor = screen[x, y];
            FloodFillUtil(screen, x, y, prevColor, newColor);
        }

        private void FloodFillUtil(int[,] screen, int x, int y, int prevColor, int newColor)
        {
            if(x > screen.GetUpperBound(0) || y > screen.GetUpperBound(1) || x<0 || y<0)
            {
                return;
            }
            if (screen[x, y] != prevColor)
            {
                return;
            }
            screen[x, y] = newColor;
            FloodFillUtil(screen, x + 1, y, prevColor, newColor);
            FloodFillUtil(screen, x, y + 1, prevColor, newColor);
            FloodFillUtil(screen, x - 1, y, prevColor, newColor);
            FloodFillUtil(screen, x, y - 1, prevColor, newColor);
        }
    }
}
