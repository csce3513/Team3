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
	
		if(zombietime > 3 && zombiecount < 10){
			Instantiate(zombie);
			zombiecount++;
			zombietime = 0;
		}
	}
}
