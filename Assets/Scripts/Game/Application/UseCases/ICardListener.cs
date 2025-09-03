using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public interface ICardListener
    {
        void UpdateCardView(bool locked, CardState beforeFlipState, CardState afterFlipState);
    }
}