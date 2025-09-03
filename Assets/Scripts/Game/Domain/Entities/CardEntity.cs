namespace Game.Domain.Entities
{
    public enum CardState
    {
        Opened,
        Closed,
        Matched,
        Flipping,
    }

    public class CardEntity
    {
        public int CardId { get; set; }
        public bool IsMatched { get; set; }
        public CardState CardState { get; set; }
        public bool IsLocked { get; set; }

        public bool CanFlip()
        {
            return (CardState is CardState.Opened or CardState.Closed) && !IsLocked;
        }
    }
}