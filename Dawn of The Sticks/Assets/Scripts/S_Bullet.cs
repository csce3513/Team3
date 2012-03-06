using UnityEngine;
using System.Collections;

public class S_Bullet : MonoBehaviour {
	
	public float bulletspeed;
	private Transform mytransform;
	private Vector3 bulletDir;
	private Vector3 targetPos;
	private float timealive;
	
	// Use this for initialization
	void Start () {
		mytransform = transform;
		timealive = 0;
		
		// Find the position of the mouse
    	targetPos = Input.mousePosition;
		
		print(targetPos);

    	// Determine the direction towards the target
    	bulletDir = targetPos - transform.position;
		bulletDir.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		float amttomove = bulletspeed * Time.deltaTime;
		/*Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
		
		if (S_Player.bulletdirection == 2)
			amttomove = -amttomove;*/
		
		/*
		mytransform.Translate(0, 0, amttomove);
		mytransform.position = new Vector3(mytransform.position.x,mytransform.position.y,0);
		*/
		if (S_Player.bulletdirection == 1)
			this.transform.Translate(Vector3.right * (bulletspeed * Time.deltaTime));
		
		else if (S_Player.bulletdirection == 2)
			this.transform.Translate(Vector3.right * (-bulletspeed * Time.deltaTime));
		
		timealive += Time.deltaTime;
		
		if(timealive > .5f)
			Destroy(gameObject);
		
		if (mytransform.position.x > 6.20f || mytransform.position.x < -6.20f)
			Destroy(this.gameObject);
		
	}
	
	void OnDisable()
	{
		this.rigidbody.velocity = Vector3.zero;

    	this.transform.position = Vector3.zero;

    	this.transform.rotation = Quaternion.identity;
	}
}
