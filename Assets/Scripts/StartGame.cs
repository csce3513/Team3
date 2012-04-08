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
		Application.LoadLevel("Level1");	
	}
/*
	void HighScores(string username)
{
	StreamReader sr = null;
	sr = new StreamReader(Application.dataPath + "/High Scores/HighScores.txt");	
    string fileContents = sr.ReadToEnd();
	fileContents.Replace('}', ' ');
    sr.Close();
	string userscore;
	int i = 0;
    string[] lines = fileContents.Split(' ');
	foreach (string score in lines)
		{
			if(score == "Nick")
			{
				i += 1;
				userscore = lines[i];
				print(userscore);
			}
			else
			{
				i += 1;
			}
		}
		
}*/
	
}

