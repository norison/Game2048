namespace Game2048.Core
{
    public interface ITile
    {
        int X { get; set; }
        int Y { get; set; }
        int Value { get; set; }
    }
}