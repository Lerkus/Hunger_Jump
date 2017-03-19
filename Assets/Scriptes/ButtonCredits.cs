using UnityEngine;
using System.Collections;

public class ButtonCredits : MonoBehaviour {


    public GameObject logoetc;
    public GameObject credits;
    public GameObject anykey;
    public Camera mainCamera;
    private bool isClicked = false;
    private bool isControlsPlaying = false;
    private float width;
    private float hidingPoint;
    private float height;

    void Start()
    {
        isClicked = false;
        isControlsPlaying = false;
        width = logoetc.transform.position.x;
        hidingPoint = logoetc.transform.position.x * -1;
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
            if (logoetc.transform.position.x >= hidingPoint)
            {
                logoetc.transform.position = Vector2.Lerp(logoetc.transform.position, new Vector2(3 * hidingPoint, logoetc.transform.position.y), Time.deltaTime);
            }
            else
            {
                isControlsPlaying = true;
            }
        }

        if (isControlsPlaying)
        {
            if (Input.anyKeyDown)
            {
                credits.transform.position = new Vector2(credits.transform.position.x, -(height / 3));
                logoetc.transform.position = new Vector2(width, logoetc.transform.position.y);
                anykey.SetActive(false);
                isControlsPlaying = false;
                isClicked = false;
            }
            if(credits.transform.position.y > logoetc.transform.position.y - (logoetc.transform.position.y / 10))
            {
                anykey.SetActive(true);
            }

            credits.transform.position = Vector2.Lerp(credits.transform.position, new Vector2(credits.transform.position.x, logoetc.transform.position.y),  Time.deltaTime);
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
