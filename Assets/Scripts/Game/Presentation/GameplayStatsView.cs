using Game.Presentation;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Infrastructure.Views
{
    public class GameplayStatsView
    {
        private IGameplayListener _gameplayListener;
    private Label turnCountLabel;
    private Label matchesCountLabel;
    private Label timeLabel;

        public void Init(IGameplayListener gameplayListener)
        {
            _gameplayListener = gameplayListener;
        }

        // Setup UI bindings with provided screen root
        public void Setup(VisualElement screen)
        {
            turnCountLabel = screen.Q<Label>("turnCountLabel");
            matchesCountLabel = screen.Q<Label>("matchCountLabel");
            timeLabel = screen.Q<Label>("timeLabel");
            var concrete = (GameplayListener)_gameplayListener;
            concrete.OnMatchesCountChangeEvent += OnMatchesCountChanged;
            concrete.OnTurnsCountChangeEvent += OnTurnsCountChanged;
            // Initial update
            OnMatchesCountChanged(0);
            OnTurnsCountChanged(0);
            if (timeLabel != null)
                timeLabel.text = "Time: 00:00";
            // Schedule periodic elapsed time updates
            screen.schedule.Execute(_ =>
            {
                var concrete = (GameplayListener)_gameplayListener;
                var summary = concrete.GetSummary();
                if (timeLabel != null)
                    timeLabel.text = "Time: " + FormatTime(summary.ElapsedSeconds);
            }).Every(1000);
        }

        // Cleanup bindings
        public void Dispose()
        {
            var concrete = (GameplayListener)_gameplayListener;
            concrete.OnMatchesCountChangeEvent -= OnMatchesCountChanged;
            concrete.OnTurnsCountChangeEvent -= OnTurnsCountChanged;
        }

        private void OnTurnsCountChanged(int turnsCount)
        {
            turnCountLabel.text = "Turns: " + turnsCount.ToString();
        }

        private void OnMatchesCountChanged(int matchesCount)
        {
            matchesCountLabel.text = "Matches: " + matchesCount.ToString();
        }

        // ...existing code...
        private static string FormatTime(float elapsedSeconds)
        {
            var span = TimeSpan.FromSeconds(elapsedSeconds);
            return span.Hours > 0
                ? $"{span.Hours:00}:{span.Minutes:00}:{span.Seconds:00}"
                : $"{span.Minutes:00}:{span.Seconds:00}";
        }
    }
}