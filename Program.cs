using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();

            Console.ReadKey();
        }

        public void Start()
        {
            PrintFrame();
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
    }
}