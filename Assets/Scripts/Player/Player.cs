using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(InputManager))]

public class Player : BaseUnit
{
    private PlayerMotor _playerMotor;
    private InputManager _inputManager;

    private void Start()
    {
        _playerMotor = GetComponent<PlayerMotor>();
        _inputManager = GetComponent<InputManager>();
    }
}
