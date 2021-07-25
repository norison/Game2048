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
            IGameEngine gameEngine = new ConsoleGameEngine();
            IGame game = new Game(gameEngine, board);

            game.DisplayRequired += PrintBoard;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            game.Play();

            game.DisplayRequired -= PrintBoard;

            Console.WriteLine("Game over");
            Console.ReadKey();
        }

        static void PrintBoard(IBoard board)
        {
            Console.Clear();

            var board2D = board.Get2DBoard();

            Console.WriteLine($"Used {board.Steps} steps, score {board.Score}" + Environment.NewLine);

            for (int y = 0; y < board2D.GetLength(0); y++)
            {
                for (int x = 0; x < board2D.GetLength(1); x++)
                {
                    var value = board2D[y, x].Value;
                    Console.ForegroundColor = TileColorizer.GetColorByValue(value);
                    Console.Write("{0, 4}", value);
                }

                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Press q to exit, r to restart, use arrows to play.");
        }
    }
}
