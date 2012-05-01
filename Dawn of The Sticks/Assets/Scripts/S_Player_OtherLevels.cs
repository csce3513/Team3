using UnityEngine;
using System.Collections;

public class S_Player_OtherLevels : MonoBehaviour {

	public float playerSpeed;
	public float ladderSpeed;
	public GameObject P_Bullet;
	public GameObject Reload_Sound;
	private float shot;
	private float amttomove;
	private float floortime;
	public float fallSpeed;
	private float playervisible;
	private float reloadtime;
	private float wallhit;
	private float floorhit;
	private float downtime;
	private float elevhit;
	private float doorhit;
	private float dooropen;
	private float doorenter;
	static public float climbdirection;
	static public GameObject play;
	static public float reloadwanted;
	private State state;
	public GameObject DoorOpen;
	
	public enum State
	{
		Death,
		Playing,
		Invincible
	}
	
	// Use this for initialization
	void Start () 
	{
		state = State.Playing;
		//S_PlayerZombieCollision.state = S_PlayerZombieCollision.State.Playing;
		/*S_Player.currentlevel = 4;
		S_Player.ammoleft = 50;
		S_Player.currentgun = 3;
		S_Player.playerlives = 3;*/
		play = GameObject.FindGameObjectWithTag("Player");
		reloadtime = 0;
		climbdirection = 0;
		if(S_Player.currentlevel == 4)
		{
			dooropen = 1;
		}
		else
		{
		DoorOpen.renderer.enabled = false;
		dooropen = 0;
		}
		//S_Player.zombieskilled = 0;
		floortime = 0;
		floorhit = 1;
		
		//assigning the player the position of the player in the lower left hand position
		if (S_Player.currentlevel == 4)
		{
		transform.position = new Vector3(-5f, -1.65f, transform.position.z);
		}
		else
		{
		transform.position = new Vector3(-5.8f, -1.65f, transform.position.z);
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(state != State.Death)
		{
			floortime += Time.deltaTime;
		amttomove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
		doorenter = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
			
			if (amttomove > 0)
			{
				if(S_Player.bulletdirection == 2)
					{
						transform.Rotate(0,180,0);
					}
					S_Player.bulletdirection = 1;
					animation.Play("Walking");
			}
			else if (amttomove < 0)
			{
				if(S_Player.bulletdirection == 1)
					{
						transform.Rotate(0,180,0);
					}
					S_Player.bulletdirection = 2;
					animation.Play("Walking");
				amttomove = amttomove * -1f;
			}
			
			if((floorhit == 0 && elevhit == 0) || (floorhit == 0 && elevhit == 1))
				{
					transform.rigidbody.useGravity = true;
					transform.rigidbody.isKinematic = false;
				}
			else
			{
				transform.rigidbody.useGravity = false;
					transform.rigidbody.isKinematic = true;
			}
		
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
				Debug.Log(amttomove);
				
				if (wallhit == 1 && S_Player.bulletdirection == 1)
				{
					amttomove = 0;
				}
				
				else if (wallhit == 2 && S_Player.bulletdirection == 2)
				{
					amttomove = 0;
				}
				
				if(floorhit == 0 || elevhit == 1)
				{
					amttomove = 0;
				}
				
				if(doorenter > 0 && doorhit == 1 && dooropen == 1)
				{
					if(S_Player.currentlevel != 4)
					{
					Application.LoadLevel("Store");
					}
					else
					{
						Application.LoadLevel("WinningScreen");
					}
						
				}
				
				Debug.Log(downtime);
				
				if(doorhit < 0 && downtime < 0.5f)
				{
				downtime += Time.deltaTime;
				floortime = 0;
				}
				
				if(floorhit == 1)
				{
					downtime = 0;
				}
				
				Debug.Log(downtime);
				
				transform.Translate(Vector3.forward * amttomove);
		}
		
			
			
		//move the camera
		GameObject maincam = Camera.main.gameObject;
		GameObject light = GameObject.Find("Directional light");
		maincam.transform.position = new Vector3(transform.position.x, transform.position.y, maincam.transform.position.z);
			if(S_Player.currentlevel == 4)
			{
				light.transform.position = new Vector3(transform.position.x, light.transform.position.y, light.transform.position.z);
			}
		
		//shoot
		if (Input.GetKeyDown("space") && S_Player.currentammo > 0)
		{
			shot = ShootGun(S_Player.firerate);
			if (shot == 1)
			{
					if(S_Player.currentgun != 3)
					{
				Instantiate(P_Bullet, transform.position, Quaternion.identity);
					}
					else
					{
						StartCoroutine(ShootShotgun());
					}
						
			}
		}
		
		//reload
		else if(Input.GetKeyDown("r") && S_Player.ammoleft > 0 && S_Player.currentammo < 10)
		{
			reloadwanted = 1;
			reloadtime = 0;
			Instantiate(Reload_Sound, transform.position, transform.rotation);
		}
		
		else if(Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
		
		S_Player.firerate += Time.deltaTime;
		reloadtime += Time.deltaTime;
		
		if (reloadtime > .8f && reloadwanted == 1)
				{
					ReloadGun();
				}
		
		//open the door
		if(S_Player.zombieskilled >= S_Player.zombiestokill)
		{
			OpenDoor();
		}
		else
		{
			DoorOpen.renderer.enabled = false;
		}
		
	  }
	}
	
	
	
	//Shoots the Gun
	static public float ShootGun(float firing)
	{
		float bulletshot;
		//creates the bullet
			if ((firing > S_Player.rateofgun) && (S_Player.currentammo > 0))
			{
			S_Player.firerate = 0;
			bulletshot = 1;
			S_Player.currentammo -= 1;
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
		while(S_Player.ammoleft > 0 && S_Player.currentammo < 10)
					{
					S_Player.currentammo += 1;
				    S_Player.ammoleft -= 1;
					}
		reloadwanted = 0;
	}
	
	//"Opens" the Exit Door
	void OpenDoor()
	{
		DoorOpen.renderer.enabled = true;
		dooropen = 1;
	}
	
	static public float PlayerLeave(float y, float x)
	{
		float leave = 0;
		if (y >= 4.03 && (x >= -5.9f && x <= -5.2f) && S_Player.zombieskilled >= 10)
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
		return S_Player.currentammo;
	}
	
	static public float GetLives()
	{
		return S_Player.playerlives;
	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		if(otherObject.tag == "WallR")
		{
			Debug.Log("Hit the WallR");
			wallhit = 1;
		}
		
		else if(otherObject.tag == "WallL")
		{
			Debug.Log("Hit the WallL");
			wallhit = 2;
		}
		
		else if(otherObject.tag == "Floor" && (otherObject.gameObject.transform.position.y < (transform.position.y - 1.36f)))
		{
			if (floortime != 0f)
			{
			gameObject.transform.parent = null;
			floorhit = 1;
			}
			
			if(otherObject.transform.position.y <= -3f)
			{
				gameObject.transform.parent = null;
				floorhit = 1;
			}
		}
		
		else if(otherObject.tag == "Elevator" && (otherObject.gameObject.transform.position.y < (transform.position.y - 1.36f)))
		{
			gameObject.transform.parent = otherObject.gameObject.transform;
			elevhit = 1;
			floorhit = 1;
		}
		
		else if(otherObject.tag == "Door")
		{
			doorhit = 1;
		}
	}
	
	void OnTriggerExit(Collider otherObject)
	{
		if(otherObject.tag == "WallR" || otherObject.tag == "WallL")
		{
			wallhit = 0;
		}
		
		if(otherObject.tag == "Floor")
		{
			floorhit = 0;
		}
		
		if (otherObject.tag	 == "Elevator")
		{
			gameObject.transform.parent = null;
			elevhit = 0;
			//transform.position = new Vector3(transform.position.x, transform.position.y, 0);
			//transform.localScale= new Vector3(50, 25, 8);
		}
		
		if (otherObject.tag	== "Zombie" && state == State.Playing)
		{
			state = State.Death;
			S_Player.playerlives -= 1;
			S_Player.playerscore -= 300;
			StartCoroutine(DestroyPlayer());
			
			if (S_Player.playerlives	== -1f)
			{
				//load the lost game screen
				Application.LoadLevel("SubmitScreen");
			}
		}
		
		if(otherObject.tag == "Door")
		{
			if(S_Player.currentlevel == 4)
			{
				Debug.Log("Left");
				Application.LoadLevel("Win Screen");
			}
			doorhit = 0;
		}
		
		}
	IEnumerator ShootShotgun()
	{
		Vector3 pos = new Vector3(transform.position.x, transform.position.y + .2f, 0);
		Instantiate(P_Bullet, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.05f);
		Instantiate(P_Bullet, pos, Quaternion.identity);
		pos = new Vector3(pos.x, transform.position.y - .2f, pos.z);
		yield return new WaitForSeconds(0.05f);
		Instantiate(P_Bullet, pos, Quaternion.identity);
	}
	
	IEnumerator DestroyPlayer()
	{
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.enabled = false;
		yield return new WaitForSeconds(1.5f);
		state = State.Invincible;
		transform.position = new Vector3(-5f, -1.5f, 0);
		
		//make the Player's color Flash
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.enabled = true;
		yield return new WaitForSeconds(0.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.yellow;
		yield return new WaitForSeconds(.2f);
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.material.color = Color.blue;
		
		state = State.Playing;
	}
	
}
