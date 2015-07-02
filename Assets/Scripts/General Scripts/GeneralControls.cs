using UnityEngine;
using System.Collections;

public class GeneralControls : MonoBehaviour
{
	public GameObject menuPlate;

	void Start()
	{
		menuPlate.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{
		OpenMenu();
	}

	public void OpenMenu()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			menuPlate.SetActive(true);
			MenuToolbox.crosshair.SetActive(false);
			Cursor.visible = true;
			Camera.main.GetComponent<MouseLook>().MenuIsUp = true;
		}
	}

	#if UNITY_EDITOR
	void LateUpdate()
	{
		if(!menuPlate.activeSelf)
			Cursor.lockState = CursorLockMode.Locked;
	}
	#endif
	
	void OnApplicationFocus()
	{
		Cursor.lockState = CursorLockMode.Confined;
	}
}

