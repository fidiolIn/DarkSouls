namespace Sources.Entity
{
    public interface IStamina
    {
        public float MaxStamina { get; }
        public float Stamina { get; }
        public void DecreaseStamina(float amount);
        public void IncreaseStamina(float amount);
    }
}
