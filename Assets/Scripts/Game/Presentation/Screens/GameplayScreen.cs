using Game.Presentation;
using Game.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Infrastructure.Screens
{
    public class GameplayScreen : UIScreen
    {
    private IGameplayListener _gameplayListener;
    private GameplayStatsView _statsView;

        public void Init(IGameplayListener gameplayListener, GameplayStatsView statsView)
        {
            _gameplayListener = gameplayListener;
            _statsView = statsView;
        }

        public void OnClickExitGameButton()
        {
            LoadingManager.Instance.UnloadScene("Gameplay");
            LoadingManager.Instance.LoadSceneAdditive("Lobby");
        }

        private void EventOnGameEnded()
        {
            Debug.Log("Game Ended");
            //UiManager.ShowScreen(UIScreenType.GameEnd);
        }

        private void OnEnable()
        {
            ((GameplayListener)_gameplayListener).OnGameEndEvent += EventOnGameEnded;
        }

        private void OnDisable()
        {
            ((GameplayListener)_gameplayListener).OnGameEndEvent -= EventOnGameEnded;
        }

        protected override void SetupScreen(VisualElement screen)
        {
            _statsView.Setup(screen);
        }
    }
}