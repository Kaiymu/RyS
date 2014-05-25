using UnityEngine;
using System.Collections;

public class DestroyColisions : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		Destroy(col.gameObject);
	}
}
