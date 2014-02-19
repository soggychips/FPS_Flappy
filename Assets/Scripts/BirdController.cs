using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

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
		rigidbody.useGravity = false;
		waitingForPlayerToStart = true;
	}

	void Update(){
		if(waitingForPlayerToStart){
			if(Input.GetKeyDown(KeyCode.Space)){
				Debug.Log ("Starting Game");
				waitingForPlayerToStart = false;
				rigidbody.useGravity = true;
				rigidbody.AddForce(Vector3.right*boost,ForceMode.Force);
			}
		}else{
			if(Input.GetKeyDown(KeyCode.Space)){
				if(rigidbody.velocity.y<0){
					Debug.Log("Falling, extra boost");
					rigidbody.AddForce(Vector3.up*boost*2.5f,ForceMode.Impulse);
				}else{
					rigidbody.AddForce(Vector3.up*boost,ForceMode.Impulse);
				}
			}
		}
	}

	void FixedUpdate(){
		if(!waitingForPlayerToStart)
			transform.position += Vector3.right*Time.fixedDeltaTime*forwardMovement;

		if(rigidbody.velocity.y<0){ //falling

		}else{

		}
	}

	void OnCollisionEnter(){
		Debug.Log ("Game Over");
		rigidbody.useGravity = false;
		waitingForPlayerToStart = true;
		rigidbody.velocity=Vector3.zero;
		transform.position = startingPosition;
		transform.rotation = startingRotation;
	}


}
