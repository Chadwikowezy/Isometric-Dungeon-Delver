using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> equipableItems;
    public List<GameObject> consumableItems;
    public List<GameObject> reuseableItems;

    public Dictionary<string, GameObject> equipItems;
    public Dictionary<string, GameObject> consumeItems;
    public Dictionary<string, GameObject> reuseItems;

    private void Start()
    {
        InitializeDictionaries();
    }

    void InitializeDictionaries()
    {
        equipItems = new Dictionary<string, GameObject>();
        consumeItems = new Dictionary<string, GameObject>();
        reuseItems = new Dictionary<string, GameObject>();

        for (int i = 0; i < equipableItems.Count; i++)
        {
            string itemName = equipableItems[i].GetComponent<BaseItem>().ItemName;
            equipItems.Add(itemName, equipableItems[i]);
        }

        for (int i = 0; i < consumableItems.Count; i++)
        {
            string itemName = consumableItems[i].GetComponent<BaseItem>().ItemName;
            consumeItems.Add(itemName, equipableItems[i]);
        }

        for (int i = 0; i < reuseableItems.Count; i++)
        {
            string itemName = reuseableItems[i].GetComponent<BaseItem>().ItemName;
            reuseItems.Add(itemName, equipableItems[i]);
        }
    } 
}
