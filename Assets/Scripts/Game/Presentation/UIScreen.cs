using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Presentation
{
    public abstract class UIScreen : MonoBehaviour
    {
        private VisualElement _root;
        [SerializeField] protected VisualTreeAsset screenAsset;
        public virtual void Show()
        {
            _root.Clear();
            VisualElement screen = screenAsset.CloneTree();
            screen.style.flexGrow = 1;
            _root.Add(screen);
            SetupScreen(screen);
        }
        
        public void SetupRoot(VisualElement root)
        {
            this._root = root;
        }

        protected abstract void SetupScreen(VisualElement screen);
    }

}