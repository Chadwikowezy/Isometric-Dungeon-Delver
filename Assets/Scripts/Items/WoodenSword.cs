using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSword : BaseItem, IEquipable
{
    //Properties
    public int Health
    { get; set; }
    public int Attack
    { get; set; }
    public int Defense
    { get; set; }
    public float Range
    { get; set; }
    public float Knockback
    { get; set; }
    public float Cooldown
    { get; set; }
    public float StunTime
    { get; set; }

    public void Equip(BaseUnit character)
    {

    }
    public void Unequip(BaseUnit character)
    {

    }
}
