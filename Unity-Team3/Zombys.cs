using UnityEngine;
using System.Collections;

public class Zombys : MonoBehaviour {
	
	private float startx;
	private float starty;
	private float zombyspeed;
	private int startdoor;
	private float health;//undefined
	private float direction;
	public GameObject player;

	// Use this for initialization
	void Start () {
		getstartdoor();
		zombyspeed = 1f;
		health = 2f;
		
		//default direction 1 (right)
		direction = 1;
		
		transform.position = new Vector3(startx, starty, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//get direction toward player
		direction = getplayerdirection();
		
		//move zombie toward the player
		moveZomby(direction);
	
	}
	
	public int getstartdoor() {
		sety();
		setx();
		return 1;
	}
	
	//set x and y
	public float sety() {
		starty = -2.9f;
		return starty;
	}		
	public float setx() {
		startx = -5.95f;
		return startx;
	}
	
	public void moveZomby(float dir) {
		
		//keep zombie inside the map
		if(transform.position.x < -6f && transform.position.x > 6f);
			//do nothing
		else
		{
			transform.Translate(Vector3.right * dir * zombyspeed * Time.deltaTime);
		}
	}
	
	//get the direction toward the player
	public float getplayerdirection() {
		if(player.transform.position.x > transform.position.x) 
		{
			return 1f;
		}
		else
		{
			return -1f;
		}
	}
	
}
