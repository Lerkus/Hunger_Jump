using UnityEngine;
using System.Collections;

public class AirplaneStartScene : MonoBehaviour {

    public GameObject test;
    public GameObject colider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (test.transform.position.x <= -7.579955)
        {
            colider.SetActive(false);
        }
        test.transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);

    }
}
