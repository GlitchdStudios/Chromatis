using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Level : BaseLevel
{
	public int index;
	public enum DestTower {NO_MOVEMENT = -1, A = 0, B, C }
	public enum NodeControl { ZERO = 0, ONE}
	public DestTower levelTo;
	public DestTower levelFrom;
	public NodeControl nodeControl;
	public float speed;
	
	public Tower FromTower { get; set; }
	public Tower ToTower { get; set; }
	public int towerKey;
	public int i;
	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		platformSwitch = GetComponentsInChildren<Switch>();
//		for(int i=0; i < node.Length; i++)
//		{
//			node[i].GetComponent<Renderer>().enabled = false;
//		}

		initPlatformPos = thisTransform.position;
		index = 2;
		levelFrom = DestTower.B;
		nodeControl = NodeControl.ZERO;
		i = 0;
	}

	public override void InitPlatform()
	{
		levelTo = DestTower.NO_MOVEMENT;
		thisTransform.position = initPlatformPos;
		for(int i = 0; i < platformSwitch.Length; i++)
		{
			if(platformSwitch[i].IsActive)
			{
				platformSwitch[i].ToggleState();
			}
		}
	}

	public Tower FindCurTower(DestTower curTower)
	{
		switch(curTower)
		{
		case DestTower.A:
			FromTower = Toolbox._towerA;
			break;

		case DestTower.B:
			FromTower = Toolbox._towerB;
			break;

		case DestTower.C:
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
			if(IsValid(FindCurTower(levelFrom), Toolbox._towerA))
			{
				levelFrom = levelTo;
				ToTower = Toolbox._towerA;

				levelTo = DestTower.A;
			}
			break;
			
		case "SwitchB":
			if(IsValid(FindCurTower(levelFrom), Toolbox._towerB))
			{
				levelFrom = levelTo;
				ToTower = Toolbox._towerB;
				levelTo = DestTower.B;
			}
			break;

		case "SwitchC":
			if(IsValid(FindCurTower(levelFrom), Toolbox._towerC))
			{
				levelFrom = levelTo;
				ToTower = Toolbox._towerC;
				levelTo = DestTower.C;
			}
			break;
		}
	}

	public void MoveToTower() 
	{
		if(levelTo != DestTower.NO_MOVEMENT && FromTower != null && ToTower != null)
		{
			if(FromTower.getTopLevel() == this && ToTower.AllowLevel(this))
			{
				if(ToTower.Levels.Count > 0)
				{
					towerKey = ToTower.Levels.Count;
				}

				if(nodeControl == NodeControl.ZERO)
				{
					if(thisTransform.position != FromTower.node[0].transform.position)
						FromTower.node[0].MoveToNodeWorld(thisTransform, FromTower.node[0].transform, speed * Time.deltaTime);
					else
					{
						nodeControl = NodeControl.ONE;
					}
				}

				else if(nodeControl == NodeControl.ONE)
				{
					if(ToTower.node[i] != null)
					{
						if(thisTransform.position != ToTower.node[i].transform.position)
						{
							ToTower.node[i].MoveToNodeWorld(thisTransform, ToTower.node[i].transform, speed * Time.deltaTime);
						}
						else
						{
							i++;
						}
						if(thisTransform.position == ToTower.node[3 - towerKey].transform.position)
						{
							i = 0;
							nodeControl = NodeControl.ZERO;
							levelFrom = levelTo;
							FromTower.RemoveLevel(this);
							ToTower.AddLevel(this);
							towerKey = 0;
						}
					}
				}
			}
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

