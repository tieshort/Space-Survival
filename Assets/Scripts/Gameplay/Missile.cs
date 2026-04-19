using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 20f;
    [SerializeField] private float lifetime = 3f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (lifetime < 0)
        {
            Destroy(gameObject);
            return;
        }

        _rb.MovePosition((Vector2)transform.position + speed * Time.fixedDeltaTime * (Vector2)transform.up);
        lifetime -= Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
