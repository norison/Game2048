using System;
using Game2048.Core;

namespace Game2048.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(4);

           var board2D = board.Get2DBoard();

            for (int y = 0; y < board2D.GetLength(0); y++)
            {
                for (int x = 0; x < board2D.GetLength(1); x++)
                {
                    Console.Write("{0, 4}", board2D[y, x].Value);
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
