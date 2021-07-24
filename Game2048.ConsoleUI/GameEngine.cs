using System;
using Game2048.Core;

namespace Game2048.ConsoleUI
{
    public class GameEngine : IGameEngine
    {
        private readonly IBoard _board;
        private readonly IGamePrinter _printer;

        public GameEngine(IBoard board, IGamePrinter printer)
        {
            _board = board;
            _printer = printer;
        }

        public void Play()
        {
            while (true)
            {
                _printer.PrintBoard(_board.Get2DBoard(), _board.Score, _board.Steps);

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        _board.MoveUp();
                        break;
                    case ConsoleKey.RightArrow:
                        _board.MoveRight();
                        break;
                    case ConsoleKey.DownArrow:
                        _board.MoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        _board.MoveLeft();
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}