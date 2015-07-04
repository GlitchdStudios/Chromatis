using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Vector3 initPos;
	public Vector3 initGravity;
	private Transform thisTransform;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		initPos = thisTransform.position;
		initGravity = Toolbox.characterControls.Gravity;
	}

	public void InitPlayer()
	{
		thisTransform.position = initPos;
		thisTransform.GetComponent<Rigidbody>().Sleep();
		Toolbox.characterControls.Gravity = initGravity;
	}

	public void HitCheckpoint()
	{
		initPos = this.transform.position;
		initGravity = Toolbox.characterControls.Gravity;
		Toolbox.initChromaState = A1Toolbox.chromaState;
	}
}

