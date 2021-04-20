using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    [HideInInspector]
    public Dictionary<Combo, Combo> comboMap = new Dictionary<Combo, Combo>();
    public List<Combo> combo_list = new List<Combo>();

    public GameObject ItemGroup;
    [HideInInspector]
    public Item[] selItem = new Item[2];

    public static InventoryManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        foreach (Combo combo in combo_list)
        {
            comboMap.Add(combo, combo);
        }
    }

    public void AddItem(Item item)
    {
        if (items.Count == 6)
        {
            Debug.Log("Inventory full");
        } else
        {
            items.Add(item);
            UpdateItemGroup();
        }
    }

    public void DeleteItem(Item item)
    {
        items.Remove(item);
        UpdateItemGroup();
    }

    public void SelectItem()
    {
        Item found = items[this.GetComponent<ItemButton>().index];
        if (found == null)
        {
            ClearSelection();
        } else if (selItem[0] == null)
        {
            selItem[0] = found;
        } else
        {
            selItem[1] = found;
            CompleteCombo();
            ClearSelection();
            UpdateItemGroup();
        }
    }

    private void ClearSelection()
    {
        for (int i=0; i<selItem.Length; i++)
        {
            selItem[i] = null;
        }
    }

    private void CompleteCombo()
    {
        Combo poss = new Combo(selItem[0], selItem[1], null);
        Combo found;
        if (comboMap.ContainsKey(poss))
        {
            comboMap.TryGetValue(poss, out found);
            AddItem(found.final);
        }
    }

    private void UpdateItemGroup()
    {
        for (int i=0; i<items.Count; i++)
        {
            Image image = ItemGroup.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            image.sprite = items[i].sprite;
            image.enabled = true;
        }
    } 
}

[System.Serializable]
public class Combo {
    public Item item_one, item_two, final;

    public Combo(Item item_one, Item item_two, Item final)
    {
        this.item_one = item_one;
        this.item_two = item_two;
        this.final = final;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Combo);
    }
    public bool Equals(Combo c)
    {
        if (this.item_one.Equals(c.item_one))
        {
            return this.item_two.Equals(c.item_two);
        }
        else if (this.item_one.Equals(c.item_two))
        {
            return this.item_two.Equals(c.item_one);
        }
        return false;
    }
    public override int GetHashCode()
    {
        return (item_one.item_name + item_two.item_name + final.item_name).GetHashCode();
    }
}

