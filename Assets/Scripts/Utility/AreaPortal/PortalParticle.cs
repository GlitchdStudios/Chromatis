using UnityEngine;
using System.Collections;

public class PortalParticle : MonoBehaviour
{
	public ParticleSystem thisParticle;
	public ParticleSystem childParticle;

	public void EnableEmit()
	{
		thisParticle.enableEmission = true;
		childParticle.enableEmission = true;
	}
}

