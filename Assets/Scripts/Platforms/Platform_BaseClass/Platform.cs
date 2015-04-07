using UnityEngine;
using System.Collections;

public abstract class Platform : MonoBehaviour
{
	protected Transform thisTransform;
	protected Node[] node;

	public Vector3 initPlatformPos;
	public Switch[] platformSwitch;

	abstract public void SetDirection(Switch _switch); 
	abstract public void InitPlatform();
}

