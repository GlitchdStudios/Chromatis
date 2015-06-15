using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	private RaycastHit rayHit;
	private Ray ray;
	private Chromas chroma;
	private RedMenu redMenu;
	private ApplyButton applyButton;
	private AudioSource menuClip;

	public GameObject applyButtonObj;
	public Texture[] toggleTexture;
	
	void Start()
	{
		chroma = gameObject.GetComponent<Chromas>();
		redMenu = gameObject.GetComponent<RedMenu>();
		applyButton = applyButtonObj.GetComponent<ApplyButton>(); 
		menuClip = gameObject.GetComponent<AudioSource>();
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
		menuClip.Play();
		switch(rayHit.collider.name)
		{
		case "Start":
			rayHit.transform.GetComponent<Start>().StartDemo();
			chroma.ChangeChroma(ChromaState.RED);
			redMenu.ChangeOptions(RedMenuState.LOADING);
			break;
			
		case "Options":
			chroma.ChangeChroma(ChromaState.RED);
			redMenu.ChangeOptions(RedMenuState.OPTIONS);
			break;
			
		case "Exit":
			Application.Quit();
			break;
		}
	}
	
	private void ChooseSubMenuItem()
	{
		switch(rayHit.collider.name)
		{
		case "FullScreenToggle":
			applyButton.fullScreenToggle.ToggleFullScreen();
			
			if(applyButton.fullScreenToggle.getIsFullScreen())
			{
				rayHit.transform.GetComponent<Renderer>().material.mainTexture = toggleTexture[1];
			}
			else
			{
				rayHit.transform.GetComponent<Renderer>().material.mainTexture = toggleTexture[0];
			}
			break;
			
		case "LeftArrow":
			applyButton.resOption.ResIndex--;
			
			if(applyButton.resOption.ResIndex < 0)
			{
				applyButton.resOption.ResIndex = (applyButton.resOption.resolutions.Length - 1);
			}
			
			rayHit.transform.GetComponent<Arrow>().textMesh.text = applyButton.resOption.resolutions[applyButton.resOption.ResIndex].width.ToString() + " x " + applyButton.resOption.resolutions[applyButton.resOption.ResIndex].height.ToString();
			break;
			
		case "RightArrow":
			applyButton.resOption.ResIndex++;
			
			if(applyButton.resOption.ResIndex > (applyButton.resOption.resolutions.Length - 1))
			{
				applyButton.resOption.ResIndex = 0;
			}	
			
			rayHit.transform.GetComponent<Arrow>().textMesh.text = applyButton.resOption.resolutions[applyButton.resOption.ResIndex].width.ToString() + " x " + applyButton.resOption.resolutions[applyButton.resOption.ResIndex].height.ToString();
			break;
			
		case "ApplyButton":
			rayHit.transform.GetComponent<ApplyButton>().ChangeResolution();
			break;
			
		case "Cancel":
			chroma.ChangeChroma(ChromaState.BLUE);
			//	redMenu.ChangeOptions();
			break;
		}
	}
}

