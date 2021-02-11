using System;
using System.IO;
using System.Threading;

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

            sudoku = new Sudoku(PrintDigit);
            // GenerateRandom();
            LoadSudoku("../../../sudoku.txt");
            Console.ForegroundColor = ConsoleColor.Green;
            sudoku.Solve();
        }

        private void GenerateRandom()
        {
            Random random = new Random();

            for (int x = 0; x < Sudoku.max; x++)
            {
                for (int y = 0; y < Sudoku.max; y++)
                {
                    sudoku.PlaceDigit(x, y, random.Next(0, Sudoku.max + 1));
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
            Thread.Sleep(100);
        }

        public void LoadSudoku(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int j = 0;
            for (int sqrY = 0; sqrY < Sudoku.sqr; sqrY++)
            {
                for (int sqrX = 0; sqrX < Sudoku.sqr; sqrX++)
                {
                    for (int boxY = 0; boxY < Sudoku.sqr; boxY++)
                    {
                        for (int boxX = 0; boxX < Sudoku.sqr; boxX++)
                        {
                            if (j < lines.Length)
                            {
                                if (lines[j].Length == 1)
                                {
                                    sudoku.PlaceDigit(
                                        sqrX * Sudoku.sqr + boxX,
                                        sqrY * Sudoku.sqr + boxY,
                                        Convert.ToInt32(lines[j]));
                                }
                                j++;
                            }
                        }
                    }
                }
            }
        }
    }
}