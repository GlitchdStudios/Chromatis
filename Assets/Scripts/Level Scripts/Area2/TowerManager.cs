using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour
{
	public GameObject levelTop;
	public GameObject levelMid;
	public GameObject levelBot;

	public static Level levelScrTop;
	public static Level levelScrMid;
	public static Level levelScrBot;

	// Use this for initialization
	void Start ()
	{
		levelScrTop = levelTop.GetComponentInChildren<Level>();
		levelScrMid = levelMid.GetComponentInChildren<Level>();
		levelScrBot = levelBot.GetComponentInChildren<Level>();

		Toolbox._towerB.AddLevel(levelScrBot);

		levelScrMid.Index--;
		Toolbox._towerB.AddLevel(levelScrMid);

		levelScrBot.Index--;
		Toolbox._towerB.AddLevel(levelScrTop);
	}
}

