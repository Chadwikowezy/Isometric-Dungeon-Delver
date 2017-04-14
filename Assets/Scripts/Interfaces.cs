using System.Collections;
using UnityEngine;

public interface IEquipable
{ void Equip(); }

public interface IConsumable
{ void Consume(); }

public interface IReusable
{ void Use(); }

public interface IItem
{
    ItemType ItemType
    { get; set; }
    ItemRarity ItemRarity
    { get; set; }

    int GoldValue
    { get; set; }
    int Weight
    { get; set; }
    int DropRate
    { get; set; }

    string ItemName
    { get; set; }
    string ItemDescription
    { get; set; }

    Sprite Icon
    { get; set; }
}
