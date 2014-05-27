using UnityEngine;
using System.Collections;

public class playerBullet : MonoBehaviour {
	public float speed = 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
	}
}
