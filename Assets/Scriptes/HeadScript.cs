using UnityEngine;
using System.Collections;

public class HeadScript : MonoBehaviour {

    public GameObject head1;
    public GameObject head2;
    public bool state;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void fixedUpdate () {
	    if (state == true)
        {
            head1.SetActive(true);
            head2.SetActive(false);
        }
        else
        {
            head1.SetActive(false);
            head2.SetActive(true);
        }

	}
}
