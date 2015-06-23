using UnityEngine;
using System.Collections;

public class Switch : Utility
{
	private ParticleSystem particle;

	// Use this for initialization
	void Start ()
	{
		particle = transform.GetComponentInChildren<ParticleSystem>();
	}

	public void ToggleParticle() { particle.enableEmission = (particle.enableEmission == true) ? false : true; }

	public override bool ToggleState() { isActive = (isActive == true) ? false : true;  return isActive; }
	public override void CheckState(bool _isActive) { Debug.Log(_isActive); }
	public override bool IsActive { get { return isActive; } }
}

