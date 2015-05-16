using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
	public InstructionState instructionState;
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			A1Toolbox.tutTextScr.ChangeInstructionState(instructionState);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			A1Toolbox.tutTextScr.CancelCoroutine();
		}
	}
}

