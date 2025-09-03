using Game.Presentation.Presenters;
using TMPro;
using UnityEngine;

namespace Game.Presentation.Views
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private TextMeshProUGUI _healthText;
        private PlayerPresenter _playerPresenter;

        public void Initialize(PlayerPresenter playerPresenter)
        {
            _playerPresenter = playerPresenter;
        }

        public void HandleDamageButtonPressed()
        {
            _playerPresenter.HandleDamageButtonPressed();
        }

        public void DisplayHealth(int currentHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }
}