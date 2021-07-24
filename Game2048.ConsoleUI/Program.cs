using System;
using Game2048.Core;

namespace Game2048.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ITileColorizer tileColorizer = new TileColorizer();
            IGameRandomGenerator randomGenerator = new GameRandomGenerator();
            IBoard board = new Board(randomGenerator, 4);
            IGamePrinter printer = new GamePrinter(tileColorizer, ConsoleColor.White, ConsoleColor.Black);
            IGameEngine gameEngine = new GameEngine(board, printer);

            gameEngine.Play();
        }
    }
}
