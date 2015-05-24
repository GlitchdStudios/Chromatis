using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
	private DataSphere[] dataSpheres;

	void Start()
	{
		dataSpheres = FindObjectsOfType(typeof(DataSphere)) as DataSphere[];
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			Toolbox.chromaState = Toolbox.initChromaState;
			Toolbox.chroma[(int)Toolbox.chromaState].SetActive(true);

			if(!Toolbox.isControlable)
			{
				InitDataSpheresOnDeath();
			}

			InitPlatformsOnDeath();
			A1Toolbox.playerScr.InitPlayer();
		}

		if(col.tag == "DataSphere")
		{
			InitDataSpheresOnDeath();
		}
	}


	private void InitDataSpheresOnDeath()
	{
		foreach(DataSphere dataSphere in dataSpheres)
		{
			dataSphere.GetComponent<Rigidbody>().Sleep();
			dataSphere.transform.position = dataSphere.initPos;
			dataSphere.SetupDataSphere(dataSphere.initChroma);
			Toolbox.isControlable = true;
		}
	}
	private void InitPlatformsOnDeath()
	{
		foreach(Platform platform in Toolbox.platforms)
		{
			platform.GetComponent<Platform>().InitPlatform();
		}
	}
}

