using UnityEngine;
using System.Collections;

public class ButtonCredits : MonoBehaviour {

    public GameObject logoetc;
    private bool isClicked;

    void Start()
    {
        isClicked = false;
    }

    public void clicked()
    {
        isClicked = true;
            //logoetc.transform.position = new Vector2(logoetc.transform.position.x - 0.2f, logoetc.transform.position.y); 
           
    }

    void Update()
    {
        if (isClicked)
        {
            //ANSWEISUNG, DASS ES NACH BESTIMMTER ZEIT STOPPT
            logoetc.transform.position = Vector2.Lerp(new Vector2(logoetc.transform.position.x - 40f, logoetc.transform.position.y), logoetc.transform.position, Time.deltaTime);
        }
    }
}
