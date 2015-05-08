using UnityEngine;
using System.Collections;

public class A1Toolbox: Toolbox
{
	void Awake () 
	{
		characterControls = playerObj.GetComponent<CharacterControls>();          
		playerScr = playerObj.GetComponent<Player>();
		playerTransform = playerObj.transform;
		mainCameraTransform = cameraObj.transform;
		followTrans = followObj.transform;
		generalGravityForce = 9.81f;
		platforms =	FindObjectsOfType(typeof(Platform)) as Platform[];
	}
}
