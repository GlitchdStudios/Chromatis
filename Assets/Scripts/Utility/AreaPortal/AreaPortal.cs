using UnityEngine;
using System.Collections;

public class AreaPortal : MonoBehaviour
{
	private Animator[] anim;
	private PortalParticle portalParticle;

	// Use this for initialization
	void Start ()
	{
		anim = transform.GetComponentsInChildren<Animator>();
		portalParticle = transform.GetComponentInChildren<PortalParticle>();
    	}

	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player" && A1Toolbox.inDataSlot)
		{
		        for(int i = 0; i < anim.Length; i++)
		        {
		           	 anim[i].Play((i+1).ToString());
		        }
			
			portalParticle.EnableEmit();
			transform.parent.GetComponent<Animator>().Play("Teleport");
		}
    	}
}

