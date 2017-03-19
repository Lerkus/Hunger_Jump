using UnityEngine;
using System.Collections;

public class SoundPitcher : MonoBehaviour {

    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

	void Start () {
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
	}
}
