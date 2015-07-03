using UnityEngine;
using System.Collections;

public class ApplyButton : MonoBehaviour
{
	public GameObject fullScreenToggleObj;
	public FullScreenToggle fullScreenToggle;
	public GameObject resOptionsObj;
	public GameObject mouseSenObj;
	public GameObject savedSettingsObj;
	public ResolutionOption resOption;
	public MouseSensitivity mouseSen;

	void Start()
	{
		resOption = resOptionsObj.GetComponent<ResolutionOption>();
		mouseSen = mouseSenObj.GetComponent<MouseSensitivity>();
		fullScreenToggle = fullScreenToggleObj.GetComponent<FullScreenToggle>();
	}

	public void ChangeResolution()
	{
		Screen.SetResolution(resOption.resolutions[resOption.ResIndex].width, 
		                    			resOption.resolutions[resOption.ResIndex].height, 
		                     			fullScreenToggle.getIsFullScreen());

		SavedSettings.mouseSensitivity = mouseSen.sensitivityNum[mouseSen.SensitivityIndex];
	}
}

