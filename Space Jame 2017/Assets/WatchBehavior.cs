using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchBehavior : MonoBehaviour {
    public float yValue;
    public float watchDistance = 1f;
    public int maxSwaps = 2;



    // Update is called once per frame
    void Update()
    {
        if(GetComponentInParent<GAME_JAM>().swapCount == maxSwaps)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)  //&& !stopped)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") > 0) //&& !stopped)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (GetComponentInParent<GAME_JAM>().isAlive)
        {
            if (!GetComponentInParent<GAME_JAM>().gravitySwap)
            {
                yValue = transform.parent.gameObject.transform.position.y + watchDistance;
                transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
            }
            else
            {
                yValue = transform.parent.gameObject.transform.position.y - watchDistance;
                transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
            }

        }
    }
}
