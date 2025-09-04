using Game.Application.Interfaces;
using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public class LoadingBarPresenter : ILoadingBarPresenter, ILoadingBarCallback
    {
        private readonly ILoadingBar _loadingBar;
        private ILoadingBarView _view;
        private readonly ILoadingBarUseCase _useCase;

        public LoadingBarPresenter(ILoadingBar loadingBar, ILoadingBarUseCase useCase)
        {
            _loadingBar = loadingBar;
            _useCase = useCase;
        }

        public void Init(ILoadingBarView view) => _view = view;

        public void HandleProgress(float progress) => _useCase.Execute(_loadingBar, progress, this);

        public void UpdateProgress(float progress) => _view.SetProgress(progress);
    }
}