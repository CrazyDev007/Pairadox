using System.Threading.Tasks;
using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public class CardMatchUseCase
    {
        // Callbacks
        private readonly IGameEndListener _gameEndListener;
        private readonly ICardMatchListener _cardMatchListener;
        private readonly ITurnCompleteListener _turnCompleteListener;

        private CardUseCase _firstSelected;
        private int TurnCount { get; set; }
        private int MatchCount { get; set; }
        private int TotalMatchCount { get; set; }

        private bool GameEnd { get; set; }

        public CardMatchUseCase(int totalMatchCount, IGameEndListener gameEndListener,
            ICardMatchListener cardMatchListener, ITurnCompleteListener turnCompleteListener)
        {
            TotalMatchCount = totalMatchCount;
            _gameEndListener = gameEndListener;
            _cardMatchListener = cardMatchListener;
            _turnCompleteListener = turnCompleteListener;
        }


        public void SelectCard(CardUseCase cardUseCase)
        {
            if (_firstSelected == null)
            {
                _firstSelected = cardUseCase;
                cardUseCase.CardListener.UpdateCardView(false, CardState.Flipping, CardState.Opened);
                return;
            }

            if (_firstSelected == cardUseCase)
            {
                _firstSelected = null;
                cardUseCase.CardListener.UpdateCardView(false, CardState.Flipping, CardState.Closed);
                return;
            }

            _ = RunCardProcess(_firstSelected, cardUseCase);
            _firstSelected = null;
        }

        private async Task RunCardProcess(CardUseCase cardUseCase1, CardUseCase cardUseCase2)
        {
            cardUseCase1.Card.IsLocked = true;
            cardUseCase2.CardListener.UpdateCardView(true, CardState.Flipping, CardState.Opened);

            await Task.Delay(1000);
            // compare with first
            if (cardUseCase1.GetCardID() == cardUseCase2.GetCardID())
            {
                cardUseCase1.CardListener.UpdateCardView(true, CardState.Matched, CardState.Matched);
                cardUseCase2.CardListener.UpdateCardView(true, CardState.Matched, CardState.Matched);

                MatchCount++;
                _cardMatchListener.OnCardMatched(MatchCount);
                if (MatchCount == TotalMatchCount)
                {
                    _gameEndListener.OnGameEnded();
                }
            }
            else
            {
                cardUseCase1.CardListener.UpdateCardView(false, CardState.Flipping, CardState.Closed);
                cardUseCase2.CardListener.UpdateCardView(false, CardState.Flipping, CardState.Closed);
            }

            TurnCount++;
            _turnCompleteListener.OnTurnCompleted(TurnCount);
        }
    }
}