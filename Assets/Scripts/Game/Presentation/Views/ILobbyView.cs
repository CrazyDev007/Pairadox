using Game.Application.UseCases;
using Game.Presentation.Presenters;

namespace Game.Presentation.Views
{
    public interface ILobbyView
    {
        // add GameModeView init method
        void Init(ILobbyPresenter lobbyPresenter, GameModeView gameModeView);
        void ApplyTheme(ThemeDto currentTheme);
    }
}