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
			A1Toolbox.panelScr.GetComponent<Animator>().Play("BackgroundAnim");
			A1Toolbox.panelScr.ShowInstructions();
			gameObject.GetComponentInChildren<ParticleController>().Hide();
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			A1Toolbox.panelScr.CancelInstructions();
			A1Toolbox.panelScr.GetComponent<Animator>().Play("BackgroundReverseAnim");
			gameObject.GetComponentInChildren<ParticleController>().Show();
		}
	}

	void OnDisable()
	{
		A1Toolbox.panelScr.CancelInstructions();
	}
}

