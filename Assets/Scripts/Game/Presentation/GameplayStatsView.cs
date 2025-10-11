using Game.Presentation;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Infrastructure.Views
{
    public class GameplayStatsView
    {
        private IGameplayListener _gameplayListener;
        private Label turnCountLabel;
        private Label matchesCountLabel;

        public void Init(IGameplayListener gameplayListener)
        {
            _gameplayListener = gameplayListener;
        }

        // Setup UI bindings with provided screen root
        public void Setup(VisualElement screen)
        {
            turnCountLabel = screen.Q<Label>("turnsCountLabel");
            matchesCountLabel = screen.Q<Label>("matchesCountLabel");
            var concrete = (GameplayListener)_gameplayListener;
            concrete.OnMatchesCountChangeEvent += OnMatchesCountChanged;
            concrete.OnTurnsCountChangeEvent += OnTurnsCountChanged;
            // Initial update
            OnMatchesCountChanged(0);
            OnTurnsCountChanged(0);
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
            if (turnCountLabel != null) turnCountLabel.text = turnsCount.ToString();
        }

        private void OnMatchesCountChanged(int matchesCount)
        {
            if (matchesCountLabel != null) matchesCountLabel.text = matchesCount.ToString();
        }

        // ...existing code...
    }
}