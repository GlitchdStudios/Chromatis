using UnityEngine;
using System.Collections;

public class ApplyButton : MonoBehaviour
{
	public FullScreenToggle fullScreenToggle;
	public GameObject resOptionsObj;
	public ResolutionOption resOption;

	void Start()
	{
		resOption = resOptionsObj.GetComponent<ResolutionOption>();
		fullScreenToggle = new FullScreenToggle();
	}

	public void ChangeResolution()
	{
		Screen.SetResolution(resOption.resolutions[resOption.ResIndex].width, 
		                    			resOption.resolutions[resOption.ResIndex].height, 
		                     			fullScreenToggle.getIsFullScreen());
	}
}

