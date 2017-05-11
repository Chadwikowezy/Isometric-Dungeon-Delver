using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConsumable : BaseItem
{
    [SerializeField]
    private int _healthChange,
                _attackChange,
                _defenseChange;

    [SerializeField]
    private float _rangeChange,
                  _knockbackChange,
                  _cooldownChange,
                  _stunTimeChange;

    //Properties
    public int Health
    { get { return _healthChange; } set { } }
    public int Attack
    { get { return _attackChange; } set { } }
    public int Defense
    { get { return _defenseChange; } set { } }
    public float Range
    { get { return _rangeChange; } set { } }
    public float Knockback
    { get { return _knockbackChange; } set { } }
    public float Cooldown
    { get { return _cooldownChange; } set { } }
    public float StunTime
    { get { return _stunTimeChange; } set { } }
}
