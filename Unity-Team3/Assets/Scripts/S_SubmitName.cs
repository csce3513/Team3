using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;

public class S_SubmitName : MonoBehaviour
{
	public String path;
	public String fileName;
	public string fileScore;
	static public string textInformation;
	public string storage;
	static public string ScoreValue;
	bool submit = false;
	static private string Name;
	static private float score;

	static public string UpdateName(string name)
	{
		Name = name;
		return Name;
	}
   
	static public float UpdateScore ()
	{
		score = S_Player.zombieskilled * 100f;//<---------Change S_Player.zombieskilled to whatever variable that you want it to be score
		return score;
	}
	// Use this for initialization
	void Start ()
	{
		path = Application.dataPath + "/High Scores";
		fileName = "/fileName.txt";
		fileScore = "/fileScore.txt";
		textInformation = "";
		ScoreValue = "";
	}
	void OnGUI()
	{
		textInformation = GUI.TextArea(new Rect(0.35f*Screen.width,0.3f*Screen.height, 0.3f*Screen.width , 0.04f*Screen.height),textInformation);
		if(GUI.Button(new Rect(0.45f*Screen.width,0.4f*Screen.height,
		                       0.1f*Screen.width , 0.04f*Screen.height), "SUBMIT"))
		{
			submit = true;
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if(submit)
		{
			//Delete the existing file that have the same file name
			if(File.Exists(path + fileName) && File.Exists(path + fileScore))
			{
				using(StreamWriter fs = File.AppendText(path + fileName))
				{
					string temp;
					//Only allow 15 character of name
					if(textInformation.Length > 15)
						temp = textInformation.Substring(0,15); 
					else
						temp = textInformation; 
					UpdateName(temp);
				    fs.WriteLine(temp);		
				}
				using(StreamWriter fs = File.AppendText(path + fileScore))
				{
					string temp = UpdateScore().ToString(); 
				    fs.WriteLine(temp);			
				}
				
				Application.LoadLevel("MainMenu");
				submit = false;
			}
			else
			{
				using(FileStream fs = File.Create(path + fileName))
				{
					string temp = textInformation + "\n"; 
					UpdateName(temp);
				    AddText(fs, temp);		
				}
				using(FileStream fs = File.Create(path + fileScore))
				{
					string temp = UpdateScore().ToString() + "\n"; 
				    AddText(fs, temp);		
				}
				submit = false;
			}
		}
	}
	public void AddText(FileStream fs, string value)
	{
		byte[] info = new UTF8Encoding(true).GetBytes(value);
		fs.Write(info, 0, info.Length);
	}
}

