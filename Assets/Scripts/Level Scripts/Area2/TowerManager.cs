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

		A2Toolbox._towerB.AddLevel(levelScrBot);

		levelScrMid.index = 1;
		A2Toolbox._towerB.AddLevel(levelScrMid);

		levelScrTop.index = 0;
		A2Toolbox._towerB.AddLevel(levelScrTop);
	}
}

