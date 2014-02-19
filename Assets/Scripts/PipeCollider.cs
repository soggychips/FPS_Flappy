using UnityEngine;
using System.Collections;

public class PipeCollider : MonoBehaviour {
	private GameObject bird;

	PipeGenerator pipeG;

	void Awake(){
		bird = GameObject.FindWithTag ("Player");
		transform.position = bird.transform.position + new Vector3(-5,1,0);
	}

	void Start(){
		pipeG = GameObject.FindGameObjectWithTag ("pipecreator").GetComponent<PipeGenerator> ();
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = bird.transform.position + new Vector3(-5,1,0);
	}

	void OnCollisionEnter (Collision coll) {
		//Destroy parent pipe object

		if(coll.gameObject.tag.Equals("pipe"))
			pipeG.PipeCreator ();

		if(!coll.transform.tag.Equals("floor"))
		   Destroy (coll.transform.parent.gameObject.transform.parent.gameObject);
	}
}
