using System;

namespace Game.Domain.Entities
{
    public class PlayerEntity
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public PlayerEntity(int maxHealth)
        {
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - damage);
        }
    }
}