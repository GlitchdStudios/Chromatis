using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
	public GameObject optionObj;
	public TextMesh textMesh;
	// Use this for initialization
	void Start ()
	{
		textMesh = optionObj.GetComponent<TextMesh>();
	}
}

