using UnityEngine;
using System.Collections;

public class obstacleTypeChecker : MonoBehaviour {

	public GameObject collectiblePrefab;
	public GameObject obstaclePrefab;
	// Use this for initialization
	void Start () {
		if(levelSpawner.obstacleCount == levelSpawner.numObsBeforeCollect)
		{
			Instantiate(this.collectiblePrefab, this.transform.position, this.transform.rotation);
			levelSpawner.obstacleCount = 0;
		}
		else{
			Instantiate(this.obstaclePrefab, this.transform.position, this.transform.rotation);
			levelSpawner.obstacleCount += 1;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
