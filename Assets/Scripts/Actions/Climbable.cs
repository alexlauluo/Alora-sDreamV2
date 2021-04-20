using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : Actionable
{
    public bool climbable = true;
    private Transform climbPosition;
    public List<GameObject> collisionsToDisable;
    private bool climbing = false;

    private void Awake()
    {
        climbPosition = this.transform.Find("Climb Position");
    }
    // Update is called once per frame
    void Update()
    {
        if (climbing)
        {
            Vector3 posDiff = Alora.instance.transform.position - Alora.instance.transform.Find("Foot Position").position;
            posDiff.x = Mathf.Abs(posDiff.x);
            Vector3 newPosition = climbPosition.position + posDiff;
            Alora.instance.transform.position = Vector3.MoveTowards(Alora.instance.transform.position, newPosition, Alora.instance.speed * Time.deltaTime);
        }
        
    }

    public override void OnMouseDown()
    {
        if (climbable && GameManager.instance.currAction == GameManager.Action.Use && Vector3.Distance(Alora.instance.transform.Find("Foot Position").position, transform.position) < interactionRadius)
        {
            StartCoroutine(Climb());
        } else
        {
            base.OnMouseDown();
        }
    }

    IEnumerator Climb()
    {
        climbable = false;
        climbing = true;
        Alora.instance.is_busy = true;
        GetComponent<BoxCollider2D>().enabled = false;
        foreach (GameObject gameObject in collisionsToDisable)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        Alora.instance.animator.SetBool("isClimbing", true);
        //this.GetComponent<Animator>().SetTrigger("beingClimbed");
        yield return new WaitForSeconds(ConstantManager.instance.climb_clip.length);
        Alora.instance.animator.SetBool("isClimbing", false);
        Alora.instance.is_busy = false;
        climbing = false;
    }
}
