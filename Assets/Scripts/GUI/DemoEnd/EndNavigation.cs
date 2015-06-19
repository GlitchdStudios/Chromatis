using UnityEngine;
using System.Collections;

public class EndNavigation : MonoBehaviour
{
	public string level;

	public void ReturnToMainMenu()
	{
		Application.LoadLevelAsync(level);
	}

	public void Exit()
	{
		Application.Quit();
	}
}

