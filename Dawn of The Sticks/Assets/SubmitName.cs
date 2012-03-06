using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;

public class SubmitName : MonoBehaviour
{
	public String path;
	public String fileName;
	public string fileScore;
	static public string textInformation;
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
		score = S_Player.zombieskilled * 100f;
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
		//path = GUI.TextField(new Rect(50,Screen.height-450, Screen.width -100, 20), path);
		//fileName = GUI.TextField(new Rect(50,Screen.height-400, Screen.width -100, 20),fileName);
		textInformation = GUI.TextArea(new Rect(100,Screen.height-100, 200, 20),textInformation);
		//GUI.Label(new Rect(50, Screen.height -350, 100, 20), "NAME");
		
		
		if(GUI.Button(new Rect(50, Screen.height -60, 100, 20), "SUBMIT"))
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
				using(FileStream fs = File.OpenWrite(path + fileName))
				{
					string temp = textInformation + "\n"; 
					UpdateName(temp);
				    AddText(fs, temp);		
				}
				using(FileStream fs = File.OpenWrite(path + fileScore))
				{
					//float floatTemp = UpdateScore
					string temp = UpdateScore().ToString() + "\n"; 
					//UpdateName(temp);
				    AddText(fs, temp);		
				}
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
					//UpdateName(temp);
				    AddText(fs, temp);		
				}
				submit = false;
			}
		}
	}
	static public void AddText(FileStream fs, string value)
	{
		byte[] info = new UTF8Encoding(true).GetBytes(value);
		fs.Write(info, 0, info.Length);
	}
}

