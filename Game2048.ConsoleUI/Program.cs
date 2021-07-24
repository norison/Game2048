using System;
using Game2048.Core;

namespace Game2048.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameRandomGenerator randomGenerator = new GameRandomGenerator();
            IBoard board = new Board(randomGenerator, 4);

            while (true)
            {
                PrintBoard(board);

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        board.MoveUp();
                        break;
                    case ConsoleKey.RightArrow:
                        board.MoveRight();
                        break;
                    case ConsoleKey.DownArrow:
                        board.MoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        board.MoveLeft();
                        break;
                }
            }
        }

        static void PrintBoard(IBoard board)
        {
            Console.Clear();

            ITile[,] board2D = board.Get2DBoard();

            for (int y = 0; y < board2D.GetLength(0); y++)
            {
                for (int x = 0; x < board2D.GetLength(1); x++)
                {
                    Console.Write("{0, 4}", board2D[y, x].Value);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
