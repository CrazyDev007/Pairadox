using Game.Application.Interfaces;
using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public class StartGameUseCase
    {
        private readonly IGameInitializer _gameInitializer;
        public StartGameUseCase(IGameInitializer gameInitializer) => _gameInitializer = gameInitializer;

        public void Execute(GameModeConfig config) => _gameInitializer.Initialize(config);
    }
}