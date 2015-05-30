using UnityEngine;
using System.Collections;

public enum DataState { EMPTY = 0, CORRUPTED_DATA, BACKDOOR_DATA, AREAPORTAL_DATA }

public class DataSphere : Utility
{
	private DataState dataState;

	public DataState thisDataState;
	public ChromaState initChroma;
	public Vector3 initPos;
	public ParticleSystem a;
	public ParticleSystem b;

	// Use this for initialization
	void Start ()
	{
		dataState = thisDataState;
		initPos = this.transform.position;
		initChroma = ChromaState.RED;
	}

	public void SetupDataSphere(ChromaState _chromaSlotState)
	{
		initChroma = _chromaSlotState;
		this.transform.parent = Toolbox.chroma[(int)initChroma].transform;
	}

	public override bool ToggleState() { isActive = (isActive == true) ? false : true; return isActive; }
	public override void CheckState(bool _isActive) {}
	//Accessors
	public override bool IsActive { get { return isActive;} } 
	public DataState GetDataState { get { return dataState; } }
}

