using UnityEngine;
using System.Collections;

public class S_HUD : MonoBehaviour {
	
	public bool Score = false;
	public bool Lives = false;
	public bool Ammo = false;
	public bool Zombies = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Score)
		{
			GetComponent<TextMesh>().text = "Score: " + S_Player.playerscore;
		}
		else if (Lives)
		{
			GetComponent<TextMesh>().text = "Lives: " + S_Player.playerlives;
		}
		else if (Ammo)
		{
			GetComponent<TextMesh>().text = "Ammo: " + S_Player.currentammo + "/" + S_Player.ammoleft;
		}
		else if (Zombies)
		{
			GetComponent<TextMesh>().text = "Zombies: " + S_Player.zombieskilled + "/" + S_Player.zombiestokill;
		}
	}
}
