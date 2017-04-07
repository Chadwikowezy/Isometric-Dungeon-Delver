using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    private bool _isAttacking;

    private BaseUnit _baseUnit;

    private void Start()
    {
        _baseUnit = GetComponent<BaseUnit>();
    }

    public void Attack()
    {
        if (_isAttacking)
            return;

        _isAttacking = true;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 1f))
        {
            BaseUnit otherCharacter = hitInfo.collider.gameObject.GetComponent<BaseUnit>();
            int damage = _baseUnit.Attack - otherCharacter.Defense;

            damage = Mathf.Clamp(damage, 0, _baseUnit.Attack);
            otherCharacter.Health -= damage;
            otherCharacter.moveState = MoveState.KnockedBack;

            StartCoroutine(otherCharacter.ResetMoveState(_baseUnit.BasicAttackStunTime));
            hitInfo.rigidbody.AddForce((hitInfo.rigidbody.position - transform.position).normalized * _baseUnit.BasicAttackKnockback);
        }

        StartCoroutine(AttackCooldown(_baseUnit.BasicAttackCooldown));
    }

    IEnumerator AttackCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);

        _isAttacking = false;
    }
}
