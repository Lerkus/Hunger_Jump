using UnityEngine;
using System.Collections;

public class ButtonControls : MonoBehaviour {


    public GameObject logoetc;
    public GameObject controls;
    private bool isClicked;
    private bool isControlsPlaying;

    void Start()
    {
        isClicked = false;
        isControlsPlaying = false;
    }

    public void clicked()
    {
        isClicked = true;
    }

    void Update()
    {
        Debug.Log(logoetc.transform.position.x);
        if (isClicked)
        {
            if (logoetc.transform.position.x <= 1800)
            {
                //Debug.Log(logoetc.transform.position.x);
                logoetc.transform.position = Vector2.Lerp(new Vector2(logoetc.transform.position.x + 50f, logoetc.transform.position.y), logoetc.transform.position, Time.deltaTime);
                //logoetc.transform.position = Vector2.Lerp(logoetc.transform.position, new Vector2(logoetc.transform.position.x - 800f, logoetc.transform.position.y), Time.deltaTime);
            }
            else
            {
                isControlsPlaying = true;
            }

        }
        else
        {
            if (logoetc.transform.position.x >= 680)
            {
                //Debug.Log(logoetc.transform.position.x);
                logoetc.transform.position = Vector2.Lerp(new Vector2(logoetc.transform.position.x - 50f, logoetc.transform.position.y), logoetc.transform.position, Time.deltaTime);
            }
        }

        if (isControlsPlaying)
        {
            if (controls.transform.position.y <= 850)
            {
                //Debug.Log(creditnamen.transform.position.y);
                controls.transform.position = Vector2.Lerp(new Vector2(controls.transform.position.x, controls.transform.position.y + 5f), controls.transform.position, Time.deltaTime);
            }
            else
            {
                controls.transform.position = new Vector2(controls.transform.position.x, -222);
                isControlsPlaying = false;
                isClicked = false;
            }
        }

    }
}
