using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public enum InstructionState { MOVEMENT = 0, INTERACTION, CHROMAS, GRAVITY }

public class TutText : MonoBehaviour
{
	public Text textObj;
	public char[] _text;

	// Use this for initialization
	void Start ()
	{
		textObj = gameObject.GetComponent<Text>();
	}

	public void ChangeInstructionState(InstructionState _instructionState)
	{
		switch(_instructionState)
		{
		case InstructionState.MOVEMENT:
			StartCoroutine(ChangeText(">  Hello Chromatis.  This is a test of your basic operation." + Environment.NewLine + Environment.NewLine + ">  To move, use: "));
			break;

		case InstructionState.INTERACTION:
			StartCoroutine(ChangeText(textObj.text = ">  To interact with Switches press:  "));
			break;

		case InstructionState.CHROMAS:
			StartCoroutine(ChangeText(textObj.text = ">  To change Chromas (dimensions) press:  "));
			break;

		case InstructionState.GRAVITY:
			StartCoroutine(ChangeText(textObj.text = ">  To change gravity, point your crosshair at the surface you want to walk on and press:  "));
			break;
		}
	}

	public IEnumerator ChangeText(string baseText)
	{
		_text = new char[baseText.Length];
		_text = baseText.ToCharArray();

		for(int i = 0; i < _text.Length; i++)
		{
			yield return new WaitForSeconds(0.05f);
			textObj.text += _text[i].ToString();
		}
	}	
}

