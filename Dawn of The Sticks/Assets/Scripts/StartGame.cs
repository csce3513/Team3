using UnityEngine;
using System.IO;
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
		//string username = "Nick";
		//HighScores(username);
		Application.LoadLevel("ControlInfo");	
	}
	
}

