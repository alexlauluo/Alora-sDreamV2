using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string item_name;
    public Sprite sprite;

    public override bool Equals(object obj)
    {
        return Equals(obj as Item);
    }
    public bool Equals(Item item)
    {
        return item.item_name.Equals(this.item_name) && item.sprite.Equals(this.sprite);
    }
    public override int GetHashCode()
    {
        return item_name.GetHashCode();
    }
}
