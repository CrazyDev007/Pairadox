using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation
{
    public class ThemeManager : MonoBehaviour, IThemeView
    {
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI text;
        private IThemePresenter _themePresenter;

        private void Awake() => _themePresenter.ApplyTheme();

        public void Init(IThemePresenter themePresenter) => _themePresenter = themePresenter;

        public void OnClickLightThemeButton() => _themePresenter.ApplyTheme("light");

        public void OnClickDarkThemeButton() => _themePresenter.ApplyTheme("dark");

        public void SetBackgroundColor(Color color) => background.color = color;

        public void SetBorderColor(Color color)
        {
        }

        public void SetFontColor(Color color) => text.color = color;
    }
}