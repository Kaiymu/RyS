using UnityEngine;
using System.Collections;

public class blockMove : MonoBehaviour {
	
	public float speed = 10f;
	public bool isDead = false;
	
	void Update () {
	
		transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
	}

}
