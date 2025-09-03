using System.Threading.Tasks;
using Game.Application.UseCases;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation.Screens
{
    public class GameEndScreen : UIScreen, IGameEndView
    {
        [SerializeField] private Image backgroundImage;
        private IGameEndPresenter _gameEndPresenter;

        public void Init(IGameEndPresenter gameEndPresenter) => _gameEndPresenter = gameEndPresenter;
        private void Awake() => _gameEndPresenter.ApplyTheme();

        public void ApplyTheme(ThemeDto currentTheme)
        {
            backgroundImage.color =
                ColorUtility.TryParseHtmlString(currentTheme.BackgroundColor, out var backgroundColor)
                    ? backgroundColor
                    : Color.white;
        }

        public void OnClickedNextButton() => _ = RestartGame();

        public void OnClickExitGameButton()
        {
            LoadingManager.Instance.UnloadScene("Gameplay");
            LoadingManager.Instance.LoadSceneAdditive("Lobby");
        }

        private async Task RestartGame()
        {
            //GameManager.Instance.ResetGame();
            LoadingManager.Instance.UnloadScene("Gameplay");
            await Task.Delay(2000);
            LoadingManager.Instance.LoadSceneAdditive("Gameplay");
        }
    }
}