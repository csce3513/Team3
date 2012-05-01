using UnityEngine;
using System.Collections;

public class ChangeTextColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
