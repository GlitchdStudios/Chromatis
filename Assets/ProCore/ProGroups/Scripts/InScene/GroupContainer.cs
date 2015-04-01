using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Group
{
	public string name;
	public List<GameObject> objects;
	public bool frozen;
	public bool hidden;
}


public class GroupContainer : MonoBehaviour
{
	public List<Group> sceneGroups;

	public void NewGroup(GameObject[] theObjects, string newGroupName)
	{
		Group newGroup = new Group();
		newGroup.name  = newGroupName;
		newGroup.objects = new List<GameObject>(theObjects);
		newGroup.frozen = false;
		newGroup.hidden = false;

		if(sceneGroups != null)
		{
			List<Group> tempGroups = sceneGroups;
			tempGroups.Add(newGroup);
			sceneGroups = tempGroups;
		}
		else
		{
			sceneGroups = new List<Group>();
			sceneGroups.Add(newGroup);
		}
	}

	public void ToggleFreeze(Group theGroup)
	{
		CleanGroup(theGroup);

		theGroup.frozen = !theGroup.frozen;

		foreach(GameObject obj in theGroup.objects)
		{
			if(theGroup.frozen)	
				obj.hideFlags = HideFlags.NotEditable;
			else
				if(!theGroup.hidden)
					obj.hideFlags = 0;
		}
	}

	public void ToggleVis(Group theGroup)
	{
		if(theGroup.hidden)
			ShowGroup(theGroup);
		else
			HideGroup(theGroup);
	}
	
	public void HideGroup(Group theGroup)
	{
		CleanGroup(theGroup);

		foreach(GameObject obj in theGroup.objects)
		{
			obj.hideFlags = HideFlags.NotEditable;

		#if UNITY_3_5
			obj.active = false;
		#else
			obj.SetActive(false);
		#endif
		}

		theGroup.hidden = true;
	}

	public void ShowGroup(Group theGroup)
	{
		CleanGroup (theGroup);

		foreach(GameObject obj in theGroup.objects)
		{
			if(!theGroup.frozen)
				obj.hideFlags = 0;
		#if UNITY_3_5
			obj.active = true;
		#else
			obj.SetActive(true);
		#endif

		}

		theGroup.hidden = false;
	}

	public void Isolate(int i )
	{
		for(int j = 0; j < sceneGroups.Count; j++)
		{
			if(j != i)
			{
				HideGroup(sceneGroups[j]);
			}
		}

		ShowGroup(sceneGroups[i]);
	}

	public void RemoveGroup(int i )
	{
		CleanGroup(sceneGroups[i]);

		foreach(GameObject obj in sceneGroups[i].objects)
		{
		#if UNITY_3_5
			obj.active = true;
		#else
			obj.SetActive(true);
		#endif
			obj.hideFlags = 0;
		}

		List<Group> tempGroup = sceneGroups;
		tempGroup.RemoveAt(i);
		sceneGroups = tempGroup;
	}

	public void UpdateGroup(Group theGroup, GameObject[] objects)
	{
		CleanGroup(theGroup);

		foreach(GameObject obj in theGroup.objects)
		{
		#if UNITY_3_5
			obj.active = true;
		#else
			obj.SetActive(true);
		#endif
			obj.hideFlags = 0;
		}

		theGroup.objects = new List<GameObject>(objects);

		theGroup.hidden = false;
		theGroup.frozen = false;
	}

	public void MoveGroupUp(int shiftIndex)
	{
		List<Group> tempGroups = sceneGroups;

		for(int i = 0; i < shiftIndex-1; i ++)
		{
			if(i != shiftIndex)
			{
				tempGroups.Add(sceneGroups[i]);
			}
		}

		sceneGroups = tempGroups;
	}

	public void CleanGroup(Group theGroup)
	{
		List<GameObject> tempObjects = new List<GameObject>();

		foreach(GameObject obj in theGroup.objects)
		{
			if(obj != null)
				tempObjects.Add(obj);
		}

		theGroup.objects = tempObjects;
	}
}