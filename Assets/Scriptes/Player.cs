using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public Spawner spawner;
	public MoveDeadzone deadzone;
	public float PlayerSize = 1;
	public float GrowRate = 1;
	public GameObject Camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "food") 
		{
			col.gameObject.GetComponent<Food> ().respawn ();
			PlayerSize += 0.1f * col.gameObject.GetComponent<Food> ().eatSize;
			this.Scale ();
			this.ScaleCamera ();
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
