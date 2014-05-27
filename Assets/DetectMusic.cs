using UnityEngine;
using System.Collections;

public class DetectMusic : MonoBehaviour {

	public float lastMusicPlayed;

	private float _coutdown;
	private bool _gameLaunched = false;

	void OnTriggerEnter(Collider col) {
		if(col.tag == "BlockSpawn")
		{
			_coutdown = lastMusicPlayed;
			_gameLaunched = true;
		}
	}

	void Update()
	{
		if(_gameLaunched)
		{
			_coutdown -= Time.deltaTime;
			if(_coutdown <= 0)
			{
				displayUI();
				_gameLaunched = false;
			}
		}
	}

	void displayUI()
	{	
		for(int i = 0; i < MusicPlay.disablesOtherButon.Length; i++)
		{
			if(MusicPlay.disablesOtherButon[i] != null)
				MusicPlay.disablesOtherButon[i].SetActive(true);
		}
	}
	
	
	
}
