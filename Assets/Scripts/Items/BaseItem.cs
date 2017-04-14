using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    //Variables
    [SerializeField]
    private ItemType _itemType;
    private ItemRarity _itemRarity;

    [SerializeField]
    private string _itemName,
                   _itemDescription;

    [SerializeField]
    private int _goldValue,
                _weight,
                _dropRate;

    [SerializeField]
    private Sprite _icon;

    //Properties
    public int GoldValue
    {
        get { return _goldValue; }
        set { _goldValue = value; }
    }
    public int Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }
    public int DropRate
    {
        get { return _dropRate; }
        set { _dropRate = value; }
    }
    public string ItemName
    {
        get { return _itemName; }
        set { _itemName = value; }
    }
    public string ItemDescription
    {
        get { return _itemDescription; }
        set { _itemDescription = value; }
    }
    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public ItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }
    public ItemRarity ItemRarity
    {
        get { return _itemRarity; }
        set { _itemRarity = value; }
    }
}
