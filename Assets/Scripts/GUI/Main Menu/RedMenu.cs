using UnityEngine;
using System.Collections;

public enum RedMenuState  { LOADING = 0 }  

public class RedMenu : MonoBehaviour
{
	private GameObject[] redOptions;
	private RedMenuState redMenuState;
	void Start()
	{
		redOptions = GameObject.FindGameObjectsWithTag("RedOption");
	}
	
	// Update is called once per frame
	void Update ()
	{	
		for(int i = 0; i < redOptions.Length; i++)
		{
			if((int)redMenuState != i)
			{
				if(redOptions[i].activeSelf)
				{
					redOptions[i].SetActive(false);
				}
			}
		}
	}
	
	public void ChangeOptions(RedMenuState m_redMenuState)
	{
		redMenuState = m_redMenuState;
		redOptions[(int)redMenuState].SetActive(true);
	}

}