using System;

namespace Game2048.Core
{
    public interface IGame
    {
        event Action<IBoard> DisplayRequired;
        void Play();
    }
}