using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    private Team teamAffiliation; 

    [SerializeField]
    private int _health,
                _maxHealth,
                _attack,
                _defense;

    [SerializeField]
    private float _speed,
                  _maxSpeed,
                  _acceleration;
}
