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
            if (x < 0 || x >= Sudoku.max) return false;
            if (y < 0 || y >= Sudoku.max) return false;
            if (digit <= 0 || digit > Sudoku.max) return false;
            
            if (map[x, y] != 0) return false;
            if (map[x, y] == digit) return true;

            for (int cx = 0; cx < Sudoku.max; cx++)
            {
                if (map[cx, y] == digit) return false;
            }            
            
            for (int cy = 0; cy < Sudoku.max; cy++)
            {
                if (map[x, cy] == digit) return false;
            }

            // The coordinates of the top-left corner of the current square
            int sx = Sudoku.sqr * (x / Sudoku.sqr);
            int sy = Sudoku.sqr * (y / Sudoku.sqr);

            for (int cx = sx; cx < sx + Sudoku.sqr; cx++)
            {
                for (int cy = sy; cy < sy + Sudoku.sqr; cy++)
                {
                    if (map[cx, cy] == digit) return false;
                }
            }
            
            map[x, y] = digit;
            PrintDigit(x, y, digit);

            return true;
        }
    }
}