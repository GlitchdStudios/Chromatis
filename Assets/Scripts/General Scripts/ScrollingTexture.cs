using UnityEngine;
using System.Collections;

public class ScrollingTexture : MonoBehaviour
{
	public Vector2 scrollSpeed;
	
	void FixedUpdate()	
	{
		Vector2 offset = Time.time * scrollSpeed;
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}

