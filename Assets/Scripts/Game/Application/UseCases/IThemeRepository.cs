namespace Game.Application.UseCases
{
    public interface IThemeRepository
    {
        ThemeDto GetCurrentTheme();
        void SaveTheme(string newThemeName);
    }
}