using UnityEngine;
using System.Collections;

public class MouseCaster : MonoBehaviour
{
	private RaycastHit rayHit;
	private Ray ray;
	private Chromas chroma;
	private RedMenu redMenu;

	void Start()
	{
		chroma = gameObject.GetComponent<Chromas>();
		redMenu = gameObject.GetComponent<RedMenu>();
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
       		{
			if(Physics.Raycast(ray, out rayHit))
            		{
				ChooseMenuItem();
			}
		}
	}

	private void ChooseMenuItem()
	{
		switch(rayHit.collider.tag)
		{
			case "StartMenuOption":
				rayHit.transform.GetComponent<Start>().StartDemo();
				chroma.ChangeChroma(ChromaState.RED);
				redMenu.ChangeOptions(RedMenuState.LOADING);
			break;

			case "Options":
				rayHit.transform.parent.parent.GetComponent<Animator>().Play("PlateRotation");
				chroma.ChangeChroma(ChromaState.RED);
				redMenu.ChangeOptions(RedMenuState.OPTIONS);
			break;
		}
	}

	public void ChooseSubMenuItem()
	{
//		switch(rayHit.collider.tag)
//       	 	{
//
//		}
	}
}

