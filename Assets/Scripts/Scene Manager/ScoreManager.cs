using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private float _score = 0f;
	private GUIText _GuiScore;
	private float _scoreIncrease = 0f;

	public GameObject goodEmiter, badEmiter;
	private Detonator _goodEmiter, _badEmiter;
	private bool _particleBadOnce, _particleGoodOnce = true;


	void Awake()
	{	
		_GuiScore = GetComponent<GUIText>();
	}

	void Start()
	{
		_goodEmiter = goodEmiter.GetComponent<Detonator>();
		_badEmiter  = badEmiter.GetComponent<Detonator>();
	}

	void Update()
	{
		_GuiScore.text = "Your score is" + " : " + _score;

			if(_score < _scoreIncrease && _particleGoodOnce)
			{
				_goodEmiter.Explode();
				_particleGoodOnce = false;
			}
			else if(_score > _scoreIncrease && _particleBadOnce)
			{
				_badEmiter.Explode();
				_particleBadOnce = false;
			}
			
		_scoreIncrease = _score;
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

}
