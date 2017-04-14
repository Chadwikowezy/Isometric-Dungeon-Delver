using System.Collections;
using UnityEngine;

public interface IEquipable
{ void Equip(BaseUnit character); }

public interface IConsumable
{ void Consume(); }

public interface Reuseable
{ void Use(); }
