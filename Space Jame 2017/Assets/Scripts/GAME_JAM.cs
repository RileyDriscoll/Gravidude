using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAME_JAM : MonoBehaviour
{
    private Animator anim;
    private Transform watchanim;
    private ParticleSystem particle;
    private int levelCount = 1;
   

    public float speed = 10.0f;
    public bool gravitySwap = false;
    public int swapCount = 0;
    public bool isAlive = true;
    public bool alreadyDead = false;



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); ;
        watchanim = transform.GetChild(0);
        swapCount = 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
            swapCount = 2;

        if (other.gameObject.tag == "Reset")
        {
            other.gameObject.SetActive(false);
            swapCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ouch")
        {
            isAlive = false;
        }
        if(other.gameObject.tag == "Tele")
        {
            GameObject.FindGameObjectWithTag("Cancer").GetComponent<LiteralCancer>().curLevel++;
            if(GameObject.FindGameObjectWithTag("Cancer").GetComponent<LiteralCancer>().curLevel > levelCount)
            {
                Application.Quit();
            }
            SceneManager.LoadScene(GameObject.FindGameObjectWithTag("Cancer").GetComponent<LiteralCancer>().sceneList[GameObject.FindGameObjectWithTag("Cancer").GetComponent<LiteralCancer>().curLevel]);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(GameObject.FindGameObjectWithTag("Cancer").GetComponent<LiteralCancer>().sceneList[GameObject.FindGameObjectWithTag("Cancer").GetComponent<LiteralCancer>().curLevel]);
        }

    }

    void FixedUpdate()
    {
        if (!isAlive && !alreadyDead)
        {
            transform.Rotate(0, 0, 90);
            particle = GetComponent<ParticleSystem>();
            particle.Play(true);
            alreadyDead = true;
        }


        if (Input.GetButtonDown("Jump") && (swapCount > 0) && isAlive)
        {
            gravitySwap = !gravitySwap;

            //GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
            swapCount -= 1;
        }

        if (gravitySwap)
        {
            GetComponent<Rigidbody2D>().gravityScale = -4;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 4;
        }

        if (!isAlive)
        {
            GetComponent<Rigidbody2D>().gravityScale = Mathf.Abs(GetComponent<Rigidbody2D>().gravityScale);
        }

        if ((Input.GetAxisRaw("Horizontal") < 0) && isAlive)  //&& !stopped)
        {
            transform.Translate(Vector3.right * speed * 2.25f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if ((Input.GetAxisRaw("Horizontal") > 0) && isAlive) //&& !stopped)
        {
            transform.Translate(Vector3.right * speed * 2.25f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        anim.SetBool("gravity swap", gravitySwap);
        watchanim.GetComponent<Animator>().SetInteger("swapCount", swapCount);

    }
}