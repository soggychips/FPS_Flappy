using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {
	public GameObject pipeCollider;
	public float boost = 20f;
	public float forwardMovement = 2f;

	public Vector3 startingPosition = Vector3.up*5.0f;
	[Range (-90,90)] public int zRotation;
	public Quaternion startingRotation;
	private bool waitingForPlayerToStart, scoreboard;
	private Engine engine;
	private int fallCount=0;
	private float rotationAmount;
	
	void Awake(){
		engine = GameObject.Find ("GameObjectSpawner").GetComponent<Engine>();
	}

	// Use this for initialization
	void Start () {
		transform.position = startingPosition;
		startingRotation = transform.rotation;
		Debug.Log ("starting rotation = "+startingRotation);
		rigidbody.useGravity = false;
		waitingForPlayerToStart = true;
		Instantiate(pipeCollider);
	}

	void Update(){
		if(scoreboard){
			if(Input.GetKeyDown(KeyCode.Space)){
				engine.Reset();
				BirdReset();
				scoreboard = false;
			}
		}else if(waitingForPlayerToStart){
			if(Input.GetKeyDown(KeyCode.Space)){
				Debug.Log ("Starting Game");
				engine.StartGame();
				waitingForPlayerToStart = false;
				rigidbody.freezeRotation = false;
				rigidbody.useGravity = true;
				rigidbody.AddForce(Vector3.right*boost,ForceMode.Force);
			}
		}else{
			if(Input.GetKeyDown(KeyCode.Space)){
				if(rigidbody.velocity.y<0){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x,0,0);
				}
				rigidbody.AddForce(Vector3.up*boost,ForceMode.Impulse);
				if(transform.rotation.eulerAngles.z<45){
					rotationAmount = 45 - transform.rotation.eulerAngles.z;
					transform.RotateAround(transform.position,Vector3.forward,rotationAmount *.5f);
				}
				else if(transform.rotation.eulerAngles.z>180){
					rotationAmount = 360 - (transform.rotation.eulerAngles.z - 45);
					transform.RotateAround(transform.position,Vector3.forward,rotationAmount *.5f);
				}
				
				
				fallCount = 0;
			}
		}
	}

	void FixedUpdate(){
		if(!waitingForPlayerToStart){
			transform.position += Vector3.right*Time.fixedDeltaTime*forwardMovement;
			
			if(rigidbody.velocity.y<0){ //falling
				if(transform.rotation.eulerAngles.z > 280 || transform.rotation.eulerAngles.z<180 ){
					if(fallCount<10){
						Debug.Log ("small fall");
						transform.RotateAround(transform.position,Vector3.forward,-.5f);
					}else{
						//drop rotation until it's facing is almost down (-80 degrees?)
						Debug.Log ("larger fall");
						transform.RotateAround(transform.position,Vector3.forward,-2);
					}
				}
				fallCount++;
			}else{
				//increase rotation on Z until bird is facing in proper up direction
				if(transform.rotation.eulerAngles.z<45 ){
					transform.RotateAround(transform.position,Vector3.forward,2);
				}
			}
		}
	}

	void OnCollisionEnter(){
		Debug.Log ("Game Over");
		rigidbody.useGravity = false;
		waitingForPlayerToStart = true;
		rigidbody.velocity=Vector3.zero;
		rigidbody.freezeRotation = true;
		Debug.Log ("current rotation = "+transform.rotation);
		engine.Die();
		scoreboard = true;
		
	}

	void BirdReset(){
		rigidbody.velocity=Vector3.zero;
		transform.position = startingPosition;
		rigidbody.rotation = startingRotation;
		rigidbody.freezeRotation = true;
	}

	void OnTriggerEnter(Collider scorebox){
		Debug.Log ("Score Increased");
		Destroy (scorebox.gameObject);
	}




}
