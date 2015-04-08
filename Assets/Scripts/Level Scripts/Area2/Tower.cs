using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
	public SortedList<int, Level> Levels = new SortedList<int, Level>();
	public int Index { get; set; }	

	void Update()
	{
		Debug.Log(Levels.Count);
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

		return getTopLevel().Index > level.Index;
	}

	public Level getTopLevel()
	{
		if(Levels.Count > 0)
		{
			return Levels.First().Value;
		}

		return null;
	}

	public void RemoveLevel()
	{
		Levels.Remove(Levels.First().Key);
	}

	public void AddLevel(Level level)
	{
		if(AllowLevel(level))
		{
			Levels.Add(level.Index, level);
		}
	}    
}

