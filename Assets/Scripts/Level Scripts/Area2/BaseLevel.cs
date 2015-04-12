using UnityEngine;
using System.Collections;

public abstract class BaseLevel : MonoBehaviour
{
	protected Transform thisTransform;
	
	public Vector3 initPlatformPos;
	public Switch[] platformSwitch;
	
	abstract public void SetDirection(Switch _switch); 
	abstract public void InitPlatform();
}

