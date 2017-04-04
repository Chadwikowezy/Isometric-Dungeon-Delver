using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public string itemName,
                  description;

    public int health,
               attack,
               defense;
}
