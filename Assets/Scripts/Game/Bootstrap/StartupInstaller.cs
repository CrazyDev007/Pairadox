using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Infrastructure;
using Game.Presentation;
using Game.Presentation.Presenters;

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
            // Loading Manager
            var loadingManager = FindAnyObjectByType<LoadingManager>();
            loadingManager.Init(loadingPresenter);
            loadingPresenter.Init(loadingManager);
            //
        }
    }
}