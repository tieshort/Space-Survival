using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement), typeof(Rotation), typeof(Attack))]
public class PlayerController : MonoBehaviour
{
    public bool useLocalMovementCoordinates;

    private Movement _movement;
    private Rotation _rotation;
    private Attack _attack;

    private Vector2 _moveDirection;
    private Vector2 _lookDirection;

    private ArcadeInput input;
    private InputAction attackAction;
    private InputAction moveAction;
    private InputAction mouseLookAction;
    private InputAction stickLookAction;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _rotation = GetComponent<Rotation>();
        _attack = GetComponent<Attack>();

        input = new();

        attackAction = input.Player.Attack;
        moveAction = input.Player.Move;
        mouseLookAction = input.Player.MouseLook;
        stickLookAction = input.Player.StickLook;
    }

    private void Update()
    {
        ReadInput();

        Move();
        Rotate();
    }

    private void Rotate()
    {
        _rotation.SetRotation(_lookDirection);
    }

    private void Move()
    {
        Vector2 targetPosition = (Vector2)transform.position + _moveDirection;
        _movement.SetPosition(targetPosition);
    }

    private void ReadInput()
    {
        _moveDirection = moveAction.ReadValue<Vector2>();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mouseLookAction.ReadValue<Vector2>());

        _lookDirection = (mousePosition - (Vector2)transform.position).normalized;

        if (useLocalMovementCoordinates)
        {
            _moveDirection = (Vector2)(transform.rotation * (Vector3)_moveDirection);
        }

        _attack.isAttacking = attackAction.IsPressed();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
