using UnityEngine;
using System.Collections;

public class ButtonHover : MonoBehaviour {

    public GameObject button;
    private bool isHovered;
    float scale = 0.1f;
    float minScale = 0.1f;
    float maxScale = 0.2f;
    float scaleSpeed = 0.1f;

    // Use this for initialization
    void Start () {
        isHovered = false;
        //scale = button.transform.localScale.
	}

    public void scaleOnHover()
    {
        isHovered = true;
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
            // Apply the new scale

            button.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
