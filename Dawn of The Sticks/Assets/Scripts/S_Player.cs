using UnityEngine;
using System.Collections;

public class S_Player : MonoBehaviour {
	
	public float playerSpeed;
	public float ladderSpeed;
	public GameObject P_Bullet;
	public GameObject Reload_Sound;
	private float shot;
	static public float currentammo;
	static public float ammoleft;
	static public float currentlevel;
	static public float cash;
	public float fallSpeed;
	private float playervisible;
	private float reloadtime;
	static public float climbdirection;
	static public float firerate;
	static public float currentgun;
	static public float rateofgun;
	static public GameObject play;
	static public float reloadwanted;
	static public float bulletdirection;
	static public Vector3 posmouse;
	static public float zombiestokill;
	static public float zombieskilled;
	static public float playerlives;
	static public float playerscore;
	public GameObject DoorOpen;
	
	// Use this for initialization
	void Start () 
	{
		DoorOpen.renderer.enabled = false;
		Initial();
		play = GameObject.FindGameObjectWithTag("Player");
		float originaldirection = 1;
		currentgun = 1;
		rateofgun = .2f;
		currentlevel = 1;
		reloadtime = 0;
		climbdirection = 0;
		firerate = 0;
		playerscore = 0;
		zombieskilled = 0;
		zombiestokill = 10;
		bulletdirection = originaldirection;
		//assigning the player the position of the player in the lower left hand position
		transform.position = new Vector3(-5.8f, -2.5f, transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(S_PlayerZombieCollision.state != S_PlayerZombieCollision.State.Death)
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
			shot = ShootGun(firerate);
			if (shot == 1)
			{
				Instantiate(P_Bullet, transform.position, Quaternion.identity);
			}
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
					ReloadGun();
				}
		
		//open the door
		if(zombieskilled == 10)
		{
			OpenDoor();
			playervisible = PlayerLeave(transform.position.y, transform.position.x);
			if (playervisible == 1)
			{
				Application.LoadLevel("Store");
			}
		}
		else
		{
			DoorOpen.renderer.enabled = false;
		}
		
	  }
	}
	
	void PlayerMovement(float horizontalmov, float verticalmov, float falling)
	{
		if ((transform.position.x <= -5.8f && horizontalmov < 0) || (transform.position.x >= 5.8f && horizontalmov > 0));
			//do nothing this keeps the player from leaving the edges of the map
		
		else if (transform.position.y >= -2.5f && transform.position.y <= 4.55f)
		{
			//climb the ladder to the second level
			if((transform.position.x >= -1.8f && transform.position.x <= -1.26f) && (transform.position.y <= 1.1f))
			{
				transform.Translate(Vector3.up * verticalmov);
				if (verticalmov	!= 0 && climbdirection == 0)
				{
					if(bulletdirection == 1)
					{
						transform.Rotate(0,-90,0);
						climbdirection = 1;
					}
					else if (bulletdirection == 2)
					{
						transform.Rotate(0,90f, 0);
						climbdirection = 2;
					}
				}
				
					if(transform.position.y > 1f && transform.position.y < 1.5f)
						{
						transform.position= new Vector3(transform.position.x, 1f, 0);
						}
					else if(transform.position.y < -2.5f)
						{
						transform.position= new Vector3(transform.position.x, -2.5f, 0);
						}
					if(transform.position.y == -2.5f || transform.position.y >= 1f)
				{
					if (horizontalmov	!= 0)
					{
						if (climbdirection	== 1)
						{
							transform.Rotate(0,90f,0);
							climbdirection =0;
						}
						else if(climbdirection == 2)
						{
							transform.Rotate(0,-90,0);
							climbdirection = 0;
						}
					}
					if (horizontalmov > 0)
				{
						
					if(bulletdirection == 2)
					{
						transform.Rotate(0,180,0);
					}
					bulletdirection = 1;
					animation.Play("Walking");
				}
				else if (horizontalmov < 0)
				{
					if(bulletdirection == 1)
					{
						transform.Rotate(0,180,0);
					}
					bulletdirection = 2;
					animation.Play("Walking");
					horizontalmov = horizontalmov * -1f;
				}
				
				//transform.Translate(Vector3.right * horizontalmov);
				transform.Translate(Vector3.forward * horizontalmov);
				}
			}
			
			//climb the ladder to the top level
			else if((transform.position.x >= 3.35f && transform.position.x <= 3.93) && (transform.position.y >= 1f))
				{
				if (verticalmov	!= 0 && climbdirection == 0)
				{
					if(bulletdirection == 1)
					{
						transform.Rotate(0,-90,0);
						climbdirection = 1;
					}
					else if (bulletdirection == 2)
					{
						transform.Rotate(0,90f, 0);
						climbdirection = 2;
					}
				}
				transform.Translate(Vector3.up * verticalmov);
				
					if(transform.position.y > 4.55f)
						{
						transform.position = new Vector3(transform.position.x, 4.55f, 0);
						}
					else if(transform.position.y < 1f)
						{
						transform.position = new Vector3(transform.position.x, 1f, 0);
						}
					if(transform.position.y == 1f || transform.position.y >= 4.55f)
					{
						if (horizontalmov	!= 0)
					{
						if (climbdirection	== 1)
						{
							transform.Rotate(0,90f,0);
							climbdirection =0;
						}
						else if(climbdirection == 2)
						{
							transform.Rotate(0,-90,0);
							climbdirection = 0;
						}
					}
						if (horizontalmov > 0)
						{
							if(bulletdirection == 2)
							{
							transform.Rotate(0,180,0);
							}
							bulletdirection = 1;
							animation.Play("Walking");
						}
						else if (horizontalmov < 0)
						{
						if(bulletdirection == 1)
						{
							transform.Rotate(0,180,0);
						}
						bulletdirection = 2;
						animation.Play("Walking");
						horizontalmov = horizontalmov * -1f;
						}
						transform.Translate(Vector3.forward * horizontalmov);
				}
				}
			
			//move horizontally
			else
			{
				if (horizontalmov > 0)
				{
					if(bulletdirection == 2)
					{
						transform.Rotate(0,180,0);
					}
					bulletdirection = 1;
					animation.Play("Walking");
				}
				else if (horizontalmov < 0)
				{
					if(bulletdirection == 1)
					{
						transform.Rotate(0,180,0);
					}
					bulletdirection = 2;
					animation.Play("Walking");
					horizontalmov = horizontalmov * -1f;
				}
				
				//transform.Translate(Vector3.right * horizontalmov);
				transform.Translate(Vector3.forward * horizontalmov);
			}
			
			//calculate if falling
			if(transform.position.x < -3.2f && transform.position.y <= 1f && transform.position.y > -2.5f)
			{
				transform.Translate(Vector3.up * -1f * falling * Time.deltaTime);
				//damage health
			}
			
			//fix position if in ground
			if(transform.position.y < -2.5f)
			{
				transform.position = new Vector3(transform.position.x, -2.5f, 0);
			}
			
			
		}
	}
	
	//Shoots the Gun
	static public float ShootGun(float firing)
	{
		float bulletshot;
		//creates the bullet
			if ((firing > rateofgun) && (currentammo > 0))
			{
			firerate = 0;
			bulletshot = 1;
			currentammo -= 1;
			}
			else
			{
				bulletshot = 0;
			}
		
		return bulletshot;
	}
	
	//Reloads the Gun
	static public void ReloadGun()
	{
		while(ammoleft > 0 && currentammo < 10)
					{
					currentammo += 1;
				    ammoleft -= 1;
					}
		reloadwanted = 0;
	}
	
	//"Opens" the Exit Door
	void OpenDoor()
	{
		DoorOpen.renderer.enabled = true;	
	}
	
	static public float PlayerLeave(float y, float x)
	{
		float leave = 0;
		if (y >= 4.03 && (x >= -5.9f && x <= -5.2f) && zombieskilled >= 10)
		{
			GameObject.FindGameObjectWithTag("PlayerRender").renderer.enabled = false;
			leave = 1f;
		}
		else
		{
			leave = 0f;
		}
		
		return leave;
	}
	
	
	static public float GetBullets()
	{
		return currentammo;
	}
	
	
	static public void Initial()
	{
		currentammo = 10;
		ammoleft = 20;
		reloadwanted = 0;
		playerlives = 2;
	}
	
	static public float GetLives()
	{
		return playerlives;
	}
	
}