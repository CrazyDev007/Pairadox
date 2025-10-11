using System;
using Game.Application.UseCases;
using UnityEngine;

namespace Game.Presentation
{
    public class GameplayListener : IGameplayListener, IGameEndListener, ITurnCompleteListener, ICardMatchListener, IGameResultsProvider
    {
        public event Action<int> OnMatchesCountChangeEvent;
        public event Action<int> OnTurnsCountChangeEvent;
        public event Action<GameEndSummaryDto> OnGameEndEvent;

        private int _matchCount;
        private int _turnCount;
        private int _bestMatchStreak;
        private int _currentMatchStreak;
        private bool _currentTurnHadMatch;
        private int _score;
        private int _totalMatchesRequired;
        private float _sessionStartTime;
        private float _sessionEndTime;

        public void BeginSession(int totalMatchesRequired)
        {
            _totalMatchesRequired = totalMatchesRequired;
            _matchCount = 0;
            _turnCount = 0;
            _bestMatchStreak = 0;
            _currentMatchStreak = 0;
            _currentTurnHadMatch = false;
            _score = 0;
            _sessionStartTime = Time.realtimeSinceStartup;
            _sessionEndTime = _sessionStartTime;
        }

        public void OnGameEnded()
        {
            _sessionEndTime = Time.realtimeSinceStartup;
            OnGameEndEvent?.Invoke(GetSummary());
        }

        public void OnTurnCompleted(int turnCount)
        {
            _turnCount = turnCount;
            OnTurnsCountChangeEvent?.Invoke(turnCount);
            if (!_currentTurnHadMatch)
            {
                _currentMatchStreak = 0;
            }
            _currentTurnHadMatch = false;
        }

        public void OnCardMatched(int matchCount)
        {
            _matchCount = matchCount;
            _currentTurnHadMatch = true;
            _currentMatchStreak++;
            if (_currentMatchStreak > _bestMatchStreak)
            {
                _bestMatchStreak = _currentMatchStreak;
            }

            _score += CalculateScoreForMatch();
            OnMatchesCountChangeEvent?.Invoke(matchCount);
        }

        public GameEndSummaryDto GetSummary()
        {
            // If game not yet ended, use current realtime to show live elapsed time
            var currentTime = Time.realtimeSinceStartup;
            var endTime = _sessionEndTime > _sessionStartTime ? _sessionEndTime : currentTime;
            var elapsedSeconds = Mathf.Max(0f, endTime - _sessionStartTime);
            var progress = _totalMatchesRequired == 0
                ? 0
                : Mathf.RoundToInt((float)_matchCount / _totalMatchesRequired * 100f);
            return new GameEndSummaryDto(_score, _matchCount, _turnCount, _bestMatchStreak, elapsedSeconds, progress);
        }

        public string GetMessage()
        {
            return "Gameplay Message!";
        }

        private int CalculateScoreForMatch()
        {
            const int baseScorePerMatch = 100;
            const int streakBonus = 25;
            return baseScorePerMatch + streakBonus * Math.Max(0, _currentMatchStreak - 1);
        }
    }
}