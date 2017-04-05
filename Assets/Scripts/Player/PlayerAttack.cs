using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private BaseUnit _baseUnit;
    private InputManager _inputManager;

    private bool isAttacking;

    private void Start()
    {
        _baseUnit = GetComponent<BaseUnit>();
        _inputManager = GetComponent<InputManager>();
    }
    private void Update()
    {
        if (_inputManager.AttackInput)
            Attack();
    }

    void Attack()
    {
        if (isAttacking)
            return;

        int layerMask = 1 << 9;
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, _baseUnit.BasicAttackRange, layerMask))
        {
            BaseUnit enemy = hitInfo.rigidbody.gameObject.GetComponent<BaseUnit>();

            enemy.Health -= _baseUnit.Attack - enemy.Defense;
            hitInfo.rigidbody.AddForceAtPosition(transform.forward * _baseUnit.BasicAttackKnockback, hitInfo.point);
        }

        isAttacking = true;
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_baseUnit.BasicAttackCooldown);
        isAttacking = false;
        print(isAttacking);
    }
}
