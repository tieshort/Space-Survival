using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 5;
    private Vector2 targetDirection;


    public void SetRotation(Vector2 direction)
    {
        targetDirection = direction;
    }

    private void Update()
    {
        Vector2 dir = Vector2.Lerp(transform.up, targetDirection, rotationSpeed * Time.deltaTime);
        transform.up = dir;
    }
}
