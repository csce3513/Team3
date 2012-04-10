using UnityEngine;
using System.Collections;

public class S_HUD : MonoBehaviour {
	
	public bool Score = false;
	public bool Lives = false;
	public bool Ammo = false;
	public bool Zombies = false;
	public bool Cash = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Score)
		{
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + 1, GameObject.FindGameObjectWithTag("Player").transform.position.y + 1.7f, 1);
			GetComponent<TextMesh>().text = "Score: " + S_Player.playerscore;
		}
		else if (Cash)
		{
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + 1, GameObject.FindGameObjectWithTag("Player").transform.position.y + 1.4f, 1);
			GetComponent<TextMesh>().text = "Cash: " + S_Player.cash;
		}
		else if (Lives)
		{
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + 1, GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.8f, 1);
			GetComponent<TextMesh>().text = "Lives: " + S_Player.playerlives;
		}
		else if (Ammo)
		{
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + 1, GameObject.FindGameObjectWithTag("Player").transform.position.y + 1.1f, 1);
			GetComponent<TextMesh>().text = "Ammo: " + S_Player.currentammo + "/" + S_Player.ammoleft;
		}
		else if (Zombies)
		{
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + 1, GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.5f, 1);
			GetComponent<TextMesh>().text = "Zombies: " + S_Player.zombieskilled + "/" + S_Player.zombiestokill;
		}
	}
}
