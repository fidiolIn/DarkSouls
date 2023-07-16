using System;

namespace Sources.Entity
{
    public abstract class AbstractWarrior : IHealth, IStamina, IDamage, IAttack
    {
        private float _maxHealth;//
        private float _health;
        private float _maxStamina;
        private float _stamina;
        private float _weight;
        private float _strength;

        public float MaxHealth => _maxHealth;
        public float Health => _health;
        public float MaxStamina => _maxStamina;
        public float Stamina => _stamina;
        public float Weight => _weight;
        public bool IsAlive => _health > 0;

        public event Action Died;
        public event Action TakedDamage;
        public event Action Attacked;
        public event Action<float> StaminaChanged;
        public event Action<float> HealthChanged;

        public AbstractWarrior(float maxHealth, float maxStamina, float weight, float strength)
        {
            _maxHealth = maxHealth;
            _maxStamina = maxStamina;
            _weight = weight;
            _strength = strength;
            _stamina = maxStamina;
            _health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            DecreaseHealth(damage);
            TakedDamage?.Invoke();
        }

        public void DecreaseHealth(float amount)
        {
            if (IsAlive && amount >= 0)
            {
                _health -= amount;
                if (_health <= 0)
                {
                    Die();
                }

                HealthChanged?.Invoke(_health);
            }
        }

        public void DecreaseStamina(float amount)
        {
            if (IsAlive && amount >= 0)
            {
                _stamina -= amount;
                if (_stamina <= 0)
                {
                    _stamina = 0;
                }

                StaminaChanged?.Invoke(_stamina);
            }
        }

        public void IncreaseStamina(float amount)
        {
            if (IsAlive && amount >= 0)
            {
                _stamina += amount;
                if (_stamina >= _maxStamina)
                {
                    _stamina = _maxStamina;
                }

                StaminaChanged?.Invoke(_stamina);
            }
        }

        public void Attack(Weapon weapon, IDamage enemy)
        {
            if (weapon == null) return;
            if (enemy == null) return;
            if (IsAlive)
            {
                float staminaConsumedPerAttack = weapon.Weight / _strength * _maxStamina;
                if (_stamina >= staminaConsumedPerAttack)
                {
                    weapon.Attack(enemy);
                    DecreaseStamina(staminaConsumedPerAttack);
                    Attacked?.Invoke();
                }
            }
        }

        public void Die()
        {
            if (IsAlive)
            {
                _health = 0;
                Died?.Invoke();
            }
        }
    }
}
