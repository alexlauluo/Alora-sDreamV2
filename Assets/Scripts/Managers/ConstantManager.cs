using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantManager : MonoBehaviour
{
    public static ConstantManager instance;

    public string default_use_text;
    public string default_pickUp_text;
    public string default_push_text;
    public string default_open_text;

    public AnimationClip pickUp_clip;
    public AnimationClip push_clip;
    public AnimationClip climb_clip;
    public AnimationClip chair_clip;
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
    
}
