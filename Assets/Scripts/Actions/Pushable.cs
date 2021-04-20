using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Actionable
{
    public bool pushFromLeft;
    public bool pushed;
    public bool pushable = true;
    public override void OnMouseDown()
    {
        if (pushable) {
            Vector3 aloraPos = Alora.instance.transform.Find("Foot Position").position;
            if (pushFromLeft)
            {
                if (!pushed && Vector3.Distance(aloraPos, transform.position) < interactionRadius && transform.position.x > aloraPos.x)
                {
                    if (GameManager.instance.currAction == GameManager.Action.Push)
                    {
                        Alora.instance.GetComponent<SpriteRenderer>().flipX = true;
                        StartCoroutine(Push());
                    }
                    else
                    {
                        base.OnMouseDown();
                    }
                }
            }
            else
            {
                if (!pushed && Vector3.Distance(aloraPos, transform.position) < interactionRadius && transform.position.x < aloraPos.x)
                {
                    if (GameManager.instance.currAction == GameManager.Action.Push)
                    {
                        StartCoroutine(Push());
                    }
                    else
                    {
                        base.OnMouseDown();
                    }
                }
            }
        }
        
    }

    IEnumerator Push()
    {
        GameManager.instance.SetAction((int)GameManager.Action.Push);
        Alora.instance.is_busy = true;
        Alora.instance.animator.SetBool("isPushing", true);
        this.GetComponent<Animator>().SetTrigger("beingPushed");
        this.GetComponent<Climbable>().climbable = true;
        Alora.instance.transform.SetParent(transform);
        yield return new WaitForSeconds(ConstantManager.instance.chair_clip.length);
        Alora.instance.transform.SetParent(null);
        Alora.instance.animator.SetBool("isPushing", false);
        Alora.instance.is_busy = false;
        pushable = false;
    }
}
