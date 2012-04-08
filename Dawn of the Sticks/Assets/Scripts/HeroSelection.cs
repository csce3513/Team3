using UnityEngine;
using System.Collections;

public class HeroSelection : MonoBehaviour {
	public GameObject Hero1;
	public GameObject Hero2;
	public GameObject Hero3;
	public static GameObject StHero1;
	public static GameObject StHero2;
	public static GameObject StHero3;
	public static float CharacterSelected;
	public bool isBack = false;
	
	void Start()
	{
		CharacterSelected = 1;
		StHero1 = Hero1;
		StHero2 = Hero2;
		StHero3 = Hero3;
		StHero2.renderer.enabled = false;
		StHero3.renderer.enabled = false;
	}
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
		else
		{
			Application.LoadLevel("Level1");
		}
	}
}

