using UnityEngine;
using System.Collections;

public class S_Bullet : MonoBehaviour {
	
	public float bulletspeed;
	private Transform mytransform;
	public float bulletDir;
	private Vector3 targetPos;
	private float timealive;
	static public float Damage;
	
	// Use this for initialization
	void Start () {
		mytransform = transform;
		timealive = 0;
		Damage = 1;

    	// Determine the direction towards the target
    	bulletDir = S_Player.bulletdirection;
	}
	
	// Update is called once per frame
	void Update () {
		
		float amttomove = bulletspeed * Time.deltaTime;
		
		if (bulletDir == 1)
			this.transform.Translate(Vector3.right * (bulletspeed * Time.deltaTime));
		
		else if (bulletDir == 2)
			this.transform.Translate(Vector3.right * (-bulletspeed * Time.deltaTime));
		
		timealive += Time.deltaTime;
		
		if(timealive > 1f)
			Destroy(gameObject);
		
		if (mytransform.position.x > 20f || mytransform.position.x < -20f)
			Destroy(this.gameObject);
		
	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		if(otherObject.tag == "Zombie")
		{
				Destroy(otherObject.gameObject);
				S_Player.zombieskilled ++;
				S_Player.playerscore += 100;
			
			if (S_Player.currentlevel == 1)
				S_Player.cash += 10;
			else if (S_Player.currentlevel == 2)
				S_Player.cash += 20;
			
			Destroy(this.gameObject);

		}
	}
	
	void OnDisable()
	{
		this.rigidbody.velocity = Vector3.zero;

    	this.transform.position = Vector3.zero;

    	this.transform.rotation = Quaternion.identity;
	}
}
