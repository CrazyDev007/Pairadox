using Game.Presentation.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation.Views
{
    public class LoadingBarView : MonoBehaviour, ILoadingBarView
    {
        [SerializeField] private Image loadingImage;

        private ILoadingBarPresenter _presenter;

        private float _value;

        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                _presenter.HandleProgress(_value);
            }
        }

        public void Init(ILoadingBarPresenter presenter) => _presenter = presenter;

        public void SetProgress(float progress)
        {
            loadingImage.fillAmount = progress;
        }
    }
}