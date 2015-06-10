using UnityEngine;
using System.Collections;

public class Chromas : MonoBehaviour
{
	void Start()
	{
		Toolbox.chroma = GameObject.FindGameObjectsWithTag("Chroma");
		Toolbox.initChromaState = ChromaState.BLUE;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		for(int i = 0; i < Toolbox.chroma.Length; i++)
		{
			if((int)Toolbox.chromaState != i)
			{
				if(Toolbox.chroma[i].activeSelf)
				{
					Toolbox.chroma[i].SetActive(false);
				}
			}
		}
	}

	public void ChangeChromaBlue()
	{
		Toolbox.chromaState = ChromaState.BLUE;
		Toolbox.chroma[(int)ChromaState.BLUE].SetActive(true);
	}

	public void ChangeChromaRed()
	{
		Toolbox.chromaState = ChromaState.RED;
		Toolbox.chroma[(int)ChromaState.RED].SetActive(true);
	}
}

