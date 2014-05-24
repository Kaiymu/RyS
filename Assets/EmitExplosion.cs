using UnityEngine;
using System.Collections;

public class EmitExplosion : MonoBehaviour {

	public GameObject particlesDetonator;
	private Detonator _test;
	private int _index;

	void Awake()
	{
		//for(_index = 0; _index < particlesDetonator.Length - 1; _index++);
		//{
		//	_test[_index] = particlesDetonator[_index].GetComponent<Detonator>();
		//}

		_test = particlesDetonator.GetComponent<Detonator>();
	}

	public void exploseMe()
	{
		_test.Explode();
		this.GetComponent<MeshRenderer>().enabled = false;
	}

}
