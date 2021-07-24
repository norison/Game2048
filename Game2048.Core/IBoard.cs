namespace Game2048.Core
{
    public interface IBoard
    {
        int Score { get; }
        int Size { get; }
        int Steps { get; set; }
        ITile[,] Get2DBoard();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        bool NextStepAvailable();
    }
}