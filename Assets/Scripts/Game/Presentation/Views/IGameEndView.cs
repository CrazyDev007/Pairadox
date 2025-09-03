using Game.Application.UseCases;
using Game.Presentation.Presenters;

namespace Game.Presentation.Views
{
    public interface IGameEndView
    {
        void Init(IGameEndPresenter gameEndPresenter);
        void ApplyTheme(ThemeDto currentTheme);
    }
}