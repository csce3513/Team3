using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;

public class S_HighScore : MonoBehaviour
{
	public String path;
	public String fileName;
	public string fileScore;
	static public string textInformation;
	static public string ScoreValue;
//	bool save = false;
	//bool overwrite = false;
	bool back = false;
	//int increSave = 0;
	static private string Name;
	static private float score;

	static public string UpdateName(string name)
	{
		Name = name;
		return Name;
	}
   
	static public float UpdateScore ()
	{
		score = S_Player.playerscore;
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
	private Vector2 scrollViewVector = Vector2.zero;
	//private string innerText = "I am inside the ScrollView";


	void OnGUI()
	{
		// Begin the ScrollView
		scrollViewVector = GUI.BeginScrollView (new Rect (0.125f*Screen.width,
		                                        0.4f*Screen.height, 0.75f*Screen.width,
		                                        0.3f*Screen.height), scrollViewVector, 
		                                        new Rect (0.125f*Screen.width,0.4f*Screen.height,
		                                                  0.7f*Screen.width, .6f*Screen.height));

		// Put something inside the ScrollView
		textInformation = GUI.TextArea(new Rect(0.25f*Screen.width,0.4f*Screen.height,
		                          0.25f*Screen.width,0.6f*Screen.height),textInformation);
		ScoreValue = GUI.TextArea(new Rect(0.5f*Screen.width,0.4f*Screen.height,
		                          0.25f*Screen.width,0.6f*Screen.height),ScoreValue);
		// End the ScrollView
		GUI.EndScrollView();

		GUI.Box(new Rect(0.3f*Screen.width,0.3f*Screen.height,
		                 100,20), "NAME");
		//GUI.Label(new Rect(0.25f*Screen.width,0.4f*Screen.height, 0.1f*Screen.width , 0.04f*Screen.height), "NAME");
		GUI.Box(new Rect(0.575f*Screen.width,0.3f*Screen.height,
		                 100,20), "SCORE");
		//GUI.Label(new Rect(0.85f*Screen.width,0.4f*Screen.height, 0.1f*Screen.width , 0.04f*Screen.height), "SCORE");
		if(GUI.Button(new Rect(0.425f*Screen.width,0.8f*Screen.height,
		                       0.15f*Screen.width,20), "MAIN MENU"))
		{
			back = true;
		}

	}
	// Update is called once per frame
	void Update ()
	{
			using(FileStream fs = File.OpenRead(path + fileName))
			{
			   byte[] b = new byte[1024];
			   UTF8Encoding temp = new UTF8Encoding(true);
			   while(fs.Read(b, 0 ,b.Length)>0)
			   {
			       textInformation = temp.GetString(b);				   
			   }
			}
		    using(FileStream fs = File.OpenRead(path + fileScore))
			{
			   byte[] b = new byte[1024];
			   UTF8Encoding temp = new UTF8Encoding(true);
			   while(fs.Read(b, 0 , b.Length)>0)
			   {
			       ScoreValue = temp.GetString(b);				   
			   }
			}
		if (back)
		{
			Application.LoadLevel("MainMenu");
		}
	}
}
