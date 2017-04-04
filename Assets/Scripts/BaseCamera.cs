using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCamera : MonoBehaviour
{
    public float speed;

    public Vector3 positionOffset;

    private GameObject _target;

    private void Start()
    {
        if (FindObjectOfType<Player>())
            _target = FindObjectOfType<Player>().gameObject;
    }
    private void FixedUpdate()
    {
        moveCamera();
    }

    void moveCamera()
    {
        Vector3 targetPosition = _target.transform.position;

        targetPosition = targetPosition + positionOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * 0.01f);

        transform.LookAt(_target.transform, Vector3.up);
    }
}
