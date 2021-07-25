using System;
using Game2048.Core;

namespace Game2048.ConsoleUI
{
    public class ConsoleGameEngine : IGameEngine
    {
        public NextStepCommand GetNextStepCommand()
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    return NextStepCommand.Up;
                case ConsoleKey.DownArrow:
                    return NextStepCommand.Down;
                case ConsoleKey.LeftArrow:
                    return NextStepCommand.Left;
                case ConsoleKey.RightArrow:
                    return NextStepCommand.Right;
                case ConsoleKey.R:
                    return NextStepCommand.Restart;
                case ConsoleKey.Q:
                    return NextStepCommand.Quit;
            }

            return NextStepCommand.Default;
        }
    }
}