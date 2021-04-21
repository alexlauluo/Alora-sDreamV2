using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Action { Use, PickUp, Push, Open, LookAt, TalkTo, None }
    public Action currAction;
    public UIButtonManager uIButtonManager;

    public GameObject currActionable;

    public static GameManager instance;

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
        currAction = Action.None;
        currActionable = null;
    }

    public void SetAction(int actionSel)
    {
        uIButtonManager.resetButtonColor();
        if ((int)currAction == actionSel)
        {
            currAction = Action.None;
            return;
        }
        switch (actionSel)
        {
            case 0:
                currAction = Action.Use;
                break;
            case 1:
                currAction = Action.PickUp;
                break;
            case 2:
                currAction = Action.Push;
                break;
            case 3:
                currAction = Action.Open;
                break;
            case 4:
                currAction = Action.LookAt;
                break;
            case 5:
                currAction = Action.TalkTo;
                break;
        }
        uIButtonManager.changeButtonColor();
    }
}
