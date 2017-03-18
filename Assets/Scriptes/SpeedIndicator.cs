using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedIndicator : MonoBehaviour
{

    public int startHeight = 10000;
    public GameObject uiToUpdate;
    public int finishHeight = 50;
    public Spawner spawner;

    private int meterFallen = 0;
    private float timeStampLastGravityChange;
    private float lastGravity;
    private Text textToUpdate;

    public void Start()
    {
        lastGravity = Physics2D.gravity.y;
        timeStampLastGravityChange = Time.time;
        textToUpdate = uiToUpdate.GetComponent<Text>();
    }

    void Update()
    {
        if (lastGravity != Physics2D.gravity.y)
        {
            meterFallen += (int)((Time.time - timeStampLastGravityChange) * lastGravity);
            lastGravity = Physics2D.gravity.y;
            timeStampLastGravityChange = Time.time;
        }

        float actualMeterFallen = startHeight - (meterFallen + (Time.time - timeStampLastGravityChange) * lastGravity);

        if (actualMeterFallen <= finishHeight)
        {
            spawner.shouldSpawnObjects = false;
            spawner.spawnFinishLine();
            textToUpdate.text = "";
        }
        else
        {
            textToUpdate.text = (int)actualMeterFallen + "m Height";
        }
    }
}
