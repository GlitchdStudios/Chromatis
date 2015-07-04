using UnityEngine;
using System.Collections;

public class SurfaceRaycastTrigger : MonoBehaviour
{
	private Transform surfaceCasterTrans;
	private Vector3 playerPos;
	private Rigidbody playerRigidbody;
	private Vector3 surfaceDirection;
	private RaycastHit rayHit;
	private bool gravityIsNormal;
	public float rightRayDistance;
	public LayerMask rightMask;


	void Update()
	{
		//Debug.DrawRay(playerPos,surfaceDirection,Color.green);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			gravityIsNormal = true;
		}
		if(Input.GetMouseButtonDown(1))
		{
			gravityIsNormal = false;
		}
	}
	// Use this for initialization
	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player" && !gravityIsNormal)
		{
			playerPos = col.transform.position;
			playerRigidbody = col.transform.GetComponent<Rigidbody>();
			surfaceCasterTrans = col.transform.FindChild("SurfaceCaster");
			surfaceDirection = surfaceCasterTrans.forward;

			if(Physics.Raycast(playerPos, surfaceDirection, out rayHit, rightRayDistance, rightMask))
			{
				Toolbox.characterControls.Gravity = -rayHit.normal * Toolbox.generalGravityForce;
			}
		}
	}
}

