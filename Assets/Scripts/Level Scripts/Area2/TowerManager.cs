using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour
{
	public GameObject levelTop;
	public GameObject levelMid;
	public GameObject levelBot;

	private Level levelScrTop;
	private Level levelScrMid;
	private Level levelScrBot;

	// Use this for initialization
	void Start ()
	{
		levelScrTop = levelTop.GetComponent<Level>();
		levelScrMid = levelMid.GetComponent<Level>();
		levelScrBot = levelBot.GetComponent<Level>();

		Toolbox._towerB.AddLevel(levelScrBot);

		levelScrMid.Index--;
		Toolbox._towerB.AddLevel(levelScrMid);

		levelScrBot.Index--;
		Toolbox._towerB.AddLevel(levelScrTop);
	}
}

