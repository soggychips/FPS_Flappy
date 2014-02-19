using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {
	public GameObject pipeCollider;
	public float boost = 20f;
	public float forwardMovement = 2f;

	public Vector3 startingPosition = Vector3.up*5.0f;
	[Range (-90,90)] public int zRotation;
	public Quaternion startingRotation;
	private bool waitingForPlayerToStart;

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
		if(waitingForPlayerToStart){
			if(Input.GetKeyDown(KeyCode.Space)){
				Debug.Log ("Starting Game");
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
			}
		}
	}

	void FixedUpdate(){
		if(!waitingForPlayerToStart){
			transform.position += Vector3.right*Time.fixedDeltaTime*forwardMovement;

			if(rigidbody.velocity.y<0){ //falling
				//Debug.Log ("z rotation = " + transform.rotation.z);
				/*if(transform.rotation.z > -80){
					transform.RotateAround(transform.position,Vector3.forward,-1);
				}*/
			}else{
				//if(transform.rotation.eulerAngles.z < 80){
				//	transform.RotateAround(transform.position,Vector3.forward,+1);
				//}
			}
		}
	}

	void OnCollisionEnter(){
			Debug.Log ("Game Over");
			rigidbody.useGravity = false;
			waitingForPlayerToStart = true;
			rigidbody.velocity = Vector3.zero;
			transform.position = startingPosition;
			rigidbody.rotation = startingRotation;
			rigidbody.freezeRotation = true;
			Debug.Log ("current rotation = " + transform.rotation);
	}

	void OnTriggerEnter(Collider scorebox){
		Debug.Log ("Score Increased");
		Destroy (scorebox.gameObject);
	}




}
