using UnityEngine;
using System.Collections;

public class S_Pause : MonoBehaviour {
	bool paused;
	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	void OnGUI() {
		if( paused ) {
			GUI.Box(new Rect( .25f*Screen.width,.25f*Screen.height, .5f*Screen.width, .5f*Screen.height),
			        "paused");
			
			if(GUI.Button(new Rect(0.43f*Screen.width,0.45f*Screen.height,
		                       150,20), "Main Menu"))
			{
				Time.timeScale = 1f;
				Application.LoadLevel("MainMenu");
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown("p") )
			togglePause();
	}
	
	void togglePause() {
		if( !paused ){
			paused = !paused;
			Time.timeScale = 0f;
		}
		else {
			paused = !paused;
			Time.timeScale = 1f;
		}
	}
}
