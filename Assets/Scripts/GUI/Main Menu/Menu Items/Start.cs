using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour 
{
	AsyncOperation asyncOp;

	public void StartDemo()
	{
		StartCoroutine(DelayLoad());
	}

	private IEnumerator DelayLoad()
	{
		asyncOp = Application.LoadLevelAsync("Area_01");
		yield return asyncOp;
	}
}

