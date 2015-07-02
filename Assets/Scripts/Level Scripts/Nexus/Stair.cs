using UnityEngine;
using System.Collections;

public class Stair : MonoBehaviour
{
	private Vector3 pos;

	// Use this for initialization
	void Start ()
	{
		pos = transform.position;
	}
	
	public void MoveStair(float yPos, float speed)
	{
		pos = Vector3.MoveTowards(pos, new Vector3(pos.x, 0.2f, pos.z), speed *Time.deltaTime);
	}
}

