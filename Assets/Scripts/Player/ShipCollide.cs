using UnityEngine;
using System.Collections;

public class ShipCollide : MonoBehaviour {

	public GameObject ScoreManager;
	private ScoreManager _scoreGive;
	private ParticleSystem _particleExplodesSelf;
	
	void Start()
	{
		_particleExplodesSelf = this.transform.GetChild(0).GetComponent<ParticleSystem>();
		_scoreGive = ScoreManager.GetComponent<ScoreManager>();
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "Collectible")
		{
			//col.GetComponent<EmitExplosion>().exploseMe();
			Destroy(col.gameObject);
			_scoreGive.score += 10;
			_particleExplodesSelf.Play();
		}
		if(col.tag == "BlockSpawn")
		{
			col.GetComponent<EmitExplosion>().exploseMe();
			_scoreGive.score -= 15;
		}
	}

}
