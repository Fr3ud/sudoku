namespace Sudoku
{
    public delegate void dePrintDigit(int x, int y, int digit);
    public class Sudoku
    {
        public const int max = 9; // field size
        public const int sqr = 3; // square size
        
        public int [,] map { get; private set; }
        
        private dePrintDigit PrintDigit;

        public Sudoku(dePrintDigit printDigit)
        {
            map = new int[max, max];
            PrintDigit = printDigit;
            ClearMap();
        }

        private void ClearMap()
        {
            for (int x = 0; x < max; x++)
            {
                for (int y = 0; y < max; y++)
                {
                    map[x, y] = 0;
                }
            }
        }

        public bool PlaceDigit(int x, int y, int digit)
        {
            map[x, y] = digit;
            PrintDigit(x, y, digit);

            return true;
        }
    }
}