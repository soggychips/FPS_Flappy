using UnityEngine;
using System.Collections;

public class PipeCollider : MonoBehaviour {
	private GameObject bird;


	void Awake(){
		bird = GameObject.FindWithTag ("Player");
		transform.position = bird.transform.position + new Vector3(-5,0,0);
	}

	void Start(){

	}

	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = bird.transform.position + new Vector3(-5,0,0);
	}
}
