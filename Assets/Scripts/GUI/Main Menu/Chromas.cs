using UnityEngine;
using System.Collections;

public class Chromas : MonoBehaviour
{
	private ChromaState chromaState;
	private GameObject[] chroma;

	void Start()
	{
		chroma = GameObject.FindGameObjectsWithTag("Chroma");
		chromaState = ChromaState.BLUE;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		for(int i = 0; i < chroma.Length; i++)
		{
			if((int)chromaState != i)
			{
				if(chroma[i].activeSelf)
				{
					chroma[i].SetActive(false);
				}
			}
		}
	}

	public void ChangeChroma(ChromaState m_chromaState)
	{
		chromaState = m_chromaState;
		chroma[(int)m_chromaState].SetActive(true);
	}
}

