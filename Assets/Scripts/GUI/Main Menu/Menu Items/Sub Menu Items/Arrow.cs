using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
	public GameObject resOptionObj;
	public TextMesh textMesh;
	// Use this for initialization
	void Start ()
	{
		textMesh = resOptionObj.GetComponent<TextMesh>();
	}
}

