using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public UnitType unitType;
    public UnitClass unitClass;
    public MoveState moveState;

    [SerializeField]
    private int _health,
                _maxHealth,
                _attack,
                _defense;

    [SerializeField]
    private float _speed,
                  _maxSpeed;

    //Properties
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    public int Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }
    public int Defense
    {
        get { return _defense; }
        set { _defense = value; }
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float MaxSpeed
    {
        get { return _maxHealth; }
        set { _maxSpeed = value; }
    }
}
