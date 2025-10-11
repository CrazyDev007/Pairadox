using Game.Application.UseCases;

namespace Game.Presentation
{
    public interface IGameResultsProvider
    {
        GameEndSummaryDto GetSummary();
    }
}
