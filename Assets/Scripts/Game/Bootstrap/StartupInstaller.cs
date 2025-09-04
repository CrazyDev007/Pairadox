using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Infrastructure;
using Game.Presentation;
using Game.Presentation.Presenters;
using Game.Presentation.Views;

namespace Game.Bootstrap
{
    public class StartupInstaller : MonoInstaller
    {
        protected override void InstallBindings()
        {
            // Loading State
            ILoadingState loadingState = new LoadingState();
            // Load Scene Use Case
            ILoadSceneUseCase loadSceneUseCase = new LoadSceneUseCase(loadingState);
            // Theme
            IThemeRepository themeRepository = new PlayerPrefsThemeRepository();
            var changeThemeUseCase = new ChangeThemeUseCase(themeRepository);
            // Loading Presenter
            ILoadingPresenter loadingPresenter =
                new LoadingPresenter(loadSceneUseCase, themeRepository, changeThemeUseCase);
            // Loading Bar View
            var loadingBar = new LoadingBar();
            var loadingBarUseCase = new LoadingBarUseCase();
            var loadingBarPresenter = new LoadingBarPresenter(loadingBar, loadingBarUseCase);
            var loadingBarView = FindAnyObjectByType<LoadingBarView>();
            loadingBarPresenter.Init(loadingBarView);
            loadingBarView.Init(loadingBarPresenter);
            // Loading Manager
            var loadingManager = FindAnyObjectByType<LoadingManager>();
            loadingManager.Init(loadingPresenter, loadingBarView);
            loadingPresenter.Init(loadingManager);
            //
        }
    }
}