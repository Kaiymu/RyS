using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private float posX = 0f;
	private float posY;
	private float fov = 35;

	public float speed;
	public float fovDeduct;
	public float speedDeduct;
	public float speedMin, speedMax, speedMid;
	public float speedDown;

	public float smooth = 2.0F;
	public float tiltAroundX = 0;
	public float tiltAngle = 30.0F;

	private float AxisDown =-1f;
	private float AxisTop  = 1f;

	void Awake () {
		posY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		changeCameraFov();
		movePlayer();
	}

	void changeCameraFov()
	{
		if(Input.GetKey("d"))
		{
			if(fov < 45)
				fov += fovDeduct * Time.deltaTime;
			else
				fov = 45;
			
			if(speed < speedMax)
				speed += speedDeduct * Time.deltaTime;
			else
				speed = speedMax;
			
		}
		else if(Input.GetKey("q"))
		{
			if(fov > 25)
				fov -= fovDeduct * Time.deltaTime;
			else 
				fov = 25;
			
			if(speed > speedMin)
				speed -= speedDeduct * Time.deltaTime;
			else
				speed = speedMin;
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
			
			if(speed > speedMid)
				speed -= speedDeduct * Time.deltaTime;
			else if (fov < speedMid)
				speed += speedDeduct * Time.deltaTime;
			else 
				speed = speedMid;
		}
		Camera.main.fieldOfView = fov;
	}

	void movePlayer()
	{
		posX += speed;
		if(Input.GetKey("z")){
			tiltAroundX = AxisTop * tiltAngle;
			posY = Mathf.Lerp(posY, posY + speedDown, Time.deltaTime);
		}

		else if(Input.GetKey("s")){
			tiltAroundX = AxisDown * tiltAngle;
			posY = Mathf.Lerp(posY, posY - speedDown, Time.deltaTime);
		}
		else
			tiltAroundX = 0;

		Quaternion target = Quaternion.Euler(tiltAroundX, 270, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		transform.position = new Vector3(posX, posY, 0);
		Camera.main.transform.position = new Vector3(transform.position.x + (-15.89729f), transform.position.y +1, transform.position.z);
	}

}
