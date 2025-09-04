using Game.Application.Interfaces;
using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public interface ILoadingBarUseCase
    {
        void Execute(ILoadingBar loadingBar, float progress, ILoadingBarCallback loadingBarCallback);
    }
}