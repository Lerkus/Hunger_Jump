using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedIndicator : MonoBehaviour
{

    public int startHeight = 10000;
    public int finishHeight = 100;

    public GameObject uiToUpdate;
    public Spawner spawner;
    public GameObject playerPhisi;
    public ObjectMoveMaster mover;
    private Text textToUpdate;

    private float meterFallen = 0;
    private float timeStampLastGravityChange;
    private float lastGravity;

    private bool finishing = false;
    private bool changingGravity = false;


    public void Start()
    {
        lastGravity = Physics2D.gravity.y;
        timeStampLastGravityChange = Time.time;
        textToUpdate = uiToUpdate.GetComponent<Text>();
    }

    void Update()
    {
        if (!changingGravity)
        {

            if (lastGravity != Physics2D.gravity.y)
            {
                meterFallen += ((Time.time - timeStampLastGravityChange) * lastGravity);
                lastGravity = Physics2D.gravity.y;
                timeStampLastGravityChange = Time.time;
            }
        }

        float actualHeight = startHeight - (meterFallen + (Time.time - timeStampLastGravityChange) * lastGravity);

        if (actualHeight <= finishHeight)
        {
            if (!finishing)
            {
                finishing = true;
                spawner.shouldSpawnObjects = false;
            }

            if (actualHeight <= finishHeight / 2)
            {
                if (!changingGravity)
                {
                    changingGravity = true;
                    Rigidbody2D phisi =  playerPhisi.GetComponent<Rigidbody2D>();
                    phisi.gravityScale = -1;
                    phisi.isKinematic = false;

                    mover.changeGravity();
                    //spawner.spawnFinishLine();
                    textToUpdate.text = "";
                }
            }
        }
        if (actualHeight < 0)
        {
            actualHeight = 0;
        }
        textToUpdate.text = actualHeight - actualHeight%1 + "m";
    }
}
