using UnityEngine;

namespace Game.Presentation
{
    public interface IThemeView
    {
        void Init(IThemePresenter themePresenter);
        public void SetBackgroundColor(Color color);
        public void SetBorderColor(Color color);
        public void SetFontColor(Color color);
    }
}