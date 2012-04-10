using UnityEngine;
using System.Collections;

public class S_Store : MonoBehaviour {

	public bool isBack = false;
	public bool isAmmo = false;
	public bool isLives = false;
	public bool isGun1 = false;
	public bool isnextLevel = false;
	void OnMouseOver()
	{
		renderer.material.color = Color.red;
	
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.blue;
	}
	
	void OnMouseDown()
	{
		if (isBack)
		{
			Application.LoadLevel("MainMenu");
		}
		else if (isAmmo)
		{
			//code to increase ammo
		}
		else if (isLives)
		{
			//code to increase lives
		}
		else if (isnextLevel)
		{
			LoadLevel();
		}
		else if (isGun1)
		{
			//code to buy new gun
		}
	}
	
	public static bool LoadLevel()
	{
		//code to load level 2
			S_Player.currentlevel += 1;
			Application.LoadLevel("Level" + S_Player.currentlevel);
			return true;
	}
}
