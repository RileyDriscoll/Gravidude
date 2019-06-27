using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public float push = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit2D hitDown = Physics2D.Raycast(new Vector3(transform.position.x,
            transform.position.y - .6f, transform.position.z), Vector2.down);
        RaycastHit2D hitUp = Physics2D.Raycast(new Vector3(transform.position.x,
            transform.position.y + .6f, transform.position.z), Vector2.up);

        if ((hitDown.transform.tag != null) && (hitDown.transform.tag == "FloorFan"))
        {
            if (!GetComponent<GAME_JAM>().gravitySwap)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, (push - hitDown.distance) * 100 * Time.deltaTime, 0);
            }
        }
        if ((hitUp.transform.tag != null) && (hitUp.transform.tag == "CeilingFan"))
        {
            if (GetComponent<GAME_JAM>().gravitySwap)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, -(push - hitUp.distance) * 100 * Time.deltaTime, 0);
            }
        }

        if (hitDown.transform.tag == "GravBeam")
        {
            GetComponent<GAME_JAM>().gravitySwap = !GetComponent<GAME_JAM>().gravitySwap;
        }
        if (hitUp.transform.tag == "CeilingLaser")
        {

        }
    }
}
