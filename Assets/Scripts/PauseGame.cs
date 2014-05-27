using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	public static bool pause = false;
		
	void Update () {
		if (Input.GetKeyDown("p")){
			Time.timeScale = 0;
			pause = true;
		}
		if(Input.GetKeyDown("m")){
			Time.timeScale = 1;
			pause = false;
		}
	}
}
