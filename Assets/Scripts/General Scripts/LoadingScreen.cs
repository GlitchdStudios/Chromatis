using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	private Image image;
	public Sprite loadingImage;

	void Awake()
	{
		Object.DontDestroyOnLoad(this);
		Object.DontDestroyOnLoad(transform.parent);
	}
	// Use this for initialization
	void Start ()
	{
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Application.isLoadingLevel)
		{
			image.sprite = loadingImage;
		}
	}
}

