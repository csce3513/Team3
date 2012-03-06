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
	
//		public void InitTimealive (float x)
//		{
//			timealive = x;
//		}
//		public static float Gettimealive()
//		{
//			return timealive;
//		}
//		public float GetBulletSpeed()
//		{
//			return bulletspeed;
//		}
//		public Transform Getmytransform()
//		{
//			return mytransform;
//		}
//		public Vector3 GetBulletDir()
//		{
//			return bulletDir;
//		}
//		public Vector3 GetTargetPos()
//		{
//			return targetPos;
//		}
}
