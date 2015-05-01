using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
	public enum TowerLetter { A = 0, B, C }
	public TowerLetter towerLetter;
//	public List<KeyValuePair<int, Level>> Levels = new List<KeyValuePair<int, Level>>();
//	public List<KeyValuePair<int, Level>> CurLevels = new List<KeyValuePair<int, Level>>();
	public Stack Levels = new Stack();
	public IEnumerable<int> noDupes;
	public Node[] node;
	public int Index { get; set; }	

	void Start()
	{
		node = transform.GetComponentsInChildren<Node>();
	}

	void Update()
	{
		if(towerLetter == TowerLetter.A)
		{
			if(Levels.Count != 0)
				getTopLevel().MoveToTower();
		}

		else if(towerLetter == TowerLetter.B)
		{
			if(Levels.Count != 0)
				getTopLevel().MoveToTower();
		}

		else if(towerLetter == TowerLetter.C)
		{
			if(Levels.Count != 0)
				getTopLevel().MoveToTower();
		}
	}
	
	public bool IsEmpty()
	{
		return Levels.Count == 0;
	}

	public bool AllowLevel(Level level)
	{
		if(level == null)
		{
			return false;
		}

		if(Levels.Count == 0)
		{
			return true;
		}

		return getTopLevel().index > level.index;
	}

	public Level getTopLevel()
	{
		if(Levels.Count > 0)
		{
			return (Level)Levels.Peek();
		}

		return null;
	}

	public void RemoveLevel(Level level)
	{
		Levels.Pop();
	}

	public void AddLevel(Level level)
	{
		if(AllowLevel(level))
		{
			Levels.Push(level);
		}
	}    
}

