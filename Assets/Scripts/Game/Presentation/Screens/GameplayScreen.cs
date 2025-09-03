using Game.Presentation;
using UnityEngine;

namespace Game.Infrastructure.Screens
{
    public class GameplayScreen : UIScreen
    {
        private IGameplayListener _gameplayListener;

        public void Init(IGameplayListener gameplayListener) => _gameplayListener = gameplayListener;

        public void OnClickExitGameButton()
        {
            LoadingManager.Instance.UnloadScene("Gameplay");
            LoadingManager.Instance.LoadSceneAdditive("Lobby");
        }

        private void EventOnGameEnded()
        {
            Debug.Log("Game Ended");
            UiManager.ShowScreen(UIScreenType.GameEnd);
        }

        private void OnEnable()
        {
            ((GameplayListener)_gameplayListener).OnGameEndEvent += EventOnGameEnded;
        }

        private void OnDisable()
        {
            ((GameplayListener)_gameplayListener).OnGameEndEvent -= EventOnGameEnded;
        }
    }
}