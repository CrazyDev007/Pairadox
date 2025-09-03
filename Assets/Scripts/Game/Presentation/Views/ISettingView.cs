using Game.Application.UseCases;
using Game.Presentation.Presenters;

namespace Game.Presentation.Views
{
    public interface ISettingView
    {
        void Init(ISettingPresenter settingPresenter);
        void ApplyTheme(ThemeDto theme);
    }
}