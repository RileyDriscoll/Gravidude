using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool beingHandled = false;

    public float seconds = 3;

    // Update is called once per frame
    void Update()
    {
        if (!beingHandled)
        {
            StartCoroutine(WaitForFade());
        }
    }

    IEnumerator WaitForFade()
    {
        beingHandled = true;
        //Debug.Log(gameObject.active);
        gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.active);
        yield return new WaitForSeconds(seconds);
        beingHandled = false;
    }
}