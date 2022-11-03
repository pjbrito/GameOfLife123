namespace GameOfLifeTests
{
    public class RuleTestsMoreThan3
    {
        [Fact]
        public void NextGen_4Rules_LiveCellWithMoreThan3LiveNeighboursDies1_ResultsInNoLiveCellAt_1_1()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 1, 1, 0, 1, 1 },
                { 0, 0, 1, 0, 0 },
                { 1, 1, 0, 1, 1 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0 }
            };

            //act
            var gameOfLife = new GameOfLife.GameOfLife(startingGrid);
            gameOfLife.NextGen();
            int[,] output = gameOfLife.GetCurrentGrid();
            var test = gameOfLife.GetCurrentGridVis();

            //assert
            Assert.True(GridsAreEqual(expectedGrid, output));
        }

        [Fact]
        public void NextGen_3Rules_LiveCellWithMoreThan3LiveNeighboursDies2_ResultsInNoLiveCellAt_1_1()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 1, 0, 0 },
                { 1, 1, 1, 1, 1 },
                { 0, 0, 1, 0, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 }
            };

            //act
            var gameOfLife = new GameOfLife.GameOfLife(startingGrid);
            gameOfLife.NextGen();
            int[,] output = gameOfLife.GetCurrentGrid();

            //assert
            Assert.True(GridsAreEqual(expectedGrid, output));
        }

        private bool GridsAreEqual(int[,] grid1, int[,] grid2)
        {
            return grid1.Rank == grid2.Rank &&
                Enumerable.Range(0, grid1.Rank).All(dimension => grid1.GetLength(dimension) == grid2.GetLength(dimension)) &&
                grid1.Cast<int>().SequenceEqual(grid2.Cast<int>());
        }
    }
}