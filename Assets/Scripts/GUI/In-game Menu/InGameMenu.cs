using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour
{
	private RaycastHit rayHit;
	private Ray ray;
	// Use this for initialization
	void Start ()
	{

	}
	
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit))
			{
				ChooseMenuItem();
				//ChooseSubMenuItem();
			}
		}
	}

	private void ChooseMenuItem()
	{
		switch(rayHit.collider.name)
		{
		case "ReturnToGame":
			gameObject.SetActive(false);
			break;
			
		case "Options":
			break;
			
		case "ExitToMenu":
			Application.LoadLevelAsync("Menu");
			break;
		}
	}
}

