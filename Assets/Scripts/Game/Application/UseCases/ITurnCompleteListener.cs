namespace Game.Application.UseCases
{
    public interface ITurnCompleteListener
    {
        void OnTurnCompleted(int turnCount);
    }
}