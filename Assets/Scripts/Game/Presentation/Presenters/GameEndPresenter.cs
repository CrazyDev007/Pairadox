using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public class GameEndPresenter : IGameEndPresenter
    {
        private IGameEndView _gameEndView;
        private readonly IThemeRepository _themeRepository;

        public GameEndPresenter(IThemeRepository themeRepository) => _themeRepository = themeRepository;

        public void Init(IGameEndView gameEndView) => _gameEndView = gameEndView;

        public void ApplyTheme()
        {
            var currentTheme = _themeRepository.GetCurrentTheme();
            _gameEndView.ApplyTheme(currentTheme);
        }
    }
}