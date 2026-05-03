using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 5;
    private Vector2 targetDirection;

    public float AdditionalBaseSpeed { get; set; }
    public float SpeedMultiplier { get; set; }

    private float actualRotationSpeed;

    public void SetRotation(Vector2 direction)
    {
        targetDirection = direction;
    }

    private void OnEnable()
    {
        CalculateRotationSpeed();
    }

    private void CalculateRotationSpeed()
    {
        actualRotationSpeed = (rotationSpeed + AdditionalBaseSpeed) * SpeedMultiplier;
    }

    private void Update()
    {
        Vector2 dir = Vector2.Lerp(transform.up, targetDirection, actualRotationSpeed * Time.deltaTime);
        transform.up = dir;
    }
}
