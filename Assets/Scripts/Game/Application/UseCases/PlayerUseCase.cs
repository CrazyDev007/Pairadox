using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public class PlayerUseCase
    {
        private readonly PlayerEntity _playerEntity;
        public PlayerUseCase(PlayerEntity playerEntity) => _playerEntity = playerEntity;
        public void ExecuteTakeDamage(int damage) => _playerEntity.TakeDamage(damage);
        public int ExecuteGetPlayerHealth() => _playerEntity.CurrentHealth;
    }
}