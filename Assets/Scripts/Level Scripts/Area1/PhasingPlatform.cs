using UnityEngine;
using System.Collections;

public class PhasingPlatform : MonoBehaviour
{
	private Renderer thisRenderer;
	public Material blueMat;
	public Material redMat;

	// Use this for initialization
	void Start ()
	{
		thisRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine(Phase());
	}

	public IEnumerator Phase()
	{
		yield return new WaitForSeconds(0.5f);
		thisRenderer.material = redMat;
	}
}

