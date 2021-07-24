namespace Game2048.Core
{
    public interface IGameEngine
    {
        public NextStepCommand GetNextStepCommand();
    }
}