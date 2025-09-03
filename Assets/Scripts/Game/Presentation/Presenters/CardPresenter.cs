using System.Threading.Tasks;
using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Presentation.Views;
using UnityEngine;

namespace Game.Presentation.Presenters
{
    public class CardPresenter : ICardListener
    {
        private readonly ICardView _cardView;
        private readonly CardEntity _card;
        private readonly CardUseCase _cardUseCase;
        private readonly CardMatchUseCase _cardMatchUseCase;

        public CardPresenter(ICardView cardView, CardEntity card, CardUseCase cardUseCase,
            CardMatchUseCase cardMatchUseCase)
        {
            _cardView = cardView;
            _card = card;
            _cardUseCase = cardUseCase;
            _cardMatchUseCase = cardMatchUseCase;
            //CardUseCase.SetCardID(_cardEntity, Random.Range(0, 2));
            _cardUseCase.CardListener = this;
        }

        public void Initialize()
        {
            UpdateCardView(false, CardState.Flipping, CardState.Closed);
            UpdateCardIDView();
        }

        public void OnCardClicked()
        {
            if (!_card.CanFlip()) return;
            _cardMatchUseCase.SelectCard(_cardUseCase);
        }

        private void UpdateCardStateView()
        {
            if (_cardUseCase.IsOpen())
                _cardView.OpenCard();
            else if (_cardUseCase.IsClose())
                _cardView.CloseCard();
            else if (_cardUseCase.IsMatched())
                _cardView.LockCard();
            else
                _cardView.CloseCard();
        }

        public void UpdateCardView(bool locked, CardState beforeFlipState, CardState afterFlipState)
        {
            if (afterFlipState == CardState.Opened)
            {
                _ = OpenCard(locked, beforeFlipState, afterFlipState, 0, .25f);
            }
            else if (afterFlipState == CardState.Closed)
                _ = CloseCard(locked, beforeFlipState, afterFlipState, 180, .25f);
            else if (afterFlipState == CardState.Matched)
            {
                _card.CardState = afterFlipState;
                _cardView.LockCard();
            }
            else
                _ = CloseCard(locked, beforeFlipState, afterFlipState, 180, .25f);
        }

        private async Task OpenCard(bool locked, CardState beforeFlipState, CardState afterFlipState,
            float angleToRotate,
            float duration)
        {
            _card.IsLocked = locked;
            await HandleCardRotation(beforeFlipState, afterFlipState, angleToRotate, duration);
        }

        private async Task CloseCard(bool locked, CardState beforeFlipState, CardState afterFlipState,
            float angleToRotate,
            float duration)
        {
            await HandleCardRotation(beforeFlipState, afterFlipState, angleToRotate, duration);
            _card.IsLocked = locked;
        }

        private async Task HandleCardRotation(CardState beforeFlipState, CardState afterFlipState,
            float angleToRotate,
            float duration)
        {
            _card.CardState = beforeFlipState;
            var from = _cardView.GetCardRotation();
            var to = Quaternion.Euler(0f, angleToRotate, 0f);
            var t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                _cardView.SetCardRotation(Quaternion.Lerp(from, to, t / duration));
                await Task.Yield();
            }

            _cardView.SetCardRotation(to);
            _card.CardState = afterFlipState;
        }

        private void UpdateCardIDView()
        {
            _cardView.UpdateCardIDText(_cardUseCase.GetCardID());
        }

        public void HandleActionCloseCard()
        {
            _cardUseCase.SetClosed();
            UpdateCardStateView();
        }

        public void HandleActionLockCard()
        {
            _cardUseCase.SetMatched();
            UpdateCardStateView();
        }

        public void HandleActionUpdateCardID(int cardID)
        {
            _cardUseCase.SetCardID(cardID);
            UpdateCardIDView();
        }
    }
}