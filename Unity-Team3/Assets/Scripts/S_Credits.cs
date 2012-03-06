using UnityEngine;
using System.Collections;

public class S_Credits : MonoBehaviour {
	
	public bool isBack = false;
	
	void OnMouseEnter()
	{	
		renderer.material.color = Color.red;
	
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.yellow;
	}
	
	void OnMouseDown()
	{
		if (isBack)
		{
			Application.LoadLevel("MainMenu");
		}

	}
}
