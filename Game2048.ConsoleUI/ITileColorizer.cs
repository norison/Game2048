using System;

namespace Game2048.ConsoleUI
{
    public interface ITileColorizer
    {
        ConsoleColor GetColorByValue(int value);
    }
}