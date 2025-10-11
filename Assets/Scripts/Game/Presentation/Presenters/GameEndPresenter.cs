using Game.Application.UseCases;
using Game.Presentation.Views;
using Game.Presentation;

namespace Game.Presentation.Presenters
{
    public class GameEndPresenter : IGameEndPresenter
    {
        private IGameEndView _gameEndView;
        private readonly IThemeRepository _themeRepository;
        private readonly IGameResultsProvider _resultsProvider;

        public GameEndPresenter(IThemeRepository themeRepository, IGameResultsProvider resultsProvider)
        {
            _themeRepository = themeRepository;
            _resultsProvider = resultsProvider;
        }

        public void Init(IGameEndView gameEndView)
        {
            _gameEndView = gameEndView;
            ApplyTheme();
        }

        public void ApplyTheme()
        {
            var currentTheme = _themeRepository.GetCurrentTheme();
            _gameEndView.ApplyTheme(currentTheme);
        }

        public void PresentSummary()
        {
            var summary = _resultsProvider.GetSummary();
            _gameEndView.RenderSummary(summary);
        }
    }
}