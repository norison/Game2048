using System;

namespace Game2048.Core
{
    public class GameRandomGenerator : IGameRandomGenerator
    {
        #region Private Fields

        private readonly Random _random;

        #endregion

        #region Constructor

        public GameRandomGenerator()
        {
            _random = new Random();
        }

        #endregion

        #region Public Methods

        public int GetRandomValue()
        {
            return _random.Next(0, 100) > 10 ? 2 : 4;
        }

        public int GetRandomPosition(int max)
        {
            return _random.Next(0, max);
        }

        #endregion
    }
}