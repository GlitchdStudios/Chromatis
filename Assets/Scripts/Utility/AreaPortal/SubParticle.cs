using UnityEngine;
using System.Collections;

public class SubParticle : MonoBehaviour
{
	private AsyncOperation asyncOp;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			StartCoroutine(LoadEnd());
		}
	}

	private IEnumerator LoadEnd()
	{
		asyncOp = Application.LoadLevelAsync("DemoEnd");
		yield return asyncOp;
	}
}

