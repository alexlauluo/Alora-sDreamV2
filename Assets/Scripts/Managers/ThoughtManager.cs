using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThoughtManager : MonoBehaviour
{
    /**
    public GameObject thoughtBubble;
    public Animator animator;
    public TMP_Text thoughtText;
    public bool open = false;
    **/
    public static ThoughtManager instance;
    public float textDuration;
    public bool textEnabled;
    public TMP_Text AloraText;
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
    }
    public void Dialogue(string text)
    {
        if (textEnabled)
        {
            StopCoroutine(ChangeText(text));
        }
        StartCoroutine(ChangeText(text));
    }

    IEnumerator ChangeText(string text)
    {
        textEnabled = true;
        AloraText.text = text;
        yield return new WaitForSeconds(textDuration);
        AloraText.text = "";
        textEnabled = false;
    }
    /**
    public void Dialogue(string text)
    {
        thoughtText.text = text;
        if (open)
        {
            open = false;
            StopCoroutine("OpenBubble");
        }
        else
        {
            animator.SetTrigger("open");
        }
        StartCoroutine("OpenBubble");
    }

    IEnumerator OpenBubble()
    {
        open = true;
        yield return new WaitForSeconds(10);
        animator.SetTrigger("close");
        open = false;
    }
    **/
}
