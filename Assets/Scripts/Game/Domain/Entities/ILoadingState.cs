namespace Game.Domain.Entities
{
    public interface ILoadingState
    {
        public bool IsLoading { get; set; }
        public float Progress { get; set; }
        public void StartLoading();

        public void UpdateProgress(float progress);

        public void FinishLoading();
    }
}