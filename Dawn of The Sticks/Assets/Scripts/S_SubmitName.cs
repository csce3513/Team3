using UnityEngine;
using System.Collections.Generic;
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
		score = S_Player.playerscore;//<---------Change S_Player.zombieskilled to whatever variable that you want it to be score
		return score;
	}

	// Use this for initialization
	void Start ()
	{
		path = "C:/Users/Public/Public Documents"; 
			//"/Users/Shared";
			//Application.dataPath + "/High Scores";
		fileName = "/fileName.txt";
		fileScore = "/fileScore.txt";
		textInformation = "";
		ScoreValue = "";
	}
	void OnGUI()
	{
		textInformation = GUI.TextArea(new Rect(0.35f*Screen.width,0.85f*Screen.height, 0.3f*Screen.width , 0.04f*Screen.height),textInformation);
		if(GUI.Button(new Rect(0.65f*Screen.width,0.85f*Screen.height,
		                       0.1f*Screen.width , 0.04f*Screen.height), "SUBMIT"))
		{
			submit = true;
			
		}
	}
	void add15charName()
	{
		string temp;
		//Only allow 15 characters of name
		if(textInformation.Length > 15)
			temp = textInformation.Substring(0,15); 
		else
			temp = textInformation; 
		UpdateName(temp);
		
	}
	// Update is called once per frame
	void Update ()
	{
		if(submit)
		{
			if(File.Exists(path + fileName))
			{
				//Approach new method of writing text to file
				using(StreamWriter fs = File.AppendText(path + fileName))
				{
					add15charName();
				    fs.WriteLine(Name);	
					fs.WriteLine(UpdateScore().ToString());
				}
				submit = false;
			}
			else
			{
				StreamWriter wr = File.AppendText(path + fileName);
				//Old method of writing text to file
				using(FileStream fs = File.Create(path + fileName))
				{
					StreamWriter aa = File.AppendText(path + fileName);
					add15charName();
					aa.WriteLine(Name);	
					aa.WriteLine(UpdateScore().ToString());
				    //AddText(fs, Name);	
					//AddText(fs, UpdateScore().ToString()+"\n");
				}
				submit = false;
			}
			if(File.Exists(path + fileScore))
				File.Delete(path+fileScore);
			Application.LoadLevel("MainMenu");
		}
	}
	public void AddText(FileStream fs, string value)
	{
		byte[] info = new UTF8Encoding(true).GetBytes(value);
		fs.Write(info, 0, info.Length);
	}
}