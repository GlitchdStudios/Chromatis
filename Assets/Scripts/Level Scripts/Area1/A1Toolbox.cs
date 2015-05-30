using UnityEngine;
using System.Collections;

public enum InstructionState {MOVEMENT = 0, INTERACTION, CHROMAS, GRAVITY, PICKUP }

public class A1Toolbox: Toolbox
{
	public  GameObject panelObj;
	public  static TutPanel panelScr;

	void Awake () 
	{
		characterControls = playerObj.GetComponent<CharacterControls>();          
		playerScr = playerObj.GetComponent<Player>();
		playerTransform = playerObj.transform;
		mainCameraTransform = cameraObj.transform;
		followTrans = followObj.transform;
		generalGravityForce = 9.81f;
		platforms =	FindObjectsOfType(typeof(Platform)) as Platform[];
		panelScr = panelObj.GetComponent<TutPanel>();
	}
}
