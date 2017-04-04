using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody _rb;
    private InputManager _inputManager;
    private BaseUnit _stats;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inputManager = GetComponent<InputManager>();
        _stats = GetComponent<BaseUnit>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        if (_stats.moveState != MoveState.Running)
            return;

        if (_rb.velocity.magnitude < _stats.MaxSpeed)
        {
            _rb.AddForce(_inputManager.MoveInput * _stats.Speed);
        }
    }
    void RotatePlayer()
    {
        Vector3 lookDirection = _inputManager.RotationInput - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        lookDirection.y = transform.position.y;
        lookRotation.x = 0;
        lookRotation.z = 0;

        transform.rotation = lookRotation;
    }
}
