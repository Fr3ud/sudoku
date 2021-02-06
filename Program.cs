using System;

namespace Sudoku
{
    class Program
    {
        Sudoku sudoku;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();

            Console.ReadKey();
        }

        public void Start()
        {
            PrintFrame();

            Random random = new Random();
            sudoku = new Sudoku(PrintDigit);

            for (int x = 0; x < Sudoku.max; x++)
            {
                for (int y = 0; y < Sudoku.max; y++)
                {
                    sudoku.PlaceDigit(x, y, random.Next(0, 10));
                }
            }
        }

        public void PrintFrame()
        {
            int frameSize = Sudoku.sqr + 1;
            string symbol = " ";
            for (int x = 0; x <= frameSize * Sudoku.sqr; x++)
            {
                for (int y = 0; y <= frameSize * Sudoku.sqr; y++)
                {
                    if (x % frameSize == 0 && y % frameSize == 0)
                    {
                        symbol = "+";
                    }
                    else if (x % frameSize == 0)
                    {
                        symbol = "|";
                    }
                    else if (y % frameSize == 0)
                    {
                        symbol = "-";
                    }
                    else
                    {
                        symbol = " ";
                    }
                    
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(symbol);
                }
            }
        }

        public void PrintDigit(int x, int y, int digit)
        {
            int px = 1 + x + x / Sudoku.sqr;
            int py = 1 + y + y / Sudoku.sqr;
            
            Console.SetCursorPosition(px, py);
            Console.Write(digit == 0 ? " " : digit.ToString());
        }
    }
}