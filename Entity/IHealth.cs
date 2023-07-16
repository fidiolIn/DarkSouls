namespace Sources.Entity
{
    public interface IHealth
    {
        public float MaxHealth { get; }
        public float Health { get; }
        public void DecreaseHealth(float amount);
        public bool IsAlive { get; }
        public void Die();
    }
}
