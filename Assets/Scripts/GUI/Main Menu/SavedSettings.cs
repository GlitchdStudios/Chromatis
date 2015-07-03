using UnityEngine;
using System.Collections;

public class SavedSettings : MonoBehaviour
{
	public static int mouseSensitivity;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}

}

