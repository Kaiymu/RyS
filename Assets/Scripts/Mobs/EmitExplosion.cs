using UnityEngine;
using System.Collections;

public class EmitExplosion : MonoBehaviour {

	public GameObject particlesDetonator;
	private Detonator _particlesDetonator;

	void Awake()
	{
		_particlesDetonator = particlesDetonator.GetComponent<Detonator>();
	}

	public void exploseMe()
	{
		_particlesDetonator.Explode();
		particlesDetonator.transform.parent.GetComponent<blockMove>().isDead = true;
			ParticleSystem[] allChildren = GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem childParticles in allChildren) {
			Destroy(childParticles);
		}
	}

}
