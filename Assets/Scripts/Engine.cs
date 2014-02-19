using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {
	public GameObject camera,light,bird,floor,background,pipeCreator;


	//GUI Bool Elements
	bool isNotStarted = true;
	bool playing = false;
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
		/*
		if(Input.GetKeyDown(KeyCode.G)) {
			isNotStarted = !isNotStarted;
			isDead = !isDead;
		}
		if(Input.GetKeyDown(KeyCode.H)) {
			playing = !playing;
		}
		*/
	}

	void OnGUI () {

		if (isNotStarted)
			GUI.Box (new Rect ((Screen.width / 3), (Screen.height / 8), (Screen.width / 3), (Screen.height / 8)), new GUIContent ("Get Ready"));

		if (playing)
			GUI.Box (new Rect (20, 20, 50, 50), new GUIContent ("1337"));		

		if (isDead) {
			//show score screen gui
			GUI.Box (new Rect ((Screen.width / 3), (Screen.height / 8), (Screen.width / 3), (Screen.height / 8)), new GUIContent ("Game Over"));
			GUI.Box (new Rect ((Screen.width / 3), (Screen.height / 8 * 2), (Screen.width / 3), (Screen.height / 8)), new GUIContent ("Score" + "\t\t\t\t\t\t\t\t\t" + "Best" + "\n" + 
			                                                                                                                          "1337" + "\t\t\t\t\t\t\t\t\t\t" + "9001"));
		}
	}
}
