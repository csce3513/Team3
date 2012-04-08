using UnityEngine;
using System.Collections;

public class HeroMenu : MonoBehaviour {

	public bool isBack = false;
	public bool isHero1 = false;
	public bool isHero2 = false;
	public bool isHero3 = false;
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
		if (isBack)
		{
			Application.LoadLevel("MainMenu");
		}
		else if (isHero1)
		{
			Application.LoadLevel("Hero_1");
		}
		else if (isHero2)
		{
			Application.LoadLevel("Hero_2");
		}
		else if (isHero3)
		{
			Application.LoadLevel("Hero_3");
		}
	}
}

