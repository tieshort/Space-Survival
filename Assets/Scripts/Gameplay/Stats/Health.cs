using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float baseValue = 20.0f;

    public float HealthMultiplier { get; set; } = 1f;
    public float AdditionalBaseHealth { get; set; } = 0f;

    private float maxValue;
    private float actualValue;

    public UnityEvent OnDamage;
    public UnityEvent OnLethalDamage;

    private void OnEnable()
    {
        CalculateHealth();
    }

    private void CalculateHealth()
    {
        maxValue = (baseValue + AdditionalBaseHealth) * HealthMultiplier;
        actualValue = maxValue;
    }

    public void UpdateHealthBar(Slider healthBar)
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxValue;
            healthBar.minValue = 0;
            healthBar.value = actualValue;
        }
    }

    public void TakeDamage(float damage)
    {
        if (actualValue == 0) return;

        actualValue = Mathf.Max(0, actualValue - damage);

        if (actualValue == 0)
        {
            gameObject.SetActive(false);
            OnLethalDamage.Invoke();
            return;
        }

        OnDamage.Invoke();
    }
}