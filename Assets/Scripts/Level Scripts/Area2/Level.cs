using UnityEngine;
using System.Collections;

public class Level : Platform
{
	public int Index { get; set; }
	public enum LevelMovement {NO_MOVEMENT = -1, A = 0, B, C }
	
	public LevelMovement levelTo;
	public LevelMovement levelFrom;
	public float speed;

	public Tower ToTower { get; set; }
	public Tower FromTower { get; set; }

	public int i;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		platformSwitch = GetComponentsInChildren<Switch>();
		node = thisTransform.parent.GetComponentsInChildren<Node>();
//		for(int i=0; i < node.Length; i++)
//		{
//			node[i].GetComponent<Renderer>().enabled = false;
//		}
		levelTo = LevelMovement.A;
		initPlatformPos = thisTransform.position;
		Index = 2;
	}
	
	void Update()
	{
		MoveToTower();
	}
	
	public override void InitPlatform()
	{
		levelTo = LevelMovement.NO_MOVEMENT;
		thisTransform.position = initPlatformPos;
		for(int i = 0; i < platformSwitch.Length; i++)
		{
			if(platformSwitch[i].IsActive)
			{
				platformSwitch[i].ToggleState();
			}
		}
	}

	public Tower FindCurTower(LevelMovement curTower)
	{
		switch(curTower)
		{
		case LevelMovement.A:
			FromTower = Toolbox._towerA;
			break;

		case LevelMovement.B:
			FromTower = Toolbox._towerB;
			break;

		case LevelMovement.C:
			FromTower = Toolbox._towerC;
			break;
		}

		return FromTower;
	}
	public override void SetDirection(Switch _switch) 
	{
		switch(_switch.name)
		{
		case "SwitchA":
			levelFrom = levelTo;
			if(IsValid(FindCurTower(levelFrom), Toolbox._towerA))
			{
				levelTo = LevelMovement.A;
			}
			break;
			
		case "SwitchB":
			levelFrom = levelTo;
			if(IsValid(FindCurTower(levelFrom), Toolbox._towerB))
			{

				levelTo = LevelMovement.B;
			}
			break;

		case "SwitchC":
			levelFrom = levelTo;
			if(IsValid(FindCurTower(levelFrom), Toolbox._towerC))
			{
				levelTo = LevelMovement.C;
			}
			break;
		}
	}

	public void MoveToTower() 
	{
		if(levelTo != LevelMovement.NO_MOVEMENT)
		{
			if(thisTransform.localPosition == node[(int)levelTo + i].transform.localPosition)
			{
				i++;
			}

			node[(int)levelTo + i].MoveToNode(thisTransform, node[(int)levelTo + i].transform, speed * Time.deltaTime);	
			Debug.Log(levelTo);
		} 
	}

	public bool IsValid(Tower from, Tower to)
	{
		for(int i = 0; i < Toolbox.towers.Length; i++)
		{
			if(Toolbox.towers[i] == from)
			{
				if(Toolbox.towers[i] == to)
				{
					return false;
				}
			}
		}

		return to.AllowLevel(from.getTopLevel());
	}
}

