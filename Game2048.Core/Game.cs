using System;

namespace Game2048.Core
{
    public class Game : IGame
    {
        private readonly IGameEngine _gameEngine;
        private readonly IBoard _board;

        public Game(IGameEngine gameEngine, IBoard board)
        {
            _gameEngine = gameEngine;
            _board = board;
        }

        public event Action<IBoard> DisplayRequired;

        public void Play()
        {
            var running = true;

            while (running)
            {
                DisplayRequired?.Invoke(_board);

                var command = _gameEngine.GetNextStepCommand();

                switch (command)
                {
                    case NextStepCommand.Up:
                        _board.MoveUp();
                        break;
                    case NextStepCommand.Down:
                        _board.MoveDown();
                        break;
                    case NextStepCommand.Right:
                        _board.MoveRight();
                        break;
                    case NextStepCommand.Left:
                        _board.MoveLeft();
                        break;
                    case NextStepCommand.Quit:
                        running = false;
                        break;
                }

                if (!_board.NextStepAvailable())
                {
                    running = false;
                }
            }
        }
    }
}