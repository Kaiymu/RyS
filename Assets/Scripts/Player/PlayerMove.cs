using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private int posX = 0;
	private float posY;
	public float speed;
	public Vector3 jumpVelocity;
	public float fovDeduct;
	public float speedDeduct;

	private Vector3 newPosition;
	

	private float fov = 35;
	private bool  top, mid, down;
	private bool touchingPlatform;
	// Use this for initialization

	void Awake () {
		posY = transform.position.y;
	}
	void Start () {
		top = true;
	}
	
	// Update is called once per frame
	void Update () {
		posX++;
		changeCameraFov();
		movePlayerHorizontal();
	}

	void changeCameraFov()
	{
		if(Input.GetKey("d"))
		{
			if(fov < 45)
				fov += fovDeduct * Time.deltaTime;
			else
				fov = 45;
			
			if(speed < 75)
				speed += speedDeduct * Time.deltaTime;
			else
				speed = 75;
			
		}
		else if(Input.GetKey("q"))
		{
			if(fov > 25)
				fov -= fovDeduct * Time.deltaTime;
			else 
				fov = 25;
			
			if(speed > 25)
				speed -= speedDeduct * Time.deltaTime;
			else
				speed = 25;
		}
		else 
		{
			if(fov != 35)
			{
				if(fov >= 34)
					fov -= fovDeduct * Time.deltaTime;
				if (fov <= 36)
					fov += fovDeduct * Time.deltaTime;
			}
			
			if(speed > 50)
				speed -= speedDeduct * Time.deltaTime;
			else if (fov < 50)
				speed += speedDeduct * Time.deltaTime;
			else 
				speed = 50;
		}
		Camera.main.fieldOfView = fov;
	}

	void movePlayerHorizontal()
	{
		Vector3 positionA = new Vector3(posX, 3, 0);
		Vector3 positionB = new Vector3(posX, -3, 0);
		if(Input.GetKeyDown("z") && !top){
			newPosition = positionA;
		}

		if(Input.GetKeyDown("s") && !down){
			newPosition = positionB;
		}

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 2);
	
	}
}
