using UnityEngine;
using System.Collections;

public class ButtonControls : MonoBehaviour {


    public GameObject logoetc;
    public GameObject controls;
    public Camera mainCamera;
    private bool isClicked = false;
    private bool isControlsPlaying = false;
    private float width;
    private float height;
    public float controlSpeed = 0.3f;
    private float x;

    void Start()
    {
        isClicked = false;
        isControlsPlaying = false;
        x = logoetc.transform.position.x;
        width = logoetc.transform.position.x * 3;
        height = logoetc.transform.position.y * 3;
    }

    public void clicked()
    {
        isClicked = true;
    }

    void Update()
    {        
        if (isClicked)
        {
            if(logoetc.transform.position.x <= width)
            {
                logoetc.transform.position = Vector2.Lerp(logoetc.transform.position, new Vector2(logoetc.transform.position.x + (width), logoetc.transform.position.y), Time.deltaTime);
            }
            else
            {
                isControlsPlaying = true;
            }
        }
        else
        {
            if(logoetc.transform.position.x > x)
            {
                logoetc.transform.position = Vector2.Lerp(logoetc.transform.position, new Vector2(0, logoetc.transform.position.y), 2.5f*Time.deltaTime);
            }
        }

        if (isControlsPlaying)
        {
            if (controls.transform.position.y <= height)
            {
                controls.transform.position = Vector2.Lerp(controls.transform.position, new Vector2(controls.transform.position.x, controls.transform.position.y + height), controlSpeed * Time.deltaTime);
            }
            else
            {
                controls.transform.position = new Vector2(controls.transform.position.x, -(height/3));
                isControlsPlaying = false;
                isClicked = false;
            }
        }

    }
    public Bounds OrthographicBounds()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            mainCamera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

}
