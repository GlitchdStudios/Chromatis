using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
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
				anim.Play("WASDanim");
			break;

			case InstructionState.INTERACTION:
				anim.Play("MouseLeftAnim");
			break;

			case InstructionState.CHROMAS:
				anim.Play ("ChromasAnim");
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

