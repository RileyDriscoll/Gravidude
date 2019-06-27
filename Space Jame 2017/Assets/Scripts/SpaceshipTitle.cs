using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipTitle : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Watch")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (coll.gameObject.tag == "Respawn")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<FadeObject>().startTransition();
        }
    }

    public void StartFlying()
    {
        StartCoroutine(WaitForBend());
    }

    IEnumerator WaitForBend()
    {
        /*GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam1.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam2.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam3.gameObject.SetActive(false);*/
        yield return new WaitForSeconds(1);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Bent", false);
        Destroy(GameObject.FindGameObjectWithTag("CeilingFan"));

        yield return new WaitForSeconds(1f);

        GetComponent<Rigidbody2D>().velocity = new Vector3(-25, 0, 0);

        yield return new WaitForSeconds(1.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam1.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam2.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam3.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam1.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam2.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().beam3.gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
        yield return new WaitForSeconds(2);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<TitleRun>().button.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<FadeObject>().startTransition();
    }
}
