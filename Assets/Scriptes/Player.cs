using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	public GameObject PlayerRotationObj;
	public float RotationSpeed = 30;
	public float MaxRotationAngle = 40;
	public Spawner spawner;
	public MoveDeadzone deadzone;
	public float PlayerSize = 1;
	public float GrowRate = 1;
	public GameObject Camera;

    private float timeStampStart;
    public float slowSpeed = 4;
    public float normalSpeed = 9.81f;
    public float timeToReAccelerate = 3;

	public float NewCameraScale;
	public float OldCameraScale;
	public Vector3 NewPlayerScale;
	public Vector3 OldPlayerScale;

	// Use this for initialization
	void Start () {
		NewPlayerScale = transform.localScale;
		OldPlayerScale = transform.localScale;
		NewCameraScale = Camera.GetComponent<Camera> ().orthographicSize;
		OldCameraScale = Camera.GetComponent<Camera> ().orthographicSize;

		Scale ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horizontalInput = Input.GetAxis("Horizontal");

		/*if (horizontalInput > 0) 
		{
			if (PlayerRotationObj.transform.rotation.eulerAngles.z < MaxRotationAngle) 
			{
				PlayerRotationObj.transform.Rotate (0, 0, RotationSpeed * horizontalInput);
			}
		} 
		else 
		{
			Debug.Log ("z rot:" + PlayerRotationObj.transform.rotation.eulerAngles.z +"Max: " + MaxRotationAngle);
			if (PlayerRotationObj.transform.rotation.eulerAngles.z < 260 && PlayerRotationObj.transform.rotation.eulerAngles.z < 300 ) 
			{
				//Debug.Log ("z rot:" + PlayerRotationObj.transform.rotation.eulerAngles.z +"Max: " + MaxRotationAngle);
				PlayerRotationObj.transform.Rotate (0, 0, RotationSpeed * horizontalInput);
			}
		}*/
	}

	void FixedUpdate()
	{
		Physics2D.gravity = new Vector2(0, Mathf.Lerp(slowSpeed,normalSpeed, Mathf.Clamp01(Time.time/(timeStampStart + timeToReAccelerate))));



		transform.localScale = Vector3.Lerp (OldPlayerScale, NewPlayerScale, Time.deltaTime);

		//Debug.Log ("Log: " + transform.localScale.ToString());
		//Debug.Log ("Old" + OldPlayerScale + "New: " + NewPlayerScale);
		Camera.GetComponent<Camera> ().orthographicSize = Mathf.Lerp(OldCameraScale, NewCameraScale, Time.deltaTime/5);

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "food") 
		{
            Food foodData = col.gameObject.GetComponent<Food>();

			if (foodData.eatSize < PlayerSize) 
			{
				foodData.respawn ();
				PlayerSize += 0.1f * col.gameObject.GetComponent<Food> ().eatSize;
				this.Scale ();
				this.ScaleCamera ();
			}

			if(foodData.eatSize > PlayerSize)
			{
				timeStampStart = Time.time;
			}

		}

        if(col.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("title");
        }
	}

	public void Scale()
	{
		OldPlayerScale = transform.localScale;

		NewPlayerScale += new Vector3(PlayerSize * GrowRate, PlayerSize * GrowRate, PlayerSize *  GrowRate);
		Debug.Log ("ScalePlayer");

	}

	private void ScaleCamera()
	{
		OldCameraScale = NewCameraScale;
		NewCameraScale += PlayerSize * GrowRate * 10f;
		//Camera.GetComponent<Camera> ().orthographicSize += PlayerSize * GrowRate * 10;
		spawner.RecalculateSpawnPosition ();
		deadzone.RecalculatePosition ();
		//Camera.transform.localScale += new Vector3(PlayerSize * GrowRate, PlayerSize * GrowRate, PlayerSize *  GrowRate);
	}
}
