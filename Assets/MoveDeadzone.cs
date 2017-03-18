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
		transform.position = new Vector3 (spawner.OrthographicBounds().max.x, spawner.OrthographicBounds().max.y+5f, 0);
	}
}
