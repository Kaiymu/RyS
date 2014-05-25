using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	public static bool pause = false;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p")){
			Time.timeScale = 0;
			pause = true;
		}
		if(Input.GetKeyDown("v")){
			Time.timeScale = 1;
			pause = false;
		}
	}
}
