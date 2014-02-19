using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {
	public GameObject camera,light,bird,floor,background,pipeCreator;
	bool isNotStarted = true;
	bool isDead = false;
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
	
		//guitesting stuff
		if(Input.GetKeyDown(KeyCode.G)) {
			isNotStarted = !isNotStarted;
			isDead = !isDead;
		}
	}

	void OnGUI () {
		if (isNotStarted) {
			//make gui box for the tap to move and other pre-start items	
			GUI.Box (new Rect ((Screen.width / 3), (Screen.height / 3), (Screen.width / 3), (Screen.height / 3)), new GUIContent ("Press Space to Jump"));
		} else if (isDead) {
			//show score screen gui
			GUI.Box (new Rect ((Screen.width / 3), (Screen.height / 3), (Screen.width / 3), (Screen.height / 3)), new GUIContent ("Score: "));
		}
	}
}
