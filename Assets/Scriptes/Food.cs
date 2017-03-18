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
        Rigidbody2D phisi = gameObject.GetComponent<Rigidbody2D>();
        phisi.rotation = Random.Range(-10f, 10f);
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
            Rigidbody2D phisi = gameObject.GetComponent<Rigidbody2D>();
            phisi.velocity = Vector2.zero;
            respawn();
		}
	}

	public void respawn()
	{
		Destroy (gameObject);
	}


}
