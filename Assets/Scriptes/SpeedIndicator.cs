using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedIndicator : MonoBehaviour
{

    public int startHeight = 10000;
    public GameObject uiToUpdate;

    private int meterFallen = 0;
    private float timeStampLastGravityChange;
    private float lastGravity;

    public void Start()
    {
        lastGravity = Physics2D.gravity.y;
        timeStampLastGravityChange = Time.time;
    }

    void Update()
    {
        if(lastGravity != Physics2D.gravity.y)
        {
            meterFallen +=(int) ((Time.time - timeStampLastGravityChange) * lastGravity);
            lastGravity = Physics2D.gravity.y;
            timeStampLastGravityChange = Time.time;
        }
        uiToUpdate.GetComponent<Text>().text = startHeight - (meterFallen + (Time.time - timeStampLastGravityChange) * lastGravity) + "m Height";
    }
}
