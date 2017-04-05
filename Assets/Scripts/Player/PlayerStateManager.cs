using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private BaseUnit _baseUnit;
    private InputManager _inputManager;

    private void Start()
    {
        _baseUnit = GetComponent<BaseUnit>();
        _inputManager = GetComponent<InputManager>();
    }
    private void Update()
    {
        ManageMoveStates();
    }

    void ManageMoveStates()
    {
        if (_baseUnit.moveState != MoveState.KnockedBack && _baseUnit.moveState != MoveState.Stuned)
        {
            if (_inputManager.MoveInput != Vector3.zero)
                _baseUnit.moveState = MoveState.Running;
            else
                _baseUnit.moveState = MoveState.Standing;
        }
    }
}
