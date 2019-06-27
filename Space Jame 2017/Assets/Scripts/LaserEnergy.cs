using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnergy : MonoBehaviour
{
    public bool hitWall = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            hitWall = true;
        }
    }
}