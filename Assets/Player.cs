using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float PlayerSize = 1;

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
		}
	}

	public void Scale()
	{
		transform.localScale += new Vector3(PlayerSize * transform.localScale.x, PlayerSize * transform.localScale.y, PlayerSize * transform.localScale.x);
	}
}
