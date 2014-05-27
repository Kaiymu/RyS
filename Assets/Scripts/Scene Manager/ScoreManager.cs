using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private float _score = 0f;
	private GUIText _GuiScore;
	private float _scoreIncrease = 0f;

	public static float giveScoreToAll;

	public bool particleBadOnce, particleGoodOnce = false;

	public GameObject goodEmiter, badEmiter;
	private Detonator _goodEmiter, _badEmiter;
	private UILabel _displayScore;

	void Start()
	{
		_displayScore = this.GetComponent<UILabel>();
		_goodEmiter = goodEmiter.GetComponent<Detonator>();
		_badEmiter  = badEmiter.GetComponent<Detonator>();
	}

	public float score
	{
		get {return _score;}
		set {
			if(value < 0)
				_score = 0;
			else
				if(value < 0)
					_score = 0;
			else 
				_score = value;
		}
	}

	void Update()
	{
		if(particleGoodOnce)
		{
			_goodEmiter.Explode();
			particleGoodOnce = false;
		}
		if(particleBadOnce)
		{
			_badEmiter.Explode();
			particleBadOnce = false;
		}

		_displayScore.text = "Your score : " + _score;
		giveScoreToAll = _score;			
	}
	

}
