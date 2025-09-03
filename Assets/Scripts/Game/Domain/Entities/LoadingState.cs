namespace Game.Domain.Entities
{
    public class LoadingState : ILoadingState
    {
        public bool IsLoading { get; set; }
        public float Progress { get; set; }

        public void StartLoading()
        {
            IsLoading = true;
            Progress = 0f;
        }

        public void UpdateProgress(float progress)
        {
            Progress = progress;
        }

        public void FinishLoading()
        {
            IsLoading = false;
            Progress = 1f;
        }
    }
}