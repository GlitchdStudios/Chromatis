using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TutText : MonoBehaviour
{
	public Text textScr;
	public char[] _text;
	public bool printed;

	// Use this for initialization
	void Start ()
	{
		textScr = gameObject.GetComponent<Text>();
	}

	public void ChangeInstructionState(InstructionState _instructionState)
	{
		switch(_instructionState)
		{
		case InstructionState.MOVEMENT:
			StartCoroutine(ChangeText(">  Hello Chromatis.  This is a test of your basic operation." + Environment.NewLine + Environment.NewLine + ">  To move, use: "));
			break;

		case InstructionState.INTERACTION:
			StartCoroutine(ChangeText( ">  To interact with the arrow button on this platform press:  "));
			break;

		case InstructionState.CHROMAS:
			StartCoroutine(ChangeText(">  To change Chromas (dimensions) press:  "));
			break;

		case InstructionState.GRAVITY:
			StartCoroutine(ChangeText(">  To change gravity, point your crosshair at the surface you want to walk on and press:  "));
			break;

		case InstructionState.GRAVITY2:
			StartCoroutine(ChangeText(">  Press Spacebar to return to normal gravity/jump.  The blue circular platform below you is where you want to land."));
			break;

		case InstructionState.PRE_PICKUP:
			StartCoroutine(ChangeText(">  There's a DataSphere on the platform over there.   You will need find a slot for it."));
			break;

		case InstructionState.PICKUP:
			StartCoroutine(ChangeText(">  Since this DataSphere is blue, you will need to bring it to a matching slot in the blue chroma.  To pick up the DataSphere press:  "));
			break;

		case InstructionState.NOGRAV:
			StartCoroutine(ChangeText(">  White colored surfaces do not allow you to change your gravity to them."));
			break;
		}
	}

	public IEnumerator ChangeText(string baseText)
	{
		_text = new char[baseText.Length];
		_text = baseText.ToCharArray();
		textScr.text = "";

		for(int i = 0; i <  _text.Length; i++)
		{
			yield return new WaitForSeconds(0.05f);
			textScr.text += _text[i].ToString();

			if((i + 1) == _text.Length)
				printed = true;
		}
	}	

	public void CancelCoroutine()
	{
		if(textScr != null)
		{
			StopAllCoroutines();
			textScr.text = "";
		}
	}
}

