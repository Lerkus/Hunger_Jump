using UnityEngine;
using System.Collections;

public class ButtonCredits : MonoBehaviour {


    public GameObject logoetc;
    public GameObject credits;
    public Camera mainCamera;
    private bool isClicked = false;
    private bool isControlsPlaying = false;
    private float width;
    private float hidingPoint;
    private float height;
    public float creditSpeed = 0.3f;

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
            if (credits.transform.position.y <= height)
            {
                credits.transform.position = Vector2.Lerp(credits.transform.position, new Vector2(credits.transform.position.x, credits.transform.position.y + height), creditSpeed * Time.deltaTime);
            }
            else
            {
                credits.transform.position = new Vector2(credits.transform.position.x, -(height / 3));
                logoetc.transform.position = new Vector2(width, logoetc.transform.position.y);
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
