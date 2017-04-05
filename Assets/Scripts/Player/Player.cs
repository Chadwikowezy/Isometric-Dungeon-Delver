using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(PlayerStateManager))]

public class Player : BaseUnit
{
    private PlayerMotor _playerMotor;
    private InputManager _inputManager;
    private PlayerStateManager _stateManager;

    private void Start()
    {
        _playerMotor = GetComponent<PlayerMotor>();
        _inputManager = GetComponent<InputManager>();
        _stateManager = GetComponent<PlayerStateManager>();
    }
}
