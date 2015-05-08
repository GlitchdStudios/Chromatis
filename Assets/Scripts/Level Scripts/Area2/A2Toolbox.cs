using UnityEngine;
using System.Collections;

public class A2Toolbox: Toolbox
{
	//Area 2
	public GameObject towerA;
	public GameObject towerB;
	public GameObject towerC;
	public static Tower _towerA;
	public static Tower _towerB;
	public static Tower _towerC;
	public static Tower[] towers = new Tower[3];

	void Awake () 
	{
		//All Areas
		characterControls = playerObj.GetComponent<CharacterControls>();          
		playerScr = playerObj.GetComponent<Player>();
		playerTransform = playerObj.transform;
		mainCameraTransform = cameraObj.transform;
		followTrans = followObj.transform;
		generalGravityForce = 9.81f;
		platforms =	FindObjectsOfType(typeof(Platform)) as Platform[];

		//Area 2
		_towerA = towerA.GetComponent<Tower>();
		_towerB = towerB.GetComponent<Tower>();
		_towerC = towerC.GetComponent<Tower>();
		towers[0] = _towerA;
		towers[1] = _towerB;
		towers[2] = _towerC;
	}
}
