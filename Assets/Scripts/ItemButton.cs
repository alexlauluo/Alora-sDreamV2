using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [HideInInspector]
    public int index;

    public Color defaultColor = new Color32(161, 108, 195, 255);
    public Color selectedColor = new Color32(131, 84, 195, 255);

    private void Awake()
    {
        Transform parent = this.transform.parent;
        for (int i=0; i<parent.childCount; i++)
        {
            if (parent.GetChild(i).name.Equals(this.gameObject.name))
            {
                index = i;
                break;
            }
        }
    }

    public void resetButtonColor()
    {
        this.GetComponent<Image>().color = defaultColor;
    }

    public void changeButtonColor()
    {
        this.GetComponent<Image>().color = selectedColor;
    }
}
