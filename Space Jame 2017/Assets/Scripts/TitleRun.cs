using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleRun : MonoBehaviour {


    public Transform SpaceShip;
    private Animator anim;

    public Transform beam1 = null;
    public Transform beam2 = null;
    public Transform beam3 = null;

    public Transform canvas;

    public Transform button;

    // Use this for initialization
    void Start ()
    {
        /*foreach (Transform child in GameObject.FindGameObjectWithTag("Tele").gameObject.transform)
        {
            if (beam1 == null)
            {
                beam1 = child;
            }
            else if (beam2 == null)
            {
                beam2 = child;
            }
            else if (beam3 == null)
            {
                beam3 = child;
            }
            child.gameObject.SetActive(false);
        }

        button = GameObject.FindGameObjectWithTag("EditorOnly").transform.GetChild(1);
        */

        beam1.gameObject.SetActive(false);
        beam2.gameObject.SetActive(false);
        beam3.gameObject.SetActive(false);

        GetComponent<Rigidbody2D>().velocity = new Vector3(7, 0, 0);
        //StartCoroutine(WaitForLand());
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    IEnumerator WaitForLand()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().velocity = new Vector3(15, 0, 0);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Watch")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            BeAbducted();
        }
        if (collider.gameObject.tag == "Ouch")
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
        if (collider.gameObject.tag == "Finish")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
        }
    }

    void BeAbducted()
    {
        GetComponent<Animator>().SetBool("Bent", true);

        SpaceShip.GetComponent<SpaceshipTitle>().StartFlying();
    }
}
