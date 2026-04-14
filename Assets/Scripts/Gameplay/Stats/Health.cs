using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float baseValue = 20.0f;
    [SerializeField] private Slider linkedHealthBar;

    public float HealthMultiplier { get; set; } = 1f;
    public float AdditionalBaseHealth { get; set; } = 0f;

    private float actualValue;

    public UnityEvent OnLethalDamage;

    private void Start()
    {
        CalculateHealthValue();
    }

    public void CalculateHealthValue()
    {
        actualValue = (baseValue + AdditionalBaseHealth) * HealthMultiplier;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (linkedHealthBar != null)
        {
            linkedHealthBar.maxValue = actualValue;
            linkedHealthBar.minValue = 0;
            linkedHealthBar.value = actualValue;
        }
    }

    public void TakeDamage(float damage)
    {
        if (actualValue == 0) return;

        actualValue = Mathf.Max(0, actualValue - damage);

        if (linkedHealthBar != null)
        {
            linkedHealthBar.value = actualValue;
        }

        if (actualValue == 0)
        {
            gameObject.SetActive(false);
            OnLethalDamage.Invoke();
            return;
        }
    }
}