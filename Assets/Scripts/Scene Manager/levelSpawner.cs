using UnityEngine;
using System.Collections;

public class levelSpawner : MonoBehaviour {

	public LineRenderer highLine;
	public LineRenderer midLine;
	public LineRenderer botLine;

	public GameObject highSpawnerPrefab;
	public GameObject midSpawnerPrefab;
	public GameObject botSpawnerPrefab;

	public static int obstacleCount;
	public static int numObsBeforeCollect;
	public static int bassCount;
	public static int ActiveRailNum; // 0 : top 1 : mid 2: top

	public float rangeBetweenRails;
	public float halfScreenSize;


	public Color unUsedRail;
	public Color usedRail;
	// Use this for initialization
	void Start () {
		/*Instantiate(this.midLinePrefab, new Vector3(0,0,0), this.transform.rotation);
		Instantiate(this.highLinePrefab, new Vector3(0,0,0), this.transform.rotation);
		Instantiate(this.botLinePrefab, new Vector3(0,0,0), this.transform.rotation);*/


		Instantiate(this.midSpawnerPrefab, new Vector3(halfScreenSize,0,0), this.transform.rotation);
		Instantiate(this.highSpawnerPrefab, new Vector3(halfScreenSize,rangeBetweenRails,0), this.transform.rotation);
		Instantiate(this.botSpawnerPrefab, new Vector3(halfScreenSize,-rangeBetweenRails,0), this.transform.rotation);

		obstacleCount = 0;
		numObsBeforeCollect = 4;
		bassCount = 0;
		ActiveRailNum = 1;


	}
	
	// Update is called once per frame
	void Update () {

		if(bassCount == 1)
		{
			bassCount = 0;
			if(ActiveRailNum < 2)
				ActiveRailNum += 1;

			else{
				ActiveRailNum = 0;
				highLine.SetColors(usedRail,usedRail);
				midLine.SetColors(unUsedRail,unUsedRail);
				botLine.SetColors(unUsedRail,unUsedRail);
			}
		}
		if(ActiveRailNum == 2)
		{
			highLine.SetColors(unUsedRail,unUsedRail);
			midLine.SetColors(unUsedRail,unUsedRail);
			botLine.SetColors(usedRail,usedRail);
		}
		if(ActiveRailNum == 1)
		{
			highLine.SetColors(unUsedRail,unUsedRail);
			midLine.SetColors(usedRail,usedRail);
			botLine.SetColors(unUsedRail,unUsedRail);
		}


		//highLine.SetColors(usedRail,usedRail);
	}
}
