using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System;

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
		Fetch_Sort();
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
		textInformation = GUI.TextArea(new Rect(0.35f*Screen.width,0.4f*Screen.height,
		                          0.3f*Screen.width,0.6f*Screen.height),textInformation);
		
		// End the ScrollView
		GUI.EndScrollView();

		GUI.Box(new Rect(0.425f*Screen.width,0.3f*Screen.height,
		                 150,20), "NAME : SCORE ");
		//GUI.Label(new Rect(0.85f*Screen.width,0.4f*Screen.height, 0.1f*Screen.width , 0.04f*Screen.height), "SCORE");
		if(GUI.Button(new Rect(0.425f*Screen.width,0.8f*Screen.height,
		                       0.15f*Screen.width,20), "MAIN MENU"))
		{
			back = true;
		}

	}
	
	static int Compare2(KeyValuePair<string, float> a, KeyValuePair<string, float> b)
    {
	    return a.Value.CompareTo(b.Value);
    }

// Fetching what we got from file then sort	
	void Fetch_Sort()
	{
		var d = new Dictionary<string, float>();
		int counter = 0;
		string[] myString = File.ReadAllLines(path+fileName);
//		File.Delete(path+fileName);
		
		foreach (string s in myString)
			counter++;
	// 1.Add element to the dictionary	
        for (int i=0; i<(counter/2);i++)
		{
		   d.Add(myString[i*2], float.Parse(myString[i*2 + 1]));		
		}
	// 2.Order by values.
	// Use LINQ to specify sorting by value.
	    var items = from k in d.Keys
	                orderby d[k] descending
	                select k;

	// 3. Display results.
	foreach (string k in items)
	{
	    textInformation += (k + " : "+ d[k] + "\n");
	}
		
		
//		textInformation = aList[0].Key.ToString()+"\n" + aList[1].Key.ToString()+"\n"+aList[2].Key.ToString()+"\n"+aList[3].Key.ToString() + "\n";
//		textInformation = aList[0].Key.ToString()+"\n"
//			            + aList[1].Key.ToString()+"\n"
//				        + aList[2].Key.ToString()+"\n";
//				        + aList[3].Key.ToString()+"\n"
//				 +aList[4].Key.ToString()+"\n"
//				 +aList[5].Key.ToString()+"\n"
//				 +aList[6].Key.ToString()+"\n"
//				 +aList[7].Key.ToString()+"\n"
//				 +aList[8].Key.ToString()+"\n";
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//string temp1 = "", temp2 = "" ;
		// Read the file and display it line by line.
        //System.IO.StreamReader file = new System.IO.StreamReader(path+fileName);
		
//		textInformation = aList.Count.ToString();
//		textInformation = aList[0].Key.ToString()+"\n"+aList[1].Key.ToString()+"\n"+aList[2].Key.ToString()+"\n"+aList[3].Key.ToString() + "\n";
//		for(int i=0; i < 3; i++)
//	{
//			if(File.Exists(path + fileScore))
//			{
//				using(StreamWriter fs = File.AppendText(path + fileScore))
//				{
//				    fs.WriteLine(aList[i].Value.ToString()+"\n");	
//				}
//			}
//	}

/*			using(FileStream fs = File.OpenRead(path + fileName))
			{
			   byte[] b = new byte[1024];
			   UTF8Encoding temp = new UTF8Encoding(true);
			   while(fs.Read(b, 0 ,b.Length)>0)
			   {
			       textInformation = temp.GetString(b);
				   //aList.Add(new KeyValuePair<string, float>(temp.GetString(b), 1));
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
*/
		if (back)
		{
			Application.LoadLevel("MainMenu");
		}
	}
	public void AddText(FileStream fs, string value)
	{
		byte[] info = new UTF8Encoding(true).GetBytes(value);
		fs.Write(info, 0, info.Length);
	}
}
