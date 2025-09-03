using System;
using Game.Application.UseCases;

namespace Game.Presentation
{
    public class GameplayListener : IGameplayListener, IGameEndListener, ITurnCompleteListener, ICardMatchListener
    {
        public event Action<int> OnMatchesCountChangeEvent;
        public event Action<int> OnTurnsCountChangeEvent;
        public event Action OnGameEndEvent;

        public void OnGameEnded()
        {
            OnGameEndEvent?.Invoke();
        }

        public void OnTurnCompleted(int turnCount)
        {
            OnTurnsCountChangeEvent?.Invoke(turnCount);
        }

        public void OnCardMatched(int matchCount)
        {
            OnMatchesCountChangeEvent?.Invoke(matchCount);
        }

        public string GetMessage()
        {
            return "Gameplay Message!";
        }
    }
}