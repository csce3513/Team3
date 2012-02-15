using UnityEngine;
using System.Collections;

public class S_Prev_Charac : MonoBehaviour {

	void OnMouseOver () 
	{
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit ()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown()
	{
		HeroSelection.CharacterSelected -= 1;
		if (HeroSelection.CharacterSelected	== 0)
			HeroSelection.CharacterSelected = 3;
		
		if (HeroSelection.CharacterSelected	== 2)
		{
		HeroSelection.StHero2.renderer.enabled = true;
		HeroSelection.StHero1.renderer.enabled = false;
		HeroSelection.StHero3.renderer.enabled = false;
		}
		else if (HeroSelection.CharacterSelected == 3)
		{
		HeroSelection.StHero2.renderer.enabled = false;
		HeroSelection.StHero1.renderer.enabled = false;
		HeroSelection.StHero3.renderer.enabled = true;
		}
		else if (HeroSelection.CharacterSelected == 1)
		{
		HeroSelection.StHero2.renderer.enabled = false;
		HeroSelection.StHero1.renderer.enabled = true;
		HeroSelection.StHero3.renderer.enabled = false;
		}
	}
}
