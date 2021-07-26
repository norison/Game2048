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
        public int Size { get; }
        public int Steps { get; private set; }

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

        public bool NextStepAvailable()
        {
            return GetEmptyTiles().Any() || HasEqualInVector(x => x.Y) || HasEqualInVector(x => x.X);
        }

        public void Restart()
        {
            Score = 0;
            Steps = 0;

            FillBoardDefaultValues();
            FillNext();
        }

        #endregion

        #region Private Methods

        private List<Tile> GetEmptyTiles()
        {
            return _tiles.Where(x => x.Value == 0).ToList();
        }

        private bool HasEqualInVector(Func<Tile, int> predicate)
        {
            for (int c = 0; c < Size; c++)
            {
                var col1 = new List<Tile>(_tiles.Where(x => predicate(x) == c));
                for (int i = 0; i < Size - 1; i++)
                    if (col1[i].Value == col1[i + 1].Value)
                        return true;
            }
            return false;
        }

        private void FillBoardDefaultValues()
        {
            _tiles.Clear();

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    _tiles.Add(new Tile { Y = y, X = x });
                }
            }
        }

        private void FillNext()
        {
            var emptyTiles = GetEmptyTiles();

            if (emptyTiles.Count == 0)
            {
                return;
            }

            var position = _randomGenerator.GetRandomPosition(emptyTiles.Count - 1);
            var value = _randomGenerator.GetRandomValue();
            emptyTiles[position].Value = value;
        }

        private void Move(Func<Tile, int> predicate, bool up)
        {
            Steps++;
            for (int c = 0; c < Size; c++)
            {
                var col = new List<Tile>(_tiles.Where(x => predicate(x) == c));

                for (int i = 0; i < Size - 1; i++)
                    if (up)
                        MoveP(col);
                    else
                        MoveN(col);
            }

            FillNext();
        }

        private void MoveN(List<Tile> col)
        {
            for (var y = Size - 1; y > 0; y--)
            {
                if (col[y].Value == col[y - 1].Value || col[y].Value == 0)
                {
                    if (col[y].Value == col[y - 1].Value)
                        Score += col[y].Value;
                    col[y].Value += col[y - 1].Value;
                    col[y - 1].Value = 0;
                }
            }
        }

        private void MoveP(List<Tile> col)
        {
            for (sbyte y = 0; y < Size - 1; y++)
            {
                if (col[y].Value == col[y + 1].Value || col[y].Value == 0)
                {
                    if (col[y].Value == col[y + 1].Value)
                        Score += col[y].Value;
                    col[y].Value += col[y + 1].Value;
                    col[y + 1].Value = 0;
                }
            }
        }

        #endregion
    }
}