using UnityEngine;
using System.Collections;

public class levelSpawner : MonoBehaviour {

	public LineRenderer highLinePrefab;
	public LineRenderer midLinePrefab;
	public LineRenderer botLinePrefab;

	public GameObject highSpawnerPrefab;
	public GameObject midSpawnerPrefab;
	public GameObject botSpawnerPrefab;

	public float rangeBetweenRails;
	public float halfScreenSize;
	// Use this for initialization
	void Start () {
		Instantiate(this.midLinePrefab, new Vector3(0,0,0), this.transform.rotation);
		Instantiate(this.highLinePrefab, new Vector3(0,0,0), this.transform.rotation);
		Instantiate(this.botLinePrefab, new Vector3(0,0,0), this.transform.rotation);

		Instantiate(this.midSpawnerPrefab, new Vector3(halfScreenSize,0,0), this.transform.rotation);
		Instantiate(this.highSpawnerPrefab, new Vector3(halfScreenSize,rangeBetweenRails,0), this.transform.rotation);
		Instantiate(this.botSpawnerPrefab, new Vector3(halfScreenSize,-rangeBetweenRails,0), this.transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
