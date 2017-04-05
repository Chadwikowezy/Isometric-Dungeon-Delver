using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private BaseUnit _baseUnit;

    private bool _attackInput;

    private Vector3 _moveInput;
    private Vector3 _rotationInput;

    private void Start()
    {
        _baseUnit = GetComponent<BaseUnit>();
    }
    private void Update()
    {
        _attackInput = DetectAttackInput();
        _moveInput = DetectMoveInput();
        _rotationInput = DetectRotationInput();
    }

    bool DetectAttackInput()
    {
        bool input;

        input = Input.GetButton("Fire1");

        return input;
    }
    Vector3 DetectMoveInput()
    {
        Vector3 input;

        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = input.normalized;

        if (input == Vector3.zero)
            _baseUnit.moveState = MoveState.Standing;
        else
            _baseUnit.moveState = MoveState.Running;

        return input;
    }
    Vector3 DetectRotationInput()
    {
        Vector3 input;

        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hitInfo, 20);

        if (_baseUnit.moveState != MoveState.KnockedBack && _baseUnit.moveState != MoveState.Stuned)
            input = hitInfo.point;
        else
            input = Vector3.zero;

        return input;
    }

    //Properties
    public bool AttackInput
    {
        get { return _attackInput; }
    }
    public Vector3 MoveInput
    {
        get { return _moveInput; }
    }
    public Vector3 RotationInput
    {
        get { return _rotationInput; }
    }
}
