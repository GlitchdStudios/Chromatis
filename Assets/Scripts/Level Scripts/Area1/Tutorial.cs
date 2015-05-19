using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
	public InstructionState instructionState;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			A1Toolbox.panelScr.instructionState = instructionState;
			A1Toolbox.panelScr.ShowInstructions();
			gameObject.GetComponentInChildren<ParticleController>().Hide(instructionState);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			A1Toolbox.panelScr.CancelInstructions();
			//gameObject.GetComponentInChildren<ParticleController>().Show(instructionState);
		}
	}
}

