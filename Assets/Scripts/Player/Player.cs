using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(PlayerStateManager))]
[RequireComponent(typeof(BasicAttack))]

public class Player : BaseUnit
{
    private PlayerMotor _playerMotor;
    private InputManager _inputManager;
    private PlayerStateManager _stateManager;
    private BasicAttack _basicAttack;

    private void Start()
    {
        _playerMotor = GetComponent<PlayerMotor>();
        _inputManager = GetComponent<InputManager>();
        _stateManager = GetComponent<PlayerStateManager>();
        _basicAttack = GetComponent<BasicAttack>();
    }
    private void Update()
    {
        if (_inputManager.AttackInput)
            _basicAttack.Attack();
        //Blah Blah Blah
    }
}
