using Sources.Entity;

namespace Sources.Scripts
{
    public class WarriorMovement : PlayerMovement
    {
        private AbstractWarrior _warrior;

        public AbstractWarrior Warrior
        {
            get => _warrior;
            set => _warrior = value;
        }

        private float CalculateStaminaConsumedPerJump()
        {
            return _warrior.Weight / 300 * _warrior.MaxStamina;
        }

        public override void Jump()
        {
            base.Jump();
            float staminaConsumed = CalculateStaminaConsumedPerJump();
            _warrior.DecreaseStamina(staminaConsumed);
        }
    }
}
