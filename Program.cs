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

            sudoku = new Sudoku(PrintDigit, SaveAnswer);
            // LoadSudoku("../../../sudoku.txt");
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                GenerateRandom(30);
                Console.ForegroundColor = ConsoleColor.Green;
            } while (!sudoku.Solve());
        }

        private void GenerateRandom(int count)
        {
            Random random = new Random();
            
            if (count == 0) return;
            if (count > Sudoku.max * Sudoku.max) return;

            sudoku.ClearMap();

            for (int c = 0; c < count; c++)
            {
                int x, y, d;
                int loop = 500;
                
                do
                {
                    x = random.Next(0, Sudoku.max);
                    y = random.Next(0, Sudoku.max);
                    d = random.Next(1, Sudoku.max + 1);
                } while (--loop > 0 && !sudoku.PlaceDigit(x, y, d));

            }
        }

        public void PrintFrame()
        {
            int frameSize = Sudoku.sqr + 1;
            string symbol = " ";
            for (int px = 0; px <= frameSize * Sudoku.sqr; px++)
            {
                for (int py = 0; py <= frameSize * Sudoku.sqr; py++)
                {
                    if (px % frameSize == 0 && py % frameSize == 0)
                    {
                        symbol = "+";
                    }
                    else if (px % frameSize == 0)
                    {
                        symbol = "|";
                    }
                    else if (py % frameSize == 0)
                    {
                        symbol = "-";
                    }
                    else
                    {
                        symbol = " ";
                    }
                    
                    Console.SetCursorPosition(px, py);
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
            // Thread.Sleep(1);
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

        public void SaveAnswer()
        {
            using (StreamWriter file = new StreamWriter("../../../solver.txt"))
            {
                int frameSize = Sudoku.sqr + 1;
                string symbol = " ";
                for (int py = 0; py <= frameSize * Sudoku.sqr; py++)
                {
                    for (int px = 0; px <= frameSize * Sudoku.sqr; px++)
                    {
                        if (px % frameSize == 0 && py % frameSize == 0)
                        {
                            symbol = "+";
                        }
                        else if (px % frameSize == 0)
                        {
                            symbol = "|";
                        }
                        else if (py % frameSize == 0)
                        {
                            symbol = "-";
                        }
                        else
                        {
                            int x = px - 1 - px / (Sudoku.sqr + 1);
                            int y = py - 1 - py / (Sudoku.sqr + 1);
                            symbol = sudoku.map[x, y].ToString();
                        }
                    
                        file.Write(symbol);
                    }
                    
                    file.WriteLine();
                }
                Console.SetCursorPosition(0, 14);
                Console.WriteLine("SOLVED");
                Console.ReadKey();
            }
        }
    }
}