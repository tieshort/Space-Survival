using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Vector2 targetPosition;
    public Vector2 TargetDirection { get; private set; }
    public float TargetDistance { get; private set; }

    [SerializeField] private float speed = 5f;
    public float minReachedDistanceLength = .1f;

    private Rigidbody2D _rb;

    public float AdditionalBaseSpeed { get; set; } = 0f;
    public float SpeedMultiplier { get; set; } = 1f;

    private float actualSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        CalculateSpeed();
    }

    private void CalculateSpeed()
    {
        actualSpeed = (speed + AdditionalBaseSpeed) * SpeedMultiplier;
    }

    public void SetPosition(Vector2 newTargetPosition)
    {
        targetPosition = newTargetPosition;
    }

    private void Update()
    {
        TargetDistance = (targetPosition - (Vector2)transform.position).magnitude;
        TargetDirection = (targetPosition - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate()
    {
        // если не добрались до целевой точки, движемся к ней
        if (TargetDistance > minReachedDistanceLength)
        {
            Move();
            return;
        }
        
        // Сбрасываем скорость, чтобы корабли не трясло из-за столкновений
        _rb.linearVelocity = Vector2.zero;
    }

    private void Move()
    {
        _rb.MovePosition((Vector2)transform.position + actualSpeed * Time.fixedDeltaTime * TargetDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, TargetDirection * 2f);
    }
}
