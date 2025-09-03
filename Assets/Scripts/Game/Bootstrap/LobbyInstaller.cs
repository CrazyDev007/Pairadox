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
            // Lobby Screen
            var lobbyPresenter = new LobbyPresenter(themeRepository, changeThemeUseCase);
            var lobbyScreen = FindAnyObjectByType<LobbyScreen>();
            lobbyScreen.Init(lobbyPresenter);
            lobbyPresenter.Init(lobbyScreen);
            //
            var saveService = new SaveManager();
            var gameModeView = FindAnyObjectByType<GameModeView>();
            gameModeView.Init(saveService);
        }
    }
}