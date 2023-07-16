namespace Sources.Entity
{
    public abstract class Weapon
    {
        private float _damage;
        private float _weight;

        public float Damage => _damage;
        public float Weight => _weight;

        public void Attack(IDamage enemy)
        {
            enemy.TakeDamage(_damage);
        }
    }
}
