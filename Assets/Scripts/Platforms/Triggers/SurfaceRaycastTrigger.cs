using UnityEngine;
using System.Collections;

public class SurfaceRaycastTrigger : MonoBehaviour
{
	private Vector3 playerPos;
	private Vector3 surfaceDirection;
	private RaycastHit rayHit;
	private bool gravityIsNormal;
	public float rightRayDistance;
	public LayerMask rightMask;

	void Start()
	{
		gravityIsNormal = false;
	}

	void Update()
	{
		//Debug.DrawRay(playerPos,surfaceDirection,Color.green);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			gravityIsNormal = true;
		}
	}
	// Use this for initialization
	void OnTriggerStay(Collider col)
	{
		playerPos = Toolbox.surfaceCasterTransform.position;
		surfaceDirection = Toolbox.surfaceCasterTransform.forward;
		if(col.tag == "Player" && !gravityIsNormal)
		{
			if(Physics.Raycast(playerPos, surfaceDirection, out rayHit, rightRayDistance, rightMask))
			{
				Toolbox.characterControls.Gravity = -rayHit.normal * Toolbox.generalGravityForce;
			}
		}
	}
}

