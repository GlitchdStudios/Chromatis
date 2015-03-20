using UnityEngine;
using System.Collections;

public class PlatformAttach : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			col.transform.parent = this.transform;
		}
	}
}

