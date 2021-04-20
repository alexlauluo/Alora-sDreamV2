using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : Actionable
{
    private bool picked_up = false;
    public Item item;

    public override void OnMouseDown()
    {
        if (Vector3.Distance(Alora.instance.transform.Find("Foot Position").position, transform.position) < interactionRadius)
        {
            if (!picked_up && GameManager.instance.currAction == GameManager.Action.PickUp)
            {
                StartCoroutine(PickUp());
            }
            else
            {
                base.OnMouseDown();
            }
        }
    }

    IEnumerator PickUp()
    {
        GameManager.instance.SetAction((int)GameManager.Action.PickUp);
        Alora.instance.is_busy = true;
        picked_up = true;
        //thoughtManager.Dialogue(pickUp_text);
        InventoryManager.instance.AddItem(item);
        this.GetComponent<SpriteRenderer>().color = Color.clear;
        Alora.instance.animator.SetTrigger("isPickingUp");
        yield return new WaitForSeconds(ConstantManager.instance.pickUp_clip.length);
        Alora.instance.is_busy = false;
    }
}
