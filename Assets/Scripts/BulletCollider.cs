using UnityEngine;
using System.Collections;

public class BulletCollider : MonoBehaviour {

	private GameObject _ScoreManager;
	private ScoreManager _scoreGive;

	private int _numberHitted = 0;

	void Start()
	{
		_ScoreManager = GameObject.FindGameObjectWithTag("Score");
		if(_scoreGive != null)
			_scoreGive = _ScoreManager.GetComponent<ScoreManager>();
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "BlockSpawn")
		{
			_numberHitted++;
			col.GetComponent<EmitExplosion>().exploseMe();
			if(_scoreGive != null)
			{
				_scoreGive.score += (_numberHitted * 100);
				_scoreGive.particleGoodOnce = true;
			}

		}
	}
}
