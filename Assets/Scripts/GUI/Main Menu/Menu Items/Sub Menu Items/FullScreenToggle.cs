using UnityEngine;
using System.Collections;

public class FullScreenToggle : MonoBehaviour
{
	private bool isFullScreen;

	public void ToggleFullScreen() { isFullScreen = (isFullScreen == true) ? false : true;  }
	public bool getIsFullScreen() { return isFullScreen; }
}

