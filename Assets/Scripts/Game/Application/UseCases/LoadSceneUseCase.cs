using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public class LoadSceneUseCase : ILoadSceneUseCase
    {
        private readonly ILoadingState _loadingState;

        public LoadSceneUseCase()
        {
        }

        public LoadSceneUseCase(ILoadingState loadingState)
        {
            _loadingState = loadingState;
        }

        public ILoadingState Execute(string sceneName)
        {
            _loadingState.StartLoading();
            return _loadingState;
        }

        public bool IsLoading()
        {
            return _loadingState.IsLoading;
        }

        public void FinishLoading()
        {
            _loadingState.FinishLoading();
        }

        public void UpdateProgress(float progress)
        {
            _loadingState.UpdateProgress(progress);
        }

        public float GetProgress()
        {
            return _loadingState.Progress;
        }
    }
}