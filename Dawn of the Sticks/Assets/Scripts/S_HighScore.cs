using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	bool back = false;
	static private string Name;
	static private float score;
	private Vector2 scrollViewVector = Vector2.zero;

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
		path = Application.dataPath + "/High Scores";
		fileName = "/fileName.txt";
		fileScore = "/fileScore.txt";
		textInformation = "";
		ScoreValue = "";
		Fetch_Sort();// Sort when the game run.
	}

	void OnGUI()
	{
		// Begin the ScrollView
		scrollViewVector = GUI.BeginScrollView (new Rect (0.35f*Screen.width,
		                                        0.4f*Screen.height, 0.7f*Screen.width,
		                                        0.3f*Screen.height), scrollViewVector, 
		                                        new Rect (0.3f*Screen.width,0.4f*Screen.height,
		                                                  0.3f*Screen.width, .6f*Screen.height));

		// Put something inside the ScrollView
		GUI.Box(new Rect(0.30f*Screen.width,0.4f*Screen.height,
		                          0.3f*Screen.width,0.6f*Screen.height),textInformation);
		
		// End the ScrollView
		GUI.EndScrollView();

		GUI.Box(new Rect(0.425f*Screen.width,0.3f*Screen.height,
		                 150,20), "NAME , SCORE ");
		//GUI.Label(new Rect(0.85f*Screen.width,0.4f*Screen.height, 0.1f*Screen.width , 0.04f*Screen.height), "SCORE");
		if(GUI.Button(new Rect(0.425f*Screen.width,0.8f*Screen.height,
		                       0.15f*Screen.width,20), "MAIN MENU"))
		{
			back = true;
		}

	}
static int Compare2(KeyValuePair<string, float> a, KeyValuePair<string, float> b)
    {
	return b.Value.CompareTo(a.Value);
    }
// Fetching what we got from file then sort	
	void Fetch_Sort()
	{
		//Using KeyValuePair instead of Dictionary becasue it can handle
		//     duplicate key.
		var d = new List<KeyValuePair<string, float>>();
		int counter = 0;
		string[] myString = File.ReadAllLines(path+fileName);
	// Delete the existing file after fetch dictionary
	//    File.(path + fileName);
		foreach (string s in myString)
			counter++;
	// 1.Add element to the dictionary	
        for (int i=0; i<(counter/2);i++)
		   d.Add(new KeyValuePair<string, float>(myString[i*2], float.Parse(myString[i*2 + 1])));		
	
	// 2.Order by values.
	
		d.Sort(Compare2);
//	    var items = from k in d.Keys
//	                orderby d[k] descending
//	                select k;
	// Write sorted highscore to the file  
   // By doing this, sorting time can be reduced everytme we run the game.	
    if(File.Exists(path + fileScore)==false)
	{
	  using(StreamWriter wf = File.CreateText(path + fileScore))
	  {		
		foreach (var pair in d)
		{	
			wf.Write(pair.Key + "\n");
			wf.Write(pair.Value + "\n");	
		}
	  }
    }
		File.Delete(path + fileName);
		File.Copy(path+fileScore, path+fileName);
//File.Replace(path+fileScore, path+fileName,null);
		
	// 3. Display results on GUI text.
	foreach (var pair in d)
	    textInformation += (pair + "\n");

  
}
	
	
	// Update is called once per frame
	void Update ()
	{
		if (back)
		{
			Application.LoadLevel("MainMenu");
		}
	}

}
