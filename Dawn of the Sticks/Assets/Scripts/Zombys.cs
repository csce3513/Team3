using UnityEngine;
using System.Collections;

public class Zombys : MonoBehaviour {
	
	private float startx;
	private float starty;
	private float zombyspeed;
	private int startdoor;
	private float health;//undefined
	private float direction;
	private GameObject player;
	private Random rand;

	// Use this for initialization
	void Start () {
		rand = new Random();
		player = GameObject.FindGameObjectWithTag("Player");
		zombyspeed = 0.5f;
		health = 2f;
		//default direction 1 (right)
		direction = 1;
		getstartdoor();
		
		transform.position = new Vector3(startx, starty, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//get direction toward player
		if(transform.position.x >= 5.9f && direction == 1)
		{
			direction = -1f;
			transform.Rotate(0,180,0);
		}
		
		else if( (transform.position.x <= -5.9 || (transform.position.x <= -2.9f && transform.position.y == 1f)) && direction == -1f)
		{
			direction = 1f;
			transform.Rotate(0,180,0);
		}
		
		//move zombie toward the player
		moveZomby(direction);
	
	}
	
	public int getstartdoor() {
		startdoor = Random.Range(1,5);
		sety(startdoor);
		setx(startdoor);
		return 1;
	}
	
	//set x and y
	public float sety(int whichdoor) {
		switch (whichdoor) 
		{
		case 1:
			starty = -2.5f;
			break;
		case 2:
			starty = -2.5f;
			break;
		case 3:
			starty = 1f;
			break;
		case 4:
			starty = 4.55f;
			break;
		default:
			starty = -2.5f;
			break;
		}
		return starty;
	}		
	public float setx(int whichdoor) {
		if(whichdoor == 1)
		{
			startx = -5.95f;
			direction = 1;
		}
		else
		{
			startx = 5.95f;
			transform.Rotate(0,180,0);
			direction = -1f;
		}
		return startx;
	}
	
	public void moveZomby(float dir) {
		
		//keep zombie inside the map
		if(transform.position.x < -6f && transform.position.x > 6f);
			//do nothing
		else
		{
			animation.Play("Walking");
			transform.Translate(Vector3.forward * zombyspeed * Time.deltaTime);
		}
	}
	
	//get the direction toward the player
	public float getplayerdirection() {
		float direction = 0;
		if(transform.position.x <= -3.1f && transform.position.y == 1f)
		{
			direction = 1f;
		}
		if(transform.position.x <= -5.95f) 
		{
			direction = 1f;
		}
		else if(transform.position.x >= 5.95f) 
		{
			direction = -1f;
		}
		
		return direction;
	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		if(otherObject.tag == "Zombie")
		{
			direction = direction * -1f;
		}
	}
	
}
