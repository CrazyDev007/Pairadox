using Game.Application.UseCases;
using UnityEngine;

namespace Game.Presentation.Views
{
    public interface ICardView
    {
        void OpenCard();
        void CloseCard();
        void LockCard();
        void UpdateCardIDText(int cardID);
        Quaternion GetCardRotation();
        void SetCardRotation(Quaternion rotation);

        CardUseCase GetCardEntity();

        void ActionOpenCard();
        void ActionCloseCard();
        void ActionLockCard();
        void UpdateCartID(int cardID);
    }
}