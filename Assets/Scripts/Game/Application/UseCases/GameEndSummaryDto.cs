namespace Game.Application.UseCases
{
    /// <summary>
    /// Immutable snapshot of gameplay results used by the game end screen.
    /// </summary>
    public readonly struct GameEndSummaryDto
    {
        public GameEndSummaryDto(int finalScore, int totalMatches, int totalTurns, int bestStreak,
            float elapsedSeconds, int levelProgressPercent)
        {
            FinalScore = finalScore;
            TotalMatches = totalMatches;
            TotalTurns = totalTurns;
            BestStreak = bestStreak;
            ElapsedSeconds = elapsedSeconds;
            LevelProgressPercent = levelProgressPercent;
        }

        public int FinalScore { get; }
        public int TotalMatches { get; }
        public int TotalTurns { get; }
        public int BestStreak { get; }
        public float ElapsedSeconds { get; }
        public int LevelProgressPercent { get; }
    }
}
