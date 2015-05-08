using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutText : MonoBehaviour
{
	public enum InstructionState { MOVEMENT = 0, INTERACTION, CHROMAS, GRAVITY }
	public InstructionState instructionState;
	public Text textObj;
	// Use this for initialization
	void Start ()
	{
		textObj = gameObject.GetComponent<Text>();
		ChangeInstructionState(instructionState);
	}

	public void ChangeInstructionState(InstructionState _instructionState)
	{
		switch(_instructionState)
		{
		case InstructionState.MOVEMENT:
			textObj.text = "WASD";
			break;
		}
	}
}

