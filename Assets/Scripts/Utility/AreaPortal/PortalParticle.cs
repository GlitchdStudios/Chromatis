using UnityEngine;
using System.Collections;

public class PortalParticle : MonoBehaviour
{
	public ParticleSystem thisParticle;
	public ParticleSystem childParticle;

	// Use this for initialization
	void Start ()
	{
		thisParticle = gameObject.GetComponent<ParticleSystem>();
		childParticle = gameObject.GetComponent<ParticleSystem>();
	}

	public void EnableEmit()
	{
		thisParticle.enableEmission = true;
		childParticle.enableEmission = true;
	}
}

