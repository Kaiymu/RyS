using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float speed;
	private float _pos = 0;
	private bool _isPlaying = true;

	public delegate void ClickAction();
		
	// Update is called once per frame
	void Update () {
		if(!PauseGame.pause)
		{
			_pos += speed;
			if(_pos > 1f)
				_pos -= 1.0f;

			renderer.material.mainTextureOffset = new Vector2(_pos, 0);
		}
	}
}
