using UnityEngine;

public class BeamerAttackStrategy : AttackStrategy
{
    [SerializeField] private LineRenderer beamer;
    [SerializeField] private float maxLineLength = 10f;
    [SerializeField] private float lineWidth = 0.3f;
    [SerializeField] private LayerMask hitLayers;

    private RaycastHit2D hit;

    private void Start()
    {
        beamer.enabled = false;
    }

    protected override void Update()
    {
        beamer.enabled = isAttacking;
        beamer.SetPosition(0, attackOrigin.position);
        if (hit.collider != null)
        {
            beamer.SetPosition(1, hit.point);
            if (isAttacking)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                    return;
                }
                Attack();
                timer = interval;
            }
            return;
        }
        beamer.SetPosition(1, attackOrigin.position + attackOrigin.up * maxLineLength);
    }

    public override void Attack()
    {
        if (hit.collider != null && hit.collider.TryGetComponent<Health>(out var health))
        {
            //float dmgMultiplier = Time.deltaTime / interval;
            health.TakeDamage(damage);
        }
        OnAttack.Invoke();
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(attackOrigin.position, attackOrigin.up, maxLineLength, hitLayers);
    }

    private void OnDrawGizmos()
    {
        if (attackOrigin)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(attackOrigin.position, attackOrigin.up * maxLineLength);
        }
    }
}
