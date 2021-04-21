using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    public Button useButton, pickUpButton, pushButton, openButton, lookAtButton, talkToButton;
    public GameManager gameManager;

    public static UIButtonManager instance;
    private Color defaultColor = new Color32(161, 108, 195, 255);
    private Color selectedColor = new Color32(131, 84, 195, 255);

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
        useButton.onClick.AddListener(delegate { TaskWithParameters(0); });
        pickUpButton.onClick.AddListener(delegate { TaskWithParameters(1); });
        pushButton.onClick.AddListener(delegate { TaskWithParameters(2); });
        openButton.onClick.AddListener(delegate { TaskWithParameters(3); });
        lookAtButton.onClick.AddListener(delegate { TaskWithParameters(4); });
        talkToButton.onClick.AddListener(delegate { TaskWithParameters(5); });


    }

    public void resetButtonColor()
    {
        switch ((int)gameManager.currAction)
        {
            case 0:
                useButton.GetComponent<Image>().color = defaultColor;
                break;
            case 1:
                pickUpButton.GetComponent<Image>().color = defaultColor;
                break;
            case 2:
                pushButton.GetComponent<Image>().color = defaultColor;
                break;
            case 3:
                openButton.GetComponent<Image>().color = defaultColor;
                break;
            case 4:
                lookAtButton.GetComponent<Image>().color = defaultColor;
                break;
            case 5:
                talkToButton.GetComponent<Image>().color = defaultColor;
                break;
        }
    }

    public void changeButtonColor()
    {
        switch ((int)gameManager.currAction)
        {
            case 0:
                useButton.GetComponent<Image>().color = selectedColor;
                break;
            case 1:
                pickUpButton.GetComponent<Image>().color = selectedColor;
                break;
            case 2:
                pushButton.GetComponent<Image>().color = selectedColor;
                break;
            case 3:
                openButton.GetComponent<Image>().color = selectedColor;
                break;
            case 4:
                lookAtButton.GetComponent<Image>().color = selectedColor;
                break;
            case 5:
                talkToButton.GetComponent<Image>().color = selectedColor;
                break;
        }

    }

    void TaskWithParameters(int sel)
    {
        gameManager.SetAction(sel);
    }
}
