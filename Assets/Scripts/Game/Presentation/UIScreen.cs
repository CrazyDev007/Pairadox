using UnityEngine;

namespace Game.Presentation
{
    public abstract class UIScreen : MonoBehaviour
    {
        [SerializeField] private GameObject root;
        public UIManager UiManager { get; set; }

        public virtual void Show()
        {
            root.SetActive(true);
        }

        public virtual void Hide()
        {
            root.SetActive(false);
        }
    }
}