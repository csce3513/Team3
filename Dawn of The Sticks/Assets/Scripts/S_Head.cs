using UnityEngine;
using System.Collections;

public class S_Head : MonoBehaviour {
	
	public GameObject person;
	public Material jt;
	public Material rasta;
	public Material chop;

	// Use this for initialization
	void Start () {
		
		if(HeroSelection.CharacterSelected == 2)
		{ 
				transform.renderer.material = jt;
		}
		else if(HeroSelection.CharacterSelected == 1)
		{
				transform.renderer.material = rasta;	
		}
		else if(HeroSelection.CharacterSelected == 3)
		{
				transform.renderer.material = chop;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (S_Player.alive != "alive")
		{
			transform.renderer.enabled = false;
		}
		else
		{
			transform.renderer.enabled = true;
		}
		if(S_Player.currentlevel == 1)
		{
			transform.position = new Vector3(person.transform.position.x, person.transform.position.y + .5f, -1);
		}
		else
		{
			transform.position = new Vector3(person.transform.position.x, person.transform.position.y + 1f, -1);
		}
	}
}
