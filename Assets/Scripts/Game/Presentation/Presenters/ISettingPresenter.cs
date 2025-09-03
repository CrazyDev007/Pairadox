using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public interface ISettingPresenter
    {
        ChangeThemeUseCase ChangeThemeUseCase { get; set; }
        void Init(ISettingView view);
        void ApplyTheme();
        void ChangeTheme(string themeName);
    }
}