using UnityEngine;
using System.Collections;

public class S_Continue : MonoBehaviour {

void OnMouseOver () 
	{
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit ()
	{
		renderer.material.color = Color.blue;
	}
	
	void OnMouseDown()
	{
		//string username = "Nick";
		//HighScores(username);
		Application.LoadLevel("Level1");	
	}
}
