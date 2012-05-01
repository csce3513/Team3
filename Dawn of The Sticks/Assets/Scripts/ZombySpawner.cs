using UnityEngine;
using System.Collections;

public class ZombySpawner : MonoBehaviour {
	public GameObject zombie;
	private float zombietime;
	private int zombiecount;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		zombietime += Time.deltaTime;
	
		if(S_Player.currentlevel == 1 && zombietime > 3 && zombiecount < 10){
			Instantiate(zombie);
			zombiecount++;
			zombietime = 0;
		}
		else if(S_Player.currentlevel == 2 && zombietime > 2&& zombiecount < 20)
		{
			Instantiate(zombie);
			zombiecount++;
			zombietime = 0;
		}
		else if(S_Player.currentlevel == 3 && zombietime > 1&& zombiecount < 30)
		{
			Instantiate(zombie);
			zombiecount++;
			zombietime = 0;
		}
		else if(S_Player.currentlevel == 4 && zombietime >.5 && zombiecount < 40)
		{
			Instantiate(zombie);
			zombiecount++;
			zombietime = 0;
		}
	}
}
