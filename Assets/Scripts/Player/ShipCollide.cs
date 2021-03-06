﻿using UnityEngine;
using System.Collections;

public class ShipCollide : MonoBehaviour {

	public GameObject ScoreManager;

	private ScoreManager _scoreGive;
	private ParticleSystem _particleExplodesSelf;
	private int _combo;

	void Start()
	{
		_particleExplodesSelf = this.transform.GetChild(0).GetComponent<ParticleSystem>();
		_scoreGive = ScoreManager.GetComponent<ScoreManager>();
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "Collectible")
		{
			_combo++;
			Destroy(col.gameObject);
			_scoreGive.score += 50 * _combo;
			_particleExplodesSelf.Play();
			_scoreGive.particleGoodOnce = true;
		}

		if(col.tag == "BlockSpawn")
		{
			if(col.gameObject.GetComponent<blockMove>().isDead)
				Debug.Log ("Already dead");
			else
			{
				_combo = 0;
				col.GetComponent<EmitExplosion>().exploseMe();
				_scoreGive.score -= 600;
				_scoreGive.particleBadOnce = true;
			}
		}
	}

}
