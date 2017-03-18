using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	public Spawner spawner;
	public MoveDeadzone deadzone;
	public float PlayerSize = 1;
	public float GrowRate = 1;
	public GameObject Camera;

    private float timeStampStart;
    public float slowSpeed = 4;
    public float normalSpeed = 9.81f;
    public float timeToReAccelerate = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        Physics2D.gravity = new Vector2(0, Mathf.Lerp(slowSpeed,normalSpeed, Mathf.Clamp01(Time.time/(timeStampStart + timeToReAccelerate))));
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "food") 
		{
            Food foodData = col.gameObject.GetComponent<Food>();
            foodData.respawn ();
			PlayerSize += 0.1f * col.gameObject.GetComponent<Food> ().eatSize;
			this.Scale ();
			this.ScaleCamera ();
            
            if(foodData.eatSize > PlayerSize)
            {
                timeStampStart = Time.time;
            }

		}

        if(col.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("title");
        }
	}

	public void Scale()
	{
		transform.localScale += new Vector3(PlayerSize * GrowRate, PlayerSize * GrowRate, PlayerSize *  GrowRate);
	}

	private void ScaleCamera()
	{
		Camera.GetComponent<Camera> ().orthographicSize += PlayerSize * GrowRate * 10;
		spawner.RecalculateSpawnPosition ();
		deadzone.RecalculatePosition ();
		//Camera.transform.localScale += new Vector3(PlayerSize * GrowRate, PlayerSize * GrowRate, PlayerSize *  GrowRate);
	}
}
