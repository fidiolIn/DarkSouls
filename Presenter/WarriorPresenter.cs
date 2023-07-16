using Sources.Entity;
using Sources.Factory;
using Sources.Scripts;
using Sources.View;
using UnityEngine;

namespace Sources.Presenter
{
    [RequireComponent(typeof(WarriorMovement), typeof(WarriorView))]
    public abstract class WarriorPresenter : MonoBehaviour
    {
        private AbstractWarrior _warrior;
        private WarriorMovement _warriorMovement;
        private WarriorView _warriorView;
        [SerializeField] private WarriorFactory warriorFactory;

        private void OnHealthChanged(float health)
        {
            _warriorView.UpdateHealthBar(health, _warrior.MaxHealth);
        }

        private void OnStaminaChanged(float stamina)
        {
            _warriorView.UpdateStaminaBar(stamina, _warrior.MaxStamina);
        }

        public void Initialize()
        {
            _warriorView = GetComponent<WarriorView>();
            _warriorMovement = GetComponent<WarriorMovement>();
            _warrior = warriorFactory.CreateWarrior();
            _warriorMovement.Warrior = _warrior;

            _warrior.StaminaChanged += OnStaminaChanged;
            _warrior.HealthChanged += OnHealthChanged;
            _warrior.TakedDamage += OnTakedDamage;
            _warrior.Attacked += OnAttacked;
            _warrior.Died += OnDied;
        }

        private void OnDied()
        {
            GameEvent.GameOver();
        }

        private void OnAttacked()
        {
            //TODO: attack animation from WarriorView
        }

        private void OnTakedDamage()
        {
            //TODO: damage animation from WarriorView
        }

        public void Move()
        {
            _warriorMovement.Move();
        }

        public void Jump()
        {
            _warriorMovement.Jump();
        }

        public void IncreaseStamina()
        {
            _warrior.IncreaseStamina(Time.deltaTime);
        }
    }
}
