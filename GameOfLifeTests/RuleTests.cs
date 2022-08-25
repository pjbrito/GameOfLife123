namespace GameOfLifeTests
{
    public class RuleTests
    {
        [Fact]
        public void GetCurrentGrid_BasicGridWith1LiveCellNoGenerations_ShouldReturnSameGrid()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };

            //act
            var gameOfLife = new GameOfLife.GameOfLife(startingGrid);
            int[,] output = gameOfLife.GetCurrentGrid();

            //assert
            Assert.True(GridsAreEqual(startingGrid, output));
        }

        [Fact]
        public void NextGen_LiveCellWithNoLiveNeighbours_ResultsInNoLiveCells()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
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