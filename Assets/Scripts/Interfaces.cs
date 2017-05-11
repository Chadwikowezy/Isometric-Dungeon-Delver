using System.Collections;
using UnityEngine;

public interface IEquipable
{
    int Health
    { get; set; }
    int Attack
    { get; set; }
    int Defense
    { get; set; }

    float Range
    { get; set; }
    float Knockback
    { get; set; }
    float Cooldown
    { get; set; }
    float StunTime
    { get; set; }

    void Equip(BaseUnit character);
    void Unequip(BaseUnit character);
}

public interface IConsumable
{ void Consume(BaseUnit character); }

public interface Reuseable
{ void Use(BaseUnit character); }
