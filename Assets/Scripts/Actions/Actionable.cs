using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionable : MonoBehaviour
{
    protected BoxCollider2D coll;

    public string use_text, pickUp_text, push_text, open_text, lookAt_text, talkTo_text;
    public float interactionRadius = 4f;


    public virtual void OnMouseDown()
    {
        Debug.Log("clicked");
        Debug.Log("alora foot position " + Alora.instance.transform.Find("Foot Position").position);
        Debug.Log("pass if? " + (Vector3.Distance(Alora.instance.transform.Find("Foot Position").position, transform.position) < interactionRadius));
        if (Vector3.Distance(Alora.instance.transform.Find("Foot Position").position, transform.position) < interactionRadius)
        {
            Debug.Log("curr action " + GameManager.instance.currAction);
            GameManager.instance.GetComponent<UIButtonManager>().resetButtonColor();
            switch (GameManager.instance.currAction)
            {
                case GameManager.Action.Use:
                    if (string.IsNullOrWhiteSpace(use_text))
                    {
                        ThoughtManager.instance.Dialogue(ConstantManager.instance.default_use_text);
                    } else
                    {
                        ThoughtManager.instance.Dialogue(use_text);
                    }
                    break;
                case GameManager.Action.PickUp:
                    if (string.IsNullOrWhiteSpace(pickUp_text))
                    {
                        ThoughtManager.instance.Dialogue(ConstantManager.instance.default_pickUp_text);
                    }
                    else
                    {
                        ThoughtManager.instance.Dialogue(pickUp_text);
                    }
                    break;
                case GameManager.Action.Push:
                    if (string.IsNullOrWhiteSpace(push_text))
                    {
                        ThoughtManager.instance.Dialogue(ConstantManager.instance.default_push_text);
                    }
                    else
                    {
                        ThoughtManager.instance.Dialogue(push_text);
                    }
                    break;
                case GameManager.Action.Open:
                    if (string.IsNullOrWhiteSpace(open_text))
                    {
                        ThoughtManager.instance.Dialogue(ConstantManager.instance.default_open_text);
                    }
                    else
                    {
                        ThoughtManager.instance.Dialogue(open_text);
                    }
                    break;
                case GameManager.Action.LookAt:
                    if (string.IsNullOrWhiteSpace(lookAt_text))
                    {
                        ThoughtManager.instance.Dialogue("It's a " + this.gameObject.name.ToLower() + ".");
                    }
                    else
                    {
                        ThoughtManager.instance.Dialogue(lookAt_text);
                    }
                    break;
                case GameManager.Action.TalkTo:
                    if (string.IsNullOrWhiteSpace(talkTo_text))
                    {
                        ThoughtManager.instance.Dialogue(("Nice to meet you " + this.gameObject.name.ToLower() + "."));
                    }
                    else
                    {
                        ThoughtManager.instance.Dialogue(talkTo_text);
                    }
                    break;
            }
            GameManager.instance.currAction = GameManager.Action.None;
        }
    }
}
