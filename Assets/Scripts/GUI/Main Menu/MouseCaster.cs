using UnityEngine;
using System.Collections;

public class MouseCaster : MonoBehaviour
{
	private RaycastHit rayHit;
	public LayerMask leftMask;
	
	// Update is called once per frame
	void Update ()
	{
		ChooseMenuItem();
	}

	private void ChooseMenuItem()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit;
			if(Physics.Raycast(ray, out rayHit))
			{
				switch(rayHit.collider.tag)
				{
					case "StartMenuOption":
						rayHit.transform.GetComponent<Start>().StartDemo();
						rayHit.transform.parent.parent.GetComponent<Animator>().Play("PlateRotation");
					break;
				}
			}

		}
	}
}

