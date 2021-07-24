namespace Game2048.Core
{
    public interface IGameRandomGenerator
    {
        int GetRandomValue();
        int GetRandomPosition(int max);
    }
}