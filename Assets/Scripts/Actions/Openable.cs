using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : Actionable
{
    private bool opened = false;
    public Sprite opened_sprite;

    public override void OnMouseDown()
    {
        if (GameManager.instance.currAction == GameManager.Action.Open && Vector3.Distance(Alora.instance.transform.Find("Foot Position").position, transform.position) < interactionRadius)
        {
            if (!opened)
            {
                this.GetComponent<SpriteRenderer>().sprite = opened_sprite;
            } else
            {
                base.OnMouseDown();
            }
        }
    }
}
