using UnityEngine;
using System.Collections;

public class S_PlayerZombieCollision : MonoBehaviour {
	
	public enum State
	{
		Death,
		Playing
	}
	
	static public State state;
	
	// Use this for initialization
	void Start () {
	
		state = State.Playing;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator DestroyPlayer()
	{
		GameObject.FindGameObjectWithTag("PlayerRender").renderer.enabled = false;
		if (S_Player.climbdirection	== 1)
						{
							GameObject.FindGameObjectWithTag("Player").transform.Rotate(0,90f,0);
							S_Player.climbdirection =0;
						}
						else if(S_Player.climbdirection == 2)
						{
							GameObject.FindGameObjectWithTag("Player").transform.Rotate(0,-90,0);
							S_Player.climbdirection = 0;
						}
		GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-5f, -2.5f, 0);
		yield return new WaitForSeconds(1.5f);
		state = State.Playing;
		gameObject.renderer.enabled = true;
	}
	
	void OnTriggerEnter(Collider otherObject)
	{
		if(otherObject.tag == "Zombie" && state == State.Playing)
		{
			state = State.Death;
			S_Player.playerlives -= 1;
			StartCoroutine(DestroyPlayer());
			
			if (S_Player.playerlives	== -1f)
			{
				//load the lost game screen
				Application.LoadLevel("SubmitScreen");
			}
		}
	}
}
