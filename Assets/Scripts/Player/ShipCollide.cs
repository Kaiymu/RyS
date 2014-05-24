using UnityEngine;
using System.Collections;

public class ShipCollide : MonoBehaviour {

	public GameObject ScoreManager;
	private ScoreManager _scoreGive;


	void Start()
	{
		_scoreGive = ScoreManager.GetComponent<ScoreManager>();
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "BlockSpawn")
		{
			col.GetComponent<EmitExplosion>().exploseMe();
			_scoreGive.score += 1;
		}
	}
}
