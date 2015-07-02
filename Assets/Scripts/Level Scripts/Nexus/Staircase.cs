using UnityEngine;
using System.Collections;

public class Staircase : MonoBehaviour
{
	public Stair[] stairs;

	// Use this for initialization
	void Start ()
	{
		stairs = GetComponentsInChildren<Stair>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		for(int i = 0; i < stairs.Length; i++)
		{
			stairs[i].MoveStair(0.2f, 1f);
      		}
	}

}

