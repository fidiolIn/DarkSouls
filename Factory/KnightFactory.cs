using Sources.Entity;
using UnityEngine;

namespace Sources.Factory
{
    [CreateAssetMenu(fileName = "KnightFactory", menuName = "WarriorFactory")]
    public class KnightFactory : WarriorFactory
    {
        public override AbstractWarrior CreateWarrior()
        {
            return new Knight(MaxHealth, MaxStamina, Weight, Strength);
        }
    }
}
