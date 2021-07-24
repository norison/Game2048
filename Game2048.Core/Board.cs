using System;
using System.Collections.Generic;
using System.Linq;

namespace Game2048.Core
{
    public class Board : IBoard
    {
        #region Private Fields

        private readonly IGameRandomGenerator _randomGenerator;
        private readonly List<Tile> _tiles;

        #endregion

        #region Properties

        public int Score { get; private set; }
        public int Size { get; private set; }

        #endregion

        #region Constructor

        public Board(IGameRandomGenerator randomGenerator, int size)
        {
            _randomGenerator = randomGenerator;
            Size = size;
            _tiles = new List<Tile>(Size * Size);

            FillBoardDefaultValues();
            FillNext();
        }

        #endregion

        #region Public Methods

        public ITile[,] Get2DBoard()
        {
            var result = new ITile[Size, Size];

            foreach (var tile in _tiles)
            {
                result[tile.Y, tile.X] = new Tile { Y = tile.Y, X = tile.X, Value = tile.Value };
            }

            return result;
        }

        public void MoveDown()
        {
            Move(x => x.X, false);
        }

        public void MoveLeft()
        {
            Move(x => x.Y, true);
        }

        public void MoveRight()
        {
            Move(x => x.Y, false);
        }

        public void MoveUp()
        {
            Move(x => x.X, true);
        }

        #endregion

        #region Private Methods

        private void FillBoardDefaultValues()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
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

        private void Move(Func<Tile, int> predicate, bool up)
        {
            for (int c = 0; c < Size; c++)
            {
                var col1 = new List<Tile>(_tiles.Where(x => predicate(x) == c));

                for (int i = 0; i < Size - 1; i++)
                    if (up)
                        MoveP(col1);
                    else
                        MoveN(col1);
            }

            FillNext();
        }

        private void MoveN(List<Tile> col1)
        {
            for (sbyte y1 = (sbyte)(Size - 1); y1 > 0; y1--)
            {
                if (col1[y1].Value == col1[y1 - 1].Value || col1[y1].Value == 0)
                {
                    if (col1[y1].Value == col1[y1 - 1].Value)
                        Score += col1[y1].Value;
                    col1[y1].Value = col1[y1].Value + col1[y1 - 1].Value;
                    col1[y1 - 1].Value = 0;
                }
            }
        }

        private void MoveP(List<Tile> col1)
        {
            for (sbyte y1 = 0; y1 < Size - 1; y1++)
            {
                if (col1[y1].Value == col1[y1 + 1].Value || col1[y1].Value == 0)
                {
                    if (col1[y1].Value == col1[y1 + 1].Value)
                        Score += col1[y1].Value;
                    col1[y1].Value = col1[y1].Value + col1[y1 + 1].Value;
                    col1[y1 + 1].Value = 0;
                }
            }
        }

        #endregion
    }
}