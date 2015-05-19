using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
	public InstructionState instructionState;
	public ParticleSystem particle;
	void Start()
	{
		particle = GetComponent<ParticleSystem>();
	}

	public void Hide(InstructionState _instructionState)
	{
		//if(instructionState == _instructionState)
		particle.Stop();
		particle.enableEmission = false;
	}

	public void Show(InstructionState _instructionState)
	{
		if(instructionState != _instructionState)
			particle.enableEmission = true;
	}
}

