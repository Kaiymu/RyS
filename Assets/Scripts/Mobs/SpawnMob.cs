using UnityEngine;
using System.Collections;

public class SpawnMob : MonoBehaviour {

    public Vector2 range;
    public float delay;
    public GameObject prefab;

    private bool spawn = false;

	void Awake () 
    {
        GameManager.Instance.onRunBegin += StartSpawn;
        GameManager.Instance.onRunEnd += StopSpawn;
	}

    void OnDestroy()
    {
        GameManager.Instance.onRunBegin -= StartSpawn;
        GameManager.Instance.onRunEnd -= StopSpawn;
    }

    void StartSpawn()
    {
        Debug.Log("Spawn");
        spawn = true;
        Spawn();
    }

    void StopSpawn(float time)
    {
        spawn = false;
    }

	void Spawn () 
    {
        if (spawn == false) return;
	    Vector3 position = transform.position;
        position.x = Random.Range(range.x, range.y);
        GameObject o = Instantiate(prefab, position, Random.rotation) as GameObject;
        o.transform.parent = this.transform;
        Invoke("Spawn", delay);
	}
}
