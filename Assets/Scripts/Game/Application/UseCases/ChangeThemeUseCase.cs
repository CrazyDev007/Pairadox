using System;

namespace Game.Application.UseCases
{
    public class ChangeThemeUseCase
    {
        public event Action<ThemeDto> OnChangeTheme;
        private readonly IThemeRepository _themeRepository;
        public ChangeThemeUseCase(IThemeRepository themeRepository) => _themeRepository = themeRepository;

        public void ChangeTheme(string newThemeName)
        {
            _themeRepository.SaveTheme(newThemeName);
            OnChangeTheme?.Invoke(_themeRepository.GetCurrentTheme());
        }
    }
}