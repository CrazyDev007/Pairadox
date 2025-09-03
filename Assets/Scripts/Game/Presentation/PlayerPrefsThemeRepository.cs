using Game.Application.UseCases;
using UnityEngine;

namespace Game.Presentation
{
    public class PlayerPrefsThemeRepository : IThemeRepository
    {
        private const string ThemeKey = "CurrentTheme";

        public ThemeDto GetCurrentTheme()
        {
            var themeName = PlayerPrefs.GetString(ThemeKey, "default");
            return string.Equals(themeName, "dark")
                ? new ThemeDto("dark", "#121212")
                : new ThemeDto("light", "#D3D3D3");
        }

        public void SaveTheme(string newThemeName)
        {
            if (string.Equals(newThemeName, "default"))
            {
                var themeName = PlayerPrefs.GetString(ThemeKey, "");
                if (!string.IsNullOrEmpty(themeName)) return;
                PlayerPrefs.SetString(ThemeKey, "light");
            }
            else
            {
                PlayerPrefs.SetString(ThemeKey, newThemeName);
            }

            PlayerPrefs.Save();
        }
    }
}