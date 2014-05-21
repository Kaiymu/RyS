using UnityEngine;
using System.Collections;

public class blockMove : MonoBehaviour {
	
	public float speed = 10f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		
		transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
	}
	
	public void OnTriggerEnter(Collider other)
	{
		

		
		
	}
}
