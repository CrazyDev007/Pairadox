namespace Game.Presentation
{
    public interface IThemePresenter
    {
        void Init(IThemeView themeView);
        void ApplyTheme(string themeName = "default");
    }
}