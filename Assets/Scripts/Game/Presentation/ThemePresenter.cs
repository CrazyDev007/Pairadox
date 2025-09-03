using Game.Application.UseCases;
using UnityEngine;

namespace Game.Presentation
{
    public class ThemePresenter : IThemePresenter
    {
        private IThemeView _themeView;
        private readonly ChangeThemeUseCase _changeThemeUseCase;
        private readonly IThemeRepository _themeRepository;

        public void Init(IThemeView themeView) => _themeView = themeView;

        public ThemePresenter(ChangeThemeUseCase changeThemeUseCase,
            IThemeRepository themeRepository)
        {
            _changeThemeUseCase = changeThemeUseCase;
            _themeRepository = themeRepository;
        }

        public void ApplyTheme(string themeName)
        {
            _changeThemeUseCase.ChangeTheme(themeName);
            var themeDto = _themeRepository.GetCurrentTheme();
            //
            _themeView.SetBackgroundColor(ColorUtility.TryParseHtmlString(themeDto.BackgroundColor, out var bgColor)
                ? bgColor
                : Color.white);
        }
    }
}