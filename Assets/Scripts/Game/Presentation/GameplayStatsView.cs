using Game.Presentation;
using UnityEngine;

namespace Game.Infrastructure.Views
{
    public class GameplayStatsView : MonoBehaviour
    {
        [SerializeField] private GameplayStatItemView matchesCountItemView;
        [SerializeField] private GameplayStatItemView turnsCountItemView;

        private IGameplayListener _gameplayListener;

        public void Init(IGameplayListener gameplayListener) => _gameplayListener = gameplayListener;

        private void Start()
        {
            OnTurnsCountChanged(0);
            OnMatchesCountChanged(0);
        }

        private void OnEnable()
        {
            ((GameplayListener)_gameplayListener).OnMatchesCountChangeEvent += OnMatchesCountChanged;
            ((GameplayListener)_gameplayListener).OnTurnsCountChangeEvent += OnTurnsCountChanged;
        }

        private void OnTurnsCountChanged(int turnsCount)
        {
            turnsCountItemView.SetCounts(turnsCount);
        }

        private void OnMatchesCountChanged(int matchesCount)
        {
            matchesCountItemView.SetCounts(matchesCount);
        }

        private void OnDisable()
        {
            ((GameplayListener)_gameplayListener).OnMatchesCountChangeEvent -= OnMatchesCountChanged;
            ((GameplayListener)_gameplayListener).OnTurnsCountChangeEvent -= OnTurnsCountChanged;
        }
    }
}