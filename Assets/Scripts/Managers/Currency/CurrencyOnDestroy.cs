using UnityEngine;

public class CurrencyOnDestroy : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private CurrencyItemDropChance[] dropList;
    [SerializeField] private float maxDropRadius = 5f;

    private void Awake()
    {
        health.OnLethalDamage.AddListener(DropCurrency);
    }

    private void DropCurrency()
    {
        foreach (var item in dropList)
        {
            int rnd = Random.Range(0, 101);
            if (rnd <= item.dropChance)
            {
                Vector2 dropPosition = (Vector2)transform.position + Random.insideUnitCircle * maxDropRadius;
                Instantiate(item.gameObject, dropPosition, Quaternion.identity);
            }
        }
    }
}
[System.Serializable]
public struct CurrencyItemDropChance
{
    public GameObject gameObject;
    [Range(0, 100)] public float dropChance;
}
