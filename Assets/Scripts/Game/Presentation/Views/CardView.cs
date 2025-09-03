using Game.Application.UseCases;
using Game.Presentation.Presenters;
using TMPro;
using UnityEngine;

namespace Game.Presentation.Views
{
    public class CardView : MonoBehaviour, ICardView
    {
        private CardPresenter _cardPresenter;
        [SerializeField] private TextMeshPro cardText;
        [SerializeField] private Transform graphicsTransform;
        [SerializeField] private float timeToFlipCard = 1f;

        public void Initialize(CardPresenter cardPresenter)
        {
            _cardPresenter = cardPresenter;
            _cardPresenter.Initialize();
        }

        public void OnMouseClicked2D() => _cardPresenter.OnCardClicked();

        public void CloseCardAfterDelay()
        {
            Debug.Log($"{name} not matched -> flip back");
            // Could use coroutine/animation here
        }

        public void OpenCard()
        {
            //cardText.color = Color.green;
            //_ = HandleCardRotation(0, timeToFlipCard);
        }

        public void CloseCard()
        {
            //_ = HandleCardRotation(180, timeToFlipCard);
            //cardText.color = Color.black;
        }

        public void LockCard()
        {
            cardText.color = Color.green;
        }

        public void UpdateCardIDText(int cardID)
        {
            cardText.text = cardID.ToString();
        }

        public Quaternion GetCardRotation()
        {
            return graphicsTransform.rotation;
        }

        public void SetCardRotation(Quaternion rotation)
        {
            graphicsTransform.rotation = rotation;
        }

        public CardUseCase GetCardEntity()
        {
            return null; //_cardPresenter.GetCardUseCase();
        }

        public void ActionOpenCard()
        {
        }

        public void ActionCloseCard()
        {
            _cardPresenter.HandleActionCloseCard();
        }

        public void ActionLockCard()
        {
            _cardPresenter.HandleActionLockCard();
        }

        public void UpdateCartID(int cardID)
        {
            _cardPresenter.HandleActionUpdateCardID(cardID);
        }
    }
}