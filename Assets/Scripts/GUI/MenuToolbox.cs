using UnityEngine;
using System.Collections;


public class MenuToolbox : MonoBehaviour
{
	public GameObject crosshairObj;
	public static GameObject crosshair;

	void Start()
	{
		crosshair = crosshairObj;
	}
}

