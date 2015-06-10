using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	private bool isLoading;
	private GameObject loadingPlate;

	void Awake()
	{
		Object.DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start ()
	{
		loadingPlate = gameObject;
		loadingPlate.SetActive(false);
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
			loadingPlate.SetActive(true);
		}

		else if(!isLoading)
		{
			loadingPlate.SetActive(false);
		}
	}
}

