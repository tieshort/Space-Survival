using UnityEngine;

[RequireComponent(typeof(Movement), typeof(Rotation), typeof(Attack))]
public class UnitAI : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    [SerializeField] private string _targetName = "Player";
    private Movement _movement;
    private Rotation _rotation;
    private Attack _attack;

    //[SerializeField] private float _reachedDistanceLength = 5f;
    [SerializeField] private float _attackRange = 10f;
    [SerializeField] private float _updateStep = .1f;

    private float _timer;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _rotation = GetComponent<Rotation>();
        _attack = GetComponent<Attack>();
        //_movement.minReachedDistanceLength = _reachedDistanceLength;
    }

    private void OnEnable()
    {
        FindTarget();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            return;
        }

        _timer = _updateStep;

        if (_targetTransform != null)
        {
            _movement.SetPosition((Vector2)_targetTransform.position);

            _rotation.SetRotation(_movement.TargetDirection);

            if(_movement.TargetDistance <= _attackRange)
            {
                _attack.isAttacking = true;
                return;
            }
            
            _attack.isAttacking = false;
        }

    }

    private void FindTarget()
    {
        _targetTransform = GameObject.Find(_targetName).transform;
    }
}
