using System.Collections.Generic;

namespace Game2048.Core
{
    public class Board : IBoard
    {
        #region Private Fields

        private readonly int _size;
        private readonly List<ITile> _tiles;

        #endregion

        #region Constructor

        public Board(int size)
        {
            _size = size;
            _tiles = new List<ITile>(_size * _size);

            FillBoardDefaultValues();
        }

        #endregion

        #region Public Methods

        public ITile[,] Get2DBoard()
        {
            ITile[,] result = new ITile[_size, _size];

            foreach (var tile in _tiles)
            {
                result[tile.Y, tile.X] = tile;
            }

            return result;
        }

        #endregion

        #region Private Methods

        private void FillBoardDefaultValues()
        {
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    _tiles.Add(new Tile { Y = y, X = x });
                }
            }
        }

        #endregion
    }
}