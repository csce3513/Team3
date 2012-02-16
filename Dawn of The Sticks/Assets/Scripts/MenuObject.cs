using UnityEngine;
using System.Collections;

public class MenuObject : MonoBehaviour {
	
	public bool isQuit = false;
	public bool isHighScore = false;
	public bool isStartGame = false;
	public bool isCredits = false;
	public bool isSound = false;
	
	void OnMouseEnter()
	{
		renderer.material.color = Color.red;
	
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown()
	{
		if (isQuit)
		{
			Application.Quit();
		}
		else if (isHighScore)
		{
			//Application.LoadLevel("HighScore");
		}
		
		else if (isStartGame)
		{
			Application.LoadLevel("Hero_Selection");
			
		}
		
		else if (isCredits)
		{
			Application.LoadLevel("Credits");
		}
	}
}
