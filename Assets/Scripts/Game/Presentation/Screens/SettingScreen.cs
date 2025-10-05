using Game.Application.UseCases;
using Game.Presentation;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Game.Infrastructure.Screens
{
    public class SettingScreen : UIScreen, ISettingView
    {
        // Theme
        //[SerializeField] private Image[] images;

        //
        private ISettingPresenter _settingPresenter;

        public void Init(ISettingPresenter settingPresenter) => _settingPresenter = settingPresenter;

        private void Awake() => _settingPresenter.ApplyTheme();

        public void OnClickBtnBack()
        {
            UIManager.Instance.ShowScreen(UIScreenType.Lobby);
        }

        public void OnClickLightThemeButton() => _settingPresenter.ChangeTheme("light");

        public void OnClickDarkThemeButton() => _settingPresenter.ChangeTheme("dark");

        public void ApplyTheme(ThemeDto theme)
        {
            // Background Color
            /*foreach (var image in images)
            {
                image.color = ColorUtility.TryParseHtmlString(theme.BackgroundColor, out var backgroundColor)
                    ? backgroundColor
                    : Color.black;
            }*/
        }

        private void HandleChangeTheme(ThemeDto theme) => ApplyTheme(theme);

        private void OnEnable() => _settingPresenter.ChangeThemeUseCase.OnChangeTheme += HandleChangeTheme;

        private void OnDisable() => _settingPresenter.ChangeThemeUseCase.OnChangeTheme -= HandleChangeTheme;

        protected override void SetupScreen(UnityEngine.UIElements.VisualElement screen)
        {
            var backButton = screen.Q<UnityEngine.UIElements.Button>("backButton");
            var darkThemeButton = screen.Q<UnityEngine.UIElements.Button>("darkThemeButton");
            var lightThemeButton = screen.Q<UnityEngine.UIElements.Button>("lightThemeButton");

            backButton.clicked += OnClickBtnBack;
            darkThemeButton.clicked += OnClickDarkThemeButton;
            lightThemeButton.clicked += OnClickLightThemeButton;
        }
    }
}