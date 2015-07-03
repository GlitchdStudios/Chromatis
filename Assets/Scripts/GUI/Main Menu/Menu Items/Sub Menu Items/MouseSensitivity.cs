using UnityEngine;
using System.Collections;

public class MouseSensitivity : MonoBehaviour
{
	public int[] sensitivityNum;
	private TextMesh textMesh;

	void Start()
	{
		for(int i = 0; i < sensitivityNum.Length; i++)
		{
			sensitivityNum[i] = i + 1;
		}

		SensitivityIndex = 4;
		textMesh = gameObject.GetComponent<TextMesh>();
		textMesh.text = sensitivityNum[SensitivityIndex].ToString();
		SavedSettings.mouseSensitivity = sensitivityNum[SensitivityIndex];
	}
	
	public int SensitivityIndex { get; set; }
}

