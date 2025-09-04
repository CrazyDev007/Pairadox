using Game.Presentation.Presenters;

namespace Game.Presentation.Views
{
    public interface ILoadingBarView
    {
        float Value { get; set; }
        void Init(ILoadingBarPresenter presenter);
        void SetProgress(float progress);
    }
}