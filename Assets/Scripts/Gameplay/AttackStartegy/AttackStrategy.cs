using UnityEngine;
using UnityEngine.Events;

public abstract class AttackStrategy : MonoBehaviour
{
    [SerializeField] protected Transform attackOriginOverride;
    protected Transform attackOrigin;

    [Min(0f)] public float damage = 10f;

    [Min(0.0001f)] public float attackRate = 1f;
    protected float interval;
    protected float timer;

    [Range(0f, 1f)] public float accuracy = 1f;
    [Range(0f, 89f)] public float maxAngle = 30f;

    public bool isAttacking = false;

    public UnityEvent OnAttack;

    protected void Awake()
    {
        attackOrigin = attackOriginOverride != null ? attackOriginOverride : transform;
        interval = 1f / attackRate;
    }

    protected virtual void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        if (isAttacking)
        {
            Attack();
            timer = interval;
        }
    }

    public abstract void Attack();

    protected Vector2 CalculateActualDirection(Vector2 direction)
    {
        // Считаем отклонение,
        // при минимальной точности отклонение будет случайным в районе [-1; 1],
        // при максимальной точности - будет равно нулю
        float variance = Random.Range(accuracy - 1f, 1f - accuracy);
        float angle = variance * maxAngle;

        Vector2 resultDirection = Quaternion.AngleAxis(angle, Vector3.forward) * direction;

        return resultDirection;
    }
}
