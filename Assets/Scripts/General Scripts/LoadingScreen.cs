using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	private bool isLoading;
	public Canvas canvas;

	void Awake()
	{
		Object.DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start ()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		isLoading = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Application.isLoadingLevel)
		{
			if(!isLoading)
				isLoading = true;
		}
		else if(!Application.isLoadingLevel)
		{
			if(isLoading)
				isLoading = false;
		}

		if(isLoading)
		{
			canvas.enabled = true;
		}

		else if(!isLoading)
		{
			canvas.enabled = false;
		}
	}
}

