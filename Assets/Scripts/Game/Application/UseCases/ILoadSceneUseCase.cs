namespace Game.Application.UseCases
{
    public interface ILoadSceneUseCase
    {
        public bool IsLoading();

        public void FinishLoading();

        public void UpdateProgress(float progress);

        public float GetProgress();
    }
}