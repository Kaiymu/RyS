using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Runner : MonoBehaviour {

	public static float distanceTraveled;
	
	public float speed;
	public Vector3 jumpVelocity;
	public float fovDeduct;
	public float speedDeduct;


	private float fov;
	private bool  directionRight, directionLeft, directionNone;
	private bool touchingPlatform;

	void Start()
	{
		fov = Camera.main.fieldOfView;
	}
	
	void Update () {
		Jump ();
		changeCameraFov();
		distanceTraveled = transform.localPosition.x;
	}

	void Jump() {
		if(touchingPlatform && Input.GetButtonDown("Jump")){
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
			touchingPlatform = false;
		}
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

	void FixedUpdate () {
		if(touchingPlatform){
			rigidbody.AddForce(speed, 0f, 0f, ForceMode.Force);
		}
	}

	void OnCollisionEnter () {
		touchingPlatform = true;
	}

	void OnCollisionExit () {
		touchingPlatform = false;
	}
}