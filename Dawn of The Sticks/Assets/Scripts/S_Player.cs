using UnityEngine;
using System.Collections;

public class S_Player : MonoBehaviour {
	
	public float playerSpeed;
	public float ladderSpeed;
	public GameObject P_Bullet;
	public GameObject Reload_Sound;
	public float currentammo;
	public float ammoleft;
	public float fallSpeed;
	private float reloadtime;
	static public float firerate;
	private float reloadwanted;
	static public float bulletdirection;
	static public Vector3 posmouse;
	static public float zombiestokill;
	static public float zombieskilled;
	public GameObject DoorOpen;
	
	// Use this for initialization
	void Start () 
	{
		DoorOpen.renderer.enabled = false;
		reloadwanted = 0;
		float originaldirection = 1;
		reloadtime = 0;
		firerate = 0;
		zombieskilled = 0;
		zombiestokill = 10;
		bulletdirection = originaldirection;
		//assigning the player the position of the player in the lower left hand position
		transform.position = new Vector3(-5.8f, -3, transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float amttomove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
		float laddermove = Input.GetAxis("Vertical") * ladderSpeed * Time.deltaTime;
		
		if ((transform.position.x <= -5.8f && amttomove < 0) || (transform.position.x >= 5.8f && amttomove > 0));
			//do nothing this keeps the player from leaving the edges of the map
		else if (transform.position.y >= -3f && transform.position.y <= 4.03f)
		{
			if((transform.position.x >= -1.8f && transform.position.x <= -1.26f) && (transform.position.y <= 0.49f))
			{
				transform.Translate(Vector3.up * laddermove);
				
					if(transform.position.y > .486f && transform.position.y < 1.5f)
						{
						transform.position= new Vector3(transform.position.x, 0.486f, 0);
						}
					else if(transform.position.y < -3f)
						{
						transform.position= new Vector3(transform.position.x, -3f, 0);
						}
					if(transform.position.y == -3f || transform.position.y >= 0.486f)
						transform.Translate(Vector3.right * amttomove);
			}
			
			else if((transform.position.x >= 3.35f && transform.position.x <= 3.93) && (transform.position.y >= .486f))
				{
				transform.Translate(Vector3.up * laddermove);
				
					if(transform.position.y > 4.03f && transform.position.y <= 4.1f)
						{
						transform.position = new Vector3(transform.position.x, 4.03f, 0);
						}
					else if(transform.position.y < .486f)
						{
						transform.position = new Vector3(transform.position.x, .486f, 0);
						}
					if(transform.position.y == .486f || transform.position.y >= 4.03f)
						transform.Translate(Vector3.right * amttomove);
				}
			
			else //if (transform.position.y == -3f || transform.position.y == 0.486f || transform.position.y == 4.03f)
			{
				if (amttomove > 0)
					bulletdirection = 1;
				else if (amttomove < 0)
					bulletdirection = 2;
				
				transform.Translate(Vector3.right * amttomove);
			}
			
			if(transform.position.x < -3.2f && transform.position.y < 0.49f && transform.position.y > -3f)
			{
				transform.Translate(Vector3.up * -1f * fallSpeed * Time.deltaTime); 
			}
			
			if(transform.position.y < -3f)
			{
				transform.position = new Vector3(transform.position.x, -3f, 0);
			}
			
			
		}
		
		//move the camera
		GameObject maincam = Camera.main.gameObject;
		if(transform.position.y >= .486f)
		{
			maincam.transform.position = new Vector3(0,3.5f,-10);
		}
		
		else
		{
			maincam.transform.position = new Vector3(0,1f,-10);
		}
		
		
		//shoot
		if (Input.GetKeyDown("space") && currentammo > 0)
		{
			//creates the bullet
			Vector3 position = new Vector3(transform.position.x + transform.localScale.x / 2, transform.position.y, transform.position.z);
			
			if (firerate > .2f)
			{
			firerate = 0;
			Instantiate(P_Bullet, position, transform.rotation);
			currentammo -= 1;
			}
		}
		
		//reload
		else if(Input.GetKeyDown("r") && ammoleft > 0)
		{
			reloadwanted = 1;
			reloadtime = 0;
			Instantiate(Reload_Sound, transform.position, transform.rotation);
		}
		
		firerate += Time.deltaTime;
		
		reloadtime += Time.deltaTime;
		
		print(reloadtime +" " + reloadwanted);
		
		if (reloadtime > .8f && reloadwanted == 1)
				{
					while(ammoleft > 0 && currentammo < 10)
					{
						currentammo += 1;
					ammoleft -= 1;
					}
					reloadwanted = 0;
				}
		
		//open the door
		if(zombieskilled == 10)
		{
			DoorOpen.renderer.enabled = true;
		}
	}
}