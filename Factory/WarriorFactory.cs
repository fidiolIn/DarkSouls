using Sources.Entity;
using UnityEngine;

namespace Sources.Factory
{
    public abstract class WarriorFactory : ScriptableObject
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private float maxStamina;
        [SerializeField] private float weight;
        [SerializeField] private float strength;

        public float MaxHealth => maxHealth;
        public float MaxStamina => maxStamina;
        public float Weight => weight;
        public float Strength => strength;

        public abstract AbstractWarrior CreateWarrior();
    }
}
