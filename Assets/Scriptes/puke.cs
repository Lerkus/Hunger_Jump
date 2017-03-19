using UnityEngine;
using System.Collections;

public class puke : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem> ().GetComponent<Renderer> ().sortingOrder = 2600;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
