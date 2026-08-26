using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] Slider healthBar;

    float minHealth;
    float maxHealth;
    float currentHealth;

    public void OnHealthSetup(float targetMin, float targetMax)
    {
        minHealth = targetMin;
        maxHealth = targetMax;
        currentHealth = maxHealth;

        healthBar.minValue = minHealth;
        healthBar.maxValue = maxHealth;

        UpdateHealthBar();
        UpdateHealthText();
    }

    public void OnHealthChanged(float newHealthValue, float oldHealthValue)
    {
        currentHealth = newHealthValue;

        UpdateHealthBar();
        UpdateHealthText();
    }

    private void UpdateHealthBar()
    { healthBar.value = currentHealth; }

    private void UpdateHealthText()
    { healthText.text = currentHealth.ToString(); }
}
