using UnityEngine;

public class CurrencyClaimer : MonoBehaviour
{
    [SerializeField, Min(0)] private float vacuumRadius = 5f;
    [SerializeField, Min(0)] private float vacuumForce = 10f;
    [SerializeField] private LayerMask currencyLayer;

    private void FixedUpdate()
    {
        Collider2D[] currencyColliders = Physics2D.OverlapCircleAll(transform.position, vacuumRadius, currencyLayer);
        foreach (var currencyCollider in currencyColliders)
        {
            Vector3 currencyDirection = (transform.position - currencyCollider.transform.position).normalized;
            currencyCollider.transform.Translate(Time.fixedDeltaTime * vacuumForce * currencyDirection);
        }
    }

    public void TryGetCurrency(GameObject coin)
    {
        if (coin.TryGetComponent<CurrencyItem>(out var currencyItem))
        {
            currencyItem.Claim();
        }
    }

    public void ClaimAll()
    {
        foreach(var coin in FindObjectsByType<CurrencyItem>(FindObjectsSortMode.None))
        {
            coin.Claim();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryGetCurrency(collision.gameObject);
    }
}
