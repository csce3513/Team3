using UnityEngine;
using System.Collections;

public class S_Sound_Destroy : MonoBehaviour {
	
	private float timealive;
	
	// Use this for initialization
	void Start () {
		timealive = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timealive += Time.deltaTime;
		
		if (timealive > 1)
			Destroy(gameObject);
	}
}
