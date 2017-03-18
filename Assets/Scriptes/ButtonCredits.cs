using UnityEngine;
using System.Collections;

public class ButtonCredits : MonoBehaviour {

    public GameObject logoetc;
    public GameObject creditnamen;
    private bool isClicked;
    private bool isCreditsPlaying;

    void Start()
    {
        isClicked = false;
        isCreditsPlaying = false;
    }

    public void clicked()
    {
        isClicked = true;
    }

    void Update()
    {

        if (isClicked)
        {
            if (logoetc.transform.position.x >= -500)
            {
                //Debug.Log(logoetc.transform.position.x);
                logoetc.transform.position = Vector2.Lerp(new Vector2(logoetc.transform.position.x - 50f, logoetc.transform.position.y),logoetc.transform.position, Time.deltaTime);
                //logoetc.transform.position = Vector2.Lerp(logoetc.transform.position, new Vector2(logoetc.transform.position.x - 800f, logoetc.transform.position.y), Time.deltaTime);
            }
            else
            {
                isCreditsPlaying = true;
            }

        }
        else
        {
            if (logoetc.transform.position.x <= 620)
            {
                //Debug.Log(logoetc.transform.position.x);
                logoetc.transform.position = Vector2.Lerp(new Vector2(logoetc.transform.position.x + 50f, logoetc.transform.position.y), logoetc.transform.position, Time.deltaTime);
            }
        }

        if (isCreditsPlaying)
        {
            if (creditnamen.transform.position.y <= 850)
            {
                //Debug.Log(creditnamen.transform.position.y);
                creditnamen.transform.position = Vector2.Lerp(new Vector2(creditnamen.transform.position.x, creditnamen.transform.position.y + 5f), creditnamen.transform.position, Time.deltaTime);
            }
            else
            {
                creditnamen.transform.position = new Vector2 (creditnamen.transform.position.x, -222);
                isCreditsPlaying = false;
                isClicked = false;
            }
        }

    }
}
