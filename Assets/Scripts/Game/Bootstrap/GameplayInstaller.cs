using Game.Infrastructure;
using Game.Infrastructure.Screens;
using Game.Infrastructure.Views;
using Game.Presentation;
using Game.Presentation.Presenters;
using Game.Presentation.Screens;

namespace Game.Bootstrap
{
    public class GameplayInstaller : MonoInstaller
    {
        protected override void InstallBindings()
        {
            var gameplayListener = new GameplayListener();
            var saveService = new SaveManager();
            // GameInitializer
            var gameInitializer = FindAnyObjectByType<GameInitializer>();
            gameInitializer.Init(gameplayListener, saveService);
            // GameplayStatsView (normal C# class)
            var gameplayStatsView = new GameplayStatsView();
            gameplayStatsView.Init(gameplayListener);
            // GameplayScreen
            var gameplayScreen = FindAnyObjectByType<GameplayScreen>();
            gameplayScreen.Init(gameplayListener, gameplayStatsView);
            // Game End Screen
            var themeRepository = new PlayerPrefsThemeRepository();
            var gameEndPresenter = new GameEndPresenter(themeRepository);
            var gameEndScreen = FindAnyObjectByType<GameEndScreen>();
            gameEndScreen.Init(gameEndPresenter);
            gameEndPresenter.Init(gameEndScreen);
        }
    }
}