using Game2048.Core;

namespace Game2048.ConsoleUI
{
    public interface IGamePrinter
    {
        void PrintBoard(ITile[,] board2DArray, int score, int steps);
    }
}