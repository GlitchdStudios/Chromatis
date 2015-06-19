using UnityEngine;
using System.Collections;

public class URLButton : MonoBehaviour
{
	public string url;

	public void OpenWebpage()
	{
		Application.OpenURL(url);
	}
}

