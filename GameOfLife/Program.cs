namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //var game = new int[,]
            //{
            //    { 0, 1, 0, 0 },
            //    { 0, 1, 0, 0 },
            //    { 0, 1, 0, 0 },
            //    { 0, 1, 0, 0 }
            //};

            var game = new int[,]
            {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 },
            };
            (new VisualizeGameOfLive()).RunIterations(100, game);
        }
    }
}