using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(IItem item, Transform itemTf)
    {
        itemTf.SetParent(transform);
        
        items.Add(item.Obj);
    }
}