using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public interface ILoadingPresenter
    {
        ChangeThemeUseCase ChangeThemeUseCase { get; set; }
        public void Init(ILoadingView loadingView);
        public float GetProgress();
        public void UpdateProgress(float progress);
        public void FinishLoading();
        void ApplyTheme();
    }
}