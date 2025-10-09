using Game.Application.UseCases;
using Game.Infrastructure;
using Game.Infrastructure.Screens;
using Game.Presentation;
using Game.Presentation.Presenters;

namespace Game.Bootstrap
{
    public class LobbyInstaller : MonoInstaller
    {
        protected override void InstallBindings()
        {
            var themeRepository = new PlayerPrefsThemeRepository();
            var changeThemeUseCase = new ChangeThemeUseCase(themeRepository);
            var settingPresenter = new SettingPresenter(changeThemeUseCase, themeRepository);
            // Setting Screen
            var settingScreen = FindAnyObjectByType<SettingScreen>();
            settingScreen.Init(settingPresenter);
            settingPresenter.Init(settingScreen);
            // create game mode view and save service instance
            var gameModeView = new GameModeView();
            var saveService = new SaveManager();
            gameModeView.Init(saveService);

            // Lobby Screen
            var lobbyPresenter = new LobbyPresenter(themeRepository, changeThemeUseCase);
            var lobbyScreen = FindAnyObjectByType<LobbyScreen>();
            lobbyScreen.Init(lobbyPresenter, gameModeView);
            lobbyPresenter.Init(lobbyScreen);
        }
    }
}