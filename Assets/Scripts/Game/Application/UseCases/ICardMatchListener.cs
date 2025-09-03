namespace Game.Application.UseCases
{
    public interface ICardMatchListener
    {
        void OnCardMatched(int  matchCount);
    }
}