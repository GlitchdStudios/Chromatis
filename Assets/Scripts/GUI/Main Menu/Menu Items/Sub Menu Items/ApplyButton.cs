using UnityEngine;
using System.Collections;

public class ApplyButton : MonoBehaviour
{
	private FullScreenToggle fullScreenToggle;
	private ResolutionOption resolutionOption;

	public void ChangeResolution()
	{
		fullScreenToggle = new FullScreenToggle();
		resolutionOption = new ResolutionOption();

		Screen.SetResolution(resolutionOption.getWidth(), resolutionOption.getHeight(), fullScreenToggle.getIsFullScreen());
	}
}

