using UnityEngine;
using System.Collections;

public class DataSphereSlot : Utility
{
	private DataSphere dataSphereScr;
	private Transform dataSphereTrans;
	private AudioSource dataSlotFilledClip;

	public Renderer dataSlotBars;
	public Renderer dataSlotPlates;
	public GameObject areaPortal;
	public ChromaState initChroma;

	public override bool ToggleState() { isActive = (isActive == true) ? false : true; return isActive; }
	public override void CheckState(bool _isActive) {}

	void Start()
	{
		dataSlotFilledClip = gameObject.GetComponent<AudioSource>();
	}

	public void ProcessData(DataState _dataState)
	{
		switch(_dataState)
		{
			case DataState.AREAPORTAL_DATA:
			areaPortal.GetComponent<CapsuleCollider>().enabled = true;
			break;
		}
	}

	private void InitDataSpheres(DataSphere _dataSphereScr)
	{	
		dataSphereScr.initPos = this.GetComponent<Collider>().bounds.center;
		dataSphereScr.SetupDataSphere(initChroma);
	}

	private void ShowDataSlot()
	{
		dataSlotBars.enabled = true;
		dataSlotPlates.enabled = true;
		gameObject.GetComponent<Animator>().Play("DataSlotRing");
	}

	public override bool IsActive { get { return isActive;} }

	//When receiving a triggerEnter from a DataSphere, Send data to the given slot.
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "DataSphere")
		{
			dataSphereTrans = col.transform;
			dataSphereScr = dataSphereTrans.GetComponent<DataSphere>();
			InitDataSpheres(dataSphereScr);
			A1Toolbox.playerScr.HitCheckpoint();
			ProcessData(dataSphereScr.GetDataState);
			ShowDataSlot();
			dataSphereScr.a.enableEmission = true;
			dataSphereScr.b.enableEmission = true;
			dataSlotFilledClip.Play();
			A1Toolbox.inDataSlot = true;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "DataSphere")
		{
			dataSphereTrans.position = this.GetComponent<Collider>().bounds.center;
		}
	}
}

