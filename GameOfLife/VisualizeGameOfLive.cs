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
                cur = cur.Replace("0", " ");
                Console.Clear();
                Console.WriteLine($"{i}\n");
                Console.WriteLine(cur);
                Thread.Sleep(200);
                gol.NextGen();
            }
        }
    }
}
