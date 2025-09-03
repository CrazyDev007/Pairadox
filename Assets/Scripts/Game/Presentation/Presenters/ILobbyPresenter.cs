using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public interface ILobbyPresenter
    {
        ChangeThemeUseCase ChangeThemeUseCase { get; set; }
        void Init(ILobbyView view);
        void ApplyTheme();
    }
}