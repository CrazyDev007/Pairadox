using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public class PlayerPresenter
    {
        private readonly IPlayerView _playerView;
        private readonly PlayerUseCase _playerUseCase;

        public PlayerPresenter(IPlayerView playerView, PlayerUseCase playerUseCase)
        {
            _playerView = playerView;
            _playerUseCase = playerUseCase;
            UpdatePlayerView();
        }

        public void HandleDamageButtonPressed()
        {
            _playerUseCase.ExecuteTakeDamage(1);
            UpdatePlayerView();
        }

        private void UpdatePlayerView()
        {
            _playerView.DisplayHealth(_playerUseCase.ExecuteGetPlayerHealth());
        }
    }
}