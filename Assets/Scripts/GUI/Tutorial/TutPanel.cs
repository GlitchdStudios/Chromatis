using UnityEngine;
using System.Collections;

public class TutPanel : MonoBehaviour
{
	public TutText tutText;
	public TutImage tutImage;
	public InstructionState instructionState;

	// Use this for initialization
	void Start ()
	{
		tutText = GetComponentInChildren<TutText>();
		tutImage = GetComponentInChildren<TutImage>();
	}

	void Update()
	{
		if(tutText.printed)
		{
			tutImage.ChangeAnimation(instructionState);
			tutText.printed = false;
		}
	}

	public void ShowInstructions()
	{
		tutText.ChangeInstructionState(instructionState);	
	}

	public void CancelInstructions()
	{
		tutText.CancelCoroutine();
	}
}

