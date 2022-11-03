namespace GameOfLife
{
    public class VisualizeGameOfLive
    {
        public void RunIterations(int v, string strArray)
        {
            var g = new GameOfLife(strArray);
            RunVisLoop(v, g);
        }

        public void RunIterations(int v, int[,] gameGrid)
        {
            var g = new GameOfLife(gameGrid);
            RunVisLoop(v, g);
        }

        private static void RunVisLoop(int v, GameOfLife gol)
        {
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
