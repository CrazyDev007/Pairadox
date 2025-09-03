using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public class LobbyPresenter : ILobbyPresenter
    {
        private ILobbyView _lobbyView;
        private readonly IThemeRepository _themeRepository;
        public ChangeThemeUseCase ChangeThemeUseCase { get; set; }

        public LobbyPresenter(IThemeRepository themeRepository, ChangeThemeUseCase changeThemeUseCase)
        {
            _themeRepository = themeRepository;
            ChangeThemeUseCase = changeThemeUseCase;
        }

        public void Init(ILobbyView view) => _lobbyView = view;

        public void ApplyTheme()
        {
            var currentTheme = _themeRepository.GetCurrentTheme();
            _lobbyView.ApplyTheme(currentTheme);
        }
    }
}