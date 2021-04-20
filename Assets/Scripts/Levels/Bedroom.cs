using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedroom : MonoBehaviour
{
    public GameObject door;
    private GameObject managers;

    private void Awake()
    {
        managers = GameObject.Find("Managers");
    }
    private void Start()
    {
        StartCoroutine(Initiate());
    }

    IEnumerator Initiate()
    {
        Alora.instance.is_busy = true;
        managers.SetActive(false);
        yield return new WaitForSeconds(3f);
        door.SetActive(false);
        Alora.instance.is_busy = false;
        managers.SetActive(true);
    }
}
