using UnityEngine;
using System.Collections;

public class S_Player : MonoBehaviour {
	
	public float playerSpeed;
	public float ladderSpeed;
	public GameObject P_Bullet;
	public GameObject Reload_Sound;
	static public float currentammo;
	static public float ammoleft;
	public float fallSpeed;
	private float reloadtime;
	static public float firerate;
	static public float reloadwanted;
	static public float bulletdirection;
	static public Vector3 posmouse;
	static public float zombiestokill;
	static public float zombieskilled;
	public GameObject DoorOpen;
	
	// Use this for initialization
	void Start () 
	{
		DoorOpen.renderer.enabled = false;
		currentammo = 10;
		ammoleft = 20;
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
		
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			PlayerMovement(amttomove, laddermove, fallSpeed);
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
			ShootGun();
		}
		
		//reload
		else if(Input.GetKeyDown("r") && ammoleft > 0 && currentammo < 10)
		{
			reloadwanted = 1;
			reloadtime = 0;
			Instantiate(Reload_Sound, transform.position, transform.rotation);
		}
		
		else if(Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
		
		firerate += Time.deltaTime;
		reloadtime += Time.deltaTime;
		
		if (reloadtime > .8f && reloadwanted == 1)
				{
					currentammo = ReloadGun(currentammo);
				}
		
		//open the door
		if(zombieskilled == 10)
		{
			OpenDoor();
		}
	}
	
	void PlayerMovement(float horizontalmov, float verticalmov, float falling)
	{
		if ((transform.position.x <= -5.8f && horizontalmov < 0) || (transform.position.x >= 5.8f && horizontalmov > 0));
			//do nothing this keeps the player from leaving the edges of the map
		
		else if (transform.position.y >= -3f && transform.position.y <= 4.03f)
		{
			//climb the ladder to the second level
			if((transform.position.x >= -1.8f && transform.position.x <= -1.26f) && (transform.position.y <= 0.49f))
			{
				transform.Translate(Vector3.up * verticalmov);
				
					if(transform.position.y > .486f && transform.position.y < 1.5f)
						{
						transform.position= new Vector3(transform.position.x, 0.486f, 0);
						}
					else if(transform.position.y < -3f)
						{
						transform.position= new Vector3(transform.position.x, -3f, 0);
						}
					if(transform.position.y == -3f || transform.position.y >= 0.486f)
						transform.Translate(Vector3.right * horizontalmov);
			}
			
			//climb the ladder to the top level
			else if((transform.position.x >= 3.35f && transform.position.x <= 3.93) && (transform.position.y >= .486f))
				{
				transform.Translate(Vector3.up * verticalmov);
				
					if(transform.position.y > 4.03f && transform.position.y <= 4.1f)
						{
						transform.position = new Vector3(transform.position.x, 4.03f, 0);
						}
					else if(transform.position.y < .486f)
						{
						transform.position = new Vector3(transform.position.x, .486f, 0);
						}
					if(transform.position.y == .486f || transform.position.y >= 4.03f)
						transform.Translate(Vector3.right * horizontalmov);
				}
			
			//move horizontally
			else
			{
				if (horizontalmov > 0)
					bulletdirection = 1;
				else if (horizontalmov < 0)
					bulletdirection = 2;
				
				transform.Translate(Vector3.right * horizontalmov);
			}
			
			//calculate if falling
			if(transform.position.x < -3.2f && transform.position.y < 0.49f && transform.position.y > -3f)
			{
				transform.Translate(Vector3.up * -1f * falling * Time.deltaTime);
				//damage health
			}
			
			//fix position if in ground
			if(transform.position.y < -3f)
			{
				transform.position = new Vector3(transform.position.x, -3f, 0);
			}
			
			
		}
	}
	
	//Shoots the Gun
	void ShootGun()
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
	
	//Reloads the Gun
	static public float ReloadGun(float ammoingun)
	{
		while(ammoleft > 0 && ammoingun < 10)
		{
			ammoingun += 1;
		    ammoleft -= 1;
		}
		reloadwanted = 0;
		return ammoingun;
	}
	
	//"Opens" the Exit Door
	void OpenDoor()
	{
		DoorOpen.renderer.enabled = true;	
	}
	
}