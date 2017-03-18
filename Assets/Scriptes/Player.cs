using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	public GameObject PlayerRotationObj;
	public float RotationSpeed = 0.1f;
	public float MaxRotationAngle = 40;
	public Spawner spawner;
	public MoveDeadzone deadzone;
	public float PlayerSize = 1;
    private float amountFoodEaten = 0;
	public float GrowRate = 1;
	public GameObject Camera;

    private float timeStampStart;
    public float slowSpeed = 4;
    public float normalSpeed = 9.81f;
    public float timeToReAccelerate = 3;

    private float camStartScale;
    private Vector3 playerStartScale;

    public Animator eating;

	public float NewCameraScale;
	public float OldCameraScale;

	public Vector3 NewPlayerScale;
	public Vector3 OldPlayerScale;

	public Vector2 RotationRange = new Vector2(320, 20);

	bool lockRot = false;

	// Use this for initialization
	void Start () {
        Camera camData = Camera.GetComponent<Camera>();

        NewPlayerScale = transform.localScale;
		OldPlayerScale = transform.localScale;
		NewCameraScale = camData.orthographicSize;
		OldCameraScale = camData.orthographicSize;

        playerStartScale = transform.localScale;
        camStartScale = camData.orthographicSize;
		Scale ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//Debug.Log ("z rot:" + PlayerRotationObj.transform.rotation.eulerAngles.z +"Max: " + MaxRotationAngle);



	}

	void FixedUpdate()
	{
		Physics2D.gravity = new Vector2(0, Mathf.Lerp(slowSpeed,normalSpeed, Mathf.Clamp01(Time.time/(timeStampStart + timeToReAccelerate))));



		transform.localScale = Vector3.Lerp (OldPlayerScale, NewPlayerScale, Time.deltaTime);

		//Debug.Log ("Log: " + transform.localScale.ToString());
		//Debug.Log ("Old" + OldPlayerScale + "New: " + NewPlayerScale);
		Camera.GetComponent<Camera> ().orthographicSize = Mathf.Lerp(OldCameraScale, NewCameraScale, Time.deltaTime);

		Debug.Log("CameraSize: " + Camera.GetComponent<Camera>().orthographicSize + "TargetSize: " + NewCameraScale + "OriginTarget: " + OldCameraScale);

		float horizontalInput = Input.GetAxis("Horizontal");

		// Rotate Player
		if (horizontalInput > 0) 
		{
			if (!lockRot) 
			{
				PlayerRotationObj.transform.Rotate (0, 0, RotationSpeed * horizontalInput);
			}

			if( PlayerRotationObj.transform.rotation.eulerAngles.z < RotationRange.x && PlayerRotationObj.transform.rotation.eulerAngles.z > RotationRange.y)
			{
				PlayerRotationObj.transform.Rotate (0, 0, -(RotationSpeed * horizontalInput));
				//Debug.Log ("++Angle" + (RotationSpeed * horizontalInput));
				this.lockRot = false;
			}
		} 
		else 
		{
			if (!lockRot) 
			{
				PlayerRotationObj.transform.Rotate (0, 0, RotationSpeed * horizontalInput);
			}

			if( PlayerRotationObj.transform.rotation.eulerAngles.z < RotationRange.x && PlayerRotationObj.transform.rotation.eulerAngles.z > RotationRange.y)
			{
				PlayerRotationObj.transform.Rotate (0, 0, -(RotationSpeed * horizontalInput));

				this.lockRot = false;
			}
		}

		if( PlayerRotationObj.transform.rotation.eulerAngles.z < RotationRange.x && PlayerRotationObj.transform.rotation.eulerAngles.z > RotationRange.y)
		{
			this.lockRot = true;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "food") 
		{
            Food foodData = col.gameObject.GetComponent<Food>();

			if (foodData.eatSize <= PlayerSize) 
			{
				foodData.respawn ();
                amountFoodEaten += foodData.eatSize;
                updatePlayerSize();
				this.Scale ();
				this.ScaleCamera ();
                eating.SetTrigger("isEating");
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

    private void updatePlayerSize()
    {
        PlayerSize = Mathf.Log(amountFoodEaten,2) + 1;
        //Debug.Log(PlayerSize);
    }
	public void Scale()
	{
		OldPlayerScale = transform.localScale;

		NewPlayerScale = playerStartScale * PlayerSize * 3;
		//Debug.Log ("ScalePlayer");
	}

	private void ScaleCamera()
	{
		OldCameraScale = Camera.GetComponent<Camera> ().orthographicSize;
		NewCameraScale =  PlayerSize * camStartScale;
		spawner.RecalculateSpawnPosition ();
		deadzone.RecalculatePosition ();
	}
}
