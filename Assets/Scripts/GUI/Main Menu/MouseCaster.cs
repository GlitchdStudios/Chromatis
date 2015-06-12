using UnityEngine;
using System.Collections;

public class MouseCaster : MonoBehaviour
{
	private RaycastHit rayHit;
	private Ray ray;
	private Chromas chroma;
	private RedMenu redMenu;
	private FullScreenToggle fullScreenToggle;

	public Texture[] toggleTexture;

	void Start()
	{
		chroma = gameObject.GetComponent<Chromas>();
		redMenu = gameObject.GetComponent<RedMenu>();
		fullScreenToggle = new FullScreenToggle();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit))
			{
				ChooseMenuItem();
				ChooseSubMenuItem();
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
		switch(rayHit.collider.name)
       	 	{
			case "FullScreenToggle":
				fullScreenToggle.ToggleFullScreen();
				
				if(fullScreenToggle.getIsFullScreen())
				{
					rayHit.transform.GetComponent<Renderer>().material.mainTexture = toggleTexture[1];
				}
				else
				{
					rayHit.transform.GetComponent<Renderer>().material.mainTexture = toggleTexture[0];
				}
			break;
		}
	}
}