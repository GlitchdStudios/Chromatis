using UnityEngine;
using System.Collections;

public enum ChromaState { BLUE = 0, RED }

public class Toolbox : MonoBehaviour
{
	public GameObject playerObj;
	public GameObject cameraObj;
	public GameObject followObj;
	public GameObject dataSphereObj;

	public static GameObject dataSlotObj;
	public static Collider dataSlotCenter;
	public static Transform followTrans;
	public static Transform playerTransform;
	public static Transform mainCameraTransform;
	public static Transform surfaceCasterTransform;
	public static CharacterControls characterControls;
	public static DataSphere dataSphereScr;
	public static Player playerScr;
	public static float generalGravityForce;
	public static ChromaState chromaState;
	public static ChromaState initChromaState;
	public static GameObject[] chroma;
	public static bool isControlable = true;
	public static Platform[] platforms;

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
		characterControls = playerObj.GetComponent<CharacterControls>();          
		surfaceCasterTransform = GameObject.FindGameObjectWithTag("SurfaceCaster").transform;
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
