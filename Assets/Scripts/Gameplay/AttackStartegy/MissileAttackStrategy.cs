using UnityEngine;

//[CreateAssetMenu(fileName = "MissileShotAttackStrategy", menuName = "Scriptable Objects/Missile Shot Attack Strategy")]
public class MissileAttackStrategy : AttackStrategy
{
    public GameObject missilePrefab;
    public string missileLayerName;

    public override void Attack()
    {
        Vector2 actualDirection = CalculateActualDirection(transform.up);

        var missile = Instantiate(missilePrefab, attackOrigin.position, Quaternion.LookRotation(Vector3.forward, actualDirection));
        missile.layer = LayerMask.NameToLayer(missileLayerName);
        OnAttack.Invoke();
    }
}
