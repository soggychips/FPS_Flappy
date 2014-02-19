using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {
	public GameObject camera,light,bird,floor,background,pipeCreator;
	// Use this for initialization
	void Start () {
		Instantiate(camera);
		Instantiate(light);
		Instantiate(floor);
		Instantiate(background);
		Instantiate(pipeCreator);
		Instantiate(bird);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
