using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour 
{

	private Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "deadzone") 
		{
			transform.position = startPosition;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}
}
