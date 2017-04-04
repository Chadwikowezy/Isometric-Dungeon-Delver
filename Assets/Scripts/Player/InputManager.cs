using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private BaseUnit _baseUnit;

    private Vector3 _moveInput;

    private void Start()
    {
        _baseUnit = GetComponent<BaseUnit>();
    }
    private void Update()
    {
        _moveInput = DetectMoveInput();
    }

    public Vector3 DetectMoveInput()
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

    //Properties
    public Vector3 MoveInput
    {
        get { return _moveInput; }
    }
}
