using UnityEngine;
using System.Collections;

public class EndNavigation : MonoBehaviour
{
	public string level;

	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
	}

	public void ReturnToMainMenu()
	{
		Application.LoadLevelAsync(level);
	}

	public void Exit()
	{
		Application.Quit();
	}
}

