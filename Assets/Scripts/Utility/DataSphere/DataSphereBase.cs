using UnityEngine;
using System.Collections;

public class DataSphereBase : MonoBehaviour
{
	private enum ParticleObject { HOVER = 0, BARRIER }
	private Rigidbody dataSphere;
	public ParticleSystem barrierParticle;

	void OnTriggerEnter(Collider col)
	{
		if(col.name == "DataSphere")
		{
			dataSphere = col.GetComponent<Rigidbody>();
			dataSphere.useGravity = false;
			dataSphere.Sleep();
			barrierParticle.Play();
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.name == "DataSphere")
		{
			col.GetComponent<Rigidbody>().useGravity = true;
			barrierParticle.Stop();
		}
	}
}

