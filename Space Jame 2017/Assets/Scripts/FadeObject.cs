using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeObject : MonoBehaviour {

    public float fadeSpeed = 0.005f;
    public bool showOrFade = false;
    public bool triggered = false;
    private float opacity;
    private Color currentColor;

    // Update is called once per frame
    void Start()
    {
        if(showOrFade)
        {
            opacity = 0;
        }
        else
        {
            opacity = 1;
        }

        try
        {
            currentColor = gameObject.GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);
        }
        catch
        {
            currentColor = gameObject.GetComponentInChildren<Image>().material.color;
            gameObject.GetComponentInChildren<Image>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);
        }
    }

    void Update ()
    {
        if(triggered)
        {
            if (showOrFade)
            {
                if (!gameObject.active)
                {
                    gameObject.SetActive(true);
                }
                if (opacity < 1)
                {
                    opacity += fadeSpeed;
                    try
                    {
                        gameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);
                    }
                    catch 
                    {
                        gameObject.GetComponentInChildren<Image>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);
                    }
                }
                if(opacity >= 1)
                {
                    triggered = false;
                }
            }
            else
            {
                if (opacity > 0)
                {
                    opacity -= fadeSpeed;
                    try
                    {
                        gameObject.GetComponent<Renderer>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);
                    }
                    catch
                    {
                        gameObject.GetComponentInChildren<Image>().material.color = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);
                    }
                }
                if (opacity <= 0)
                {
                    gameObject.SetActive(false);
                    triggered = false;
                }
            }
        }
	}

    public void startTransition()
    {
        triggered = true;
        if(!gameObject.active)
        {
            gameObject.SetActive(true);
        }
    }

    public void startTransition(bool showOrFade)
    {
        triggered = true;
        this.showOrFade = showOrFade;
        if (!gameObject.active)
        {
            gameObject.SetActive(true);
        }
    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Reign Catcher" && gameObject.tag == "Reign Logo")
        {
            startTransition(false);

            //GameObject.FindGameObjectWithTag("Reign Catcher").GetComponent<TitleScreenController>().QueueMainMenu();
            
        }
    }*/
}
