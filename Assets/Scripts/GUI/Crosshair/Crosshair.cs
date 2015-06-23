using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void StartAnim()
	{
		anim.Play("Start");
	}

	public void StopAnim(Transform rayCasterTrans)
	{
		bool grounded = Physics.Raycast(rayCasterTrans.position, Toolbox.characterControls.Gravity.normalized, 1.1f);

		if(grounded)
		{
			anim.Play("End");
		}
	}
}

