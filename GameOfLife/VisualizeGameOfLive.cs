namespace GameOfLife
{
    public class VisualizeGameOfLive
    {
        internal void RunIterations(int v, int[,] gameGrid)
        {
            var gol = new GameOfLife(gameGrid);
            for (var i = 0; i < v; i++)
            {
                var cur = gol.GetCurrentGridVis();
                Console.Clear();
                Console.WriteLine($"{i}\n");
                Console.WriteLine(cur);
                Thread.Sleep(300);
                gol.NextGen();
            }
        }
    }
}
