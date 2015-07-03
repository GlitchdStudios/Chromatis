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
		switch(rayHit.collider.name)
		{
		case "Start":
			menuClip.Play();
			rayHit.transform.GetComponent<Start>().StartDemo();
			chroma.ChangeChroma(ChromaState.RED);
			redMenu.ChangeOptions(RedMenuState.LOADING);
			break;
			
		case "Options":
			menuClip.Play();
			chroma.ChangeChroma(ChromaState.RED);
			redMenu.ChangeOptions(RedMenuState.OPTIONS);
			break;
			
		case "Exit":
			menuClip.Play();
			Application.Quit();
			break;
		}
	}
	
	private void ChooseSubMenuItem()
	{
		switch(rayHit.collider.name)
		{
		case "FullScreenToggle":
			menuClip.Play();
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
			
		case "ResLeftArrow":
			menuClip.Play();
			applyButton.resOption.ResIndex--;
			
			if(applyButton.resOption.ResIndex < 0)
			{
				applyButton.resOption.ResIndex = (applyButton.resOption.resolutions.Length - 1);
			}
			
			rayHit.transform.GetComponent<Arrow>().textMesh.text = applyButton.resOption.resolutions[applyButton.resOption.ResIndex].width.ToString() + " x " + applyButton.resOption.resolutions[applyButton.resOption.ResIndex].height.ToString();
			break;
			
		case "ResRightArrow":
			menuClip.Play();
			applyButton.resOption.ResIndex++;
			
			if(applyButton.resOption.ResIndex > (applyButton.resOption.resolutions.Length - 1))
			{
				applyButton.resOption.ResIndex = 0;
			}	
			
			rayHit.transform.GetComponent<Arrow>().textMesh.text = applyButton.resOption.resolutions[applyButton.resOption.ResIndex].width.ToString() + " x " + applyButton.resOption.resolutions[applyButton.resOption.ResIndex].height.ToString();
			break;

		case "SenRightArrow":
			menuClip.Play();
			applyButton.mouseSen.SensitivityIndex++;
			
			if(applyButton.mouseSen.SensitivityIndex > (applyButton.mouseSen.sensitivityNum.Length - 1))
			{
				applyButton.mouseSen.SensitivityIndex = 0;
			}	
			
			rayHit.transform.GetComponent<Arrow>().textMesh.text = applyButton.mouseSen.sensitivityNum[applyButton.mouseSen.SensitivityIndex].ToString();
			break;

		case "SenLeftArrow":
			menuClip.Play();
			applyButton.mouseSen.SensitivityIndex--;
			
			if(applyButton.mouseSen.SensitivityIndex < 0)
			{
				applyButton.mouseSen.SensitivityIndex = (applyButton.mouseSen.sensitivityNum.Length - 1);
			}

			
			rayHit.transform.GetComponent<Arrow>().textMesh.text = applyButton.mouseSen.sensitivityNum[applyButton.mouseSen.SensitivityIndex].ToString();
			break;

		case "ApplyButton":
			menuClip.Play();
			rayHit.transform.GetComponent<ApplyButton>().ChangeResolution();
			break;
			
		case "Back":
			menuClip.Play();
			chroma.ChangeChroma(ChromaState.BLUE);
			//	redMenu.ChangeOptions();
			break;
		}
	}
}

