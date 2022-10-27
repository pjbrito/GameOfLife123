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

        [Fact]
        public void NextGen_Cells_LiveWithTwoLiveNeighboursAt_1_0_AndDeadWithExactlyThreeLiveNeighboursAt_1_1_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 1, 1, 1 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
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
        public void NextGen_Cells_LiveWithTwoLiveNeighboursAt_0_1_AndDeadWithExactlyThreeLiveNeighboursAt_1_1_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 0, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 1, 1, 0 },
                { 0, 0, 0 }
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
        public void NextGen_Cells_LiveWithTwoLiveNeighboursAt_1_2_AndDeadWithExactlyThreeLiveNeighboursAt_1_1_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 1, 1, 1 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 }
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
        public void NextGen_Cells_LiveWithTwoLiveNeighboursAt_2_1_AndDeadWithExactlyThreeLiveNeighboursAt_1_1_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 1 },
                { 0, 0, 1 },
                { 0, 0, 1 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 1 },
                { 0, 0, 0 }
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
        public void NextGen_Cells_LiveWithTwoLiveNeighboursColumnX1At_1_1_AndTwoDeadWithExactlyThreeLiveNeighboursAt_0_1_n_2_1_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 0, 0 }
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
        public void NextGen_Cells_LiveWithTwoLiveNeighboursRowY1At_1_1_AndTwoDeadWithExactlyThreeLiveNeighboursAt_1_0_n_1_2_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 0, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 }
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
        public void NextGen_LiveCellWithTwoLiveNeighbours_Diagonal_1_At_1_1_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 1 },
                { 0, 1, 0 },
                { 1, 0, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
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
        public void NextGen_LiveCellWithTwoLiveNeighbours_Diagonal_2_At_1_1_ResultsInSameCellSurviving()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
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
        public void NextGen_resurrectAt_0_1_noResurrectAt_1_1_n_2_1_ignoredExtraComplexity()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 1, 1, 1 },
                { 0, 0, 0 },
                { 1, 0, 0 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 1, 0 },
                { 1, 0, 0 },
                { 0, 0, 0 }
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
        public void NextGen_resurrectAt_1_0_noResurrectAt_1_1_n_1_2_ignoredExtraComplexity()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 1, 0, 1 },
                { 0, 0, 1 },
                { 0, 0, 1 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 1, 0 },
                { 0, 0, 1 },
                { 0, 0, 0 }
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
        public void NextGen_resurrectAt_2_1_noResurrectAt_1_1_n_0_1_ignoredExtraComplexity()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 0, 0, 1 },
                { 0, 0, 0 },
                { 1, 1, 1 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 1 },
                { 0, 1, 0 }
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
        public void NextGen_resurrectAt_1_2_noResurrectAt_1_1_n_1_0_ignoredExtraComplexity()
        {
            //arrange
            int[,] startingGrid = new int[,]
            {
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 0, 1 }
            };

            int[,] expectedGrid = new int[,]
            {
                { 0, 0, 0 },
                { 1, 0, 0 },
                { 0, 1, 0 }
            };

            //act
            var gameOfLife = new GameOfLife.GameOfLife(startingGrid);
            gameOfLife.NextGen();
            int[,] output = gameOfLife.GetCurrentGrid();
            var test = gameOfLife.GetCurrentGridVis();

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