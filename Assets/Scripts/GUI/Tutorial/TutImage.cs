using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutImage : MonoBehaviour
{
	private Animator anim;
	private Image image;

	public Sprite blankSprite;

	void Start()
	{
		anim = GetComponent<Animator>();
		image = GetComponent<Image>();
	}
	public void ChangeAnimation(InstructionState instructionState)
	{
		anim.enabled = true;
		switch(instructionState)
		{        
			case InstructionState.MOVEMENT:
				anim.Play("WASDanim", -1, 0f);
			break;

			case InstructionState.INTERACTION:
				anim.Play("IntroAnim_Interaction");
			break;

			case InstructionState.CHROMAS:
				anim.Play ("ChromasAnim");
			break;

			case InstructionState.GRAVITY:
				anim.Play("IntroAnim_Gravity");
			break;

			case InstructionState.GRAVITY2:
				Clear();
			break;

			case InstructionState.PICKUP:
				anim.Play("PickupTut");
			break;

			case InstructionState.NOGRAV:
				Clear();
			break;
		}
	}

	public void Clear()
	{
		if(anim != null)
		{
			anim.enabled = false;
			image.sprite = blankSprite;
		}
	}
}

