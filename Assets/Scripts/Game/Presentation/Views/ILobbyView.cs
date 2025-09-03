using Game.Application.UseCases;
using Game.Presentation.Presenters;

namespace Game.Presentation.Views
{
    public interface ILobbyView
    {
        void Init(ILobbyPresenter lobbyPresenter);
        void ApplyTheme(ThemeDto currentTheme);
    }
}