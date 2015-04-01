using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


public class ProGroups_Window : EditorWindow {
	
	static GroupContainer groupContainer;
	
	string guiPath = "Assets/ProCore/ProGroups/GUI/";
	public static string newGroupName = "New Group";

	Texture2D icon_Rect, icon_SnowFlake, icon_Eye, icon_Select, icon_UpdateGroup, icon_MoveUp, icon_Delete, icon_Gear, icon_Add, icon_MultiPlus;

	Texture2D freezeIcon;
	Texture2D visIcon;
	
	Vector2 scrollPos;
	bool modMode = false;
	// bool needsConnected = false;

	static EditorWindow window;

	[MenuItem("Tools/ProGroups/Open Progroups2 Window")]
	static void Init()
	{
		window = (ProGroups_Window)GetWindow (typeof(ProGroups_Window));
		window.Show();
		window.title = "ProGroups 2";
	}

	[MenuItem("Tools/ProGroups/New Group From Selection %g")]
	 static void NewGroupFromSelection()
	 {
		groupContainer.NewGroup(Selection.gameObjects, newGroupName);
		window.Repaint();
	 }

	void OnEnable()
	{
		window = (ProGroups_Window)GetWindow(typeof(ProGroups_Window));

		// needsConnected = true;

		icon_Rect = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_Rect.png");
		icon_SnowFlake = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_SnowFlake.png");
		icon_Eye = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_Eye.png");
		icon_Select = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_Select.png");
		icon_UpdateGroup = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_UpdateGroup.png");
		icon_MoveUp  = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_MoveUp.png");
		icon_Delete  = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_Delete.png");
		icon_Gear  = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_Gear.png");
		icon_Add  = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_Add.png");
		icon_MultiPlus = Resources.LoadAssetAtPath<Texture2D>(guiPath+"ProGroupsIcons_MultiPlus.png");
	}

	void OnDisable()
	{
		// needsConnected = true;
	}

	void Connect()
	{
		if(groupContainer == null)
		{
			if(GameObject.Find("_GroupContainer"))
			{
				groupContainer = GameObject.Find("_GroupContainer").GetComponent<GroupContainer>();
			}
			else
			{
				GameObject groupObj = new GameObject();
				groupObj.name = "_GroupContainer";
				groupObj.AddComponent<GroupContainer>();
				groupContainer = groupObj.GetComponent<GroupContainer>();

				HideFlags newHideFlags = HideFlags.NotEditable | HideFlags.HideInHierarchy;
				groupObj.hideFlags = newHideFlags;
			}
		}

		// needsConnected = false;

		EditorWindow windowMe = GetWindow(typeof(ProGroups_Window));
		windowMe.Repaint();

	}

	//GUI
	void OnGUI()
	{
		if(!groupContainer)
		{
			Connect();
		}

		GUIStyle iconButtonStyle = new GUIStyle(GUI.skin.button);
		iconButtonStyle.stretchWidth = false;
		iconButtonStyle.margin = new RectOffset(2,2,1,1);
		iconButtonStyle.padding.left = 1;
		iconButtonStyle.padding.right = 1;
		iconButtonStyle.normal.background = null;
		iconButtonStyle.hover.background = null;
		iconButtonStyle.active.background = null;
		iconButtonStyle.focused.background = null;
		iconButtonStyle.onNormal.background = null;
		iconButtonStyle.onHover.background = null;
		iconButtonStyle.onActive.background = null;
		iconButtonStyle.onFocused.background = null;

		EditorGUILayout.BeginHorizontal();
		if(!modMode)
		{
			newGroupName = EditorGUILayout.TextField(newGroupName);
			if(newGroupName == "")
				newGroupName = "New Group";

			if(GUILayout.Button(new GUIContent(icon_Add, "Create New Group from Selected Objects"), iconButtonStyle))
			{
				GUIUtility.keyboardControl = 0;
				NewGroupFromSelection();
				window.Repaint();
			}

			if(GUILayout.Button (new GUIContent(icon_Gear, "Modify Groups"), iconButtonStyle))
			{
				modMode = true;
			}
			
		}
		else
		{
			if(GUILayout.Button("Done"))
			{
				modMode = false;
//				string modBtnText = "Modify";
			}
		}

		EditorGUILayout.EndHorizontal();

		if(groupContainer.sceneGroups != null)
		{
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
			EditorGUILayout.BeginVertical();

			int i = 0;
			foreach(Group group in groupContainer.sceneGroups)
			{
				if(group.frozen)
					freezeIcon = icon_SnowFlake;
				else
					freezeIcon = icon_Rect;

				if(group.hidden)
					visIcon = icon_Rect;
				else
					visIcon = icon_Eye;

				EditorGUILayout.BeginHorizontal();

				if(modMode)
				{
					//move up
					if(i != 0)
					{
						if(GUILayout.Button(new GUIContent(icon_MoveUp, "Move Group Up"), iconButtonStyle))
						{
							GUIUtility.keyboardControl = 0;
							groupContainer.MoveGroupUp(i);
							window.Repaint();
						}
					}

					//delete
					if(GUILayout.Button(new GUIContent(icon_Delete, "Remove Group (NOT Objects!"), iconButtonStyle))
					{
						if(EditorUtility.DisplayDialog("Remove This Group?", "All objects from the group will become visable and un-frozen. No objects will be deleted.", "Confirm","Cancel"))
						{
							GUIUtility.keyboardControl = 0;
							groupContainer.RemoveGroup(i);
							window.Repaint();
						}
					}

					//add selected to group
					if(GUILayout.Button(new GUIContent(icon_MultiPlus, "Add Selected Objects to this Group"), iconButtonStyle))
					{
						GUIUtility.keyboardControl = 0;
						AddSelectedToGroup(group);
						window.Repaint();
					}

					//update
					if(GUILayout.Button(new GUIContent(icon_UpdateGroup, "Rebuild Group from Selection"), iconButtonStyle))
					{
						if(EditorUtility.DisplayDialog("Replace Objects in the Group With Selected Objects", "Note: all objects from the old group will become visable and un-frozen.", "Confirm", "Cancel"))
						{
							GUIUtility.keyboardControl = 0;
							groupContainer.UpdateGroup(group, Selection.gameObjects);
							if(window != null)
								window.Repaint();
						}
					}

					//group name
					group.name = EditorGUILayout.TextField(group.name);

				}
				else
				{
					//select
					if(GUILayout.Button(new GUIContent(icon_Select, "Select Group Objects"), iconButtonStyle))
					{
						GUIUtility.keyboardControl = 0;
						SelectGroup(group);
					}
					
					//vis toggle
					if(GUILayout.Button(visIcon, iconButtonStyle))
					{
						if(Event.current.alt)
						{
							groupContainer.Isolate(i);
						}
						else
						{
							groupContainer.ToggleVis(group);
						}
						
						GUIUtility.keyboardControl = 0;
					}
					
					//freeze toggle
					if(GUILayout.Button(freezeIcon, iconButtonStyle))
					{
						GUIUtility.keyboardControl = 0;
						groupContainer.ToggleFreeze(group);
					}
					
					//group name
					GUILayout.Label(group.name);
				}
				
				i++;
				EditorGUILayout.EndHorizontal();
		}

		EditorGUILayout.EndVertical();
		EditorGUILayout.EndScrollView();

	}
}
	
	void SelectGroup(Group theGroup)
	{
		bool foundIssue = false;
		bool continueCheck = true;
		bool continueSelect = true;

		foreach(GameObject obj in theGroup.objects)
		{
			if(continueCheck)
			{
			#if UNITY_3_5
				if(!obj.active || obj.hideFlags == HideFlags.NotEditable)
					foundIssue = true;
			#else
				if(!obj.activeSelf || obj.hideFlags == HideFlags.NotEditable)
					foundIssue = true;
			#endif
				if(foundIssue)
				{
					continueCheck = false;
					if(!EditorUtility.DisplayDialog("Warning! Some Objects in this Group are Frozen or Hidden.", "You should probably un-hide and un-freeze the objects in this group first", "Select Anyway", "Cancel Selection"))
					{
						continueSelect = false;
						Selection.objects = new UnityEngine.Object[0];
					}
				}

			}
		}

		if(continueSelect)
		{
			List<GameObject> tempSelectionList = new List<GameObject>();

			foreach(GameObject obj in theGroup.objects)
			{
				tempSelectionList.Add (obj);
			}

			Selection.objects = tempSelectionList.ToArray();
		}
	}

	void AddSelectedToGroup(Group theGroup)
	{
		List<GameObject> tempSelectionList = new List<GameObject>();

		foreach(GameObject obj in theGroup.objects)
		{
			tempSelectionList.Add (obj);
		}
		foreach(GameObject obj in Selection.gameObjects)
		{
			tempSelectionList.Add(obj);
		}

		Selection.objects = tempSelectionList.ToArray();

		groupContainer.UpdateGroup(theGroup, Selection.gameObjects);

	}

}