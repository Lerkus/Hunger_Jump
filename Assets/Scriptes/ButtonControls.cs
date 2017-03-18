using UnityEngine;
using System.Collections;

public class ButtonControls : MonoBehaviour {


    public GameObject logoetc;
    public GameObject controls;
    private bool isClicked = false;
    private bool isControlsPlaying = false;
    public bool isItVisible;

    void Start()
    {
        isClicked = false;
        isControlsPlaying = false;
        isItVisible = false;
    }

    public void clicked()
    {
        isClicked = true;
    }

    void OnBecameInvisible()
    {
        isItVisible = false;
        Debug.Log("CONTROL INVISIBLE");
    }

    void OnBecameVisible()
    {
        isItVisible = true;
    }

    void Update()
    {

        


        /*
        Debug.Log("X_MIN:" + OrthographicBounds().min.x);
        Debug.Log("X_MAX:" + OrthographicBounds().max.x);
        Debug.Log("Y_MIN:" + OrthographicBounds().min.y);
        Debug.Log("Y_MAX:" + OrthographicBounds().max.y);
        
        
        if (isClicked)
        {
            position -= positionSpeed * Time.deltaTime;

            if(position > minPos)
            {
                position = minPos;
            }
            Debug.Log("Posi" + position);
            Debug.Log("maxPosi" + maxPos);
            Debug.Log("minPosi" + minPos);
            logoetc.transform.position = new Vector2(position, logoetc.transform.position.y);
        }

        if (isHovered)
        {
            scale += scaleSpeed * Time.deltaTime;

            if (scale > maxScale)
            {
                scale = maxScale;
            }

            button.transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            scale -= scaleSpeed * Time.deltaTime;

            if (scale < minScale)
            {
                scale = minScale;
            }

            button.transform.localScale = new Vector3(scale, scale, scale);
        }

        */


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
                //Debug.Log(controls.transform.position.y);
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
