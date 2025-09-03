using Game.Domain.Entities;

namespace Game.Application.Interfaces
{
    public interface ISaveService
    {
        void SaveGameMode(GameModeConfig gameConfigToSave);
        GameModeConfig LoadGameMode();
    }
}