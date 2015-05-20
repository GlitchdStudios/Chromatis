using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
	public ParticleSystem particle;
	void Start()
	{
		particle = GetComponent<ParticleSystem>();
	}

	public void Hide()
	{
		particle.Stop();
 		particle.enableEmission = false;
	}

	public void Show()
	{
		particle.Play();
		particle.enableEmission = true;
	}
}

