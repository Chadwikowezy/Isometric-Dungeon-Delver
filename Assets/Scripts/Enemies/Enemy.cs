using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : BaseUnit
{
    public MonsterType monsterType;

    public Item itemDrop;

    public bool detectedPlayer;

    public float aggroRadius,
                 waypointDetectionRadius;

    private GameObject currentWaypoint;

    private Vector3 _currentPosition,
                    _destination;

    private Rigidbody _rb;

    private List<GameObject> allWaypoints = new List<GameObject>();

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        FindAllWaypoints();
        StartCoroutine(ChangeMoveState());

        print(_destination);
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void FindAllWaypoints()
    {
        GameObject[] waypoints = FindObjectsOfType<GameObject>();

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i].layer == 8)
            {
                allWaypoints.Add(waypoints[i]);
            }
        }
    }
    void SetCurrentWaypoint()
    {
        List<GameObject> moveableWaypoints = new List<GameObject>();

        for (int i = 0; i < allWaypoints.Count; i++)
        {
            float distance = (allWaypoints[i].transform.position - transform.position).magnitude;

            if (distance < waypointDetectionRadius)
            {
                moveableWaypoints.Add(allWaypoints[i]);
            }
        }

        _destination = moveableWaypoints[(int)Random.Range(0, moveableWaypoints.Count)].transform.position;
    }
    void MoveCharacter()
    {
        Vector3 moveDirection = (_destination - transform.position).normalized;
        moveDirection.y = transform.position.y;

        if ((_destination - transform.position).magnitude > 0.1f)
            _rb.velocity = moveDirection * Speed;
        else
            _rb.velocity = Vector3.zero;
    }

    IEnumerator ChangeMoveState()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));

        if (!detectedPlayer)
        {
            float randomNumber = Random.Range(0f, 1f);

            if (randomNumber <= 0.25f)
            {
                moveState = MoveState.Idle;
                _destination = transform.position;
            }
            else if (randomNumber >= 0.26f && randomNumber <= 0.50f)
            {
                _destination = transform.position;
                moveState = MoveState.Standing;
            }
            else
            {
                moveState = MoveState.Running;
                SetCurrentWaypoint();
            }
        }
        else
        {
            moveState = MoveState.Running;
        }

        StartCoroutine(ChangeMoveState());
    }
}
