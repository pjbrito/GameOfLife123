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

        public string GetCurrentGridVis()
        {
            return CreateVis(GetCurrentGrid());
        }

        public void NextGen()
        {
            /*  Any live cell (live to dead)
                1. with fewer than two live neighbours dies, as if caused by underpopulation.  < 2
                2. with more than three live neighbours dies, as if by overcrowding.           > 3

                Any live cell
                3. with two or three live neighbours lives on to the next generation.          = 2 or 3

                Any dead cell (dead to live)
                4. with exactly three live neighbours becomes a live cell.                     = 3
            */

            if (grid == null)
            {
                throw new Exception("Grid must be defined");
            }

            int[,] nextGenGrid = grid.Clone() as int[,];

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (LiveCell(grid[x, y]))
                    {
                        if (FewerThanTwoLiveNeighbours(grid, x, y))
                        {
                            nextGenGrid[x, y] = 0;
                        }
                        else if (MoreThanThreeLiveNeighbours(grid, x, y))
                        {
                            nextGenGrid[x, y] = 0;
                        }
                    }
                    else
                    {
                        if (ExactlyThreeLiveNeighbours(grid, x, y))
                        {
                            nextGenGrid[x, y] = 1;
                        }
                    }
                }
            }

            grid = nextGenGrid.Clone() as int[,];
        }

        private bool FewerThanTwoLiveNeighbours(int[,] grid, int xPosition, int yPosition)
        {
            var count = CountLiveNeighbours(grid, xPosition, yPosition);
            return count < 2;
        }

        private bool MoreThanThreeLiveNeighbours(int[,] grid, int xPosition, int yPosition)
        {
            var count = CountLiveNeighbours(grid, xPosition, yPosition);
            return count > 3;
        }

        private bool ExactlyThreeLiveNeighbours(int[,] grid, int xPosition, int yPosition)
        {
            if (LiveCell(grid[xPosition, yPosition]))
                throw new Exception("Something is wrong: this should only be called with dead cells!");

            var count = CountLiveNeighbours(grid, xPosition, yPosition);
            return count == 3;
        }

        private int CountLiveNeighbours(int[,] grid, int xPosition, int yPosition)
        {
            int count = 0;
            for (var x = xPosition - 1; x <= xPosition + 1; x++)
            {
                for (var y = yPosition - 1; y <= yPosition + 1; y++)
                {
                    if (x == xPosition && y == yPosition)
                        continue;

                    if (x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1))
                    {
                        if (LiveCell(grid[x, y])) count++;
                    }
                }
            }

            return count;
        }

        private bool LiveCell(int v)
        {
            return v == 1;
        }

        private string CreateVis(int[,] ints)
        {
            var vis = string.Empty;
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    vis += $"{ints[x, y]} ";
                }
                vis += "\n";
            }
            return vis;
        }
    }
}
