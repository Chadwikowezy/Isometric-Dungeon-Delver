using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private BaseUnit _baseUnit;

    private bool _attackInput;

    private Vector3 _moveInput;
    private Vector3 _rotationInput;

    private string[] _joysticks;

    private void Start()
    {
        _baseUnit = GetComponent<BaseUnit>();
        _joysticks = Input.GetJoystickNames();
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

        return input;
    }
    Vector3 DetectRotationInput()
    {
        Vector3 input;

        if (_joysticks == null)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hitInfo, 20);

            input = hitInfo.point;

            return input;
        }
        else
        {
            input = new Vector3(Input.GetAxis("Right Horizontal"), 0, Input.GetAxis("Right Vertical"));

            //for (int i = 0; i < Input.GetJoystickNames().Length; i++)
            //    Debug.Log(Input.GetJoystickNames()[i]);

            return input;
        }
    }

    //Properties
    public string[] Joysticks
    {
        get { return _joysticks; }
    }
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
