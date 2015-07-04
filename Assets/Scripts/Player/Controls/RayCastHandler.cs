using UnityEngine;
using System.Collections;

public class RayCastHandler : MonoBehaviour
{
	private RaycastHit rayHit;
	private Rigidbody hitObject;
	private Vector3 direction;
	private AudioSource audioSource;
	//private Vector3 curDirection;
	private Switch switchScr;
	private BaseLevel baseLevelScr;
	private Platform platformScr;
	private Crosshair crosshairScr;
	private float startSpeed;
	private float curDistance;
	private float maxDistance;

	public float leftRayDistance;
	public float rightRayDistance;
	public float speed;
	public LayerMask leftMask;
	public LayerMask rightMask;
	public LayerMask pickupMask;
	public LayerMask blockMask;
	public AudioClip interactionClip;
	public AudioClip gravityClip;

	void Start()
	{
		startSpeed = speed;
		maxDistance = 0.5f;
		Toolbox.followTrans.localPosition = new Vector3(Toolbox.followTrans.localPosition.x, Toolbox.followTrans.localPosition.y, 2.5f);
		crosshairScr = MenuToolbox.crosshair.GetComponent<Crosshair>();
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{
		crosshairScr.StopAnim(transform);
	}

	public void Interact(Vector3 origin, Vector3 direction)
	{
		if(Input.GetMouseButtonDown(0) && Physics.Raycast(origin, direction, out rayHit, leftRayDistance, leftMask))
		{
			HitSwitch();
			audioSource.clip = interactionClip;
			audioSource.Play();
		}

		if(Toolbox.isControlable)
		{
			if(Input.GetKeyDown(KeyCode.E) && Physics.Raycast(origin, direction, out rayHit, leftRayDistance, pickupMask))
			{
				PickupObject();
			}
		}

		else
		{
			if(hitObject != null)
			{
				UpdateObject(origin, direction);
				DropObject(origin, direction);
			}
		}
	}

	public void HitSwitch()
	{
		if(rayHit.collider.tag == "Switch")
		{
			switchScr = rayHit.collider.GetComponent<Switch>();

			platformScr = switchScr.transform.parent.GetComponent<Platform>();
			baseLevelScr = switchScr.transform.parent.GetComponent<BaseLevel>();

			//For Area_02
			if(baseLevelScr != null)
			{
				if(!switchScr.IsActive)
				{
					baseLevelScr.SetDirection(switchScr);
				}
			}

			//For Moving Platform Switches
			if(platformScr != null)
			{
				if(!switchScr.IsActive)
				{
					platformScr.SetDirection(switchScr);
					switchScr.ToggleParticle();
				}
			}
		}
	}

	public void ChangeGravity(Vector3 origin, Vector3 direction)
	{
		if(Input.GetMouseButtonDown(1) && !Physics.Raycast(origin, direction, out rayHit, rightRayDistance, blockMask))
		{
			if(Physics.Raycast(origin, direction, out rayHit, rightRayDistance, rightMask))
			{
				Toolbox.characterControls.Gravity = -rayHit.normal * Toolbox.generalGravityForce;
				crosshairScr.StartAnim();
				audioSource.clip = gravityClip;
				audioSource.Play();

			}
		}

		if(!Physics.Raycast(origin, direction, out rayHit, rightRayDistance, blockMask))
		{
			if(Physics.Raycast(origin, direction, out rayHit, rightRayDistance,rightMask))
			{
				Debug.DrawRay(origin, direction * 38);
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Toolbox.characterControls.Gravity = Vector3.down * Toolbox.generalGravityForce;
		}
	}

	public void PickupObject()
	{
		if(rayHit.collider.tag == "DataSphere")
		{
			hitObject = rayHit.collider.GetComponent<Rigidbody>();
			hitObject.position = Toolbox.followTrans.position;
			hitObject.constraints = RigidbodyConstraints.FreezeRotation;

			if(Toolbox.chromaState == ChromaState.BLUE)
			{
				hitObject.transform.parent = Toolbox.chroma[(int)ChromaState.BLUE].transform.parent;
			}

			if(Toolbox.chromaState == ChromaState.RED)
			{
				hitObject.transform.parent = Toolbox.chroma[(int)ChromaState.RED].transform.parent;
			}

			Toolbox.isControlable = false;
		}
	}

	public void UpdateObject(Vector3 origin, Vector3 direction)
	{
		curDistance = GetSqrDistXZ(hitObject.position, Toolbox.followTrans.position);
		curDistance = Mathf.Clamp (curDistance, 0, maxDistance);

		Debug.Log("CurDistance " + curDistance);
		speed = startSpeed * curDistance;
		
	 	direction = (Toolbox.followTrans.position - hitObject.position).normalized;
		hitObject.velocity = direction * speed;

		if(!A1Toolbox.inDataSlot)
		{
			hitObject.rotation = A1Toolbox.playerTransform.rotation;
		}
	}

	private void ChangeFollowPos(Vector3 origin, Vector3 direction)
	{
//		if(!Physics.Raycast(origin, direction, out rayHit, leftRayDistance, floorMask))
//		{
//			Toolbox.followTrans.position.z = 
//      		}
	}

	public void DropObject(Vector3 origin, Vector3 direction)
	{
		if(Input.GetKeyDown(KeyCode.E) && Physics.Raycast(origin, direction, out rayHit, leftRayDistance, pickupMask))
		{
			Toolbox.isControlable = true;
			hitObject.constraints = RigidbodyConstraints.None;
		}
	}

	public float GetSqrDistXZ(Vector3 a, Vector3 b)
	{
		Vector3 vector = a - b;
		return vector.sqrMagnitude;
	}

}

