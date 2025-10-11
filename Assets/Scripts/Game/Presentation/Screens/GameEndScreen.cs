using System;
using System.Threading.Tasks;
using Game.Application.UseCases;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Presentation.Screens
{
    public class GameEndScreen : UIScreen, IGameEndView
    {
        [SerializeField] private Image backgroundImage;
        // Add UI element fields
        private VisualElement _backgroundOverlay;
        private VisualElement _contentCard;
        private Label _titleLabel;
        private Label _subtitleLabel;
        private Label _scoreValueLabel;
        private Label _matchesValueLabel;
        private Label _turnsValueLabel;
        private Label _bestStreakValueLabel;
        private Label _timeValueLabel;
        private ProgressBar _levelProgressBar;
        private Button _playAgainButton;
        private Button _backToLobbyButton;

    private IGameEndPresenter _gameEndPresenter;

    public void Init(IGameEndPresenter gameEndPresenter) => _gameEndPresenter = gameEndPresenter;

        public void ApplyTheme(ThemeDto currentTheme)
        {
            /*backgroundImage.color =
                ColorUtility.TryParseHtmlString(currentTheme.BackgroundColor, out var backgroundColor)
                    ? backgroundColor
                    : Color.white;*/
        }

        public void OnClickedNextButton() => _ = RestartGame();

        public void OnClickExitGameButton()
        {
            LoadingManager.Instance.UnloadScene("Gameplay");
            LoadingManager.Instance.LoadSceneAdditive("Lobby");
        }

        private async Task RestartGame()
        {
            //GameManager.Instance.ResetGame();
            LoadingManager.Instance.UnloadScene("Gameplay");
            await Task.Delay(2000);
            LoadingManager.Instance.LoadSceneAdditive("Gameplay");
        }

        protected override void SetupScreen(VisualElement screen)
        {
            _backgroundOverlay = screen.Q<VisualElement>(className: "background-overlay");
            _contentCard = screen.Q<VisualElement>(className: "content-card");
            _titleLabel = screen.Q<Label>(className: "title");
            _subtitleLabel = screen.Q<Label>(className: "subtitle");
            _scoreValueLabel = screen.Q<Label>(className: "score-value");

            var statValues = screen.Q<VisualElement>(className: "stats-grid").Query<Label>(className: "tile-value").ToList();
            if (statValues.Count >= 4)
            {
                _matchesValueLabel = statValues[0];
                _turnsValueLabel = statValues[1];
                _bestStreakValueLabel = statValues[2];
                _timeValueLabel = statValues[3];
            }

            _levelProgressBar = screen.Q<ProgressBar>(className: "level-progress");
            _playAgainButton = screen.Q<Button>(className: "primary-button");
            _backToLobbyButton = screen.Q<Button>(className: "secondary-button");

            _playAgainButton.clicked += OnClickedNextButton;
            _backToLobbyButton.clicked += OnClickExitGameButton;

            _gameEndPresenter?.PresentSummary();
        }

        public void RenderSummary(GameEndSummaryDto summary)
        {
            if (_scoreValueLabel != null)
            {
                _scoreValueLabel.text = summary.FinalScore.ToString();
            }

            if (_matchesValueLabel != null)
            {
                _matchesValueLabel.text = summary.TotalMatches.ToString();
            }

            if (_turnsValueLabel != null)
            {
                _turnsValueLabel.text = summary.TotalTurns.ToString();
            }

            if (_bestStreakValueLabel != null)
            {
                _bestStreakValueLabel.text = summary.BestStreak.ToString();
            }

            if (_timeValueLabel != null)
            {
                _timeValueLabel.text = FormatElapsedTime(summary.ElapsedSeconds);
            }

            if (_levelProgressBar != null)
            {
                _levelProgressBar.value = summary.LevelProgressPercent;
            }
        }

        private static string FormatElapsedTime(float elapsedSeconds)
        {
            var span = TimeSpan.FromSeconds(Math.Max(0, elapsedSeconds));
            return span.Hours > 0
                ? $"{span.Hours:00}:{span.Minutes:00}:{span.Seconds:00}"
                : $"{span.Minutes:00}:{span.Seconds:00}";
        }
    }
}