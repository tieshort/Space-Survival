using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    private Health health;
    [SerializeField] private Slider healthBar;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.OnDamage.AddListener(() => health.UpdateHealthBar(healthBar));
        health.OnLethalDamage.AddListener(() => health.UpdateHealthBar(healthBar));
        health.UpdateHealthBar(healthBar);
    }
}
