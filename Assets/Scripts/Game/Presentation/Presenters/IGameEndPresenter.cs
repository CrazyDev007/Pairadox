using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public interface IGameEndPresenter
    {
        void Init(IGameEndView gameEndView);
        void ApplyTheme();
    }
}