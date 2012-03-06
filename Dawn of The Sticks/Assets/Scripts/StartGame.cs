using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

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
		Application.LoadLevel("Level1");
	}
}
