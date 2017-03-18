using UnityEngine;
using System.Collections;

public class ButtonHover : MonoBehaviour {

    public GameObject button;
    public bool isHovered;
    private float scale = 0.2f;
    private float minScale = 0.2f;
    private float maxScale = 0.25f;
    private float scaleSpeed = 0.9f;

    // Use this for initialization
    void Start () {
        isHovered = false;
	}

    public void scaleOnHover()
    {
        if (isHovered)
        {
            isHovered = false;
        }
        else
        {
            isHovered = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (isHovered)
        {
            scale += scaleSpeed * Time.deltaTime;

            if (scale > maxScale)
            {
                scale = maxScale;
            }

            button.transform.localScale = new Vector3(scale, scale, scale);
        }else
        {
            scale -= scaleSpeed * Time.deltaTime;

            if (scale < minScale)
            {
                scale = minScale;
            }

            button.transform.localScale = new Vector3(scale, scale, scale);
        }

    }
}
