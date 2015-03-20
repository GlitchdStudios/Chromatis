using UnityEngine;
using System.Collections;

public class GeneralRotation : MonoBehaviour
{
	public Vector3 rotation;
	private Vector3 curRotation;
	void Update()
	{
		curRotation = this.transform.eulerAngles + rotation;
		this.transform.eulerAngles = curRotation;
	}
}

