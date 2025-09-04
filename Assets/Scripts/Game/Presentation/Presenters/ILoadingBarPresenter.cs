using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public interface ILoadingBarPresenter
    {
        void Init(ILoadingBarView view);
        void HandleProgress(float progress);
    }
}