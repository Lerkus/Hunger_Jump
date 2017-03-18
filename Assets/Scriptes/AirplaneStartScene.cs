using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AirplaneStartScene : MonoBehaviour {

    public GameObject moveMyPlane;
    public GameObject colider;
    public Rigidbody2D myBody;
    
    

	// Use this for initialization
	void Start () {
       myBody = moveMyPlane.GetComponent<Rigidbody2D>();
        myBody.velocity = new Vector2(7f , 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "SceneStartSwitch")
        {
            SceneManager.LoadScene("title");
            
        }
        if (col.gameObject.tag == "LosePackage")
        {
            colider.SetActive(false);

        }

    }
}
