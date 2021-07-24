using System;
using System.Collections.Generic;

namespace Game2048.ConsoleUI
{
    public static class TileColorizer
    {
        private static readonly Dictionary<int, ConsoleColor> _colors = new()
        {
            { 2, ConsoleColor.Black },
            { 4, ConsoleColor.Gray },
            { 8, ConsoleColor.Green },
            { 16, ConsoleColor.DarkGreen },
            { 32, ConsoleColor.Magenta },
            { 64, ConsoleColor.DarkMagenta },
            { 128, ConsoleColor.Cyan },
            { 256, ConsoleColor.DarkCyan },
            { 512, ConsoleColor.Red },
            { 1024, ConsoleColor.DarkRed },
            { 2048, ConsoleColor.Blue },
            { 4096, ConsoleColor.DarkBlue },
            { 8192, ConsoleColor.Yellow },
            { 16384, ConsoleColor.DarkYellow }
        };

        public static ConsoleColor GetColorByValue(int value)
        {
            return _colors.TryGetValue(value, out var color) ? color : ConsoleColor.Black;
        }
    }
}