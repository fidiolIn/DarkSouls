using UnityEngine;
using UnityEngine.UI;

namespace Sources.View
{
    public class WarriorView : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private Image staminaBar;

        public void UpdateHealthBar(float health, float maxHealth)
        {
            healthBar.fillAmount = health / maxHealth;
        }

        public void UpdateStaminaBar(float stamina, float maxStamina)
        {
            staminaBar.fillAmount = stamina / maxStamina;
        }
    }
}
