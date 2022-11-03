namespace GameOfLife
{
    public class ConvertSpacesAndXsInto2DMultiDimensionalArray
    {
        public int[,] Convert(string arrayStr)
        {
            arrayStr = arrayStr.Replace("\r", "");
            var stringLines = arrayStr.Split("\n");
            var numRows = CountCharsInString('\n', arrayStr);
            var numCols = stringLines[0].Length;

            var ret = new int[numRows, numCols];
            for (var row = 0; row < ret.GetLength(0); row++)
            {
                var curRow = stringLines[row] ?? string.Empty;
                for (var col = 0; col < ret.GetLength(1); col++)
                {
                    var tmp = curRow[col];
                    int num;
                    if (tmp == ' ')
                        num = 0;
                    else if (tmp.ToString().ToLower() == "x")
                        num = 1;
                    else
                        throw new ApplicationException("this is unexpected - investigate");

                    ret[row, col] = num;
                }
            }

            return ret;
        }

        private int CountCharsInString(char target, string str)
        {
            var str1 = $"{str}";
            return (str1?.Split(target, StringSplitOptions.None).Length) ?? 0;
        }

    }
}
