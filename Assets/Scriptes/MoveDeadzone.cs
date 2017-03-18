using UnityEngine;
using System.Collections;

public class MoveDeadzone : MonoBehaviour {

	public Spawner spawner;



	// Use this for initialization
	void Start () 
	{
		RecalculatePosition ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void RecalculatePosition()
	{
		transform.position = new Vector3 (transform.position.x, spawner.OrthographicBounds().max.y+30f, 0);
		//GetComponent<BoxCollider2D> ().size += new Vector2 (1, 0);
	}
}
