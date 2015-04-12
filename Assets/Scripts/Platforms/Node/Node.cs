using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
	public void MoveToNodeLocal(Transform platform, Transform node, float speed)
	{
		platform.localPosition = Vector3.MoveTowards(platform.localPosition, node.localPosition, speed);
	}
	public void MoveToNodeWorld(Transform platform, Transform node, float speed)
	{
		platform.position = Vector3.MoveTowards(platform.position, node.position, speed);
	}

	public void RotateToNode(Transform platform, Transform node, float speed)
	{
		platform.rotation = Quaternion.RotateTowards(platform.rotation, node.rotation, speed * Time.deltaTime);
	}
}

