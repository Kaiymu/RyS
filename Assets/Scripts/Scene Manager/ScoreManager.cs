using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private float _score = 0f;
	private GUIText _GuiScore;

	void Awake()
	{
		_GuiScore = GetComponent<GUIText>();
	}

	void Update()
	{
		_GuiScore.text = "Your score is" + " : " + _score;
	}

	public float score
	{
		get {return _score;}
		set{_score = value;}
	}

}
