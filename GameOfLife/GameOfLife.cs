using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameOfLife
    {
        private int[,] grid;

        public GameOfLife(int[,] grid)
        {
            this.grid = grid;
        }

        public int[,] GetCurrentGrid()
        {
            return grid;
        }

        public void NextGen()
        {
            if (grid == null)
            {
                throw new Exception("Grid must be defined");
            }

            int[,] nextGenGrid = grid.Clone() as int[,];

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (LiveCell(grid[x,y]))
                    {
                        if (FewerThanTwoLiveNeighbours(grid, x, y))
                        {
                            nextGenGrid[x, y] = 0;
                        }
                        //else if (MoreThanThreeLiveNeighbours(grid[i, j]))
                        //{
                        //    nextGenGrid[i, j] = 0;
                        //}
                    }
                    //else
                    //{
                    //    if (ExactlyThreeLiveNeighbours(grid[i, j]))
                    //    {
                    //        nextGenGrid[i, j] = 1;
                    //    }
                    //}
                }
            }

            grid = nextGenGrid.Clone() as int[,];
        }

        private bool FewerThanTwoLiveNeighbours(int[,] grid, int xPosition, int yPosition)
        {
            int count = 0;
            for (var x = xPosition -1; x < xPosition + 1; x++)
            {
                for (var y = yPosition - 1; y < yPosition + 1; y++)
                {
                    if(x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1))
                    {
                        if (LiveCell(grid[x, y])) count++;
                    }
                }
            }
            return count < 2;
        }

        private bool LiveCell(int v)
        {
            return v == 1;
        }
    }
}
