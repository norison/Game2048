namespace Game2048.Core
{
    public class Tile : ITile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }
}