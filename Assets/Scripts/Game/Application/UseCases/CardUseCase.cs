using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public class CardUseCase
    {
        public ICardListener CardListener { get; set; }

        private readonly CardEntity _card;
        public CardEntity Card => _card;
        public CardUseCase(CardEntity card) => _card = card;
        public int GetCardID() => _card.CardId;
        public void ChangeCardState(CardState newState) => _card.CardState = newState;
        public void SetCardID(int newID) => _card.CardId = newID;
        public CardState GetCardState() => _card.CardState;
        public int GetCardStateAsInt() => (int)_card.CardState;
        public bool IsMatched() => _card.CardState == CardState.Matched;
        public void SetMatched() => _card.CardState = CardState.Matched;
        public bool IsOpen() => _card.CardState == CardState.Opened;
        public void SetOpen() => _card.CardState = CardState.Opened;
        public bool IsClose() => _card.CardState == CardState.Closed;
        public void SetClosed() => _card.CardState = CardState.Closed;
        public bool IsLocked() => _card.IsLocked;
        public void SetLocked(bool locked) => _card.IsLocked = locked;
    }
}