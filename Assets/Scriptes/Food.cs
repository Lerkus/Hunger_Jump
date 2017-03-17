using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour 
{

	private Vector3 startPosition;
	public float eatSize = 1;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisonEnter2D(Collision2D col)
	{
		Debug.Log ("Destroy!!22");
		if (col.gameObject.tag == "Player") 
		{
			Debug.Log ("Destroy!!");
			this.respawn ();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "deadzone") 
		{
			transform.position = startPosition;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}

	public void respawn()
	{
		Destroy (gameObject);
	}


}
