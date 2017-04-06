using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody _rb;
    private InputManager _inputManager;
    private BaseUnit _stats;

    [SerializeField]
    private float _rotateSpeed;

    private Quaternion lookRotation;

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
            _rb.AddForce(_inputManager.MoveInput * _stats.Speed);
    }
    void RotatePlayer()
    {
        Quaternion newRotation;

        if (_inputManager.Joysticks.Length > 0)
            newRotation = ControllerRotation();
        else
            newRotation = MouseRotation();

        transform.rotation = newRotation;
    }

    Quaternion ControllerRotation()
    {
        Vector3 rotationInput = _inputManager.RotationInput;

        if (rotationInput.magnitude < 0.1f)
            return _rb.rotation;

        float targetAngle = Mathf.Atan2(rotationInput.x, rotationInput.z) * Mathf.Rad2Deg;
        float newAngle = Mathf.Lerp(_rb.rotation.eulerAngles.y, targetAngle, _rotateSpeed);
        Quaternion newRotation;

        newRotation = Quaternion.Lerp(_rb.rotation, Quaternion.Euler(new Vector3(0, targetAngle, 0)), _rotateSpeed);

        return newRotation;
    }
    Quaternion MouseRotation()
    {
        Quaternion newRotation;

        Vector3 rotationInput = _inputManager.RotationInput;
        Vector3 lookDirection = rotationInput - _rb.position;

        newRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        return newRotation;
    }
}
