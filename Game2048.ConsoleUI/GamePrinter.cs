using Game2048.Core;
using System;

namespace Game2048.ConsoleUI
{
    public class GamePrinter : IGamePrinter
    {
        private readonly ITileColorizer _colorizer;

        public GamePrinter(ITileColorizer colorizer, ConsoleColor background, ConsoleColor foreground)
        {
            _colorizer = colorizer;

            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public void PrintBoard(ITile[,] board2DArray, int score, int steps)
        {
            Console.Clear();

            Console.WriteLine($"Score: {score}. Steps: {steps}");

            for (int y = 0; y < board2DArray.GetLength(0); y++)
            {
                for (int x = 0; x < board2DArray.GetLength(1); x++)
                {
                    var value = board2DArray[y, x].Value;

                    Console.ForegroundColor = _colorizer.GetColorByValue(value);
                    Console.Write("{0, 4}", value);
                }

                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Press q to exit, use arrow keys for game");
        }
    }
}