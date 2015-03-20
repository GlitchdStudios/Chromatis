using UnityEngine;
using System.Collections;

public class PlatformDetach : MonoBehaviour
{	
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			col.transform.parent = null;
		}
	}
}

