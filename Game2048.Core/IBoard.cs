namespace Game2048.Core
{
    public interface IBoard
    {
        int Size { get; }
        ITile[,] Get2DBoard();
        void MoveUp();
        void MoveRight();
        void MoveDown();
        void MoveLeft();
    }
}