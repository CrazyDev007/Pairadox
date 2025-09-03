using Game.Application.UseCases;

namespace Game.Presentation.Views
{
    public interface ILoadingView
    {
        void ApplyTheme(ThemeDto theme);
    }
}