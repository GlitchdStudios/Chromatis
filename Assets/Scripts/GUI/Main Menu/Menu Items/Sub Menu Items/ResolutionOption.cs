using UnityEngine;
using System.Collections;

public class ResolutionOption : MonoBehaviour
{
	private int m_width;
	private int m_height;

	public void SetResolutionValues(int width, int height)
	{
		m_width = width;
		m_height = height;
	}

	public int getWidth() { return m_width; }
	public int getHeight() { return m_height; }
}

