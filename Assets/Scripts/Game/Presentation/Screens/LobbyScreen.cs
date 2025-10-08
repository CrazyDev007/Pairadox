using Game.Application.UseCases;
using Game.Presentation;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Infrastructure.Screens
{
    public class LobbyScreen : UIScreen, ILobbyView
    {
        // UI
        [SerializeField] private Image[] images;

        //
        private ILobbyPresenter _lobbyPresenter;

        public void Init(ILobbyPresenter lobbyPresenter) => _lobbyPresenter = lobbyPresenter;

        private void Awake()
        {
            _lobbyPresenter.ApplyTheme();
        }

        public void ApplyTheme(ThemeDto currentTheme)
        {
            /*foreach (var image in images)
            {
                image.color = ColorUtility.TryParseHtmlString(currentTheme.BackgroundColor, out var backgroundColor)
                    ? backgroundColor
                    : Color.white;
            }*/
        }

        public void OnClickBtnPlay()
        {
            //Debug.Log(GameManager.Instance.gameMode.ToString());
            LoadingManager.Instance.UnloadScene("Lobby");
            LoadingManager.Instance.LoadSceneAdditive("Gameplay");
        }

        public void OnClickBtnSettings()
        {
            UIManager.Instance.ShowScreen(UIScreenType.Setting);
        }

        public void OnClickBtnQuitGame()
        {
            UnityEngine.Device.Application.Quit();
        }

        private void HandleThemeChange(ThemeDto currentTheme) => ApplyTheme(currentTheme);

        private void OnEnable() => _lobbyPresenter.ChangeThemeUseCase.OnChangeTheme += HandleThemeChange;

        private void OnDisable() => _lobbyPresenter.ChangeThemeUseCase.OnChangeTheme -= HandleThemeChange;

        protected override void SetupScreen(UnityEngine.UIElements.VisualElement screen)
        {
            // get instance of settings button
            var settingsButton = screen.Q<Button>("settingsButton");
            settingsButton.RegisterCallback<ClickEvent>(e => OnClickBtnSettings());
        }
    }
}