using UnityEngine;
using System.Collections;

public class ResolutionOption : MonoBehaviour
{
	public Resolution[] resolutions;
	public Texture[] resImages;

	void Start()
	{
		resolutions = Screen.resolutions;
	}

	public int ResIndex { get; set; }
}

