using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float speed;

	float pos = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos += speed;

		if(pos > 1.0f)
			pos -= 1.0f;

		renderer.material.mainTextureOffset = new Vector2(pos, 0);
	}
}
