using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public class LoadingPresenter : ILoadingPresenter
    {
        private ILoadingView _loadingView;

        private readonly ILoadSceneUseCase _loadSceneUseCase;

        // Theme
        private readonly IThemeRepository _themeRepository;
        public ChangeThemeUseCase ChangeThemeUseCase { get; set; }

        public LoadingPresenter(ILoadSceneUseCase loadSceneUseCase,
            IThemeRepository themeRepository,
            ChangeThemeUseCase changeThemeUseCase)
        {
            _loadSceneUseCase = loadSceneUseCase;
            _themeRepository = themeRepository;
            ChangeThemeUseCase = changeThemeUseCase;
        }

        public void Init(ILoadingView loadingView) => _loadingView = loadingView;
        public bool ShouldShow() => _loadSceneUseCase.IsLoading();
        public float GetProgress() => _loadSceneUseCase.GetProgress();
        public void UpdateProgress(float progress) => _loadSceneUseCase.UpdateProgress(progress);
        public void FinishLoading() => _loadSceneUseCase.FinishLoading();

        public void ApplyTheme()
        {
            var currentTheme = _themeRepository.GetCurrentTheme();
            _loadingView.ApplyTheme(currentTheme);
        }
    }
}