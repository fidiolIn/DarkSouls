namespace Sources.Entity
{
    public interface IAttack
    {
        public void Attack(Weapon weapon, IDamage enemy);
    }
}
