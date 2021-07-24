using System.Collections.Generic;
using System.Linq;

namespace Game2048.Core
{
    public class Board : IBoard
    {
        #region Private Fields

        private readonly IGameRandomGenerator _randomGenerator;
        private readonly int _size;
        private readonly List<ITile> _tiles;

        #endregion

        #region Constructor

        public Board(IGameRandomGenerator randomGenerator, int size)
        {
            _randomGenerator = randomGenerator;
            _size = size;
            _tiles = new List<ITile>(_size * _size);

            FillBoardDefaultValues();
            FillNext();
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

        private bool FillNext()
        {
            var emptyTiles = _tiles.Where(x => x.Value == 0).ToList();

            if (emptyTiles.Count == 0)
            {
                return false;
            }

            var position = _randomGenerator.GetRandomPosition(emptyTiles.Count - 1);
            var value = _randomGenerator.GetRandomValue();
            emptyTiles[position].Value = value;
            return true;
        }

        #endregion
    }
}